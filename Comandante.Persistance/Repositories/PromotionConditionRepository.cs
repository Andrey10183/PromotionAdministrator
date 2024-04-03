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

public class PromotionConditionRepository : IPromotionConditionRepository
{
    private readonly IDbContextFactory<PromotionContext> _dbWriteContextFactory;
    private readonly IDbContextFactory<PromotionContext> _dbReadContextFactory;

    public PromotionConditionRepository(
        IPromotionContextFactorySelector contextFactorySelector)
    {
        _dbWriteContextFactory = contextFactorySelector.GetFactory(false);
        _dbReadContextFactory = contextFactorySelector.GetFactory(true);
    }

    public async Task<List<PromotionCondition>> GetById(
        int promotionId, 
        CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var promoConditionEf = await context.PromotionConditions
            .AsNoTracking()
            .Where(x => promotionId == x.PromotionId)
            .ToListAsync(token);

        var promoCondition = promoConditionEf.Adapt<List<PromotionCondition>>();

        return promoCondition ?? new();
    }

    public async Task<Result<PromotionCondition>> Create(PromotionCondition promotionCondition,
        CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        promotionCondition.CreateDateTime = DateTime.Now;

        var promoConditionEf = promotionCondition.Adapt<PromotionConditionEf>();

        context.PromotionConditions.Add(promoConditionEf);
        
        var affectedEntries = await context.SaveChangesAsync(token);
        
        var group = $"_cevents_{promoConditionEf.Id}";
        promoConditionEf.EventGroupId = group;

        await context.SaveChangesAsync(token);

        var result = promoConditionEf?.Adapt<PromotionCondition>();
        
        return affectedEntries == 1 ? 
            result : 
            PromotionConditionsErrors.DatabaseError;
    }

    public async Task<Result<PromotionCondition>> Update(PromotionCondition promotionCondition,
        CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        promotionCondition.ChangeDateTime = DateTime.Now;

        var updatedEntity = await context.PromotionConditions
            .FirstOrDefaultAsync(x => x.Id == promotionCondition.Id, token);

        if (updatedEntity is null)
        {
            return PromotionConditionsErrors.IdNotExists;
        }

        var promotionConditionsEf = promotionCondition.Adapt<PromotionConditionEf>();

        context.Entry(updatedEntity).CurrentValues.SetValues(promotionConditionsEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        var result = updatedEntity?.Adapt<PromotionCondition>();

        return affectedEntries == 1 ?
            result :
            PromotionConditionsErrors.DatabaseError;
    }

    public async Task<Result<int>> Delete(int id, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        var entityToDelete = await context.PromotionConditions
            .FirstOrDefaultAsync(x => x.Id == id, token);

        if (entityToDelete is null)
        {
            return PromotionConditionsErrors.IdNotExists;
        }

        var promoId = entityToDelete.PromotionId;

        //Ищем все привязанные события
        var eventGroupDetailsToDelete = await context.EventGroupDetails
            .Where(x => x.EventGroupId == entityToDelete.EventGroupId)
            .ToListAsync(token);

        //бежим по всем привязанным событиям
        foreach (var grDetail in eventGroupDetailsToDelete)
        {
            //Получаем все привязанные к событию акции
            var connectedPromotions = await RepositoryHelper
                .GetAllPromotionsIdsByEventGroupDetail(context, grDetail.EventGroupId);

            var connectedConditions = await RepositoryHelper.
                GetAllConditionsIdsByEventGroupDetail(context, grDetail.EventGroupId);

            //Если хотя бы одно событие имеет привязку к другой акции помимо удаляемой  
            //Или в пределах данной акции есть условие использующее ту же группу событий не удаляем
            if (connectedPromotions.Any(x => x != promoId) || 
                connectedConditions.Count > 1) continue;

            //В противном случае удаляем
            context.EventGroupDetails.Remove(grDetail);
        }

        //Удаляем главную сущность
        context.PromotionConditions.Remove(entityToDelete);

        var totalAffectedEntries = await context.SaveChangesAsync(token);
        
        return totalAffectedEntries > 0 ? 
            totalAffectedEntries : 
            EventGroupErrors.DatabaseError;
    }
}
