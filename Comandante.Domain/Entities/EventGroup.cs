namespace Comandante.Domain.Entities;

public class EventGroup
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? LastUserId { get; set; }

    public static EventGroup Create()
    {
        return new()
        {
            UniqueKey = Guid.NewGuid(),
            IsActive = true,
            //Name = string.Empty,
            Id = string.Empty
        };
    }
}
