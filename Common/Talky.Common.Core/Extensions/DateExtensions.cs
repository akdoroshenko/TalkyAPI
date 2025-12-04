using System.Globalization;

namespace Talky.Common.Core.Extensions;

public static class DateExtensions
{
    private const string DateFormat = "dd.MM.yyyy";
    private const string TimeFormat = "HH:mm";
    private const string TimeFormatWithTimeOfDay = "hh:mm tt";  // American style
    private const string DateTimeFormat = $"{DateFormat} {TimeFormat}";
    
    public static string FormatDate(this DateTimeOffset date) =>
        date.ToString(DateFormat, CultureInfo.InvariantCulture);

    public static string FormatTime(this DateTimeOffset date) =>
        date.ToString(TimeFormat, CultureInfo.InvariantCulture);
    
    public static string FormatDateAndTime(this DateTimeOffset date) =>
        date.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
    
    public static string FormatDate(this DateTime date) =>
        date.ToString(DateFormat, CultureInfo.InvariantCulture);

    public static string FormatTime(this DateTime date) =>
        date.ToString(TimeFormat, CultureInfo.InvariantCulture);
    
    public static string FormatDateAndTime(this DateTime date) =>
        date.ToString(DateTimeFormat, CultureInfo.InvariantCulture);
    
    public static DateTime? ToDateTime(this string? dateTime)
    {
        if (string.IsNullOrEmpty(dateTime))
        {
            return null;
        }

        return DateTime.TryParse(dateTime, out var result)
            ? result
            : null;
    }
}