using FluentAssertions;
using Xunit;

namespace ArrayExtensions.Tests;

public class ArrayExtensionsTests
{
    [Fact]
    public void Add_ShouldAppendItemToEndOfArray()
    {
        // Arrange
        int[] initialArray = { 1, 2, 3 };

        // Act
        var result = initialArray.Add(4);

        // Assert
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public void Add_WithNullArray_ShouldThrowArgumentNullException()
    {
        // Arrange
        int[] nullArray = null;

        // Act
        Action act = () => nullArray.Add(4);

        // Assert
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AllEqual_WithAllEqualItems_ShouldReturnTrue()
    {
        // Arrange
        int[] equalArray = { 2, 2, 2 };

        // Act
        var result = equalArray.AllEqual();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void AllEqual_WithDifferentItems_ShouldReturnFalse()
    {
        // Arrange
        int[] differentArray = { 1, 2, 3 };

        // Act
        var result = differentArray.AllEqual();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void AnyNull_WithNonNullItems_ShouldReturnFalse()
    {
        // Arrange
        string[] nonNullArray = { "apple", "banana", "cherry" };

        // Act
        var result = nonNullArray.AnyNull();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void AnyNull_WithNullItem_ShouldReturnTrue()
    {
        // Arrange
        string[] arrayWithNull = { "apple", null, "cherry" };

        // Act
        var result = arrayWithNull.AnyNull();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void RemoveAt_WithValidIndex_ShouldRemoveItemAtGivenIndex()
    {
        // Arrange
        int[] initialArray = { 1, 2, 3 };

        // Act
        var result = initialArray.RemoveAt(1);

        // Assert
        result.Should().Equal(1, 3);
    }

    [Fact]
    public void RemoveAt_WithInvalidIndex_ShouldThrowIndexOutOfRangeException()
    {
        // Arrange
        int[] initialArray = { 1, 2, 3 };

        // Act
        Action act = () => initialArray.RemoveAt(5);

        // Assert
        act.Should().Throw<IndexOutOfRangeException>();
    }

    [Fact]
    public void Shuffle_ShouldRearrangeArray()
    {
        // Arrange
        int[] initialArray = { 1, 2, 3, 4, 5 };

        // Act
        var result = initialArray.Shuffle();

        // Assert
        result.Should().NotEqual(initialArray);
        result.Should().HaveCount(5);
    }

    [Fact]
    public void IsEmpty_WithEmptyArray_ShouldReturnTrue()
    {
        // Arrange
        int[] emptyArray = { };

        // Act
        var result = emptyArray.IsEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsEmpty_WithNonEmptyArray_ShouldReturnFalse()
    {
        // Arrange
        int[] nonEmptyArray = { 1, 2, 3 };

        // Act
        var result = nonEmptyArray.IsEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void IsNullOrEmpty_WithNullArray_ShouldReturnTrue()
    {
        // Arrange
        int[] nullArray = null;

        // Act
        var result = nullArray.IsNullOrEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_WithEmptyArray_ShouldReturnTrue()
    {
        // Arrange
        int[] emptyArray = { };

        // Act
        var result = emptyArray.IsNullOrEmpty();

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_WithNonEmptyArray_ShouldReturnFalse()
    {
        // Arrange
        int[] nonEmptyArray = { 1, 2, 3 };

        // Act
        var result = nonEmptyArray.IsNullOrEmpty();

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void SafeGet_WithinArrayBounds_ShouldReturnValue()
    {
        // Arrange
        int[] array = { 1, 2, 3 };

        // Act
        var result = array.SafeGet(1);

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public void SafeGet_OutsideArrayBounds_ShouldReturnDefaultValue()
    {
        // Arrange
        int[] array = { 1, 2, 3 };

        // Act
        var result = array.SafeGet(5, -1);

        // Assert
        result.Should().Be(-1);
    }

    [Fact]
    public void FindIndices_WithMatchingPredicate_ShouldReturnIndices()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.FindIndices(x => x % 2 == 0);

        // Assert
        result.Should().Equal(1, 3);
    }

    [Fact]
    public void ForEach_ShouldExecuteActionForEachItem()
    {
        // Arrange
        int[] array = { 1, 2, 3 };
        int sum = 0;

        // Act
        array.ForEach(x => sum += x);

        // Assert
        sum.Should().Be(6);
    }

    [Fact]
    public void Chunk_ShouldBreakArrayIntoSmallerArrays()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.Chunk(2);

        // Assert
        result.Should().HaveCount(3);
        result[0].Should().Equal(1, 2);
        result[1].Should().Equal(3, 4);
        result[2].Should().Equal(5);
    }

    [Fact]
    public void DeepCopy_WithCloneableItems_ShouldReturnDeepCopiedArray()
    {
        // Arrange
        string[] array = { "apple", "banana", "cherry" };

        // Act
        var result = array.DeepCopy();

        // Assert
        result.Should().Equal(array);
        result.Should().NotBeSameAs(array);
    }

    [Fact]
    public void Resize_WithLargerSize_ShouldReturnResizedArray()
    {
        // Arrange
        int[] array = { 1, 2, 3 };

        // Act
        var result = array.Resize(5);

        // Assert
        result.Should().HaveCount(5);
        result.Take(3).Should().Equal(1, 2, 3);
    }

    [Fact]
    public void Resize_WithSmallerSize_ShouldReturnTrimmedArray()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.Resize(3);

        // Assert
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public void Tail_ShouldReturnAllElementsExceptFirst()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.Tail();

        // Assert
        result.Should().Equal(2, 3, 4, 5);
    }

    [Fact]
    public void Head_ShouldReturnFirstElement()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.Head();

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void LastN_ShouldReturnLastNElements()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.LastN(3);

        // Assert
        result.Should().Equal(3, 4, 5);
    }

    [Fact]
    public void FirstN_ShouldReturnFirstNElements()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.FirstN(3);

        // Assert
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public void ReplaceAll_ShouldReplaceAllOccurrences()
    {
        // Arrange
        int[] array = { 1, 2, 3, 2, 5 };

        // Act
        var result = array.ReplaceAll(2, 9);

        // Assert
        result.Should().Equal(1, 9, 3, 9, 5);
    }

    [Fact]
    public void SafeSet_WithinBounds_ShouldSetValue()
    {
        // Arrange
        int[] array = { 1, 2, 3 };

        // Act
        var result = array.SafeSet(1, 9);

        // Assert
        result.Should().Equal(1, 9, 3);
    }

    [Fact]
    public void SafeSet_OutsideBounds_ShouldResizeAndSetValue()
    {
        // Arrange
        int[] array = { 1, 2, 3 };

        // Act
        var result = array.SafeSet(5, 9);

        // Assert
        result.Should().Equal(1, 2, 3, 0, 0, 9);
    }

    [Fact]
    public void MaxBy_ShouldReturnElementWithMaxValueBasedOnSelector()
    {
        // Arrange
        string[] array = { "apple", "banana", "cherry" };

        // Act
        var result = array.MaxBy(s => s.Length);

        // Assert
        result.Should().Be("banana");
    }

    [Fact]
    public void MinBy_ShouldReturnElementWithMinValueBasedOnSelector()
    {
        // Arrange
        string[] array = { "apple", "banana", "cherry" };

        // Act
        var result = array.MinBy(s => s.Length);

        // Assert
        result.Should().Be("apple");
    }

    [Fact]
    public void DistinctBy_ShouldReturnDistinctElementsBySelector()
    {
        // Arrange
        var array = new[]
        {
                new { Name = "John", Age = 25 },
                new { Name = "Jane", Age = 25 },
                new { Name = "Doe", Age = 30 }
            };

        // Act
        var result = array.DistinctBy(p => p.Age);

        // Assert
        result.Should().HaveCount(2);
    }

    [Fact]
    public void RotateLeft_ShouldRotateArrayToLeftByGivenPositions()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.RotateLeft(2);

        // Assert
        result.Should().Equal(3, 4, 5, 1, 2);
    }

    [Fact]
    public void RotateRight_ShouldRotateArrayToRightByGivenPositions()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.RotateRight(2);

        // Assert
        result.Should().Equal(4, 5, 1, 2, 3);
    }

    [Fact]
    public void Flatten_ShouldConvert2DArrayTo1DArray()
    {
        // Arrange
        int[][] array = { new[] { 1, 2 }, new[] { 3, 4 } };

        // Act
        var result = array.Flatten();

        // Assert
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public void CountOf_ShouldReturnCountOfGivenItem()
    {
        // Arrange
        int[] array = { 1, 2, 3, 2, 5 };

        // Act
        var count = array.CountOf(2);

        // Assert
        count.Should().Be(2);
    }

    [Fact]
    public void DistinctValues_ShouldReturnDistinctValues()
    {
        // Arrange
        int[] array = { 1, 2, 3, 2, 5 };

        // Act
        var result = array.DistinctValues();

        // Assert
        result.Should().Equal(1, 2, 3, 5);
    }

    [Fact]
    public void Slice_WithValidStartAndEnd_ShouldReturnSubArray()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act
        var result = array.Slice(1, 4);

        // Assert
        result.Should().Equal(2, 3, 4);
    }

    [Fact]
    public void Slice_WithInvalidStart_ShouldThrowArgumentOutOfRangeException()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act & Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => array.Slice(-1, 4));
    }

    [Fact]
    public void Slice_WithInvalidEnd_ShouldThrowArgumentException()
    {
        // Arrange
        int[] array = { 1, 2, 3, 4, 5 };

        // Act & Assert
        Assert.Throws<ArgumentException>(() => array.Slice(4, 2));
    }
}
