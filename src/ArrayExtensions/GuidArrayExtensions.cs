namespace ArrayExtensions;

public static class GuidArrayExtensions
{
    /// <summary>
    /// Removes all empty GUIDs (Guid.Empty) from the array.
    /// </summary>
    /// <param name="arr">The GUID array to process.</param>
    /// <returns>A new array without empty GUIDs.</returns>
    public static Guid[] RemoveEmpty(this Guid[] arr)
        => arr.Where(g => g != Guid.Empty).ToArray();

    /// <summary>
    /// Checks if any GUID in the array is empty.
    /// </summary>
    /// <param name="arr">The GUID array to check.</param>
    /// <returns>True if any GUID is empty, otherwise false.</returns>
    public static bool AnyEmpty(this Guid[] arr)
        => arr.Any(g => g == Guid.Empty);

    /// <summary>
    /// Checks if all GUIDs in the array are empty.
    /// </summary>
    /// <param name="arr">The GUID array to check.</param>
    /// <returns>True if all GUIDs are empty, otherwise false.</returns>
    public static bool AllEmpty(this Guid[] arr)
        => arr.All(g => g == Guid.Empty);

    /// <summary>
    /// Checks if all GUIDs in the array are unique.
    /// </summary>
    /// <param name="arr">The GUID array to check.</param>
    /// <returns>True if all GUIDs are unique, otherwise false.</returns>
    public static bool AllUnique(this Guid[] arr)
        => arr.Distinct().Count() == arr.Length;

    /// <summary>
    /// Finds duplicate GUIDs in the array.
    /// </summary>
    /// <param name="arr">The GUID array to analyze.</param>
    /// <returns>An array of duplicate GUIDs.</returns>
    public static Guid[] FindDuplicates(this Guid[] arr)
        => arr.GroupBy(g => g)
              .Where(group => group.Count() > 1)
              .Select(group => group.Key)
              .ToArray();

    /// <summary>
    /// Converts all GUIDs to their string representation.
    /// </summary>
    /// <param name="arr">The GUID array to convert.</param>
    /// <returns>A string array of GUID representations.</returns>
    public static string[] ToStringArray(this Guid[] arr)
        => arr.Select(g => g.ToString()).ToArray();

    /// <summary>
    /// Converts all GUIDs to their string representation with the specified format.
    /// </summary>
    /// <param name="arr">The GUID array to convert.</param>
    /// <param name="format">The format string (N, D, B, P, or X).</param>
    /// <returns>A string array of formatted GUID representations.</returns>
    public static string[] ToStringArray(this Guid[] arr, string format)
        => arr.Select(g => g.ToString(format)).ToArray();

    /// <summary>
    /// Converts all GUIDs to their byte array representations.
    /// </summary>
    /// <param name="arr">The GUID array to convert.</param>
    /// <returns>An array of byte arrays representing the GUIDs.</returns>
    public static byte[][] ToByteArrays(this Guid[] arr)
        => arr.Select(g => g.ToByteArray()).ToArray();

    /// <summary>
    /// Sorts the GUIDs in ascending order.
    /// </summary>
    /// <param name="arr">The GUID array to sort.</param>
    /// <returns>A new array with sorted GUIDs.</returns>
    public static Guid[] SortAscending(this Guid[] arr)
        => arr.OrderBy(g => g).ToArray();

    /// <summary>
    /// Sorts the GUIDs in descending order.
    /// </summary>
    /// <param name="arr">The GUID array to sort.</param>
    /// <returns>A new array with sorted GUIDs in descending order.</returns>
    public static Guid[] SortDescending(this Guid[] arr)
        => arr.OrderByDescending(g => g).ToArray();

