using System.Diagnostics.CodeAnalysis;

namespace Talky.Common.Core.Extensions;

public static class LinqExtensions
{
    public static bool Empty<T>([NotNullWhen(false)] this IReadOnlyCollection<T>? collection)
    {
        return collection is not { Count: > 0 };
    }
    
    // using: var (with, without) = numbers.Split(x => x > 50);
    // where numbers contains ints from 0 to 100 => with = [51, 52, ..., 100] and without = [0, 1, ..., 49]
    public static (IReadOnlyList<T> With, IReadOnlyList<T> Without) Split<T>(
        this IEnumerable<T> collection,
        Func<T, bool> predicate)
    {
        var with = new List<T>();
        var without = new List<T>();
        foreach (var item in collection)
        {
            if (predicate(item))
            {
                with.Add(item);
                continue;
            }

            without.Add(item);
        }

        return (with, without);
    }

    public static void AddWhen<T>(this ICollection<T> collection, bool condition, T value)
    {
        if (condition)
        {
            collection.Add(value);
        }
    }

    public static void AddWhen<T>(this List<T> list, bool condition, IEnumerable<T> value)
    {
        if (condition)
        {
            list.AddRange(value);
        }
    }
}