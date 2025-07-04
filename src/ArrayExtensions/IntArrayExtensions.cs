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

    /// <summary>
    /// Filters the array to include only positive numbers.
    /// </summary>
    /// <param name="arr">The array to filter.</param>
    /// <returns>An array containing only positive numbers.</returns>
    public static int[] FilterPositive(this int[] arr)
        => arr.Where(n => n > 0).ToArray();

    /// <summary>
    /// Filters the array to include only negative numbers.
    /// </summary>
    /// <param name="arr">The array to filter.</param>
    /// <returns>An array containing only negative numbers.</returns>
    public static int[] FilterNegative(this int[] arr)
        => arr.Where(n => n < 0).ToArray();

    /// <summary>
    /// Filters the array to include only zero values.
    /// </summary>
    /// <param name="arr">The array to filter.</param>
    /// <returns>An array containing only zero values.</returns>
    public static int[] FilterZeros(this int[] arr)
        => arr.Where(n => n == 0).ToArray();

    /// <summary>
    /// Counts the number of positive numbers in the array.
    /// </summary>
    /// <param name="arr">The array to count.</param>
    /// <returns>The count of positive numbers.</returns>
    public static int CountPositive(this int[] arr)
        => arr.Count(n => n > 0);

    /// <summary>
    /// Counts the number of negative numbers in the array.
    /// </summary>
    /// <param name="arr">The array to count.</param>
    /// <returns>The count of negative numbers.</returns>
    public static int CountNegative(this int[] arr)
        => arr.Count(n => n < 0);

    /// <summary>
    /// Counts the number of zero values in the array.
    /// </summary>
    /// <param name="arr">The array to count.</param>
    /// <returns>The count of zero values.</returns>
    public static int CountZeros(this int[] arr)
        => arr.Count(n => n == 0);

    /// <summary>
    /// Calculates the geometric mean of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The geometric mean.</returns>
    public static double GeometricMean(this int[] arr)
    {
        if (arr.Any(n => n <= 0))
            throw new ArgumentException("All values must be positive for geometric mean calculation.");

        return Math.Pow(arr.Aggregate(1.0, (acc, x) => acc * x), 1.0 / arr.Length);
    }

    /// <summary>
    /// Calculates the harmonic mean of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The harmonic mean.</returns>
    public static double HarmonicMean(this int[] arr)
    {
        if (arr.Any(n => n == 0))
            throw new ArgumentException("Array cannot contain zero values for harmonic mean calculation.");

        return arr.Length / arr.Sum(x => 1.0 / x);
    }

    /// <summary>
    /// Calculates the median of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The median value.</returns>
    public static double Median(this int[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        var sorted = arr.OrderBy(x => x).ToArray();
        int midIndex = sorted.Length / 2;

        if (sorted.Length % 2 == 0)
            return (sorted[midIndex - 1] + sorted[midIndex]) / 2.0;
        else
            return sorted[midIndex];
    }

    /// <summary>
    /// Finds the range (difference between max and min) of the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The range of the array.</returns>
    public static int Range(this int[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.Max() - arr.Min();
    }

    /// <summary>
    /// Calculates the factorial of each element in the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>An array with factorials of each element.</returns>
    public static long[] CalculateFactorials(this int[] arr)
        => arr.Select(Factorial).ToArray();

    /// <summary>
    /// Checks if each number in the array is a perfect square.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>A boolean array indicating which elements are perfect squares.</returns>
    public static bool[] IsPerfectSquare(this int[] arr)
        => arr.Select(n => 
        {
            if (n < 0) return false;
            int sqrt = (int)Math.Sqrt(n);
            return sqrt * sqrt == n;
        }).ToArray();

    /// <summary>
    /// Filters the array to include only perfect squares.
    /// </summary>
    /// <param name="arr">The array to filter.</param>
    /// <returns>An array containing only perfect square numbers.</returns>
    public static int[] FilterPerfectSquares(this int[] arr)
        => arr.Where((n, i) => arr.IsPerfectSquare()[i]).ToArray();

    /// <summary>
    /// Checks if each number in the array is a Fibonacci number.
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>A boolean array indicating which elements are Fibonacci numbers.</returns>
    public static bool[] IsFibonacci(this int[] arr)
        => arr.Select(IsFibonacciNumber).ToArray();

    /// <summary>
    /// Filters the array to include only Fibonacci numbers.
    /// </summary>
    /// <param name="arr">The array to filter.</param>
    /// <returns>An array containing only Fibonacci numbers.</returns>
    public static int[] FilterFibonacci(this int[] arr)
        => arr.Where(IsFibonacciNumber).ToArray();

    /// <summary>
    /// Calculates the cumulative sum of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>An array containing cumulative sums.</returns>
    public static int[] CumulativeSum(this int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return Array.Empty<int>();

        var result = new int[arr.Length];
        result[0] = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            result[i] = result[i - 1] + arr[i];
        }

        return result;
    }

    /// <summary>
    /// Calculates the cumulative product of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>An array containing cumulative products.</returns>
    public static long[] CumulativeProduct(this int[] arr)
    {
        if (arr == null || arr.Length == 0)
            return Array.Empty<long>();

        var result = new long[arr.Length];
        result[0] = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            result[i] = result[i - 1] * arr[i];
        }

        return result;
    }

    /// <summary>
    /// Finds all pairs of indices whose elements sum to a target value.
    /// </summary>
    /// <param name="arr">The array to search.</param>
    /// <param name="target">The target sum.</param>
    /// <returns>An array of tuples containing indices of pairs that sum to the target.</returns>
    public static (int, int)[] FindPairsSumToTarget(this int[] arr, int target)
    {
        var pairs = new List<(int, int)>();
        var seen = new Dictionary<int, int>();

        for (int i = 0; i < arr.Length; i++)
        {
            int complement = target - arr[i];
            if (seen.ContainsKey(complement))
            {
                pairs.Add((seen[complement], i));
            }
            seen[arr[i]] = i;
        }

        return pairs.ToArray();
    }

    /// <summary>
    /// Converts integers to their binary string representations.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array of binary string representations.</returns>
    public static string[] ToBinaryStrings(this int[] arr)
        => arr.Select(n => Convert.ToString(n, 2)).ToArray();

    /// <summary>
    /// Converts integers to their hexadecimal string representations.
    /// </summary>
    /// <param name="arr">The array to convert.</param>
    /// <returns>An array of hexadecimal string representations.</returns>
    public static string[] ToHexStrings(this int[] arr)
        => arr.Select(n => n.ToString("X")).ToArray();

    // Helper methods
    private static long Factorial(int n)
    {
        if (n < 0) throw new ArgumentException("Factorial is not defined for negative numbers.");
        if (n == 0 || n == 1) return 1;
        
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        return result;
    }

    private static bool IsFibonacciNumber(int n)
    {
        if (n < 0) return false;
        if (n == 0 || n == 1) return true;

        int prev = 0, curr = 1;
        while (curr < n)
        {
            int next = prev + curr;
            prev = curr;
            curr = next;
        }

        return curr == n;
    }
}