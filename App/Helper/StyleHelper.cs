using MudBlazor;

namespace Comandante.App.Helper;

public static class StyleHelper
{
    public static string GetSelectedRowStyle(bool selected) =>
        selected? 
            $"background:{Colors.Grey.Lighten2};" :
            "background-color:white;";

    //$"background:{Colors.Gray.Lighten2};"

    //@"background: rgb(237,255,253);
    //    background: 
    //        linear-gradient(
    //            180deg, 
    //            rgba(237,255,253,1) 0%, 
    //            rgba(61,0,145,0.47111344537815125) 100%);";
}
