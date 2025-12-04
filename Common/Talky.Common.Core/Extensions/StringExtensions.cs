namespace Talky.Common.Core.Extensions;

public static class StringExtensions
{
    public static string? NullIfEmpty(this string? str) => string.IsNullOrEmpty(str) ? null : str;
    
    public static string[]? SplitTrim(this string? str, string separator) => str.NullIfEmpty()?
        .Split(separator, StringSplitOptions.RemoveEmptyEntries)
        .Select(s => s.Trim())
        .ToArray();
    
    public static bool EqualsInvariantIgnoreCase(this string? str, string other) =>
        str != null && str.Equals(other, StringComparison.InvariantCultureIgnoreCase);
    
    public static string? CapitalizeFirstLetter(this string? text) => text?.Trim() switch
    {
        var s when string.IsNullOrEmpty(s) => s,
        var s when s!.Length == 1 => s.ToUpper(),
        _ => char.ToUpper(text![0]) + text[1..]
    };

    public static string? CapitalizeEveryFirstLetter(this string? text) => !string.IsNullOrEmpty(text?.Trim())
        ? string.Join(" ", text.Split(" ").Select(s => s.CapitalizeFirstLetter()))
        : text;
    
    public static string Join(this IEnumerable<string> parts, string separator)
        => string.Join(separator, parts);
}