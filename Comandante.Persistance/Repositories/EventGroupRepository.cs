using Comandante.App;
using Comandante.Domain.Entities;
using Comandante.Domain.Errors;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using Comandante.Persistance.Helper;
using Comandante.Persistance.Models.PromotionModelsEf;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Comandante.Persistance.Repositories;

public class EventGroupRepository : IEventGroupRepository
{
    private readonly IDbContextFactory<PromotionContext> _dbWriteContextFactory;
    private readonly IDbContextFactory<PromotionContext> _dbReadContextFactory;

    public EventGroupRepository(
        IPromotionContextFactorySelector contextFactorySelector)
    {
        _dbWriteContextFactory = contextFactorySelector.GetFactory(false);
        _dbReadContextFactory = contextFactorySelector.GetFactory(true);
    }

    public async Task<EventGroup?> GetById(string id, CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var itemEf = await context.EventGroups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, token);

        var item = itemEf?.Adapt<EventGroup>();

        return item;
    }

    public async Task<List<EventGroup>> GetAll(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var itemsEf = await context.EventGroups
            .AsNoTracking()
            .ToListAsync(token);

        var items = itemsEf?.Adapt<List<EventGroup>>();

        return items ?? new();
    }

    public async Task<Result<EventGroup>> Create(EventGroup eventGroup, CancellationToken token = default)
    {
        eventGroup.CreateDateTime = DateTime.Now;

        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        var isExist = await context.EventGroups
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == eventGroup.Id, token);

        if (isExist != null)
        {
            return EventGroupErrors.IdAlreadyExist;
        }

        var itemEf = eventGroup.Adapt<EventGroupEf>();

        context.EventGroups.Add(itemEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        var result = itemEf?.Adapt<EventGroup>();

        return affectedEntries == 1 ? 
            result : 
            EventGroupErrors.DatabaseError;
    }

    public async Task<Result<EventGroup>> Update(EventGroup eventGroup, CancellationToken token = default)
    {
        eventGroup.ChangeDateTime = DateTime.Now;

        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);
        
        var updatedEntity = await context.EventGroups
            .FirstOrDefaultAsync(x => x.Id == eventGroup.Id, token);

        if (updatedEntity == null)
        {
            return EventGroupErrors.IdNotExists;
        }

        var itemEf = eventGroup.Adapt<EventGroupEf>();

        context.Entry(updatedEntity).CurrentValues.SetValues(itemEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        var result = updatedEntity?.Adapt<EventGroup>();

        return affectedEntries == 1 ?
            result :
            EventGroupErrors.DatabaseError;
    }

    public async Task<Result<int>> Delete(string id, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);
        
        var entityToDelete = await context.EventGroups
            .FirstOrDefaultAsync(x => x.Id == id, token);

        if (entityToDelete == null)
        {
            return PromotionGroupsCompatibilitiesErrors.IdNotExists;
        }

        context.EventGroups.Remove(entityToDelete);

        
        //Ищем все привязанные события
        var eventGroupDetailsToDelete = await context.EventGroupDetails
            .Where(x => x.EventGroupId == entityToDelete.Id)
            .ToListAsync(token);

        //бежим по всем привязанным событиям
        foreach (var grDetail in eventGroupDetailsToDelete)
        {
            //Получаем все привязанные к событию акции
            var connectedPromotions = await RepositoryHelper
                .GetAllPromotionsIdsByEventGroupDetail(context, grDetail.EventGroupId);

            //Получаем все привязанные к событию условия
            var connectedConditions = await RepositoryHelper.
                GetAllConditionsIdsByEventGroupDetail(context, grDetail.EventGroupId);
            
            //Если событие имеет привязку к другой акции или условию не удаляем
            if (connectedPromotions.Any() || 
                connectedConditions.Any()) continue;

            //В противном случае удаляем
            context.EventGroupDetails.Remove(grDetail);
        }
        
        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries > 0 ? 
            affectedEntries : 
            EventGroupErrors.DatabaseError;
    }
}
