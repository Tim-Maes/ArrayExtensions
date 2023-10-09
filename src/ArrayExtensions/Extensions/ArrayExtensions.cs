namespace ArrayExtensions;

public static class ArrayExtensions
{
    /// <summary>
    /// Appends a single item at the end of an array.
    /// </summary>
    /// <typeparam name="T">The type of the elements contained in the array.</typeparam>
    /// <param name="arr">The array to append to.</param>
    /// <param name="item">The item to append.</param>
    /// <returns>A new array.</returns>
    public static T[] Add<T>(this T[] arr, T item) => arr.Concat(new[] { item }).ToArray();

    /// <summary>
    /// Checks if all items in the array are equal.
    /// </summary>
    /// <typeparam name="T">The type of the elements contained in the array.</typeparam>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if all items are equal, otherwise false.</returns>
    public static bool AllEqual<T>(this T[] arr) => arr.Distinct().Count() == 1;

    /// <summary>
    /// Checks if there is a null value present in the array.
    /// </summary>
    /// <typeparam name="T">The type of elements contained in the array</typeparam>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static bool AnyNull<T>(this T[] arr) where T : class => arr.Any(item => item == null);

    /// <summary>
    /// Appends multiple items at the end of an array.
    /// </summary>
    public static T[] AddRange<T>(this T[] arr, params T[] items) => arr.Concat(items).ToArray();

    /// <summary>
    /// Removes an item at a specified index.
    /// </summary>
    public static T[] RemoveAt<T>(this T[] arr, int index)
    {
        if (index < 0 || index >= arr.Length) throw new IndexOutOfRangeException();
        return arr.Where((_, i) => i != index).ToArray();
    }

    /// <summary>
    /// Inserts an item at a specified index.
    /// </summary>
    public static T[] InsertAt<T>(this T[] arr, int index, T item)
    {
        if (index < 0 || index > arr.Length) throw new IndexOutOfRangeException();
        return arr.Take(index).Concat(new[] { item }).Concat(arr.Skip(index)).ToArray();
    }

    /// <summary>
    /// Shuffles the array elements randomly.
    /// </summary>
    public static T[] Shuffle<T>(this T[] arr)
    {
        var rng = new Random();
        return arr.OrderBy(_ => rng.Next()).ToArray();
    }

    /// <summary>
    /// Checks if the array is empty.
    /// </summary>
    public static bool IsEmpty<T>(this T[] arr) => arr.Length == 0;

    /// <summary>
    /// Checks if the array is null or empty.
    /// </summary>
    public static bool IsNullOrEmpty<T>(this T[] arr) => arr == null || arr.Length == 0;

    /// <summary>
    /// Gets the element at the given index if it exists, otherwise return a default value.
    /// </summary>
    public static T SafeGet<T>(this T[] arr, int index, T defaultValue = default)
    {
        return (index >= 0 && index < arr.Length) ? arr[index] : defaultValue;
    }

    /// <summary>
    /// Finds all indices of items that match a given predicate.
    /// </summary>
    public static int[] FindIndices<T>(this T[] arr, Predicate<T> match)
        => arr.Select((item, index) => match(item) ? index : -1)
                  .Where(index => index != -1)
                  .ToArray();

    /// <summary>
    /// Executes an action for each element in the array.
    /// </summary>
    public static void ForEach<T>(this T[] arr, Action<T> action)
    {
        foreach (var item in arr)
        {
            action(item);
        }
    }

    /// <summary>
    /// Breaks the array into smaller arrays (chunks) of a specified size.
    /// </summary>
    public static T[][] Chunk<T>(this T[] arr, int chunkSize)
        => arr.Select((s, i) => new { Value = s, Index = i })
                  .GroupBy(x => x.Index / chunkSize)
                  .Select(grp => grp.Select(x => x.Value).ToArray())
                  .ToArray();

    /// <summary>
    /// Returns a new array that is a deep copy of the source array.
    /// Note: T must implement ICloneable.
    /// </summary>
    public static T[] DeepCopy<T>(this T[] arr) where T : ICloneable
        => arr.Select(item => (T)item.Clone()).ToArray();

    /// <summary>
    /// Resizes the array to the given size, maintaining the existing elements.
    /// </summary>
    public static T[] Resize<T>(this T[] arr, int newSize)
    {
        T[] newArr = new T[newSize];
        Array.Copy(arr, newArr, Math.Min(arr.Length, newSize));
        return newArr;
    }

    /// <summary>
    /// Returns all elements in the array except for the first one.
    /// </summary>
    public static T[] Tail<T>(this T[] arr)
        => arr.Skip(1).ToArray();

    /// <summary>
    /// Returns the first element in the array.
    /// </summary>
    public static T Head<T>(this T[] arr)
        => arr.FirstOrDefault();

    /// <summary>
    /// Returns the last N elements from the array.
    /// </summary>
    public static T[] LastN<T>(this T[] arr, int n)
        => arr.Skip(Math.Max(0, arr.Length - n)).ToArray();

