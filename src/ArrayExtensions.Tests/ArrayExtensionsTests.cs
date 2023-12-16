using FluentAssertions;
using Xunit;

namespace ArrayExtensions.Tests;

public class ArrayExtensionsTests
{
    [Fact]
    public void RemoveNulls_WithNulls_ShouldRemoveNullValues()
    {
        string[] array = { "apple", null, "banana", null, "cherry" };
        var result = array.RemoveNulls();
        result.Should().Equal("apple", "banana", "cherry");
    }

    [Fact]
    public void Add_ShouldAppendItemToEnd()
    {
        int[] array = { 1, 2, 3 };
        var result = array.Add(4);
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public void AllEqual_WithIdenticalElements_ShouldReturnTrue()
    {
        int[] array = { 1, 1, 1 };
        var result = array.AllEqual();
        result.Should().BeTrue();
    }

    [Fact]
    public void AnyNull_WithNoNulls_ShouldReturnFalse()
    {
        string[] array = { "apple", "banana", "cherry" };
        var result = array.AnyNull();
        result.Should().BeFalse();
    }

    [Fact]
    public void AddRange_ShouldAppendMultipleItems()
    {
        int[] array = { 1, 2, 3 };
        var result = array.AddRange(4, 5);
        result.Should().Equal(1, 2, 3, 4, 5);
    }

    [Fact]
    public void RemoveAt_ValidIndex_ShouldRemoveElement()
    {
        int[] array = { 1, 2, 3 };
        var result = array.RemoveAt(1);
        result.Should().Equal(1, 3);
    }

    [Fact]
    public void InsertAt_ValidIndex_ShouldInsertElement()
    {
        int[] array = { 1, 2, 4 };
        var result = array.InsertAt(2, 3);
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public void Shuffle_ShouldChangeOrder()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.Shuffle();
        result.Should().NotEqual(array);
    }

    [Fact]
    public void IsEmpty_WithEmptyArray_ShouldReturnTrue()
    {
        int[] array = { };
        var result = array.IsEmpty();
        result.Should().BeTrue();
    }

    [Fact]
    public void IsNullOrEmpty_WithNullArray_ShouldReturnTrue()
    {
        int[] array = null;
        var result = array.IsNullOrEmpty();
        result.Should().BeTrue();
    }

    [Fact]
    public void SafeGet_ValidIndex_ShouldReturnValue()
    {
        int[] array = { 1, 2, 3 };
        var result = array.SafeGet(1);
        result.Should().Be(2);
    }

    [Fact]
    public void FindIndices_MatchingPredicate_ShouldReturnIndices()
    {
        int[] array = { 1, 2, 3, 4 };
        var result = array.FindIndices(x => x % 2 == 0);
        result.Should().Equal(1, 3);
    }

    [Fact]
    public void ForEach_ShouldExecuteAction()
    {
        int[] array = { 1, 2, 3 };
        int sum = 0;
        array.ForEach(x => sum += x);
        sum.Should().Be(6);
    }

    [Fact]
    public void Chunk_ValidChunkSize_ShouldDivideArray()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.Chunk(2);
        result.Length.Should().Be(3);
        result[0].Should().Equal(1, 2);
    }

    [Fact]
    public void DeepCopy_ShouldCreateSeparateArray()
    {
        string[] array = { "apple", "banana", "cherry" };
        var result = array.DeepCopy();
        result.Should().Equal(array);
        result.Should().NotBeSameAs(array);
    }

    [Fact]
    public void Resize_LargerSize_ShouldResizeWithDefaultValues()
    {
        int[] array = { 1, 2, 3 };
        var result = array.Resize(5);
        result.Should().Equal(1, 2, 3, 0, 0);
    }

    [Fact]
    public void Tail_ShouldReturnArrayWithoutFirstElement()
    {
        int[] array = { 1, 2, 3 };
        var result = array.Tail();
        result.Should().Equal(2, 3);
    }

