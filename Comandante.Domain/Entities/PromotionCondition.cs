namespace Comandante.Domain.Entities;

public class PromotionCondition
{
    public int Id { get; set; }

    public int PromotionId { get; set; }

    public string EventGroupId { get; set; } = null!;

    public int ConditionLineNumber { get; set; }

    public int Priority { get; set; }

    public string TypeChargeId { get; set; } = null!;

    public decimal ChargeParam { get; set; }

    public bool IsAccumulation { get; set; }

    public int CascadeNumber { get; set; }

    public string TypeCheckId { get; set; } = null!;

    public decimal ChargeCparam { get; set; }

    public string TypeChargeOffId { get; set; } = null!;

    public decimal ParamChargeOff { get; set; }

    public string TypeTchargeId { get; set; } = null!;

    public decimal ChargeRparam { get; set; }

    public int ActionId { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? LastUserId { get; set; }

    public static PromotionCondition Create(int promotionId)
    {
        return new PromotionCondition()
        {
            PromotionId = promotionId,
            ActionId = 0,
            IsActive = true,
            IsDeleted = false,
            ConditionLineNumber = 1,
            Priority = 0,
            UniqueKey = Guid.NewGuid(),
            TypeChargeId = "N",
            TypeCheckId = "N",
            TypeChargeOffId = "N",
            TypeTchargeId = "N",
            EventGroupId = "Авто генерация",
            ChargeParam = 0.00m,
            ChargeCparam = 0.00m,
            ChargeRparam = 0.00m,
            ParamChargeOff = 0.00m,
        };
    }
}
