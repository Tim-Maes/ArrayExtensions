using System.Text;

namespace ArrayExtensions;

public static class CharArrayExtensions
{
    /// <summary>
    /// Converts the character array to a string.
    /// </summary>
    /// <param name="arr">The character array to convert.</param>
    /// <returns>A string representation of the character array.</returns>
    public static string AsString(this char[] arr)
        => new string(arr);

    /// <summary>
    /// Counts the number of vowels in the character array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The number of vowels.</returns>
    public static int CountVowels(this char[] arr)
    {
        const string vowels = "aeiouAEIOU";
        return arr.Count(c => vowels.Contains(c));
    }

    /// <summary>
    /// Counts the number of consonants in the character array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The number of consonants.</returns>
    public static int CountConsonants(this char[] arr)
        => arr.Count(c => char.IsLetter(c) && !"aeiouAEIOU".Contains(c));

    /// <summary>
    /// Counts the number of digits in the character array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The number of digits.</returns>
    public static int CountDigits(this char[] arr)
        => arr.Count(char.IsDigit);

    /// <summary>
    /// Counts the number of letters in the character array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The number of letters.</returns>
    public static int CountLetters(this char[] arr)
        => arr.Count(char.IsLetter);

    /// <summary>
    /// Counts the number of uppercase letters in the character array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The number of uppercase letters.</returns>
    public static int CountUppercase(this char[] arr)
        => arr.Count(char.IsUpper);

    /// <summary>
    /// Counts the number of lowercase letters in the character array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The number of lowercase letters.</returns>
    public static int CountLowercase(this char[] arr)
        => arr.Count(char.IsLower);

    /// <summary>
    /// Counts the number of whitespace characters in the character array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The number of whitespace characters.</returns>
    public static int CountWhitespace(this char[] arr)
        => arr.Count(char.IsWhiteSpace);

    /// <summary>
    /// Counts the number of punctuation characters in the character array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The number of punctuation characters.</returns>
    public static int CountPunctuation(this char[] arr)
        => arr.Count(char.IsPunctuation);

    /// <summary>
    /// Converts all letters in the character array to uppercase.
    /// </summary>
    /// <param name="arr">The character array to convert.</param>
    /// <returns>A new character array with uppercase letters.</returns>
    public static char[] ToUppercase(this char[] arr)
        => arr.Select(char.ToUpper).ToArray();

    /// <summary>
    /// Converts all letters in the character array to lowercase.
    /// </summary>
    /// <param name="arr">The character array to convert.</param>
    /// <returns>A new character array with lowercase letters.</returns>
    public static char[] ToLowercase(this char[] arr)
        => arr.Select(char.ToLower).ToArray();

    /// <summary>
    /// Removes all whitespace characters from the character array.
    /// </summary>
    /// <param name="arr">The character array to process.</param>
    /// <returns>A new character array without whitespace characters.</returns>
    public static char[] RemoveWhitespace(this char[] arr)
        => arr.Where(c => !char.IsWhiteSpace(c)).ToArray();

    /// <summary>
    /// Removes all non-letter characters from the character array.
    /// </summary>
    /// <param name="arr">The character array to process.</param>
    /// <returns>A new character array with only letters.</returns>
    public static char[] KeepLettersOnly(this char[] arr)
        => arr.Where(char.IsLetter).ToArray();

    /// <summary>
    /// Removes all non-digit characters from the character array.
    /// </summary>
    /// <param name="arr">The character array to process.</param>
    /// <returns>A new character array with only digits.</returns>
    public static char[] KeepDigitsOnly(this char[] arr)
        => arr.Where(char.IsDigit).ToArray();

    /// <summary>
    /// Removes all non-alphanumeric characters from the character array.
    /// </summary>
    /// <param name="arr">The character array to process.</param>
    /// <returns>A new character array with only alphanumeric characters.</returns>
    public static char[] KeepAlphanumericOnly(this char[] arr)
        => arr.Where(char.IsLetterOrDigit).ToArray();

