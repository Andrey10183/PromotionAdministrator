namespace Comandante.Persistance.Models.PromotionModelsEf;

public partial class EventGroupEf
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsDeleted { get; set; }

    public int? LastUserId { get; set; }
}