    [Fact]
    public void Head_ShouldReturnFirstElement()
    {
        int[] array = { 1, 2, 3 };
        var result = array.Head();
        result.Should().Be(1);
    }

    [Fact]
    public void LastN_ValidNumber_ShouldReturnLastNElements()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.LastN(3);
        result.Should().Equal(3, 4, 5);
    }

    [Fact]
    public void FirstN_ValidNumber_ShouldReturnFirstNElements()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.FirstN(3);
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public void ReplaceAll_SpecifiedValue_ShouldReplaceAllOccurrences()
    {
        int[] array = { 1, 2, 3, 2 };
        var result = array.ReplaceAll(2, 4);
        result.Should().Equal(1, 4, 3, 4);
    }

    [Fact]
    public void SafeSet_ValidIndex_ShouldSetValue()
    {
        int[] array = { 1, 2, 3 };
        var result = array.SafeSet(1, 4);
        result.Should().Equal(1, 4, 3);
    }

    [Fact]
    public void MaxBy_Selector_ShouldReturnMaxElement()
    {
        string[] array = { "a", "bb", "ccc" };
        var result = array.MaxBy(s => s.Length);
        result.Should().Be("ccc");
    }

    [Fact]
    public void MinBy_Selector_ShouldReturnMinElement()
    {
        string[] array = { "a", "bb", "ccc" };
        var result = array.MinBy(s => s.Length);
        result.Should().Be("a");
    }

    [Fact]
    public void DistinctBy_Selector_ShouldReturnDistinctElements()
    {
        var array = new[] { new { Name = "John", Age = 30 }, new { Name = "Jane", Age = 25 }, new { Name = "Joe", Age = 30 } };
        var result = array.DistinctBy(x => x.Age);
        result.Should().HaveCount(2);
    }

    [Fact]
    public void RotateLeft_NumberOfPositions_ShouldRotateArray()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.RotateLeft(2);
        result.Should().Equal(3, 4, 5, 1, 2);
    }

    [Fact]
    public void RotateRight_NumberOfPositions_ShouldRotateArray()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.RotateRight(2);
        result.Should().Equal(4, 5, 1, 2, 3);
    }

    [Fact]
    public void Flatten_ShouldConvertNestedArrayToSingleDimensional()
    {
        int[][] array = { new[] { 1, 2 }, new[] { 3, 4 } };
        var result = array.Flatten();
        result.Should().Equal(1, 2, 3, 4);
    }

    [Fact]
    public void CountOf_Item_ShouldReturnNumberOfOccurrences()
    {
        int[] array = { 1, 2, 2, 3 };
        var count = array.CountOf(2);
        count.Should().Be(2);
    }

    [Fact]
    public void DistinctValues_ShouldReturnDistinctElements()
    {
        int[] array = { 1, 2, 2, 3 };
        var result = array.DistinctValues();
        result.Should().Equal(1, 2, 3);
    }

    [Fact]
    public void Slice_ValidRange_ShouldReturnSubArray()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.Slice(1, 4);
        result.Should().Equal(2, 3, 4);
    }

    [Fact]
    public void Interleave_ShouldCombineTwoArrays()
    {
        int[] array1 = { 1, 3, 5 };
        int[] array2 = { 2, 4, 6 };
        var result = array1.Interleave(array2);
        result.Should().Equal(1, 2, 3, 4, 5, 6);
    }

    [Fact]
    public void Segment_WhenPredicateIsMet_ShouldSplitArray()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.Segment(x => x % 3 == 0);
        result.Should().HaveCount(2);
        result[0].Should().Equal(1, 2);
        result[1].Should().Equal(3, 4, 5);
    }

    [Fact]
    public void BinarySearch_ExistingItem_ShouldReturnIndex()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.BinarySearch(3, Comparer<int>.Default);
        result.Should().Be(2);
    }

    [Fact]
    public void BinarySearch_NonExistingItem_ShouldReturnMinusOne()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.BinarySearch(6, Comparer<int>.Default);
        result.Should().Be(-1);
    }

    [Fact]
    public void RandomSample_ShouldReturnSubsetOfArray()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.RandomSample(3);
        result.Should().HaveCount(3);
    }

    [Fact]
    public void SequentialPairs_ShouldGeneratePairsOfElements()
    {
        int[] array = { 1, 2, 3, 4 };
        var result = array.SequentialPairs().ToList();
        result.Should().Equal(Tuple.Create(1, 2), Tuple.Create(2, 3), Tuple.Create(3, 4));
    }

    [Fact]
    public void FindFirstAndLast_MatchingPredicate_ShouldReturnFirstAndLastElements()
    {
        int[] array = { 1, 2, 3, 4, 5 };
        var result = array.FindFirstAndLast(x => x > 1 && x < 5);
        result.Should().Be((2, 4));
    }

    [Fact]
    public void Reverse_ShouldReverseArray()
    {
        int[] array = { 1, 2, 3 };
        var result = array.Reverse();
        result.Should().Equal(3, 2, 1);
    }

    [Fact]
    public void Fill_ShouldFillArrayWithSpecifiedValue()
    {
        int[] array = new int[5];
        array.Fill(1);
        array.Should().Equal(1, 1, 1, 1, 1);
    }

    [Fact]
    public void IsSorted_SortedArray_ShouldReturnTrue()
    {
        int[] array = { 1, 2, 3 };
        var result = array.IsSorted();
        result.Should().BeTrue();
    }

    [Fact]
    public void IsUnique_UniqueElements_ShouldReturnTrue()
    {
        int[] array = { 1, 2, 3 };
        var result = array.IsUnique();
        result.Should().BeTrue();
    }

    [Fact]
    public void Permute_ShouldGenerateAllPermutations()
    {
        int[] array = { 1, 2 };
        var result = array.Permute().ToList();
        result.Should().Contain(new[] { 1, 2 });
        result.Should().Contain(new[] { 2, 1 });
    }

    [Fact]
    public void Subset_ShouldGenerateAllSubsets()
    {
        int[] array = { 1, 2 };
        var result = array.Subset().ToList();
        result.Should().Contain(new int[] { });
        result.Should().Contain(new[] { 1 });
        result.Should().Contain(new[] { 2 });
        result.Should().Contain(new[] { 1, 2 });
    }

    [Fact]
    public void Contains_ExistingItem_ShouldReturnTrue()
    {
        int[] array = { 1, 2, 3 };
        var result = array.Contains(2);
        result.Should().BeTrue();
    }

    [Fact]
    public void JoinToString_ShouldJoinElementsIntoString()
    {
        int[] array = { 1, 2, 3 };
        var result = array.JoinToString(",");
        result.Should().Be("1,2,3");
    }

    [Fact]
    public void FindOrDefault_MatchingElement_ShouldReturnElement()
    {
        int[] array = { 1, 2, 3 };
        var result = array.FindOrDefault(x => x > 2, -1);
        result.Should().Be(3);
    }

    [Fact]
    public void TakeWhile_ConditionMet_ShouldReturnSubset()
    {
        int[] array = { 1, 2, 3, 4 };
        var result = array.TakeWhile(x => x < 3);
        result.Should().Equal(1, 2);
    }

    [Fact]
    public void SkipWhile_ConditionMet_ShouldSkipElements()
    {
        int[] array = { 1, 2, 3, 4 };
        var result = array.SkipWhile(x => x < 3);
        result.Should().Equal(3, 4);
    }

    [Fact]
    public void GroupBySequential_ShouldGroupElementsByKey()
    {
        int[] array = { 1, 1, 2, 2, 3 };
        var result = array.GroupBySequential(x => x).ToList();
        result.Should().HaveCount(3);
        result[0].Key.Should().Be(1);
        result[1].Key.Should().Be(2);
        result[2].Key.Should().Be(3);
    }
}
