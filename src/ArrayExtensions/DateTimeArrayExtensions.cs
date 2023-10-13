namespace ArrayExtensions;

public static class DateTimeArrayExtensions
{
    /// <summary>
    /// Finds and returns the earliest date present in the array.
    /// Throws an exception if the array is null or empty.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>The earliest DateTime object in the array.</returns>
    public static DateTime EarliestDate(this DateTime[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.Min();
    }

    /// <summary>
    /// Finds and returns the latest date present in the array.
    /// Throws an exception if the array is null or empty.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>The latest DateTime object in the array.</returns>
    public static DateTime LatestDate(this DateTime[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.Max();
    }

    /// <summary>
    /// Gets the range between the earliest and latest date.
    /// </summary>
    public static TimeSpan DateRange(this DateTime[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.LatestDate() - arr.EarliestDate();
    }

    /// <summary>
    /// Filters dates that fall within a specified date range.
    /// </summary>
    public static DateTime[] FilterByDateRange(this DateTime[] arr, DateTime startDate, DateTime endDate)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.Where(date => date >= startDate && date <= endDate).ToArray();
    }

    /// <summary>
    /// Checks if all dates in the array are in the future.
    /// </summary>
    public static bool AllInFuture(this DateTime[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        DateTime now = DateTime.Now;
        return arr.All(date => date > now);
    }

    /// <summary>
    /// Checks if all dates in the array are in the past.
    /// </summary>
    public static bool AllInPast(this DateTime[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        DateTime now = DateTime.Now;
        return arr.All(date => date < now);
    }

    /// <summary>
    /// Gets the closest date to a specified reference date.
    /// </summary>
    public static DateTime ClosestTo(this DateTime[] arr, DateTime referenceDate)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.OrderBy(date => Math.Abs((date - referenceDate).Ticks)).First();
    }

    /// <summary>
    /// Groups dates by year.
    /// </summary>
    public static IGrouping<int, DateTime>[] GroupByYear(this DateTime[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.GroupBy(date => date.Year).ToArray();
    }

    /// <summary>
    /// Groups dates by month.
    /// </summary>
    public static IGrouping<int, DateTime>[] GroupByMonth(this DateTime[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.GroupBy(date => date.Month).ToArray();
    }

    /// <summary>
    /// Groups dates by day.
    /// </summary>
    public static IGrouping<int, DateTime>[] GroupByDay(this DateTime[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.GroupBy(date => date.Day).ToArray();
    }

    /// <summary>
    /// Filters dates that are weekdays.
    /// </summary>
    public static DateTime[] FilterWeekdays(this DateTime[] arr)
    {
        if (arr is null)
            throw new ArgumentNullException(nameof(arr));

        return arr.Where(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday).ToArray();
    }

    /// <summary>
    /// Filters and returns an array of DateTime objects that fall on weekends (Saturday or Sunday).
    /// Throws an ArgumentNullException if the array is null.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>An array of DateTime objects that are weekends.</returns>
    public static DateTime[] FilterWeekends(this DateTime[] arr)
    {
        if (arr is null)
            throw new ArgumentNullException(nameof(arr));

        return arr.Where(date => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday).ToArray();
    }

    /// <summary>
    /// Groups the array of DateTime objects by their DayOfWeek and returns an array of groupings.
    /// Each grouping contains DateTime objects that fall on the same DayOfWeek.
    /// Throws an ArgumentNullException if the array is null.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>An array of groupings, where each grouping contains DateTime objects of the same DayOfWeek.</returns>
    public static IGrouping<DayOfWeek, DateTime>[] GroupByDayOfWeek(this DateTime[] arr)
    {
        if (arr is null)
            throw new ArgumentNullException(nameof(arr));

        return arr.GroupBy(date => date.DayOfWeek).ToArray();
    }

    /// <summary>
    /// Filters and returns an array of DateTime objects that match the dates in a provided list of holidays.
    /// Throws an ArgumentNullException if either the array or the list of holidays is null.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <param name="holidays">The array of DateTime objects representing holidays.</param>
    /// <returns>An array of DateTime objects that are holidays.</returns>
    public static DateTime[] FilterHolidays(this DateTime[] arr, DateTime[] holidays)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        if (holidays == null)
            throw new ArgumentNullException(nameof(holidays));

        return arr.Intersect(holidays).ToArray();
    }

    /// <summary>
    /// Calculates and returns the number of business days between the earliest and latest date in the array.
    /// A business day is defined as any day that is not a Saturday or Sunday.
    /// Throws an exception if the array is null or empty.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>The number of business days between the earliest and latest date in the array.</returns>
    public static int BusinessDaysCount(this DateTime[] arr)
    {
        if (arr is null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        DateTime startDate = arr.EarliestDate();
        DateTime endDate = arr.LatestDate();

        int totalDays = (endDate - startDate).Days;
        int businessDays = 0;

        for (int i = 0; i <= totalDays; i++)
        {
            DateTime currentDay = startDate.AddDays(i);
            if (currentDay.DayOfWeek != DayOfWeek.Saturday && currentDay.DayOfWeek != DayOfWeek.Sunday)
            {
                businessDays++;
            }
        }

        return businessDays;
    }

    /// <summary>
    /// Filters the array to only include DateTime objects that represent the nth occurrence of a specified day of the week within their respective months.
    /// For example, this could return all DateTime objects that represent the second Tuesday of their respective months.
    /// Throws an exception if the array is null or if n is not between 1 and 5.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <param name="dayOfWeek">The specified DayOfWeek.</param>
    /// <param name="n">The nth occurrence.</param>
    /// <returns>An array of DateTime objects that meet the criteria.</returns>
    public static DateTime[] FilterNthDayOfWeek(this DateTime[] arr, DayOfWeek dayOfWeek, int n)
    {
        if (arr is null)
            throw new ArgumentNullException(nameof(arr));

        if (n < 1 || n > 5)
            throw new ArgumentOutOfRangeException(nameof(n), "Value should be between 1 and 5.");

        return arr.Where(date => date.DayOfWeek == dayOfWeek && (date.Day - 1) / 7 == n - 1).ToArray();
    }

    /// <summary>
    /// Returns the dates in the array that fall on the last specific DayOfWeek of their month.
    /// For example, all the last Fridays of their months.
    /// </summary>
    public static DateTime[] FilterLastDayOfWeek(this DateTime[] arr, DayOfWeek dayOfWeek)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.Where(date => date.DayOfWeek == dayOfWeek && date.AddDays(7).Month != date.Month).ToArray();
    }

    /// <summary>
    /// Finds and returns an array of DateTime objects that are equidistant from a given reference date.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <param name="referenceDate">The reference DateTime object.</param>
    /// <returns>An array of DateTime objects that are equidistant from the reference date.</returns>
    public static DateTime[] EquidistantDates(this DateTime[] arr, DateTime referenceDate)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        TimeSpan minDifference = arr.Min(date => TimeSpan.FromTicks(Math.Abs(date.Ticks - referenceDate.Ticks)));
        return arr.Where(date => TimeSpan.FromTicks(Math.Abs(date.Ticks - referenceDate.Ticks)) == minDifference).ToArray();
    }
}