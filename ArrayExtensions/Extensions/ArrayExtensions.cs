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
}
