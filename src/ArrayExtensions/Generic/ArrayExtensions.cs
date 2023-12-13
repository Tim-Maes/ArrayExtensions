namespace ArrayExtensions;

public static class ArrayExtensions
{
    /// <summary>
    /// Removes all null items from the array.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array. Must be a class.</typeparam>
    /// <param name="arr">The array from which to remove nulls.</param>
    /// <returns>An array without null values.</returns>
    public static T[] RemoveNulls<T>(this T[] arr) where T : class
     => arr.Where(item => item is not null).ToArray();

    /// <summary>
    /// Appends a single item at the end of an array.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    /// <param name="arr">The array to which the item will be added.</param>
    /// <param name="item">The item to add.</param>
    /// <returns>An array with the item appended.</returns>
    public static T[] Add<T>(this T[] arr, T item)
        => arr.Concat(new[] { item }).ToArray();

    /// <summary>
    /// Checks if all elements in the array are identical.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if all elements are equal, otherwise false.</returns>
    public static bool AllEqual<T>(this T[] arr)
        => arr.Distinct().Count() == 1;

    /// <summary>
    /// Checks for the presence of null values in the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array, must be a reference type.</typeparam>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if any element is null, otherwise false.</returns>
    public static bool AnyNull<T>(this T[] arr) where T : class
        => arr.Any(item => item is null);

    /// <summary>
    /// Appends one or more elements to the end of the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <param name="items">The items to append.</param>
    /// <returns>A new array with the items appended.</returns>
    public static T[] AddRange<T>(this T[] arr, params T[] items)
        => arr.Concat(items).ToArray();

    /// <summary>
    /// Removes the element at the specified index from the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <param name="index">The index of the element to remove.</param>
    /// <returns>A new array with the element removed.</returns>
    public static T[] RemoveAt<T>(this T[] arr, int index)
    {
        if (index < 0 || index >= arr.Length) throw new IndexOutOfRangeException();
        return arr.Where((_, i) => i != index).ToArray();
    }

    /// <summary>
    /// Inserts an element at the specified index in the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <param name="index">The index at which to insert the element.</param>
    /// <param name="item">The item to insert.</param>
    /// <returns>A new array with the item inserted.</returns>
    public static T[] InsertAt<T>(this T[] arr, int index, T item)
    {
        if (index < 0 || index > arr.Length) throw new IndexOutOfRangeException();
        return arr.Take(index).Concat(new[] { item }).Concat(arr.Skip(index)).ToArray();
    }

    /// <summary>
    /// Randomly shuffles the elements of the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to shuffle.</param>
    /// <returns>A new array with the elements shuffled.</returns>
    public static T[] Shuffle<T>(this T[] arr)
    {
        var rng = new Random();
        return arr.OrderBy(_ => rng.Next()).ToArray();
    }

    /// <summary>
    /// Checks if the array has zero elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if the array is empty, otherwise false.</returns>
    public static bool IsEmpty<T>(this T[] arr)
        => arr.Length == 0;

    /// <summary>
    /// Checks if the array is either null or contains zero elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if the array is null or empty, otherwise false.</returns>
    public static bool IsNullOrEmpty<T>(this T[] arr)
        => arr is null || arr.Length == 0;

    /// <summary>
    /// Retrieves the element at the specified index if it exists, otherwise returns a default value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array from which to retrieve the element.</param>
    /// <param name="index">The index of the element to retrieve.</param>
    /// <param name="defaultValue">The value to return if the index is out of range.</param>
    /// <returns>The element at the given index or the default value.</returns>
    public static T SafeGet<T>(this T[] arr, int index, T defaultValue = default)
        => index >= 0 && index < arr.Length ? arr[index] : defaultValue;

    /// <summary>
    /// Finds the indices of all elements that match a given predicate.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to search.</param>
    /// <param name="match">The predicate function to match elements.</param>
    /// <returns>An array of indices where elements match the given predicate.</returns>
    public static int[] FindIndices<T>(this T[] arr, Predicate<T> match)
        => arr.Select((item, index) => match(item) ? index : -1)
                  .Where(index => index != -1)
                  .ToArray();

    /// <summary>
    /// Iterates over each element in the array and executes the provided action on each element.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <param name="action">The action to be executed on each element.</param>
    public static void ForEach<T>(this T[] arr, Action<T> action)
    {
        foreach (var item in arr)
        {
            action(item);
        }
    }

    /// <summary>
    /// Divides the original array into smaller arrays (chunks) each containing up to 'chunkSize' elements.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <param name="chunkSize">The maximum size for each chunk.</param>
    /// <returns>An array of smaller arrays (chunks).</returns>
    public static T[][] Chunk<T>(this T[] arr, int chunkSize)
        => arr.Select((s, i) => new { Value = s, Index = i })
                  .GroupBy(x => x.Index / chunkSize)
                  .Select(grp => grp.Select(x => x.Value).ToArray())
                  .ToArray();

