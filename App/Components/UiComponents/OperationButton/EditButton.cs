using MudBlazor;

namespace Comandante.App.Components.UiComponents.OperationButton
{
    public class EditButton : MudIcon
    {
        protected override void OnInitialized()
        {
            Icon = Icons.Material.Filled.EditNote;
            Color = Color.Info;
            Size = Size.Large;
        }
    }
}
