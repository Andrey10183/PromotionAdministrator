using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;

namespace Comandante.App.Components.UiComponents.PasswordInput;

public class BasePasswordMudText : MudTextField<string>
{
    readonly string _passwordVisible = Icons.Material.Filled.Visibility;
    readonly string _passwordInvisible = Icons.Material.Filled.VisibilityOff;

    private bool _isPasswordShow;
    protected override void OnInitialized()
    {
        Adornment = Adornment.End;
        InputType = InputType.Password;
        AdornmentIcon = _passwordInvisible;
        OnAdornmentClick = EventCallback.Factory.Create<MouseEventArgs>(this, VisibilitySwitch);
    }

    private void VisibilitySwitch(MouseEventArgs args)
    {
        if (_isPasswordShow)
        {
            _isPasswordShow = false;
            AdornmentIcon = _passwordInvisible;
            InputType = InputType.Password;
        }
        else
        {
            _isPasswordShow = true;
            AdornmentIcon = _passwordVisible;
            InputType = InputType.Text;
        }
    }
}
