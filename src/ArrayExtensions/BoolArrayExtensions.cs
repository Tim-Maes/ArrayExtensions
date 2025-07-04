namespace ArrayExtensions;

public static class BoolArrayExtensions
{
    /// <summary>
    /// Counts the number of true values in the array.
    /// </summary>
    /// <param name="arr">The boolean array to count.</param>
    /// <returns>The number of true values.</returns>
    public static int CountTrue(this bool[] arr)
        => arr.Count(x => x);

    /// <summary>
    /// Counts the number of false values in the array.
    /// </summary>
    /// <param name="arr">The boolean array to count.</param>
    /// <returns>The number of false values.</returns>
    public static int CountFalse(this bool[] arr)
        => arr.Count(x => !x);

    /// <summary>
    /// Checks if all values in the array are true.
    /// </summary>
    /// <param name="arr">The boolean array to check.</param>
    /// <returns>True if all values are true, otherwise false.</returns>
    public static bool AllTrue(this bool[] arr)
        => arr.All(x => x);

    /// <summary>
    /// Checks if all values in the array are false.
    /// </summary>
    /// <param name="arr">The boolean array to check.</param>
    /// <returns>True if all values are false, otherwise false.</returns>
    public static bool AllFalse(this bool[] arr)
        => arr.All(x => !x);

    /// <summary>
    /// Checks if any value in the array is true.
    /// </summary>
    /// <param name="arr">The boolean array to check.</param>
    /// <returns>True if any value is true, otherwise false.</returns>
    public static bool AnyTrue(this bool[] arr)
        => arr.Any(x => x);

    /// <summary>
    /// Checks if any value in the array is false.
    /// </summary>
    /// <param name="arr">The boolean array to check.</param>
    /// <returns>True if any value is false, otherwise false.</returns>
    public static bool AnyFalse(this bool[] arr)
        => arr.Any(x => !x);

    /// <summary>
    /// Inverts all boolean values in the array.
    /// </summary>
    /// <param name="arr">The boolean array to invert.</param>
    /// <returns>A new array with inverted boolean values.</returns>
    public static bool[] Invert(this bool[] arr)
        => arr.Select(x => !x).ToArray();

    /// <summary>
    /// Performs logical AND operation with another boolean array.
    /// </summary>
    /// <param name="arr1">The first boolean array.</param>
    /// <param name="arr2">The second boolean array.</param>
    /// <returns>A new array with AND results.</returns>
    public static bool[] And(this bool[] arr1, bool[] arr2)
    {
        if (arr1 == null || arr2 == null)
            throw new ArgumentNullException("Arrays cannot be null.");

        if (arr1.Length != arr2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return arr1.Zip(arr2, (a, b) => a && b).ToArray();
    }

    /// <summary>
    /// Performs logical OR operation with another boolean array.
    /// </summary>
    /// <param name="arr1">The first boolean array.</param>
    /// <param name="arr2">The second boolean array.</param>
    /// <returns>A new array with OR results.</returns>
    public static bool[] Or(this bool[] arr1, bool[] arr2)
    {
        if (arr1 == null || arr2 == null)
            throw new ArgumentNullException("Arrays cannot be null.");

        if (arr1.Length != arr2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return arr1.Zip(arr2, (a, b) => a || b).ToArray();
    }

    /// <summary>
    /// Performs logical XOR operation with another boolean array.
    /// </summary>
    /// <param name="arr1">The first boolean array.</param>
    /// <param name="arr2">The second boolean array.</param>
    /// <returns>A new array with XOR results.</returns>
    public static bool[] Xor(this bool[] arr1, bool[] arr2)
    {
        if (arr1 == null || arr2 == null)
            throw new ArgumentNullException("Arrays cannot be null.");

        if (arr1.Length != arr2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return arr1.Zip(arr2, (a, b) => a ^ b).ToArray();
    }

    /// <summary>
    /// Finds the indices of all true values in the array.
    /// </summary>
    /// <param name="arr">The boolean array to search.</param>
    /// <returns>An array of indices where values are true.</returns>
    public static int[] FindTrueIndices(this bool[] arr)
        => arr.Select((value, index) => new { value, index })
              .Where(x => x.value)
              .Select(x => x.index)
              .ToArray();

    /// <summary>
    /// Finds the indices of all false values in the array.
    /// </summary>
    /// <param name="arr">The boolean array to search.</param>
    /// <returns>An array of indices where values are false.</returns>
    public static int[] FindFalseIndices(this bool[] arr)
        => arr.Select((value, index) => new { value, index })
              .Where(x => !x.value)
              .Select(x => x.index)
              .ToArray();

    /// <summary>
    /// Calculates the percentage of true values in the array.
    /// </summary>
    /// <param name="arr">The boolean array to analyze.</param>
    /// <returns>The percentage of true values (0-100).</returns>
    public static double TruePercentage(this bool[] arr)
    {
        if (arr == null || arr.Length == 0)
            return 0;

        return (double)arr.CountTrue() / arr.Length * 100;
    }

    /// <summary>
    /// Calculates the percentage of false values in the array.
    /// </summary>
    /// <param name="arr">The boolean array to analyze.</param>
    /// <returns>The percentage of false values (0-100).</returns>
    public static double FalsePercentage(this bool[] arr)
    {
        if (arr == null || arr.Length == 0)
            return 0;

        return (double)arr.CountFalse() / arr.Length * 100;
    }

    /// <summary>
    /// Finds the first index where the value is true.
    /// </summary>
    /// <param name="arr">The boolean array to search.</param>
    /// <returns>The first index with true value, or -1 if not found.</returns>
    public static int FirstTrueIndex(this bool[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i]) return i;
        }
        return -1;
    }

    /// <summary>
    /// Finds the last index where the value is true.
    /// </summary>
    /// <param name="arr">The boolean array to search.</param>
    /// <returns>The last index with true value, or -1 if not found.</returns>
    public static int LastTrueIndex(this bool[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (arr[i]) return i;
        }
        return -1;
    }

    /// <summary>
    /// Finds the first index where the value is false.
    /// </summary>
    /// <param name="arr">The boolean array to search.</param>
    /// <returns>The first index with false value, or -1 if not found.</returns>
    public static int FirstFalseIndex(this bool[] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (!arr[i]) return i;
        }
        return -1;
    }

