namespace ArrayExtensions;

public static class IntArrayExtensions
{
    /// <summary>
    /// Sums all the even numbers in the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The sum of all even numbers.</returns>
    public static int SumEvenNumbers(this int[] arr)
        => arr.Where(n => n % 2 == 0).Sum();

    /// <summary>
    /// Sums all the odd numbers in the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The sum of all odd numbers.</returns>
    public static int SumOddNumbers(this int[] arr)
        => arr.Where(n => n % 2 != 0).Sum();

    /// <summary>
    /// Filters the array to include only prime numbers.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>An array of prime numbers.</returns>
    public static int[] FindPrimeNumbers(this int[] arr)
        => arr.Where(IsPrime).ToArray();

    /// <summary>
    /// Calculates the average, ignoring zero values.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The average of non-zero numbers.</returns>
    public static double AverageIgnoringZero(this int[] arr)
        => arr.Where(n => n != 0).Average();

    /// <summary>
    /// Multiplies all elements in the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The product of all elements.</returns>
    public static long MultiplyAll(this int[] arr)
        => arr.Aggregate(1L, (a, b) => a * b);

    private static bool IsPrime(int number)
    {
        if (number < 2) return false;

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0) return false;
        }
        return true;
    }

    /// <summary>
    /// Checks if the array's elements are in a strictly increasing order.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if the array is strictly increasing; otherwise, false.</returns>
    public static bool IsMonotonicallyIncreasing(this int[] arr)
        => arr.Zip(arr.Skip(1), (a, b) => a < b).All(x => x);

    /// <summary>
    /// Checks if the array's elements are in a strictly decreasing order.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if the array is strictly decreasing; otherwise, false.</returns>
    public static bool IsMonotonicallyDecreasing(this int[] arr)
        => arr.Zip(arr.Skip(1), (a, b) => a > b).All(x => x);

    /// <summary>
    /// Finds the most frequently occurring number(s) in the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>An enumerable of the most frequent number(s).</returns>
    public static IEnumerable<int> Mode(this int[] arr)
        => arr.GroupBy(n => n).OrderByDescending(g => g.Count()).Select(g => g.Key);

    /// <summary>
    /// Finds the percentile value in the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <param name="percentile">The percentile to find (0-100).</param>
    /// <returns>The value at the specified percentile.</returns>
    public static double Percentile(this int[] arr, double percentile)
    {
        Array.Sort(arr);
        int index = (int)Math.Ceiling(percentile / 100.0 * arr.Length) - 1;
        return arr[index];
    }

    /// <summary>
    /// Randomizes the order of elements in the array.
    /// </summary>
    /// <param name="arr">The array to randomize.</param>
    /// <returns>A new array with elements in random order.</returns>
    public static int[] Randomize(this int[] arr)
    {
        var rnd = new Random();
        return arr.OrderBy(x => rnd.Next()).ToArray();
    }

    /// <summary>
    /// Calculates the sum of the absolute differences between all pairs of elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The sum of absolute differences between all pairs.</returns>
    public static long SumAbsoluteDifferences(this int[] arr)
        => arr.SelectMany((x, i) => arr.Skip(i + 1), (x, y) => Math.Abs(x - y)).Sum();

    /// <summary>
    /// Creates a frequency map (count of each element).
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>A dictionary with the frequency of each element.</returns>
    public static Dictionary<int, int> ToFrequencyMap(this int[] arr)
        => arr.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());

    /// <summary>
    /// Calculates the variance of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The variance of the array elements.</returns>
    public static double Variance(this int[] arr)
    {
        double mean = arr.Average();
        return arr.Sum(num => Math.Pow(num - mean, 2)) / arr.Length;
    }

    /// <summary>
    /// Calculates the standard deviation of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The standard deviation of the array elements.</returns>
    public static double StandardDeviation(this int[] arr)
        => Math.Sqrt(arr.Variance());
}