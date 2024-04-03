using Comandante.App;
using Comandante.Persistance.Models.PromotionModelsEf;
using Microsoft.EntityFrameworkCore;

namespace Comandante.Persistance.Helper;

public static class RepositoryHelper
{
    public static async Task<List<int>> GetAllPromotionsIdsByEventGroupDetail(
        PromotionContext context, 
        string eventGroupId)
    {
        var promotionsConditions = await context.PromotionConditions
            .Where(x => x.EventGroupId == eventGroupId)
            .ToListAsync();

        var promoIds = promotionsConditions.Select(x => x.PromotionId)
            .Distinct()
            .ToList();

        return promoIds;
    }

    public static async Task<List<int>> GetAllConditionsIdsByEventGroupDetail(
        PromotionContext context, 
        string eventGroupId)
    {
        var promotionsConditions = await context.PromotionConditions
            .Where(x => x.EventGroupId == eventGroupId)
            .ToListAsync();

        var condIds = promotionsConditions.Select(x => x.Id)
            .Distinct()
            .ToList();
        return condIds;
    }

    public static async Task<PromotionConditionEf?> CreatePromoCondition(
        PromotionContext context, 
        PromotionConditionEf promotionCondition,
        int promoId,
        string? eventGroupId = null)
    {
        promotionCondition.Id = 0;
        promotionCondition.CreateDateTime = DateTime.Now;
        promotionCondition.ChangeDateTime = null;
        promotionCondition.PromotionId = promoId;
        
        int affectedEntries;

        if (eventGroupId is null)
        {
            promotionCondition.EventGroupId = string.Empty;
            context.PromotionConditions.Add(promotionCondition);
            affectedEntries = await context.SaveChangesAsync();
            var group = $"_cevents_{promotionCondition.Id}";
            promotionCondition.EventGroupId = group;
            await context.SaveChangesAsync(); 
        }
        else
        {
            promotionCondition.EventGroupId = eventGroupId;
            context.PromotionConditions.Add(promotionCondition);
            affectedEntries = await context.SaveChangesAsync();
        }

        return affectedEntries == 1 ? 
            promotionCondition : 
            null;
    }

    public static async Task<EventGroupDetailEf?> CreateEventGroupDetail(
        PromotionContext context,
        EventGroupDetailEf eventGroupDetail)
    {
        eventGroupDetail.Id = 0;
        eventGroupDetail.CreateDateTime = DateTime.Now;
        eventGroupDetail.ChangeDateTime = null;

        context.EventGroupDetails.Add(eventGroupDetail);

        var affectedEntries = await context.SaveChangesAsync();

        return affectedEntries == 1 ?
            eventGroupDetail : 
            null;
    }

    public static async Task<PromotionExecutionEf?> CreatePromoExecution(
        PromotionContext context, 
        PromotionExecutionEf promotionExecution, 
        int promoId)
    {
        promotionExecution.Id = 0;
        promotionExecution.CreateDateTime = DateTime.Now;
        promotionExecution.ChangeDateTime = null;
        promotionExecution.PromotionId = promoId;

        context.PromotionExecutions.Add(promotionExecution);

        var affectedEntries = await context.SaveChangesAsync();

        return affectedEntries == 1 ? 
            promotionExecution : 
            null;
    }
}