    /// <summary>
    /// Finds the last index where the value is false.
    /// </summary>
    /// <param name="arr">The boolean array to search.</param>
    /// <returns>The last index with false value, or -1 if not found.</returns>
    public static int LastFalseIndex(this bool[] arr)
    {
        for (int i = arr.Length - 1; i >= 0; i--)
        {
            if (!arr[i]) return i;
        }
        return -1;
    }

    /// <summary>
    /// Converts the boolean array to a binary string representation.
    /// </summary>
    /// <param name="arr">The boolean array to convert.</param>
    /// <returns>A string of 1s and 0s representing the boolean values.</returns>
    public static string ToBinaryString(this bool[] arr)
        => string.Join("", arr.Select(x => x ? "1" : "0"));

    /// <summary>
    /// Converts the boolean array to an integer array (true = 1, false = 0).
    /// </summary>
    /// <param name="arr">The boolean array to convert.</param>
    /// <returns>An integer array representation.</returns>
    public static int[] ToIntArray(this bool[] arr)
        => arr.Select(x => x ? 1 : 0).ToArray();

    /// <summary>
    /// Groups consecutive true values and returns their start indices and lengths.
    /// </summary>
    /// <param name="arr">The boolean array to analyze.</param>
    /// <returns>A collection of tuples containing start index and length of consecutive true sequences.</returns>
    public static IEnumerable<(int StartIndex, int Length)> FindConsecutiveTrueSequences(this bool[] arr)
    {
        var sequences = new List<(int StartIndex, int Length)>();
        int startIndex = -1;
        int length = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i])
            {
                if (startIndex == -1)
                {
                    startIndex = i;
                    length = 1;
                }
                else
                {
                    length++;
                }
            }
            else
            {
                if (startIndex != -1)
                {
                    sequences.Add((startIndex, length));
                    startIndex = -1;
                    length = 0;
                }
            }
        }

        // Handle case where array ends with true values
        if (startIndex != -1)
        {
            sequences.Add((startIndex, length));
        }

        return sequences;
    }

    /// <summary>
    /// Groups consecutive false values and returns their start indices and lengths.
    /// </summary>
    /// <param name="arr">The boolean array to analyze.</param>
    /// <returns>A collection of tuples containing start index and length of consecutive false sequences.</returns>
    public static IEnumerable<(int StartIndex, int Length)> FindConsecutiveFalseSequences(this bool[] arr)
    {
        return arr.Invert().FindConsecutiveTrueSequences();
    }

    /// <summary>
    /// Finds the longest sequence of consecutive true values.
    /// </summary>
    /// <param name="arr">The boolean array to analyze.</param>
    /// <returns>A tuple containing the start index and length of the longest true sequence.</returns>
    public static (int StartIndex, int Length) LongestTrueSequence(this bool[] arr)
    {
        var sequences = arr.FindConsecutiveTrueSequences();
        if (!sequences.Any())
            return (-1, 0);

        return sequences.OrderByDescending(s => s.Length).First();
    }

    /// <summary>
    /// Finds the longest sequence of consecutive false values.
    /// </summary>
    /// <param name="arr">The boolean array to analyze.</param>
    /// <returns>A tuple containing the start index and length of the longest false sequence.</returns>
    public static (int StartIndex, int Length) LongestFalseSequence(this bool[] arr)
    {
        var sequences = arr.FindConsecutiveFalseSequences();
        if (!sequences.Any())
            return (-1, 0);

        return sequences.OrderByDescending(s => s.Length).First();
    }
}