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

    /// <summary>
    /// Sorts the dates in chronological order (earliest to latest).
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>A new array with dates sorted chronologically.</returns>
    public static DateTime[] SortChronologically(this DateTime[] arr)
        => arr.OrderBy(date => date).ToArray();

    /// <summary>
    /// Sorts the dates in reverse chronological order (latest to earliest).
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>A new array with dates sorted in reverse chronological order.</returns>
    public static DateTime[] SortReverseChronologically(this DateTime[] arr)
        => arr.OrderByDescending(date => date).ToArray();

    /// <summary>
    /// Groups dates by quarter of the year.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>A dictionary grouping dates by quarter (1-4).</returns>
    public static Dictionary<int, DateTime[]> GroupByQuarter(this DateTime[] arr)
    {
        if (arr == null)
            throw new ArgumentNullException(nameof(arr));

        return arr.GroupBy(date => (date.Month - 1) / 3 + 1)
                  .ToDictionary(g => g.Key, g => g.ToArray());
    }

    /// <summary>
    /// Filters dates that fall within a specific quarter of any year.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <param name="quarter">The quarter to filter by (1-4).</param>
    /// <returns>An array of dates falling within the specified quarter.</returns>
    public static DateTime[] FilterByQuarter(this DateTime[] arr, int quarter)
    {
        if (quarter < 1 || quarter > 4)
            throw new ArgumentOutOfRangeException(nameof(quarter), "Quarter must be between 1 and 4.");

        return arr.Where(date => (date.Month - 1) / 3 + 1 == quarter).ToArray();
    }

    /// <summary>
    /// Filters dates that fall within a specific decade.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <param name="decade">The starting year of the decade (e.g., 2020 for 2020-2029).</param>
    /// <returns>An array of dates falling within the specified decade.</returns>
    public static DateTime[] FilterByDecade(this DateTime[] arr, int decade)
        => arr.Where(date => date.Year >= decade && date.Year < decade + 10).ToArray();

    /// <summary>
    /// Calculates the average time span between consecutive dates (when sorted).
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>The average time span between consecutive dates.</returns>
    public static TimeSpan AverageTimeBetweenDates(this DateTime[] arr)
    {
        if (arr == null || arr.Length < 2)
            throw new ArgumentException("Array must contain at least 2 dates.", nameof(arr));

        var sorted = arr.OrderBy(date => date).ToArray();
        var totalTicks = 0L;

        for (int i = 1; i < sorted.Length; i++)
        {
            totalTicks += (sorted[i] - sorted[i - 1]).Ticks;
        }

        return new TimeSpan(totalTicks / (sorted.Length - 1));
    }

    /// <summary>
    /// Finds dates that are birthdays (same month and day) for a given reference date.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <param name="birthday">The reference birthday date.</param>
    /// <returns>An array of dates that fall on the same month and day as the birthday.</returns>
    public static DateTime[] FindBirthdays(this DateTime[] arr, DateTime birthday)
        => arr.Where(date => date.Month == birthday.Month && date.Day == birthday.Day).ToArray();

    /// <summary>
    /// Filters dates that fall within a specific season in the Northern Hemisphere.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <param name="season">The season to filter by.</param>
    /// <returns>An array of dates falling within the specified season.</returns>
    public static DateTime[] FilterBySeason(this DateTime[] arr, Season season)
    {
        return season switch
        {
            Season.Spring => arr.Where(d => (d.Month == 3 && d.Day >= 20) || d.Month == 4 || d.Month == 5 || (d.Month == 6 && d.Day < 21)).ToArray(),
            Season.Summer => arr.Where(d => (d.Month == 6 && d.Day >= 21) || d.Month == 7 || d.Month == 8 || (d.Month == 9 && d.Day < 22)).ToArray(),
            Season.Autumn => arr.Where(d => (d.Month == 9 && d.Day >= 22) || d.Month == 10 || d.Month == 11 || (d.Month == 12 && d.Day < 21)).ToArray(),
            Season.Winter => arr.Where(d => (d.Month == 12 && d.Day >= 21) || d.Month == 1 || d.Month == 2 || (d.Month == 3 && d.Day < 20)).ToArray(),
            _ => throw new ArgumentOutOfRangeException(nameof(season), "Invalid season.")
        };
    }

    /// <summary>
    /// Calculates ages (in years) for all dates relative to a reference date.
    /// </summary>
    /// <param name="arr">The array of DateTime objects (birth dates).</param>
    /// <param name="referenceDate">The reference date to calculate age from.</param>
    /// <returns>An array of ages in years.</returns>
    public static int[] CalculateAges(this DateTime[] arr, DateTime referenceDate)
        => arr.Select(birthDate => CalculateAge(birthDate, referenceDate)).ToArray();

    /// <summary>
    /// Finds the dates with the maximum gap between consecutive dates.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>A tuple containing the two dates with the maximum gap and the gap duration.</returns>
    public static (DateTime earlier, DateTime later, TimeSpan gap) FindMaximumGap(this DateTime[] arr)
    {
        if (arr == null || arr.Length < 2)
            throw new ArgumentException("Array must contain at least 2 dates.", nameof(arr));

        var sorted = arr.OrderBy(date => date).ToArray();
        TimeSpan maxGap = TimeSpan.Zero;
        DateTime earlierDate = default;
        DateTime laterDate = default;

        for (int i = 1; i < sorted.Length; i++)
        {
            var gap = sorted[i] - sorted[i - 1];
            if (gap > maxGap)
            {
                maxGap = gap;
                earlierDate = sorted[i - 1];
                laterDate = sorted[i];
            }
        }

        return (earlierDate, laterDate, maxGap);
    }

    /// <summary>
    /// Converts all dates to UTC timezone.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>An array of dates converted to UTC.</returns>
    public static DateTime[] ToUtc(this DateTime[] arr)
        => arr.Select(date => date.Kind == DateTimeKind.Local ? date.ToUniversalTime() : 
                             date.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(date, DateTimeKind.Utc) : date).ToArray();

    /// <summary>
    /// Converts all dates to local timezone.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>An array of dates converted to local time.</returns>
    public static DateTime[] ToLocalTime(this DateTime[] arr)
        => arr.Select(date => date.Kind == DateTimeKind.Utc ? date.ToLocalTime() : 
                             date.Kind == DateTimeKind.Unspecified ? DateTime.SpecifyKind(date, DateTimeKind.Local) : date).ToArray();

    /// <summary>
    /// Rounds all dates to the nearest specified time unit.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <param name="timeUnit">The time unit to round to.</param>
    /// <returns>An array of rounded dates.</returns>
    public static DateTime[] RoundTo(this DateTime[] arr, TimeUnit timeUnit)
        => arr.Select(date => RoundDateTime(date, timeUnit)).ToArray();

    /// <summary>
    /// Groups dates by time of day periods.
    /// </summary>
    /// <param name="arr">The array of DateTime objects.</param>
    /// <returns>A dictionary grouping dates by time periods.</returns>
    public static Dictionary<TimePeriod, DateTime[]> GroupByTimePeriod(this DateTime[] arr)
    {
        return arr.GroupBy(date => GetTimePeriod(date))
                  .ToDictionary(g => g.Key, g => g.ToArray());
    }

    // Helper methods and enums
    public enum Season { Spring, Summer, Autumn, Winter }
    public enum TimeUnit { Second, Minute, Hour, Day }
    public enum TimePeriod { EarlyMorning, Morning, Afternoon, Evening, Night }

    private static int CalculateAge(DateTime birthDate, DateTime referenceDate)
    {
        int age = referenceDate.Year - birthDate.Year;
        if (referenceDate.Month < birthDate.Month || 
            (referenceDate.Month == birthDate.Month && referenceDate.Day < birthDate.Day))
        {
            age--;
        }
        return age;
    }

    private static DateTime RoundDateTime(DateTime date, TimeUnit timeUnit)
    {
        return timeUnit switch
        {
            TimeUnit.Second => new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second),
            TimeUnit.Minute => new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0),
            TimeUnit.Hour => new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0),
            TimeUnit.Day => new DateTime(date.Year, date.Month, date.Day),
            _ => date
        };
    }

    private static TimePeriod GetTimePeriod(DateTime date)
    {
        int hour = date.Hour;
        return hour switch
        {
            >= 5 and < 8 => TimePeriod.EarlyMorning,
            >= 8 and < 12 => TimePeriod.Morning,
            >= 12 and < 17 => TimePeriod.Afternoon,
            >= 17 and < 21 => TimePeriod.Evening,
            _ => TimePeriod.Night
        };
    }
}