    /// <summary>
    /// Creates a new array that is a deep copy of the original array.
    /// Note: Elements in the array must implement the ICloneable interface.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array, must implement ICloneable.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <returns>A new array that is a deep copy of the original array.</returns>
    public static T[] DeepCopy<T>(this T[] arr) where T : ICloneable
        => arr.Select(item => (T)item.Clone()).ToArray();

    /// <summary>
    /// Resizes the array to the given size, maintaining the existing elements.
    /// Any excess elements are truncated, and additional space is filled with default values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <param name="newSize">The new size for the array.</param>
    /// <returns>A new array resized to the given size.</returns>
    public static T[] Resize<T>(this T[] arr, int newSize)
    {
        T[] newArr = new T[newSize];
        Array.Copy(arr, newArr, Math.Min(arr.Length, newSize));
        return newArr;
    }

    /// <summary>
    /// Returns a new array containing all elements of the original array except the first one.
    /// If the array is empty or contains a single element, an empty array is returned.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <returns>A new array without the first element of the original array.</returns>
    public static T[] Tail<T>(this T[] arr)
        => arr.Skip(1).ToArray();

    /// <summary>
    /// Returns the first element of the array.
    /// If the array is empty, returns the default value for the type.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <returns>The first element of the array, or the default value for the type if the array is empty.</returns>
    public static T Head<T>(this T[] arr)
        => arr.FirstOrDefault();

    /// <summary>
    /// Returns a new array containing the last N elements of the original array.
    /// If N is greater than the length of the array, the entire array is returned.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <param name="n">The number of elements to take from the end of the array.</param>
    /// <returns>A new array containing the last N elements of the original array.</returns>
    public static T[] LastN<T>(this T[] arr, int n)
        => arr.Skip(Math.Max(0, arr.Length - n)).ToArray();

    /// <summary>
    /// Returns a new array containing the first N elements of the original array.
    /// If N is greater than the length of the array, the entire array is returned.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The original array.</param>
    /// <param name="n">The number of elements to take from the beginning of the array.</param>
    /// <returns>A new array containing the first N elements of the original array.</returns>
    public static T[] FirstN<T>(this T[] arr, int n)
        => arr.Take(n).ToArray();

    /// <summary>
    /// Replaces all occurrences of a specific value with another value in the array.
    /// Uses the default equality comparer for the type to determine whether two items are equal.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to be modified.</param>
    /// <param name="oldValue">The value to be replaced.</param>
    /// <param name="newValue">The value to replace the old value with.</param>
    /// <returns>A new array with all instances of the old value replaced by the new value.</returns>
    public static T[] ReplaceAll<T>(this T[] arr, T oldValue, T newValue)
        => arr.Select(item => EqualityComparer<T>.Default.Equals(item, oldValue) ? newValue : item).ToArray();

    /// <summary>
    /// Sets the value at a specified index in the array. If the index is out of range, 
    /// the array is resized to accommodate the new element at the specified index.
    /// Negative indices will result in an exception.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    /// <param name="arr">The array to be modified.</param>
    /// <param name="index">The index at which to set the value.</param>
    /// <param name="value">The value to set at the specified index.</param>
    /// <returns>A new array or resized array with the value set at the specified index.</returns>
    public static T[] SafeSet<T>(this T[] arr, int index, T value)
    {
        if (index < 0) throw new ArgumentOutOfRangeException(nameof(index), "Index cannot be negative.");

        if (index >= arr.Length)
            arr = arr.Resize(index + 1);

        arr[index] = value;
        return arr;
    }

    /// <summary>
    /// Finds and returns the maximum element in the array according to a specified selector function.
    /// Returns the default value for the type if the array is empty.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    /// <typeparam name="TKey">Type of the key to be compared.</typeparam>
    /// <param name="arr">The array to be processed.</param>
    /// <param name="selector">A function that transforms each element into a key to compare.</param>
    /// <returns>The maximum element in the array based on the key generated by the selector function.</returns>
    public static T MaxBy<T, TKey>(this T[] arr, Func<T, TKey> selector) where TKey : IComparable<TKey>
        => arr.OrderByDescending(selector).FirstOrDefault();

    /// <summary>
    /// Finds and returns the minimum element in the array according to a specified selector function.
    /// Returns the default value for the type if the array is empty.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    /// <typeparam name="TKey">Type of the key to be compared.</typeparam>
    /// <param name="arr">The array to be processed.</param>
    /// <param name="selector">A function that transforms each element into a key to compare.</param>
    /// <returns>The minimum element in the array based on the key generated by the selector function.</returns>
    public static T MinBy<T, TKey>(this T[] arr, Func<T, TKey> selector) where TKey : IComparable<TKey>
        => arr.OrderBy(selector).FirstOrDefault();

    /// <summary>
    /// Returns an array that contains only distinct elements according to a specified selector function.
    /// The returned elements are chosen from the first occurrence of each distinct element in the original array.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    /// <typeparam name="TKey">Type of the key to distinguish elements.</typeparam>
    /// <param name="arr">The array to process.</param>
    /// <param name="selector">A function that transforms each element into a key to compare.</param>
    /// <returns>A new array containing the distinct elements based on the key generated by the selector function.</returns>
    public static T[] DistinctBy<T, TKey>(this T[] arr, Func<T, TKey> selector)
        => arr.GroupBy(selector).Select(grp => grp.First()).ToArray();