    /// <summary>
    /// Returns the first N elements from the array.
    /// </summary>
    public static T[] FirstN<T>(this T[] arr, int n)
        => arr.Take(n).ToArray();

    /// <summary>
    /// Replaces all instances of a particular item with another item in the array.
    /// </summary>
    public static T[] ReplaceAll<T>(this T[] arr, T oldValue, T newValue)
        => arr.Select(item => EqualityComparer<T>.Default.Equals(item, oldValue) ? newValue : item).ToArray();

    /// <summary>
    /// Safely sets the value at the specified index. Resizes the array if index is out of range.
    /// </summary>
    public static T[] SafeSet<T>(this T[] arr, int index, T value)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");

        if (index >= arr.Length)
            arr = arr.Resize(index + 1);
        
        arr[index] = value;
        return arr;
    }

    /// <summary>
    /// Returns the maximum element in the array based on a selector.
    /// </summary>
    public static T MaxBy<T, TKey>(this T[] arr, Func<T, TKey> selector) where TKey : IComparable<TKey>
        => arr.OrderByDescending(selector).FirstOrDefault();

    /// <summary>
    /// Returns the minimum element in the array based on a selector.
    /// </summary>
    public static T MinBy<T, TKey>(this T[] arr, Func<T, TKey> selector) where TKey : IComparable<TKey>
        => arr.OrderBy(selector).FirstOrDefault();

    /// <summary>
    /// Returns distinct elements from the array based on a selector.
    /// </summary>
    public static T[] DistinctBy<T, TKey>(this T[] arr, Func<T, TKey> selector)
        => arr.GroupBy(selector).Select(grp => grp.First()).ToArray();

    /// <summary>
    /// Rotates the array N positions to the left.
    /// </summary>
    public static T[] RotateLeft<T>(this T[] arr, int positions)
    {
        if (arr.Length == 0) return arr;

        positions = positions % arr.Length;

        return arr.Skip(positions).Concat(arr.Take(positions)).ToArray();
    }

    /// <summary>
    /// Rotates the array N positions to the right.
    /// </summary>
    public static T[] RotateRight<T>(this T[] arr, int positions)
    {
        if (arr.Length == 0) return arr;
        positions = positions % arr.Length;
        return arr.Skip(arr.Length - positions).Concat(arr.Take(arr.Length - positions)).ToArray();
    }

    /// <summary>
    /// Flattens a multi-dimensional array or an array of arrays into a single array.
    /// </summary>
    public static T[] Flatten<T>(this T[][] arr)
        => arr.SelectMany(innerArray => innerArray).ToArray();

    /// <summary>
    /// Counts occurrences of a particular item in the array.
    /// </summary>
    /// <typeparam name="T">The type of elements contained in the array.</typeparam>
    /// <param name="arr">The array to search in.</param>
    /// <param name="item">The item to count.</param>
    /// <returns>The number of occurrences of the item in the array.</returns>
    public static int CountOf<T>(this T[] arr, T item) where T : IEquatable<T>
        =>  arr.Count(x => x.Equals(item));

    /// <summary>
    /// Returns distinct values from the array.
    /// </summary>
    /// <typeparam name="T">The type of elements contained in the array.</typeparam>
    /// <param name="arr">The array to process.</param>
    /// <returns>An array of distinct elements.</returns>
    public static T[] DistinctValues<T>(this T[] arr)
    => arr.Distinct().ToArray();

    /// <summary>
    /// Finds the most common element in the array.
    /// </summary>
    /// <typeparam name="T">The type of elements contained in the array.</typeparam>
    /// <param name="arr">The array to search in.</param>
    /// <returns>The most common element in the array. If multiple items share the highest count, the first one encountered is returned.</returns>
    public static T MostCommon<T>(this T[] arr) where T : IEquatable<T>
        => arr.GroupBy(x => x)
                  .OrderByDescending(group => group.Count())
                  .First().Key;

    /// <summary>
    /// Returns a portion of the array, similar to substring for strings.
    /// </summary>
    /// <typeparam name="T">The type of elements contained in the array.</typeparam>
    /// <param name="arr">The array to slice.</param>
    /// <param name="start">The zero-based starting position.</param>
    /// <param name="end">The zero-based ending position (exclusive). If not specified, will slice until the end of the array.</param>
    /// <returns>A portion of the array.</returns>
    public static T[] Slice<T>(this T[] arr, int start, int? end = null)
    {
        if (start < 0 || start >= arr.Length) throw new ArgumentOutOfRangeException(nameof(start));
        if (end.HasValue && end.Value <= start) throw new ArgumentException("End must be greater than start.");
        if (end.HasValue && end.Value > arr.Length) throw new ArgumentOutOfRangeException(nameof(end));

        int length = (end ?? arr.Length) - start;
        return arr.Skip(start).Take(length).ToArray();
    }
}