    /// <summary>
    /// Finds the most frequently occurring character in the array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>The most frequent character.</returns>
    public static char MostFrequentChar(this char[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.GroupBy(c => c)
                  .OrderByDescending(g => g.Count())
                  .First()
                  .Key;
    }

    /// <summary>
    /// Creates a frequency map of all characters in the array.
    /// </summary>
    /// <param name="arr">The character array to analyze.</param>
    /// <returns>A dictionary with character frequencies.</returns>
    public static Dictionary<char, int> GetCharacterFrequency(this char[] arr)
        => arr.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

    /// <summary>
    /// Checks if the character array represents a palindrome.
    /// </summary>
    /// <param name="arr">The character array to check.</param>
    /// <returns>True if the array is a palindrome, otherwise false.</returns>
    public static bool IsPalindrome(this char[] arr)
    {
        if (arr == null || arr.Length <= 1)
            return true;

        int left = 0;
        int right = arr.Length - 1;

        while (left < right)
        {
            if (arr[left] != arr[right])
                return false;
            left++;
            right--;
        }

        return true;
    }

    /// <summary>
    /// Reverses the character array.
    /// </summary>
    /// <param name="arr">The character array to reverse.</param>
    /// <returns>A new character array with reversed order.</returns>
    public static char[] Reverse(this char[] arr)
        => arr.Reverse().ToArray();

    /// <summary>
    /// Rotates the character array to the left by the specified number of positions.
    /// </summary>
    /// <param name="arr">The character array to rotate.</param>
    /// <param name="positions">The number of positions to rotate.</param>
    /// <returns>A new character array rotated to the left.</returns>
    public static char[] RotateLeft(this char[] arr, int positions)
    {
        if (arr == null || arr.Length == 0)
            return arr;

        positions = positions % arr.Length;
        return arr.Skip(positions).Concat(arr.Take(positions)).ToArray();
    }

    /// <summary>
    /// Rotates the character array to the right by the specified number of positions.
    /// </summary>
    /// <param name="arr">The character array to rotate.</param>
    /// <param name="positions">The number of positions to rotate.</param>
    /// <returns>A new character array rotated to the right.</returns>
    public static char[] RotateRight(this char[] arr, int positions)
    {
        if (arr == null || arr.Length == 0)
            return arr;

        positions = positions % arr.Length;
        return arr.Skip(arr.Length - positions).Concat(arr.Take(arr.Length - positions)).ToArray();
    }

    /// <summary>
    /// Finds all indices where a specific character occurs.
    /// </summary>
    /// <param name="arr">The character array to search.</param>
    /// <param name="character">The character to find.</param>
    /// <returns>An array of indices where the character occurs.</returns>
    public static int[] FindAllIndices(this char[] arr, char character)
        => arr.Select((c, index) => new { c, index })
              .Where(x => x.c == character)
              .Select(x => x.index)
              .ToArray();

    /// <summary>
    /// Replaces all occurrences of a character with another character.
    /// </summary>
    /// <param name="arr">The character array to process.</param>
    /// <param name="oldChar">The character to replace.</param>
    /// <param name="newChar">The replacement character.</param>
    /// <returns>A new character array with replacements.</returns>
    public static char[] ReplaceAll(this char[] arr, char oldChar, char newChar)
        => arr.Select(c => c == oldChar ? newChar : c).ToArray();

    /// <summary>
    /// Capitalizes the first character if it's a letter.
    /// </summary>
    /// <param name="arr">The character array to process.</param>
    /// <returns>A new character array with the first letter capitalized.</returns>
    public static char[] CapitalizeFirst(this char[] arr)
    {
        if (arr == null || arr.Length == 0)
            return arr;

        var result = new char[arr.Length];
        Array.Copy(arr, result, arr.Length);

        if (char.IsLetter(result[0]))
            result[0] = char.ToUpper(result[0]);

        return result;
    }

    /// <summary>
    /// Converts the character array to title case (capitalizes first letter of each word).
    /// </summary>
    /// <param name="arr">The character array to process.</param>
    /// <returns>A new character array in title case.</returns>
    public static char[] ToTitleCase(this char[] arr)
    {
        if (arr == null || arr.Length == 0)
            return arr;

        var result = new char[arr.Length];
        bool capitalizeNext = true;

        for (int i = 0; i < arr.Length; i++)
        {
            if (char.IsWhiteSpace(arr[i]))
            {
                result[i] = arr[i];
                capitalizeNext = true;
            }
            else if (char.IsLetter(arr[i]))
            {
                result[i] = capitalizeNext ? char.ToUpper(arr[i]) : char.ToLower(arr[i]);
                capitalizeNext = false;
            }
            else
            {
                result[i] = arr[i];
            }
        }

        return result;
    }

    /// <summary>
    /// Removes duplicate characters while preserving order.
    /// </summary>
    /// <param name="arr">The character array to process.</param>
    /// <returns>A new character array without duplicates.</returns>
    public static char[] RemoveDuplicates(this char[] arr)
        => arr.Distinct().ToArray();

    /// <summary>
    /// Checks if the character array contains only ASCII characters.
    /// </summary>
    /// <param name="arr">The character array to check.</param>
    /// <returns>True if all characters are ASCII, otherwise false.</returns>
    public static bool IsAsciiOnly(this char[] arr)
        => arr.All(c => c <= 127);

    /// <summary>
    /// Encodes the character array using the specified encoding.
    /// </summary>
    /// <param name="arr">The character array to encode.</param>
    /// <param name="encoding">The encoding to use.</param>
    /// <returns>A byte array representing the encoded characters.</returns>
    public static byte[] Encode(this char[] arr, Encoding encoding)
        => encoding.GetBytes(arr);

    /// <summary>
    /// Sorts the character array alphabetically.
    /// </summary>
    /// <param name="arr">The character array to sort.</param>
    /// <returns>A new character array sorted alphabetically.</returns>
    public static char[] SortAlphabetically(this char[] arr)
        => arr.OrderBy(c => c).ToArray();

    /// <summary>
    /// Groups characters by their Unicode category.
    /// </summary>
    /// <param name="arr">The character array to group.</param>
    /// <returns>A dictionary grouping characters by their Unicode category.</returns>
    public static Dictionary<System.Globalization.UnicodeCategory, char[]> GroupByUnicodeCategory(this char[] arr)
        => arr.GroupBy(char.GetUnicodeCategory)
              .ToDictionary(g => g.Key, g => g.ToArray());
}