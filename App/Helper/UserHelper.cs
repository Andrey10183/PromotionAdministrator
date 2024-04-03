namespace Comandante.App.Helper;

public static class UserHelper
{
    public static string GetInitialsFromUserName(string? name)
    {
        if (string.IsNullOrWhiteSpace(name)) return "??";
        
        var lines = name.Split(' ');

        if (lines.Length < 2 || 
            string.IsNullOrEmpty(lines[0]) || 
            string.IsNullOrEmpty(lines[1])) return "??";

        var initialFirs = lines[0][0].ToString();
        var initialSecond = lines[1][0].ToString();;
        
        return initialFirs + initialSecond;
    }
}
