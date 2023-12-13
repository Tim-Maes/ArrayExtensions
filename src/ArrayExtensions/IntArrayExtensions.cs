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
}