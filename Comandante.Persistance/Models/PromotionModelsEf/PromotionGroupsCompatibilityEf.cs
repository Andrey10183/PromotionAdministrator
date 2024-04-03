namespace Comandante.Persistance.Models.PromotionModelsEf;

public partial class PromotionGroupsCompatibilityEf
{
    public int Id { get; set; }

    public string PromotionGroupX { get; set; } = null!;

    public string PromotionGroupY { get; set; } = null!;

    public int CompatibilityType { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsDeleted { get; set; }

    public int? LastUserId { get; set; }
}
