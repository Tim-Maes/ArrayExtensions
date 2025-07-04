using System.Text.RegularExpressions;
using System.Globalization;

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

    /// <summary>
    /// Sorts the array of strings in alphabetical order.
    /// </summary>
    /// <param name="arr">The array to sort.</param>
    /// <returns>An array of strings sorted alphabetically.</returns>
    public static string[] SortAlphabetically(this string[] arr)
        => arr.OrderBy(s => s).ToArray();

    /// <summary>
    /// Checks if any of the strings in the array contains a specified substring.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <param name="substring">The substring to check for.</param>
    /// <returns>True if any string contains the specified substring.</returns>
    public static bool ContainsSubstring(this string[] arr, string substring)
        => arr.Any(s => s.Contains(substring));

    /// <summary>
    /// Checks if any of the strings in the array starts with a specified substring.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <param name="substring">The substring to check for.</param>
    /// <returns>True if any string starts with the specified substring.</returns>
    public static bool StartsWithSubstring(this string[] arr, string substring)
        => arr.Any(s => s.StartsWith(substring));

    /// <summary>
    /// Checks if any of the strings in the array ends with a specified substring.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <param name="substring">The substring to check for.</param>
    /// <returns>True if any string ends with the specified substring.</returns>
    public static bool EndsWithSubstring(this string[] arr, string substring)
        => arr.Any(s => s.EndsWith(substring));

    /// <summary>
    /// Concatenates non-empty strings in the array with a given separator.
    /// </summary>
    /// <param name="arr">The array to concatenate.</param>
    /// <param name="separator">The separator to use.</param>
    /// <returns>A concatenated string from non-empty array elements.</returns>
    public static string JoinNonEmpty(this string[] arr, string separator)
        => string.Join(separator, arr.Where(s => !string.IsNullOrEmpty(s)));

    /// <summary>
    /// Counts the number of strings that match a regular expression pattern.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <param name="pattern">The regular expression pattern.</param>
    /// <returns>The count of strings matching the pattern.</returns>
    public static int CountStringsMatchingPattern(this string[] arr, string pattern)
        => arr.Count(s => Regex.IsMatch(s, pattern));

    /// <summary>
    /// Replaces multiple consecutive whitespace characters in each string with a single space.
    /// </summary>
    /// <param name="arr">The array to normalize whitespace.</param>
    /// <returns>An array with normalized whitespace in each string.</returns>
    public static string[] NormalizeWhitespace(this string[] arr)
        => arr.Select(s => Regex.Replace(s, @"\s+", " ")).ToArray();

    /// <summary>
    /// Capitalizes the first letter of each string in the array.
    /// </summary>
    /// <param name="arr">The array to modify.</param>
    /// <returns>An array with the first letter of each string capitalized.</returns>
    public static string[] CapitalizeFirstLetter(this string[] arr)
        => arr.Select(s => char.ToUpper(s[0]) + s.Substring(1).ToLower()).ToArray();

    /// <summary>
    /// Returns an array of unique strings, removing duplicates.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>An array of unique strings.</returns>
    public static string[] UniqueStrings(this string[] arr)
        => arr.Distinct().ToArray();

    /// <summary>
    /// Aggregates the array into a single string using a specified function.
    /// </summary>
    /// <param name="arr">The array to aggregate.</param>
    /// <param name="aggregator">The function to aggregate the strings.</param>
    /// <returns>A single string resulting from the aggregation of the array elements.</returns>
    public static string AggregateStrings(this string[] arr, Func<string, string, string> aggregator)
        => arr.Aggregate(aggregator);

    /// <summary>
    /// Converts all strings to title case (capitalizes the first letter of each word).
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array with all strings in title case.</returns>
    public static string[] ToTitleCase(this string[] arr)
        => arr.Select(s => CultureInfo.CurrentCulture.TextInfo.ToTitleCase(s.ToLower())).ToArray();

    /// <summary>
    /// Pads all strings to the same length using a specified character.
    /// </summary>
    /// <param name="arr">The array to pad.</param>
    /// <param name="paddingChar">The character to use for padding.</param>
    /// <param name="padLeft">If true, pad on the left; otherwise, pad on the right.</param>
    /// <returns>An array with all strings padded to the same length.</returns>
    public static string[] PadToSameLength(this string[] arr, char paddingChar = ' ', bool padLeft = false)
    {
        if (arr == null || arr.Length == 0)
            return arr;

        int maxLength = arr.Max(s => s.Length);
        return arr.Select(s => padLeft ? s.PadLeft(maxLength, paddingChar) : s.PadRight(maxLength, paddingChar)).ToArray();
    }

    /// <summary>
    /// Truncates all strings to a specified maximum length.
    /// </summary>
    /// <param name="arr">The array to truncate.</param>
    /// <param name="maxLength">The maximum length for each string.</param>
    /// <param name="ellipsis">Optional ellipsis string to append to truncated strings.</param>
    /// <returns>An array with truncated strings.</returns>
    public static string[] TruncateAll(this string[] arr, int maxLength, string ellipsis = "")
        => arr.Select(s => s.Length <= maxLength ? s : s.Substring(0, maxLength) + ellipsis).ToArray();

    /// <summary>
    /// Filters strings by minimum and maximum length.
    /// </summary>
    /// <param name="arr">The array to filter.</param>
    /// <param name="minLength">The minimum length (inclusive).</param>
    /// <param name="maxLength">The maximum length (inclusive).</param>
    /// <returns>An array containing only strings within the specified length range.</returns>
    public static string[] FilterByLength(this string[] arr, int minLength, int maxLength)
        => arr.Where(s => s.Length >= minLength && s.Length <= maxLength).ToArray();

    /// <summary>
    /// Counts the total number of words in all strings.
    /// </summary>
    /// <param name="arr">The array to count words in.</param>
    /// <returns>The total word count across all strings.</returns>
    public static int TotalWordCount(this string[] arr)
        => arr.Sum(s => s.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length);

    /// <summary>
    /// Gets the word count for each string in the array.
    /// </summary>
    /// <param name="arr">The array to analyze.</param>
    /// <returns>An array of word counts corresponding to each string.</returns>
    public static int[] GetWordCounts(this string[] arr)
        => arr.Select(s => s.Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length).ToArray();

    /// <summary>
    /// Extracts all email addresses from the strings in the array.
    /// </summary>
    /// <param name="arr">The array to search for email addresses.</param>
    /// <returns>An array of all email addresses found.</returns>
    public static string[] ExtractEmailAddresses(this string[] arr)
    {
        const string emailPattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b";
        return arr.SelectMany(s => Regex.Matches(s, emailPattern).Cast<Match>().Select(m => m.Value)).ToArray();
    }

    /// <summary>
    /// Extracts all URLs from the strings in the array.
    /// </summary>
    /// <param name="arr">The array to search for URLs.</param>
    /// <returns>An array of all URLs found.</returns>
    public static string[] ExtractUrls(this string[] arr)
    {
        const string urlPattern = @"https?://[^\s]+";
        return arr.SelectMany(s => Regex.Matches(s, urlPattern).Cast<Match>().Select(m => m.Value)).ToArray();
    }

    /// <summary>
    /// Extracts all phone numbers from the strings in the array.
    /// </summary>
    /// <param name="arr">The array to search for phone numbers.</param>
    /// <returns>An array of all phone numbers found.</returns>
    public static string[] ExtractPhoneNumbers(this string[] arr)
    {
        const string phonePattern = @"(\+\d{1,3}[-.\s]?)?\(?\d{3}\)?[-.\s]?\d{3}[-.\s]?\d{4}";
        return arr.SelectMany(s => Regex.Matches(s, phonePattern).Cast<Match>().Select(m => m.Value)).ToArray();
    }

    /// <summary>
    /// Removes HTML tags from all strings in the array.
    /// </summary>
    /// <param name="arr">The array containing HTML strings.</param>
    /// <returns>An array with HTML tags removed.</returns>
    public static string[] StripHtmlTags(this string[] arr)
        => arr.Select(s => Regex.Replace(s, "<.*?>", string.Empty)).ToArray();

    /// <summary>
    /// Converts all strings to camelCase.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array with all strings in camelCase.</returns>
    public static string[] ToCamelCase(this string[] arr)
        => arr.Select(ToCamelCaseInternal).ToArray();

    /// <summary>
    /// Converts all strings to PascalCase.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array with all strings in PascalCase.</returns>
    public static string[] ToPascalCase(this string[] arr)
        => arr.Select(ToPascalCaseInternal).ToArray();

    /// <summary>
    /// Converts all strings to kebab-case.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array with all strings in kebab-case.</returns>
    public static string[] ToKebabCase(this string[] arr)
        => arr.Select(ToKebabCaseInternal).ToArray();

    /// <summary>
    /// Converts all strings to snake_case.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array with all strings in snake_case.</returns>
    public static string[] ToSnakeCase(this string[] arr)
        => arr.Select(ToSnakeCaseInternal).ToArray();

    /// <summary>
    /// Checks if all strings are valid email addresses.
    /// </summary>
    /// <param name="arr">The array to validate.</param>
    /// <returns>True if all strings are valid email addresses.</returns>
    public static bool AllValidEmails(this string[] arr)
    {
        const string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}$";
        return arr.All(s => Regex.IsMatch(s, emailPattern));
    }

    /// <summary>
    /// Checks if all strings are numeric.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if all strings represent valid numbers.</returns>
    public static bool AllNumeric(this string[] arr)
        => arr.All(s => double.TryParse(s, out _));

    /// <summary>
    /// Converts numeric strings to integers, filtering out non-numeric strings.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array of integers parsed from numeric strings.</returns>
    public static int[] ToIntegers(this string[] arr)
        => arr.Where(s => int.TryParse(s, out _)).Select(int.Parse).ToArray();

    /// <summary>
    /// Converts numeric strings to doubles, filtering out non-numeric strings.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array of doubles parsed from numeric strings.</returns>
    public static double[] ToDoubles(this string[] arr)
        => arr.Where(s => double.TryParse(s, out _)).Select(double.Parse).ToArray();

    /// <summary>
    /// Gets character frequency across all strings in the array.
    /// </summary>
    /// <param name="arr">The array to analyze.</param>
    /// <returns>A dictionary with character frequencies.</returns>
    public static Dictionary<char, int> GetCharacterFrequency(this string[] arr)
        => arr.SelectMany(s => s).GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

    /// <summary>
    /// Finds the most common words across all strings in the array.
    /// </summary>
    /// <param name="arr">The array to analyze.</param>
    /// <param name="topCount">The number of top words to return.</param>
    /// <returns>An array of the most common words.</returns>
    public static string[] MostCommonWords(this string[] arr, int topCount = 10)
    {
        return arr.SelectMany(s => s.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' }, 
                                         StringSplitOptions.RemoveEmptyEntries))
                  .Where(word => !string.IsNullOrWhiteSpace(word))
                  .GroupBy(word => word.ToLower())
                  .OrderByDescending(g => g.Count())
                  .Take(topCount)
                  .Select(g => g.Key)
                  .ToArray();
    }

    // Helper methods
    private static string ToCamelCaseInternal(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        
        var words = input.Split(new[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);
        var result = words[0].ToLower();
        
        for (int i = 1; i < words.Length; i++)
        {
            result += char.ToUpper(words[i][0]) + words[i].Substring(1).ToLower();
        }
        
        return result;
    }

    private static string ToPascalCaseInternal(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        
        var words = input.Split(new[] { ' ', '_', '-' }, StringSplitOptions.RemoveEmptyEntries);
        var result = string.Empty;
        
        foreach (var word in words)
        {
            result += char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }
        
        return result;
    }

    private static string ToKebabCaseInternal(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        
        return Regex.Replace(input, @"([a-z])([A-Z])", "$1-$2")
                   .Replace(' ', '-')
                   .Replace('_', '-')
                   .ToLower();
    }

    private static string ToSnakeCaseInternal(string input)
    {
        if (string.IsNullOrEmpty(input)) return input;
        
        return Regex.Replace(input, @"([a-z])([A-Z])", "$1_$2")
                   .Replace(' ', '_')
                   .Replace('-', '_')
                   .ToLower();
    }
}
