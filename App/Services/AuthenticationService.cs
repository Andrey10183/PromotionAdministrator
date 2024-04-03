using System.Security.Claims;
using Comandante.Domain.Entities;

namespace Comandante.App.Services;

public class AuthenticationService
{
    public event Action<ClaimsPrincipal>? UserChanged;
    private ClaimsPrincipal? _currentUser;
    private readonly ILogger<AuthenticationService> _logger;

    public AuthenticationService(ILogger<AuthenticationService> logger)
    {
        _logger = logger;
    }

    public ClaimsPrincipal GetCurrentUser()
    {
        return _currentUser ??= new ClaimsPrincipal();
    }

    public void SetCurrentUser(ClaimsPrincipal user)
    {
        _currentUser = user;

        if (UserChanged is not null)
        {
            UserChanged(_currentUser);
        }
    }

    public void LogIn(User user)
    {
        _logger.LogInformation("User {@User} logged in.", user.FullName);
        var identity = CreateIdentity(user);

        SetCurrentUser(identity);
    }

    public void LogOut()
    {
        var currentUser = GetCurrentUser();
        _logger.LogInformation("User {@User} logged out.", currentUser?.Identity?.Name);

        _currentUser = new ClaimsPrincipal();
        SetCurrentUser(_currentUser);
    }

    private ClaimsPrincipal CreateIdentity(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.Email, user.Email)
        };

        if (user.Image is not null)
        {
            claims.Add(new Claim("Image", user.Image));
        }

        if (user.Roles.Any())
        {
            foreach (var role in user.Roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role.Name));
            }
        }
            
        var identity = new ClaimsIdentity(claims, "Custom Authentication");
        var principal = new ClaimsPrincipal(identity);

        return principal;
    }
}
