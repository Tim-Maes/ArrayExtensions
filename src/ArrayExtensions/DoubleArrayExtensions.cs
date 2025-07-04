namespace ArrayExtensions;

public static class DoubleArrayExtensions
{
    /// <summary>
    /// Calculates the median value of the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The median value.</returns>
    public static double Median(this double[] arr)
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
    /// Calculates the variance of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The variance of the array elements.</returns>
    public static double Variance(this double[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        double mean = arr.Average();
        return arr.Sum(num => Math.Pow(num - mean, 2)) / arr.Length;
    }

    /// <summary>
    /// Calculates the standard deviation of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The standard deviation of the array elements.</returns>
    public static double StandardDeviation(this double[] arr)
        => Math.Sqrt(arr.Variance());

    /// <summary>
    /// Finds the range (difference between maximum and minimum values) of the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>The range of the array.</returns>
    public static double Range(this double[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.Max() - arr.Min();
    }

    /// <summary>
    /// Normalizes the array values to a range between 0 and 1.
    /// </summary>
    /// <param name="arr">The array to normalize.</param>
    /// <returns>A new array with normalized values.</returns>
    public static double[] Normalize(this double[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        double min = arr.Min();
        double max = arr.Max();
        double range = max - min;

        if (range == 0) return arr.Select(_ => 0.0).ToArray();

        return arr.Select(x => (x - min) / range).ToArray();
    }

    /// <summary>
    /// Standardizes the array values (z-score normalization).
    /// </summary>
    /// <param name="arr">The array to standardize.</param>
    /// <returns>A new array with standardized values.</returns>
    public static double[] Standardize(this double[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        double mean = arr.Average();
        double stdDev = arr.StandardDeviation();

        if (stdDev == 0) return arr.Select(_ => 0.0).ToArray();

        return arr.Select(x => (x - mean) / stdDev).ToArray();
    }

    /// <summary>
    /// Calculates the correlation coefficient between two arrays.
    /// </summary>
    /// <param name="arr1">The first array.</param>
    /// <param name="arr2">The second array.</param>
    /// <returns>The correlation coefficient.</returns>
    public static double CorrelationWith(this double[] arr1, double[] arr2)
    {
        if (arr1 == null || arr2 == null)
            throw new ArgumentNullException("Arrays cannot be null.");

        if (arr1.Length != arr2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        if (arr1.Length == 0)
            throw new ArgumentException("Arrays cannot be empty.");

        double mean1 = arr1.Average();
        double mean2 = arr2.Average();
        
        double numerator = arr1.Zip(arr2, (x, y) => (x - mean1) * (y - mean2)).Sum();
        double denominator = Math.Sqrt(arr1.Sum(x => Math.Pow(x - mean1, 2)) * arr2.Sum(y => Math.Pow(y - mean2, 2)));

        return denominator == 0 ? 0 : numerator / denominator;
    }

    /// <summary>
    /// Finds values that are outliers using the IQR method.
    /// </summary>
    /// <param name="arr">The array to analyze.</param>
    /// <param name="factor">The IQR factor for outlier detection (default: 1.5).</param>
    /// <returns>An array of outlier values.</returns>
    public static double[] FindOutliers(this double[] arr, double factor = 1.5)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        var sorted = arr.OrderBy(x => x).ToArray();
        double q1 = arr.Percentile(25);
        double q3 = arr.Percentile(75);
        double iqr = q3 - q1;
        double lowerBound = q1 - factor * iqr;
        double upperBound = q3 + factor * iqr;

        return arr.Where(x => x < lowerBound || x > upperBound).ToArray();
    }

    /// <summary>
    /// Calculates the percentile value in the array.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <param name="percentile">The percentile to find (0-100).</param>
    /// <returns>The value at the specified percentile.</returns>
    public static double Percentile(this double[] arr, double percentile)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        if (percentile < 0 || percentile > 100)
            throw new ArgumentOutOfRangeException(nameof(percentile), "Percentile must be between 0 and 100.");

        var sorted = arr.OrderBy(x => x).ToArray();
        double index = percentile / 100.0 * (sorted.Length - 1);
        int lowerIndex = (int)Math.Floor(index);
        int upperIndex = (int)Math.Ceiling(index);

        if (lowerIndex == upperIndex)
            return sorted[lowerIndex];

        double weight = index - lowerIndex;
        return sorted[lowerIndex] * (1 - weight) + sorted[upperIndex] * weight;
    }

    /// <summary>
    /// Calculates the skewness of the distribution.
    /// </summary>
    /// <param name="arr">The array to analyze.</param>
    /// <returns>The skewness value.</returns>
    public static double Skewness(this double[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        double mean = arr.Average();
        double stdDev = arr.StandardDeviation();
        int n = arr.Length;

        if (stdDev == 0) return 0;

        double skew = arr.Sum(x => Math.Pow((x - mean) / stdDev, 3)) / n;
        return skew;
    }

    /// <summary>
    /// Calculates the kurtosis of the distribution.
    /// </summary>
    /// <param name="arr">The array to analyze.</param>
    /// <returns>The kurtosis value.</returns>
    public static double Kurtosis(this double[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        double mean = arr.Average();
        double stdDev = arr.StandardDeviation();
        int n = arr.Length;

        if (stdDev == 0) return 0;

        double kurt = arr.Sum(x => Math.Pow((x - mean) / stdDev, 4)) / n;
        return kurt - 3; // Excess kurtosis
    }

    /// <summary>
    /// Applies a smoothing filter (moving average) to the array.
    /// </summary>
    /// <param name="arr">The array to smooth.</param>
    /// <param name="windowSize">The size of the moving window.</param>
    /// <returns>A smoothed array.</returns>
    public static double[] SmoothMovingAverage(this double[] arr, int windowSize)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        if (windowSize <= 0 || windowSize > arr.Length)
            throw new ArgumentOutOfRangeException(nameof(windowSize));

        var result = new double[arr.Length];
        
        for (int i = 0; i < arr.Length; i++)
        {
            int start = Math.Max(0, i - windowSize / 2);
            int end = Math.Min(arr.Length - 1, i + windowSize / 2);
            double sum = 0;
            int count = 0;

            for (int j = start; j <= end; j++)
            {
                sum += arr[j];
                count++;
            }

            result[i] = sum / count;
        }

        return result;
    }

    /// <summary>
    /// Rounds all values in the array to the specified number of decimal places.
    /// </summary>
    /// <param name="arr">The array to round.</param>
    /// <param name="decimals">The number of decimal places.</param>
    /// <returns>A new array with rounded values.</returns>
    public static double[] RoundAll(this double[] arr, int decimals)
        => arr.Select(x => Math.Round(x, decimals)).ToArray();

    /// <summary>
    /// Checks if all values in the array are finite (not NaN or infinity).
    /// </summary>
    /// <param name="arr">The array to check.</param>
    /// <returns>True if all values are finite.</returns>
    public static bool AllFinite(this double[] arr)
        => arr.All(x => !double.IsNaN(x) && !double.IsInfinity(x));

    /// <summary>
    /// Removes NaN and infinity values from the array.
    /// </summary>
    /// <param name="arr">The array to clean.</param>
    /// <returns>A new array without NaN or infinity values.</returns>
    public static double[] RemoveNaNAndInfinity(this double[] arr)
        => arr.Where(x => !double.IsNaN(x) && !double.IsInfinity(x)).ToArray();

    /// <summary>
    /// Calculates the cumulative sum of the array elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>An array containing cumulative sums.</returns>
    public static double[] CumulativeSum(this double[] arr)
    {
        if (arr == null || arr.Length == 0)
            return Array.Empty<double>();

        var result = new double[arr.Length];
        result[0] = arr[0];

        for (int i = 1; i < arr.Length; i++)
        {
            result[i] = result[i - 1] + arr[i];
        }

        return result;
    }

    /// <summary>
    /// Calculates the differences between consecutive elements.
    /// </summary>
    /// <param name="arr">The array to process.</param>
    /// <returns>An array of differences.</returns>
    public static double[] Diff(this double[] arr)
    {
        if (arr == null || arr.Length < 2)
            return Array.Empty<double>();

        return arr.Skip(1).Zip(arr, (current, previous) => current - previous).ToArray();
    }

    /// <summary>
    /// Finds local maxima in the array.
    /// </summary>
    /// <param name="arr">The array to analyze.</param>
    /// <returns>An array of indices where local maxima occur.</returns>
    public static int[] FindLocalMaxima(this double[] arr)
    {
        if (arr == null || arr.Length < 3)
            return Array.Empty<int>();

        var maxima = new List<int>();

        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] > arr[i - 1] && arr[i] > arr[i + 1])
            {
                maxima.Add(i);
            }
        }

        return maxima.ToArray();
    }

    /// <summary>
    /// Finds local minima in the array.
    /// </summary>
    /// <param name="arr">The array to analyze.</param>
    /// <returns>An array of indices where local minima occur.</returns>
    public static int[] FindLocalMinima(this double[] arr)
    {
        if (arr == null || arr.Length < 3)
            return Array.Empty<int>();

        var minima = new List<int>();

        for (int i = 1; i < arr.Length - 1; i++)
        {
            if (arr[i] < arr[i - 1] && arr[i] < arr[i + 1])
            {
                minima.Add(i);
            }
        }

        return minima.ToArray();
    }
}