    /// <summary>
    /// Rotates the array N positions to the left. Elements that are shifted off the beginning of the array are 
    /// wrapped around to the end. If the array is empty, it returns the empty array.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    /// <param name="arr">The array to be rotated.</param>
    /// <param name="positions">The number of positions to rotate to the left.</param>
    /// <returns>A new array that has been rotated N positions to the left.</returns>
    public static T[] RotateLeft<T>(this T[] arr, int positions)
    {
        if (arr.Length == 0) return arr;

        positions = positions % arr.Length;

        return arr.Skip(positions).Concat(arr.Take(positions)).ToArray();
    }

    /// <summary>
    /// Rotates the array N positions to the right. Elements that are shifted off the end of the array are 
    /// wrapped around to the beginning. If the array is empty, it returns the empty array.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    /// <param name="arr">The array to be rotated.</param>
    /// <param name="positions">The number of positions to rotate to the right.</param>
    /// <returns>A new array that has been rotated N positions to the right.</returns>
    public static T[] RotateRight<T>(this T[] arr, int positions)
    {
        if (arr.Length == 0) return arr;
        positions = positions % arr.Length;
        return arr.Skip(arr.Length - positions).Concat(arr.Take(arr.Length - positions)).ToArray();
    }

    /// <summary>
    /// Flattens a multi-dimensional array or an array of arrays into a single one-dimensional array. 
    /// The resulting array will have all the elements of the inner arrays concatenated in the order 
    /// they are found.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the array.</typeparam>
    /// <param name="arr">The array to be flattened.</param>
    /// <returns>A new one-dimensional array containing all the elements of the original array of arrays.</returns>
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
        => arr.Count(x => x.Equals(item));

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

    /// <summary>
    /// Interleaves elements of two arrays into a single array. Elements from the two arrays alternate in the resulting array.
    /// If one array is longer, the remaining elements are appended at the end.
    /// </summary>
    /// <typeparam name="T">The type of elements in the arrays.</typeparam>
    /// <param name="arr1">The first array to interleave.</param>
    /// <param name="arr2">The second array to interleave.</param>
    /// <returns>A new array containing elements from both input arrays, interleaved.</returns>
    public static T[] Interleave<T>(this T[] arr1, T[] arr2)
    {
        T[] result = new T[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;

        while (i < arr1.Length && j < arr2.Length)
        {
            result[k++] = arr1[i++];
            result[k++] = arr2[j++];
        }

        while (i < arr1.Length)
        {
            result[k++] = arr1[i++];
        }

        while (j < arr2.Length)
        {
            result[k++] = arr2[j++];
        }

        return result;
    }

    /// <summary>
    /// Splits an array into segments based on a specified predicate. Each time the predicate is true,
    /// a new segment starts.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to segment.</param>
    /// <param name="predicate">The predicate function to determine the start of a new segment.</param>
    /// <returns>A list of arrays, where each array is a segment of the original array.</returns>
    public static List<T[]> Segment<T>(this T[] arr, Predicate<T> predicate)
    {
        var result = new List<T[]>();
        var segment = new List<T>();

        foreach (var item in arr)
        {
            if (predicate(item))
            {
                if (segment.Any())
                {
                    result.Add(segment.ToArray());
                    segment.Clear();
                }
            }
            segment.Add(item);
        }

        if (segment.Any()) result.Add(segment.ToArray());

        return result;
    }

    /// <summary>
    /// Performs a binary search on a sorted array for a specific item, using a specified comparer.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The sorted array to search.</param>
    /// <param name="item">The item to search for.</param>
    /// <param name="comparer">The comparer to use for comparing elements.</param>
    /// <returns>The index of the item in the array if found; otherwise, -1.</returns>
    public static int BinarySearch<T>(this T[] arr, T item, IComparer<T> comparer)
    {
        int low = 0, high = arr.Length - 1;

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int comparison = comparer.Compare(arr[mid], item);

            if (comparison == 0) return mid;

            if (comparison < 0) low = mid + 1;
            else high = mid - 1;
        }

        return -1; // Item not found
    }

    /// <summary>
    /// Selects a random sample of elements from the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to sample from.</param>
    /// <param name="sampleSize">The number of elements to include in the sample.</param>
    /// <returns>An array containing a random sample of elements from the original array.</returns>
    public static T[] RandomSample<T>(this T[] arr, int sampleSize)
    {
        var random = new Random();
        return arr.OrderBy(x => random.Next()).Take(sampleSize).ToArray();
    }

    /// <summary>
    /// Generates a sequence of tuples from sequential pairs of elements in the array.
    /// </summary>
    /// <typeparam name="T">The type of elements in the array.</typeparam>
    /// <param name="arr">The array to generate pairs from.</param>
    /// <returns>An enumerable sequence of tuples, where each tuple contains a pair of sequential elements from the array.</returns>
    public static IEnumerable<Tuple<T, T>> SequentialPairs<T>(this T[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            yield return Tuple.Create(arr[i], arr[i + 1]);
        }
    }
}
