using MudBlazor;

namespace Comandante.App.Helper;

public static class DialogOptionsFactory
{
    public static DialogOptions Create(MaxWidth maxWidth) =>
        new()
        {
            CloseOnEscapeKey = false,
            DisableBackdropClick = true,
            CloseButton = false,
            FullWidth = true,
            MaxWidth = maxWidth,
            ClassBackground = "my-custom-class"
        };
}
