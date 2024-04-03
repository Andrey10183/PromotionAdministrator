namespace Comandante.Persistance.Models.PromotionModelsEf;

public partial class EventGroupDetailEf
{
    public int Id { get; set; }

    public string EventGroupId { get; set; } = null!;

    public string CatalogTypeId { get; set; } = null!;

    public string CatalogParamTypeId { get; set; } = null!;

    public string? Value { get; set; }

    public int? Priority { get; set; }

    public string? FilterTypeId { get; set; }

    public string? Description { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public byte? IsActive { get; set; }

    public byte? IsDeleted { get; set; }

    public int? LastUserId { get; set; }
}
