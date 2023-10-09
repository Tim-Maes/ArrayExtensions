namespace ArrayExtensions;

public static class DateTimeArrayExtensions
{
    /// <summary>
    /// Gets the earliest date from the array.
    /// </summary>
    public static DateTime EarliestDate(this DateTime[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.Min();
    }

    /// <summary>
    /// Gets the latest date from the array.
    /// </summary>
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
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.Where(date => date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday).ToArray();
    }

    /// <summary>
    /// Filters dates that are weekends.
    /// </summary>
    public static DateTime[] FilterWeekends(this DateTime[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.Where(date => date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday).ToArray();
    }

    /// <summary>
    /// Groups dates by their DayOfWeek.
    /// </summary>
    public static IGrouping<DayOfWeek, DateTime>[] GroupByDayOfWeek(this DateTime[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.GroupBy(date => date.DayOfWeek).ToArray();
    }

    /// <summary>
    /// Gets the dates that are holidays based on a provided list of holidays.
    /// </summary>
    public static DateTime[] FilterHolidays(this DateTime[] arr, DateTime[] holidays)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        if (holidays == null)
            throw new ArgumentNullException(nameof(holidays));

        return arr.Intersect(holidays).ToArray();
    }

    /// <summary>
    /// Gets the number of business days between the earliest and latest date in the array.
    /// </summary>
    public static int BusinessDaysCount(this DateTime[] arr)
    {
        if (arr == null || arr.Length == 0)
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
    /// Returns the dates in the array that are the nth occurrence of a specific DayOfWeek in their respective months.
    /// For example, all the second Tuesdays of their months.
    /// </summary>
    public static DateTime[] FilterNthDayOfWeek(this DateTime[] arr, DayOfWeek dayOfWeek, int n)
    {
        if (arr == null)
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
    /// Returns the dates in the array that are equidistant from a specified reference date.
    /// </summary>
    public static DateTime[] EquidistantDates(this DateTime[] arr, DateTime referenceDate)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        TimeSpan minDifference = arr.Min(date => TimeSpan.FromTicks(Math.Abs(date.Ticks - referenceDate.Ticks)));
        return arr.Where(date => TimeSpan.FromTicks(Math.Abs(date.Ticks - referenceDate.Ticks)) == minDifference).ToArray();
    }
}