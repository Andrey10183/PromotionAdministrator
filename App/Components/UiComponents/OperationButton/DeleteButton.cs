using MudBlazor;

namespace Comandante.App.Components.UiComponents.OperationButton
{
    public class DeleteButton : MudIcon
    {
        protected override void OnInitialized()
        {
            Icon = Icons.Material.Filled.DeleteForever;
            Color = Color.Error;
            Size = Size.Large;
        }
    }
}
