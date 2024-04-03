namespace Comandante.Domain.Entities;

public class PromotionGroup
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public int Priority { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? LastUserId { get; set; }

    public static PromotionGroup Create()
    {
        return new PromotionGroup()
        {
            UniqueKey = Guid.NewGuid(),
            IsActive = true,
            Code = string.Empty,
            Name = string.Empty,
        };
    }
}
