using System.Security.AccessControl;

namespace Comandante.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string IIN { get; set; }
    public string FullName { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Image { get; set; }
    public List<Role> Roles { get; set; }
}
