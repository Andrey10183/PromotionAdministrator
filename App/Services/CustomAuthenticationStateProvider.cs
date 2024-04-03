using Microsoft.AspNetCore.Components.Authorization;

namespace Comandante.App.Services;

public class CustomAuthenticationStateProvider: AuthenticationStateProvider
{
    private AuthenticationState _authenticationState;

    public CustomAuthenticationStateProvider(AuthenticationService service)
    {
        _authenticationState = new AuthenticationState(service.GetCurrentUser());

        service.UserChanged += (newUser) =>
        {
            _authenticationState = new AuthenticationState(newUser);

            NotifyAuthenticationStateChanged(
                Task.FromResult(new AuthenticationState(newUser)));
        };
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        return Task.FromResult(this._authenticationState);
    }
}
