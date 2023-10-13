namespace ArrayExtensions;

public static class StringArrayExtensions
{
    /// <summary>
    /// Checks if any item is null or empty in the array.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if atleast one item is null or empty.</returns>
    public static bool AnyNullOrEmpty(this string[] arr)
        => arr.Any(string.IsNullOrEmpty);

    /// <summary>
    /// Checks if any item is null or whitespace in the array.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if atleast one item is null or empty.</returns>
    public static bool AnyNullOrWhiteSpace(this string[] arr)
        => arr.Any(string.IsNullOrWhiteSpace);

    /// <summary>
    /// Trims all items in the array
    /// </summary>
    /// <param name="arr">The array to trim all items.</param>
    /// <returns>Array with trimmed items.</returns>
    public static string[] TrimAll(this string[] arr)
        => arr.Select(s => s.Trim()).ToArray();

    /// <summary>
    /// Removes all empty and null items from the array.
    /// </summary>
    /// <param name="arr">The array to remove null or empty items from.</param>
    /// <returns>Array without null or empty values.</returns>
    public static string[] RemoveNullOrEmpty(this string[] arr)
        => arr.Where(s => !string.IsNullOrEmpty(s)).ToArray();

    /// <summary>
    /// Removes all whitespace and null items from the array.
    /// </summary>
    /// <param name="arr">The array to remove whitespace or empty items from.</param>
    /// <returns>Array without null or empty values.</returns>
    public static string[] RemoveNullOrWhiteSpace(this string[] arr)
        => arr.Where(s => !string.IsNullOrWhiteSpace(s)).ToArray();

    /// <summary>
    /// Checks if the array has duplicate values.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if any duplicate values present.</returns>
    public static bool HasDuplicates(this string[] arr)
        => arr.GroupBy(s => s).Any(g => g.Count() > 1);

    /// <summary>
    /// Concatenate all strings with a given separator.
    /// </summary>
    /// <param name="arr">The array to concatenate.</param>
    /// <param name="separator">The separator.</param>
    /// <returns>Concatenated string from all array elements.</returns>
    public static string ConcatenateWithSeparator(this string[] arr, string separator)
        => string.Join(separator, arr);

    /// <summary>
    /// Converts all strings in the array to uppercase.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>Array with all uppercase strings.</returns>
    public static string[] ToUpperCase(this string[] arr)
        => arr.Select(s => s.ToUpper()).ToArray();

    /// <summary>
    /// Converts all strings in the array to lowercase.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>Array with all lowercase strings.</returns>
    public static string[] ToLowerCase(this string[] arr)
        => arr.Select(s => s.ToLower()).ToArray();

    /// <summary>
    /// Reverses each string in the array.
    /// </summary>
    /// <param name="arr">The array to reverse.</param>
    /// <returns>Array with reversed strings.</returns>
    public static string[] ReverseEach(this string[] arr)
        => arr.Select(s => new string(s.Reverse().ToArray())).ToArray();

    /// <summary>
    /// Filters strings that match a given pattern.
    /// </summary>
    /// <param name="arr">The array to filter.</param>
    /// <param name="pattern">The pattern to match.</param>
    /// <returns>Array with strings that match the pattern.</returns>
    public static string[] FilterByPattern(this string[] arr, string pattern)
        => arr.Where(s => System.Text.RegularExpressions.Regex.IsMatch(s, pattern)).ToArray();

    /// <summary>
    /// Counts occurrences of a substring in all strings of the array.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <param name="substring">The substring to count.</param>
    /// <returns>Total occurrences of the substring.</returns>
    public static int CountOccurrencesOfSubstring(this string[] arr, string substring)
        => arr.Sum(s => s.Split(new[] { substring }, StringSplitOptions.None).Length - 1);

    /// <summary>
    /// Replaces a substring in all strings of the array.
    /// </summary>
    /// <param name="arr">The array to replace in.</param>
    /// <param name="oldValue">The old substring.</param>
    /// <param name="newValue">The new substring.</param>
    /// <returns>Array with replaced substrings.</returns>
    public static string[] ReplaceInAll(this string[] arr, string oldValue, string newValue)
        => arr.Select(s => s.Replace(oldValue, newValue)).ToArray();

    /// <summary>
    /// Checks if all strings in the array are of a certain length.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <param name="length">The length to check.</param>
    /// <returns>True if all strings have the specified length.</returns>
    public static bool AllOfLength(this string[] arr, int length)
        => arr.All(s => s.Length == length);

    /// <summary>
    /// Gets the longest string from the array.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>The longest string.</returns>
    public static string LongestString(this string[] arr)
        => arr.OrderByDescending(s => s.Length).FirstOrDefault();

    /// <summary>
    /// Gets the shortest string from the array.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>The shortest string.</returns>
    public static string ShortestString(this string[] arr)
        => arr.OrderBy(s => s.Length).FirstOrDefault();
}
