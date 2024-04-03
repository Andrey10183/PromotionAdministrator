using MudBlazor;

namespace Comandante.App.Services;

public class SnackBarService
{
    private readonly ISnackbar _snackBar;

    public SnackBarService(ISnackbar snackBar)
    {
        _snackBar = snackBar;
    }
    public void ShowMessage(Severity severity, string text)
    {
        _snackBar.Configuration.PositionClass = Defaults.Classes.Position.BottomEnd;
        _snackBar.Add(text, severity, config =>
        {
            config.ShowCloseIcon = false;
        });
    }
}
