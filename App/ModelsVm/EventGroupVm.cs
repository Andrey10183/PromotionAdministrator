namespace Comandante.App.ModelsVm;

public class EventGroupVm
{
    public string Id { get; set; } = null!;

    public string? Name { get; set; }

    public DateTime? CreateDateTime { get; set; }

    public DateTime? ChangeDateTime { get; set; }

    public Guid? UniqueKey { get; set; }

    public bool IsActive { get; set; }

    public bool IsDeleted { get; set; }

    public int? LastUserId { get; set; }
}
