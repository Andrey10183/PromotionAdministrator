using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Comandante.App.Components.UiComponents.LoadingButton;

public class LoadingButtonBase<TComponent> : MudButton
    where TComponent : ComponentBase
{
    protected override void OnParametersSet()
    {
        Disabled = Processing || Disabled2;

        if (Processing)
        {
            ChildContent = builder =>
            {
                builder.OpenComponent<TComponent>(sequence: 1);
                builder.CloseComponent();
            };
        }
        base.OnParametersSet();
    }

    [Parameter]
    public bool Processing { get; set; }

    [Parameter]
    public bool Disabled2 { get; set; }
}