namespace Comandante.Domain.Entities;

public class PromotionGroupsCompatibility
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

    public static PromotionGroupsCompatibility Create()
    {
        return new PromotionGroupsCompatibility()
        {
            UniqueKey = Guid.NewGuid(),
            IsActive = true,
        };
    }
}
