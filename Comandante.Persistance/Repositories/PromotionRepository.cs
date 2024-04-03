using System.Security.Cryptography.X509Certificates;
using Comandante.App;
using Comandante.Domain.Entities;
using Comandante.Domain.Enums;
using Comandante.Domain.Errors;
using Comandante.Domain.RepositoryInterfaces;
using Comandante.Domain.Shared;
using Comandante.Persistance.Helper;
using Comandante.Persistance.Models.PromotionModelsEf;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Comandante.Persistance.Repositories;

public class PromotionRepository : IPromotionRepository
{
    private readonly IDbContextFactory<PromotionContext> _dbWriteContextFactory;
    private readonly IDbContextFactory<PromotionContext> _dbReadContextFactory;

    public PromotionRepository(
        IPromotionContextFactorySelector contextFactorySelector)
    {
        _dbWriteContextFactory = contextFactorySelector.GetFactory(false);
        _dbReadContextFactory = contextFactorySelector.GetFactory(true);
    }

    public async Task<Promotion?> GetById(int id, CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var promotionEf = await context.Promotions
            .AsNoTracking()
            .FirstOrDefaultAsync(
                x => x.PromotionId == id, 
                cancellationToken: token);

        var promotion = promotionEf?.Adapt<Promotion>();

        return promotion;
    }

    public async Task<List<Promotion>> GetPastPromotions(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var now = DateTime.Now;

        var promotionExecutionIds = await context.PromotionExecutions
            .AsNoTracking()
            .Where(x => 
                x.EndDate <= now &&
                x.IsActive != null &&
                x.IsActive != 0)
            .Select(x => x.PromotionId)
            .ToListAsync(token);

        if (promotionExecutionIds?.Any() == false)
        {
            return new();
        }

        var promotionsEf = await context.Promotions
            .AsNoTracking()
            .Where(x=> 
                promotionExecutionIds.Contains(x.PromotionId) &&
                x.IsActive != null &&
                x.IsActive != 0)
            .ToListAsync(token);

        var promotions = promotionsEf?.Adapt<List<Promotion>>();

        return promotions ?? new();
    }

    public async Task<List<Promotion>> GetCurrentPromotions(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var now = DateTime.Now;

        var promotionExecutionIds = await context.PromotionExecutions
            .AsNoTracking()
            .Where(x => 
                x.BeginDate <= now && 
                x.EndDate >= now &&
                x.IsActive != null &&
                x.IsActive != 0)
            .Select(x => x.PromotionId)
            .ToListAsync(token);

        if (promotionExecutionIds?.Any() == false)
        {
            return new();
        }

        var promotionsEf = await context.Promotions
            .AsNoTracking()
            .Where(x=> 
                promotionExecutionIds != null &&
                promotionExecutionIds.Contains(x.PromotionId) &&
                x.IsActive != null &&
                x.IsActive != 0)
            .ToListAsync(token);

        var promotions = promotionsEf?.Adapt<List<Promotion>>();

        return promotions ?? new();
    }

    public async Task<List<Promotion>> GetFuturePromotions(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var now = DateTime.Now;

        var promotionExecutionIds = await context.PromotionExecutions
            .AsNoTracking()
            .Where(x => x.BeginDate >= now)
            .Select(x => x.PromotionId)
            .ToListAsync(token);

        if (promotionExecutionIds?.Any() == false)
        {
            return new();
        }

        var promotionsEf = await context.Promotions
            .AsNoTracking()
            .Where(x=> 
                promotionExecutionIds.Contains(x.PromotionId) && 
                x.IsActive != null && 
                x.IsActive != 0)
            .ToListAsync(token);

        var promotions = promotionsEf?.Adapt<List<Promotion>>();

        return promotions ?? new();
    }

    public async Task<List<Promotion>> GetTestPromotions(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var promotionsEf = await context.Promotions
            .AsNoTracking()
            .Where(x => 
                x.IsTest != null && 
                x.IsTest != 0 &&
                x.IsActive != null && 
                x.IsActive != 0)
            .ToListAsync(token);

        var promotions = promotionsEf?.Adapt<List<Promotion>>();

        return promotions ?? new();
    }

    public async Task<List<Promotion>> GetDisabledPromotions(CancellationToken token = default)
    {
        await using var context = await _dbReadContextFactory.CreateDbContextAsync(token);

        var promotionsEf = await context.Promotions
            .AsNoTracking()
            .Where(x => 
                x.IsActive == null || 
                x.IsActive == 0)
            .ToListAsync(token);

        var promotions = promotionsEf?.Adapt<List<Promotion>>();

        return promotions ?? new();
    }
    
    public async Task<Result<Promotion>> Create(Promotion promotion, CancellationToken token)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        promotion.CreateDateTime = DateTime.Now;

        var promotionEf = promotion.Adapt<PromotionEf>();
        
        var addedEntity = context.Promotions.Add(promotionEf);
        
        var affectedEntries = await context.SaveChangesAsync(token);
        
        var result = addedEntity.Entity?.Adapt<Promotion>();

