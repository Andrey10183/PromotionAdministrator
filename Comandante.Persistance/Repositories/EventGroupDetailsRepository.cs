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

public class EventGroupDetailsRepository : IEventGroupDetailsRepository
{
    private readonly IDbContextFactory<PromotionContext> _dbWriteContextFactory;
    private readonly IDbContextFactory<PromotionContext> _dbReadContextFactory;

    public EventGroupDetailsRepository(
        IPromotionContextFactorySelector contextFactorySelector)
    {
        _dbWriteContextFactory = contextFactorySelector.GetFactory(false);
        _dbReadContextFactory = contextFactorySelector.GetFactory(true);
    }

    public async Task<List<EventGroupDetail>> GetById(
        string promoConditionId,
        CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var eventGroupDetailsEf = await context.EventGroupDetails
            .AsNoTracking()
            .Where(x => x.EventGroupId == promoConditionId)
            .ToListAsync(token);

        var promotionGroupDetails = eventGroupDetailsEf?.Adapt<List<EventGroupDetail>>();

        return promotionGroupDetails ?? new();
    }

    public async Task<Result> Create(EventGroupDetail eventGroupDetail, CancellationToken token)
    {
        eventGroupDetail.CreateDateTime = DateTime.Now;

        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        var eventGroupDetailsEf = eventGroupDetail.Adapt<EventGroupDetailEf>();
        eventGroupDetailsEf.CreateDateTime = DateTime.Now;

        context.EventGroupDetails.Add(eventGroupDetailsEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries == 1 ?
            Result.Success() : 
            EventGroupDetailsErrors.DatabaseError;
    }

    public async Task<Result> Update(EventGroupDetail eventGroupDetail, CancellationToken token)
    {
        eventGroupDetail.ChangeDateTime = DateTime.Now;

        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        var updatedEntity = await context.EventGroupDetails
            .FirstOrDefaultAsync(x => x.Id == eventGroupDetail.Id, token);

        if (updatedEntity == null)
        {
            return EventGroupDetailsErrors.IdNotExists;
        }

        var eventGroupDetailsEf = eventGroupDetail.Adapt<EventGroupDetailEf>();
        context.Entry(updatedEntity).CurrentValues.SetValues(eventGroupDetailsEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries == 1 ?
            Result.Success() :
            EventGroupDetailsErrors.DatabaseError;
    }

    public async Task<Result> Delete(int id, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);
        
        var entityToDelete = await context.EventGroupDetails
            .FirstOrDefaultAsync(x => x.Id == id, token);

        if (entityToDelete == null)
        {
            return EventGroupDetailsErrors.IdNotExists;
        }

        context.EventGroupDetails.Remove(entityToDelete);
        
        var affectedEntries = await context.SaveChangesAsync(token);

        return affectedEntries == 1 ? 
            Result.Success() : 
            EventGroupDetailsErrors.DatabaseError;
    }
}
