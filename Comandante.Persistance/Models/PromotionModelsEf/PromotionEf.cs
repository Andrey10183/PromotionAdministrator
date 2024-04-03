using Comandante.App;

namespace Comandante.Persistance.Models.PromotionModelsEf;

public partial class PromotionEf
{
    public int PromotionId { get; set; }

    public string? SortType { get; set; }

    public int? Priority { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public byte? IsLinked { get; set; }

    public string? PromotionGroup { get; set; }

    public byte? IsRepeated { get; set; }

    public string? RemindTypeId { get; set; }

    public byte? IsOnCash { get; set; }

    public string? OrderNumber { get; set; }

    public int? NextPromotion { get; set; }

    public byte? IsTest { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsDeleted { get; set; }

    public int? LastUserId { get; set; }

    public string? TrCode { get; set; }

    public string? SpeCode { get; set; }

    public byte? SeparateBySeller { get; set; }

    public int PaymentCompatibility{ get; set; }

    public virtual ICollection<PromotionCalendar> PromotionCalendars { get; set; } = new List<PromotionCalendar>();

    public virtual ICollection<PromotionExecutionEf> PromotionExecutions { get; set; } = new List<PromotionExecutionEf>();
}
