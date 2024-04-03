namespace Comandante.Persistance.Models.PromotionModelsEf;

public partial class PromotionExecutionEf
{
    public int Id { get; set; }

    public int PromotionId { get; set; }

    public int SalesChannelId { get; set; }

    public string ShopCode { get; set; } = null!;

    public DateTime BeginDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime BeginTime { get; set; }

    public DateTime EndTime { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsDeleted { get; set; }

    public int? LastUserId { get; set; }

    public bool DwMonday { get; set; }

    public bool DwTuesday { get; set; }

    public bool DwWednesday { get; set; }

    public bool DwThursday { get; set; }

    public bool DwFriday { get; set; }

    public bool DwSaturday { get; set; }

    public bool DwSunday { get; set; }

    public virtual PromotionEf Promotion { get; set; } = null!;
}
