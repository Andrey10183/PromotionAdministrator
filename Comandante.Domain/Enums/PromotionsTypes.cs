
namespace Comandante.Domain.Enums;


public enum PromotionsTypes
{
    PastPromotions,
    WorkingPromotions,
    WorkingNowPromotions,
    FuturePromotions,
    TestPromotions,
    NotActivePromotions,
    WorkingPromotionConditions,
    WorkingPromotionExecutions,
    WorkingEventGroups,
    WorkingEventGroupDetails
};

public static class PromotionTypeExtensions
{
    public static List<PromotionsTypes> GetValues(this PromotionsTypes promotionTypes)
    {
        return Enum
            .GetValues(typeof(PromotionsTypes))
            .Cast<PromotionsTypes>()
            .Where(x => 
                x != PromotionsTypes.WorkingEventGroups &&
                x != PromotionsTypes.WorkingEventGroupDetails &&
                x != PromotionsTypes.WorkingPromotionConditions &&
                x != PromotionsTypes.WorkingPromotionExecutions &&
                x != PromotionsTypes.WorkingPromotions)
            .ToList();
    }

    public static string GetUiName(this PromotionsTypes promotionTypes)
    {
        return promotionTypes switch
        {
            PromotionsTypes.WorkingNowPromotions => "Действующие акции",
            PromotionsTypes.FuturePromotions => "Будущие акции",
            PromotionsTypes.PastPromotions => "Прошедшие акции",
            PromotionsTypes.TestPromotions => "Тестовые акции",
            PromotionsTypes.NotActivePromotions => "Отключенные акции",
            _ => "Не определено"
        };
    }
}
