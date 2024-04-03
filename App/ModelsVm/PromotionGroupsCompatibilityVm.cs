namespace Comandante.App.ModelsVm;

public class PromotionGroupsCompatibilityVm
{
    public int Id { get; set; }

    public string PromotionGroupX { get; set; } = null!;

    public string PromotionGroupY { get; set; } = null!;

    public int CompatibilityType { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? LastUserId { get; set; }
}
