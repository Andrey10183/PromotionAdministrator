namespace Comandante.Domain.Entities;

public class EventGroupDetail
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

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? LastUserId { get; set; }

    public static EventGroupDetail Create(string eventGroupId)
    {
        return new EventGroupDetail()
        {
            EventGroupId = eventGroupId,
            CatalogTypeId = "GOODS",
            CatalogParamTypeId = "ARTICLE",
            Value = "0",
            Priority = 0,
            FilterTypeId = "X",
            UniqueKey = Guid.NewGuid(),
            IsActive = true,
            IsDeleted = false,
            LastUserId = 0,
            Description = string.Empty,
        };
    }
}
