namespace Comandante.Persistance.Models.PromotionModelsEf;

public partial class PromotionGroupEf
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Priority { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsDeleted { get; set; }

    public int? LastUserId { get; set; }
}
