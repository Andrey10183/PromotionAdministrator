namespace Comandante.App.Services;

public static class AppVersion
{
    public static Version? Version { get; set; }

    public static string? Environment { get; set; } = string.Empty;

    public static string VersionEx => $"{Version}.{GetEnvironment()}";

    private static string GetEnvironment()
    {
        if (string.IsNullOrEmpty(Environment) || Environment.Length <= 0)
            return "?";

        return Environment[0].ToString();
    }
}
