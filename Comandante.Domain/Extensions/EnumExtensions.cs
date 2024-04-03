namespace Comandante.Domain.Extensions;

public static class EnumExtensions
{
    public static List<T> GetEnumValues<T>(this T enumType) where T : Enum
    {
        return Enum.GetValues(enumType.GetType()).Cast<T>().ToList();
    }
}
