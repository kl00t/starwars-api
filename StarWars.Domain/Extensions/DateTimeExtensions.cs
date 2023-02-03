using System.Globalization;

namespace StarWars.Domain.Extensions;

public static class DateTimeExtensions
{
    public static DateTime ToDateTime(this string date)
    {
        return DateTime.ParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture);
    }
}