        return affectedEntries == 1 && result != null ? 
            result : 
            PromotionErrors.DatabaseError;
    }

    public async Task<Result<Promotion>> Update(Promotion promotion, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        promotion.ChangeDateTime = DateTime.Now;

        var updatedEntity = await context.Promotions
            .Include(x => x.PromotionExecutions)
            .FirstOrDefaultAsync(x => x.PromotionId == promotion.PromotionId, token);

        if (updatedEntity is null)
        {
            return PromotionErrors.IdNotExists;
        }

        var promotionEf = promotion.Adapt<PromotionEf>();
        context.Entry(updatedEntity).CurrentValues.SetValues(promotionEf);

        var affectedEntries = await context.SaveChangesAsync(token);

        var result = updatedEntity?.Adapt<Promotion>();

        return affectedEntries == 1 ? 
            result : 
            PromotionErrors.DatabaseError;
    }

    public async Task<Result<int>> Delete(int id, CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);

        //Ищем акцию
        var entityToDelete = await context.Promotions
            .Include(x => x.PromotionExecutions)
            .FirstOrDefaultAsync(x => x.PromotionId == id, token);

        //Не нашли по Id кидаем ошибку
        if (entityToDelete == null)
        {
            return PromotionErrors.IdNotExists;
        }

        //Ищем привязанные условия
        var promoConditionsToRemove = await context.PromotionConditions
            .Where(x => x.PromotionId == id)
            .ToListAsync(token);

        var promoConditionsToRemoveEventIds = promoConditionsToRemove.Select(x => x.EventGroupId);

        //Ищем все привязанные события
        var eventGroupDetailsToDelete = await context.EventGroupDetails
            .Where(x => promoConditionsToRemoveEventIds.Contains(x.EventGroupId))
            .ToListAsync(token);

        //бежим по всем привязанным событиям
        foreach (var grDetail in eventGroupDetailsToDelete)
        {
            //Получаем все привязанные к событию акции
            var connectedPromotions = await RepositoryHelper
                .GetAllPromotionsIdsByEventGroupDetail(context, grDetail.EventGroupId);

            //Если хотя бы одно событие имеет привязку к другой акции помимо удаляемой не удаляем 
            if (connectedPromotions.Any(x => x != id)) continue;

            //В противном случае удаляем
            context.EventGroupDetails.Remove(grDetail);
        }

        var grDetailsDeleted = await context.SaveChangesAsync(token);

        //Удаляем PromotionConditions
        var promoCondDeleted = await context.PromotionConditions
            .Where(x => x.PromotionId == id)
            .ExecuteDeleteAsync(token);

        //Удаляем саму акцию
        context.Promotions.Remove(entityToDelete);
        
        var promoDeleted = await context.SaveChangesAsync(token);

        var affectedEntries = grDetailsDeleted + promoCondDeleted + promoDeleted;

        return affectedEntries > 0 ? 
            affectedEntries : 
            PromotionErrors.DatabaseError;
    }
    
    public async Task<Result<Promotion>> Duplicate(
        int promotionId, 
        PromotionDuplicateProperty duplicateProperty,
        CancellationToken token = default)
    {
        await using var context = await _dbWriteContextFactory.CreateDbContextAsync(token);


        //Тянем все дерево связей
        var duplicatedPromotion = await context.Promotions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.PromotionId == promotionId, token);

        var duplicatedExecution = await context.PromotionExecutions
            .AsNoTracking()
            .Where(x => x.PromotionId == promotionId)
            .ToListAsync(token);

        if (duplicatedPromotion is null)
            return PromotionErrors.IdNotExists;

        var duplicatedConditions = await context.PromotionConditions
            .AsNoTracking()
            .Where(x => x.PromotionId == promotionId)
            .ToListAsync(token);

        var duplicatedConditionsEvGrIds = duplicatedConditions
            .Select(x => x.EventGroupId)
            .Distinct()
            .ToList();

        var duplicatedGroupDetails = await context.EventGroupDetails
            .AsNoTracking()
            .Where(x => duplicatedConditionsEvGrIds.Contains(x.EventGroupId))
            .ToListAsync();

        //Создаем дубликат акции
        duplicatedPromotion.CreateDateTime = DateTime.UtcNow;
        duplicatedPromotion.ChangeDateTime = null;
        duplicatedPromotion.Name = $"{duplicatedPromotion.Name}. (Дубликат акции {duplicatedPromotion.PromotionId})";
        duplicatedPromotion.PromotionId = 0;

        context.Promotions.Add(duplicatedPromotion);
        var affectedEntries = await context.SaveChangesAsync(token);

        //Создаем расписание акции
        foreach (var execution in duplicatedExecution)
        {
            await RepositoryHelper.CreatePromoExecution(context, execution, duplicatedPromotion.PromotionId);
        }

        foreach (var condition in duplicatedConditions)
        {
            if (duplicateProperty == PromotionDuplicateProperty.DuplicateWithNewDetails ||
                duplicateProperty == PromotionDuplicateProperty.DuplicateWithNoDetails)
            {
                var currentConditionEventGroupId = condition.EventGroupId;
                //Здесь мы получим новый GroupId
                var createdCondition = await RepositoryHelper.CreatePromoCondition(
                    context, 
                    condition, 
                    duplicatedPromotion.PromotionId);

                //В данной ветке нужно сгенерировать новые события - копии оригинальных но с новым Id
                if (duplicateProperty == PromotionDuplicateProperty.DuplicateWithNewDetails)
                {
                    var eventGroupsToCopy = duplicatedGroupDetails.Where(x => x.EventGroupId == currentConditionEventGroupId);

                    foreach (var eventGroupToCopy in eventGroupsToCopy)
                    {
                        eventGroupToCopy.EventGroupId = createdCondition.EventGroupId;
                        await RepositoryHelper.CreateEventGroupDetail(context, eventGroupToCopy);
                    }
                }
            }
            else
            {
                // Тут будут создаватся условия с уже существующей привязкой. Больше ничего делать не нужно.
                await RepositoryHelper.CreatePromoCondition(context, condition, duplicatedPromotion.PromotionId, condition.EventGroupId);
            }
        }

        var returnResult = duplicatedPromotion?.Adapt<Promotion>();

        return returnResult;
    }
}
