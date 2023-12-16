using FluentAssertions;
using Xunit;

namespace ArrayExtensions.Tests;

public class MultiDimensionalArrayTests
{
    [Fact]
    public void ForEach_ShouldExecuteActionForEachElement()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        int sum = 0;
        array.ForEach(x => sum += x);
        sum.Should().Be(10);
    }

    [Fact]
    public void Transpose_ShouldTransposeArray()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var transposed = array.Transpose();
        var expected = new[,] { { 1, 3 }, { 2, 4 } };
        transposed.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Flatten_ShouldConvertToSingleDimensionalArray()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var flattened = array.Flatten();
        var expected = new[] { 1, 2, 3, 4 };
        flattened.Should().Equal(expected);
    }

    [Fact]
    public void DeepCopy_ShouldCreateSeparateArray()
    {
        var array = new[,] { { "a", "b" }, { "c", "d" } };
        var copy = array.DeepCopy();
        copy.Should().NotBeSameAs(array);
        copy.Should().BeEquivalentTo(array);
    }

    [Fact]
    public void AllEqual_WithIdenticalElements_ShouldReturnTrue()
    {
        var array = new[,] { { 1, 1 }, { 1, 1 } };
        var result = array.AllEqual();
        result.Should().BeTrue();
    }

    [Fact]
    public void CountOf_SpecificValue_ShouldReturnCount()
    {
        var array = new[,] { { 1, 2 }, { 1, 2 } };
        var count = array.CountOf(1);
        count.Should().Be(2);
    }

    [Fact]
    public void Fill_ShouldFillArrayWithSpecifiedValue()
    {
        var array = new int[2, 2];
        array.Fill(5);
        array.Cast<int>().Should().AllBeEquivalentTo(5);
    }

    [Fact]
    public void FindFirst_MatchingPredicate_ShouldReturnCoordinates()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var result = array.FindFirst(x => x == 3);
        result.Should().Be((1, 0));
    }

    [Fact]
    public void FindFirst_NonMatchingPredicate_ShouldReturnNull()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var result = array.FindFirst(x => x == 5);
        result.Should().BeNull();
    }

    [Fact]
    public void GetRow_ShouldReturnSpecificRow()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var row = array.GetRow(1);
        row.Should().Equal(3, 4);
    }

    [Fact]
    public void GetColumn_ShouldReturnSpecificColumn()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var column = array.GetColumn(1);
        column.Should().Equal(2, 4);
    }

    [Fact]
    public void Rotate90DegreesClockwise_ShouldRotateArray()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var rotated = array.Rotate90DegreesClockwise();
        var expected = new[,] { { 3, 1 }, { 4, 2 } };
        rotated.Should().BeEquivalentTo(expected);
    }

    [Fact]
    public void Contains_ExistingElement_ShouldReturnTrue()
    {
        var array = new[,] { { 1, 2 }, { 3, 4 } };
        var result = array.Contains(3);
        result.Should().BeTrue();
    }
}