using FluentAssertions;
using Xunit;

namespace ArrayExtensions.Tests;

public class DateTimeArrayExtensionsTests
{
    [Fact]
    public void EarliestDate_ShouldReturnEarliestDateTime()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 10), new DateTime(2022, 5, 5), new DateTime(2023, 1, 1) };

        // Act
        var result = dates.EarliestDate();

        // Assert
        result.Should().Be(new DateTime(2022, 5, 5));
    }

    [Fact]
    public void LatestDate_ShouldReturnLatestDateTime()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 10), new DateTime(2022, 5, 5), new DateTime(2023, 1, 1) };

        // Act
        var result = dates.LatestDate();

        // Assert
        result.Should().Be(new DateTime(2023, 1, 10));
    }

    [Fact]
    public void DateRange_ShouldReturnDifferenceBetweenLatestAndEarliestDate()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 10), new DateTime(2022, 5, 5), new DateTime(2023, 1, 1) };

        // Act
        var result = dates.DateRange();

        // Assert
        result.Should().Be(TimeSpan.FromDays(250));
    }

    [Fact]
    public void FilterByDateRange_ShouldReturnDatesWithinSpecifiedRange()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 10), new DateTime(2022, 5, 5), new DateTime(2023, 1, 1) };
        DateTime start = new DateTime(2023, 1, 1);
        DateTime end = new DateTime(2023, 1, 10);

        // Act
        var result = dates.FilterByDateRange(start, end);

        // Assert
        result.Should().Equal(new DateTime(2023, 1, 10), new DateTime(2023, 1, 1));
    }

    [Fact]
    public void AllInFuture_WithAllFutureDates_ShouldReturnTrue()
    {
        // Arrange
        DateTime[] dates = { DateTime.Now.AddDays(1), DateTime.Now.AddDays(2), DateTime.Now.AddDays(3) };

        // Act
        var result = dates.AllInFuture();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void AllInPast_WithAllPastDates_ShouldReturnTrue()
    {
        // Arrange
        DateTime[] dates = { DateTime.Now.AddDays(-1), DateTime.Now.AddDays(-2), DateTime.Now.AddDays(-3) };

        // Act
        var result = dates.AllInPast();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void ClosestTo_ShouldReturnDateClosestToReferenceDate()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 10), new DateTime(2022, 5, 5), new DateTime(2023, 1, 1) };
        DateTime referenceDate = new DateTime(2023, 1, 5);

        // Act
        var result = dates.ClosestTo(referenceDate);

        // Assert
        result.Should().Be(new DateTime(2023, 1, 1));
    }

    // ... Continue with other methods ...

    [Fact]
    public void FilterHolidays_ShouldReturnDatesThatAreHolidays()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 1), new DateTime(2023, 12, 25), new DateTime(2023, 7, 4) };
        DateTime[] holidays = { new DateTime(2023, 1, 1), new DateTime(2023, 12, 25) };

        // Act
        var result = dates.FilterHolidays(holidays);

        // Assert
        result.Should().Equal(new DateTime(2023, 1, 1), new DateTime(2023, 12, 25));
    }

    [Fact]
    public void BusinessDaysCount_ShouldReturnNumberOfBusinessDays()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 1), new DateTime(2023, 1, 2), new DateTime(2023, 1, 3), new DateTime(2023, 1, 4), new DateTime(2023, 1, 5), new DateTime(2023, 1, 6), new DateTime(2023, 1, 7) };

        // Act
        var result = dates.BusinessDaysCount();

        // Assert
        result.Should().Be(5); // Excluding the weekend (Saturday and Sunday)
    }

    [Fact]
    public void FilterNthDayOfWeek_ShouldReturnDatesThatAreSecondMondays()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 2), new DateTime(2023, 1, 9), new DateTime(2023, 1, 16) };

        // Act
        var result = dates.FilterNthDayOfWeek(DayOfWeek.Monday, 2);

        // Assert
        result.Should().Equal(new DateTime(2023, 1, 9));
    }

    [Fact]
    public void FilterLastDayOfWeek_ShouldReturnDatesThatAreLastMondays()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 23), new DateTime(2023, 1, 30), new DateTime(2023, 2, 6) };

        // Act
        var result = dates.FilterLastDayOfWeek(DayOfWeek.Monday);

        // Assert
        result.Should().Equal(new DateTime(2023, 1, 30));
    }

    [Fact]
    public void EquidistantDates_ShouldReturnDatesEquidistantFromReferenceDate()
    {
        // Arrange
        DateTime[] dates = { new DateTime(2023, 1, 1), new DateTime(2023, 1, 10), new DateTime(2023, 1, 20) };
        DateTime referenceDate = new DateTime(2023, 1, 11);

        // Act
        var result = dates.EquidistantDates(referenceDate);

        // Assert
        result.Should().Equal(new DateTime(2023, 1, 10), new DateTime(2023, 1, 20));
    }
}