    /// <summary>
    /// Finds the earliest GUID (smallest value) in the array.
    /// </summary>
    /// <param name="arr">The GUID array to analyze.</param>
    /// <returns>The smallest GUID value.</returns>
    public static Guid Min(this Guid[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.Min();
    }

    /// <summary>
    /// Finds the latest GUID (largest value) in the array.
    /// </summary>
    /// <param name="arr">The GUID array to analyze.</param>
    /// <returns>The largest GUID value.</returns>
    public static Guid Max(this Guid[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.Max();
    }

    /// <summary>
    /// Filters GUIDs that match a specific version.
    /// </summary>
    /// <param name="arr">The GUID array to filter.</param>
    /// <param name="version">The GUID version to filter by (1-5).</param>
    /// <returns>A new array containing only GUIDs of the specified version.</returns>
    public static Guid[] FilterByVersion(this Guid[] arr, int version)
    {
        if (version < 1 || version > 5)
            throw new ArgumentOutOfRangeException(nameof(version), "GUID version must be between 1 and 5.");

        return arr.Where(g => GetGuidVersion(g) == version).ToArray();
    }

    /// <summary>
    /// Groups GUIDs by their version.
    /// </summary>
    /// <param name="arr">The GUID array to group.</param>
    /// <returns>A dictionary grouping GUIDs by their version.</returns>
    public static Dictionary<int, Guid[]> GroupByVersion(this Guid[] arr)
        => arr.GroupBy(GetGuidVersion)
              .ToDictionary(g => g.Key, g => g.ToArray());

    /// <summary>
    /// Gets the version of each GUID in the array.
    /// </summary>
    /// <param name="arr">The GUID array to analyze.</param>
    /// <returns>An array of version numbers corresponding to each GUID.</returns>
    public static int[] GetVersions(this Guid[] arr)
        => arr.Select(GetGuidVersion).ToArray();

    /// <summary>
    /// Checks if a GUID is in the array.
    /// </summary>
    /// <param name="arr">The GUID array to search.</param>
    /// <param name="guid">The GUID to find.</param>
    /// <returns>True if the GUID is found, otherwise false.</returns>
    public static bool Contains(this Guid[] arr, Guid guid)
        => arr.Contains(guid);

    /// <summary>
    /// Finds the index of a specific GUID in the array.
    /// </summary>
    /// <param name="arr">The GUID array to search.</param>
    /// <param name="guid">The GUID to find.</param>
    /// <returns>The index of the GUID, or -1 if not found.</returns>
    public static int IndexOf(this Guid[] arr, Guid guid)
        => Array.IndexOf(arr, guid);

    /// <summary>
    /// Creates a hash set from the GUID array for fast lookups.
    /// </summary>
    /// <param name="arr">The GUID array to convert.</param>
    /// <returns>A HashSet containing the GUIDs.</returns>
    public static HashSet<Guid> ToHashSet(this Guid[] arr)
        => new HashSet<Guid>(arr);

    /// <summary>
    /// Generates a new array of random GUIDs with the specified length.
    /// </summary>
    /// <param name="length">The number of GUIDs to generate.</param>
    /// <returns>A new array of random GUIDs.</returns>
    public static Guid[] GenerateRandomGuids(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), "Length cannot be negative.");

        return Enumerable.Range(0, length).Select(_ => Guid.NewGuid()).ToArray();
    }

    /// <summary>
    /// Replaces all empty GUIDs with new random GUIDs.
    /// </summary>
    /// <param name="arr">The GUID array to process.</param>
    /// <returns>A new array with empty GUIDs replaced by random ones.</returns>
    public static Guid[] ReplaceEmptyWithNew(this Guid[] arr)
        => arr.Select(g => g == Guid.Empty ? Guid.NewGuid() : g).ToArray();

    /// <summary>
    /// Validates that all GUIDs in the array are properly formatted.
    /// </summary>
    /// <param name="arr">The GUID array to validate.</param>
    /// <returns>True if all GUIDs are valid, otherwise false.</returns>
    public static bool AllValid(this Guid[] arr)
        => arr.All(g => g != default(Guid) || g == Guid.Empty);

    /// <summary>
    /// Converts the GUID array to a comma-separated string.
    /// </summary>
    /// <param name="arr">The GUID array to convert.</param>
    /// <returns>A comma-separated string of GUIDs.</returns>
    public static string ToCommaSeparatedString(this Guid[] arr)
        => string.Join(",", arr.Select(g => g.ToString()));

    /// <summary>
    /// Converts the GUID array to a delimited string with custom separator.
    /// </summary>
    /// <param name="arr">The GUID array to convert.</param>
    /// <param name="separator">The separator to use.</param>
    /// <returns>A delimited string of GUIDs.</returns>
    public static string ToDelimitedString(this Guid[] arr, string separator)
        => string.Join(separator, arr.Select(g => g.ToString()));

    // Helper method to get GUID version
    private static int GetGuidVersion(Guid guid)
    {
        var bytes = guid.ToByteArray();
        return (bytes[7] & 0xF0) >> 4;
    }
}