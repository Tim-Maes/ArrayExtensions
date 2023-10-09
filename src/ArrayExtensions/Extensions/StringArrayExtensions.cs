namespace ArrayExtensions;

public static class StringArrayExtensions
{
    /// <summary>
    /// Checks if any item is null or empty in the array.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if atleast one item is null or empty.</returns>
    public static bool AnyNullOrEmpty(this string[] arr) => arr.Any(string.IsNullOrEmpty);

    /// <summary>
    /// Checks if any item is null or whitespace in the array.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if atleast one item is null or empty.</returns>
    public static bool AnyNullOrWhiteSpace(this string[] arr) => arr.Any(string.IsNullOrWhiteSpace);

    /// <summary>
    /// Trims all items in the array
    /// </summary>
    /// <param name="arr">The array to trim all items.</param>
    /// <returns>Array with trimmed items.</returns>
    public static string[] TrimAll(this string[] arr) => arr.Select(s => s.Trim()).ToArray();

    /// <summary>
    /// Removes all empty and null items from the array.
    /// </summary>
    /// <param name="arr">The array to remove null or empty items from.</param>
    /// <returns>Array without null or empty values.</returns>
    public static string[] RemoveNullOrEmpty(this string[] arr) => arr.Where(s => !string.IsNullOrEmpty(s)).ToArray();

    /// <summary>
    /// Removes all whitespace and null items from the array.
    /// </summary>
    /// <param name="arr">The array to remove whitespace or empty items from.</param>
    /// <returns>Array without null or empty values.</returns>
    public static string[] RemoveNullOrWhiteSpace(this string[] arr) => arr.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

    /// <summary>
    /// Checks if the array has duplicate values.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if any duplicate values present.</returns>
    public static bool HasDuplicates(this string[] arr) => arr.GroupBy(s => s).Any(g => g.Count() > 1);

    /// <summary>
    /// Concatenate all strings with a given separator.
    /// </summary>
    /// <param name="arr">The array to concatenate.</param>
    /// <param name="separator">The separator.</param>
    /// <returns>Concatenated string from all array elements.</returns>
    public static string ConcatenateWithSeparator(this string[] arr, string separator) => string.Join(separator, arr);
}
