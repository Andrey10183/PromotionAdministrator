using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Comandante.App.Components.UiComponents.OperationButton;

public class AddButton : MudIcon
{
    protected override void OnInitialized()
    {
        Icon = Icons.Material.Filled.Add;
        //Color = Color.Success;
        Size = Size.Large;
    }
}
