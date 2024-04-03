namespace Comandante.Domain.Extensions;

public static class DateTimeExtension
{
    public static DateTime GetMinDateValue(this DateTime? dateTime)
    {
        return new DateTime(1753, 01, 01);
    }
}