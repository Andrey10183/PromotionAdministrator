namespace Comandante.Persistance.Models.PromotionModelsEf;

public partial class PromotionConditionEf
{
    public int Id { get; set; }

    public int PromotionId { get; set; }

    public string EventGroupId { get; set; } = null!;

    public int ConditionLineNumber { get; set; }

    public int Priority { get; set; }

    public string TypeChargeId { get; set; } = null!;

    public decimal ChargeParam { get; set; }

    public byte IsAccumulation { get; set; }

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

    public byte? IsActive { get; set; }

    public byte? IsDeleted { get; set; }

    public int? LastUserId { get; set; }
}
