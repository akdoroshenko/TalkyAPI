using System.Text.Json;

namespace Talky.Common.Core.Extensions;

public static class ObjectExtensions
{
    public static T? As<T>(this object obj)
        where T : class => obj as T;

    public static string SerializeToJson(this object obj) => JsonSerializer.Serialize(obj);

    public static void ToConsole(this object? obj, string? varName = null) => 
        Console.WriteLine(
            (!string.IsNullOrEmpty(varName) ? varName + " : " : "") + 
            (obj?.SerializeToJson() ?? "null"));
}