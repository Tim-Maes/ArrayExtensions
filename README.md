# ArrayExtensions

A comprehensive collection of extension methods for arrays in C#.

## Installation :wrench: 

Install via NuGet:

```bash
Install-Package ArrayExtensions
```

Or just copy whatever you need from this repository :) 

## Usage

`var result = array.MethodName();`

## Features :star:

### Generic Array methods

| Name                                              | Description                                                               |
|---------------------------------------------------|---------------------------------------------------------------------------|
| `Add<T>()`, `AddRange<T>()`                       | Appends single or multiple items to the end of an array.                  |
| `AllEqual<T>()`                                   | Checks if all elements in an array are identical.                         |
| `AnyNull<T>()`                                    | Determines if any element in an array of reference types is null.         |
| `BinarySearch<T>()`                               | Performs a binary search on a sorted array.                               |
| `Chunk<T>()`                                      | Divides an array into smaller arrays of a specified maximum size.         |
| `Contains<T>()`                                   | Checks if the array contains a specified element.                         |
| `CountOf<T>()`                                    | Counts occurrences of a specific item in the array.                       |
| `DeepCopy<T>()`                                   | Creates a deep copy of an array, where elements implement ICloneable.     |
| `DistinctBy<T, TKey>()`                           | Returns distinct elements based on a specified selector function.         |
| `DistinctValues<T>()`                             | Returns distinct values from the array.                                   |
| `FindFirstAndLast<T>()`                           | Finds the first and last elements that match a given predicate.           |
| `FindIndices<T>()`                                | Finds indices of all elements that match a given predicate.               |
| `FindOrDefault<T>()`                              | Finds an element matching a predicate, or returns a default value.        |
| `Flatten<T>()`                                    | Flattens a multi-dimensional array into a single-dimensional array.       |
| `ForEach<T>()`                                    | Executes an action on each element of an array.                           |
| `ForEachIndexed<T>()`                             | Executes an action on each element of an array with its index.            |
| `GroupBySequential<T, TKey>()`                    | Groups adjacent elements sharing a key or property.                       |
| `Head<T>()`, `Tail<T>()`, `LastN<T>()`, `FirstN<T>()` | Provide various ways to slice and access elements. |
| `Interleave<T>()`                                 | Interleaves elements of two arrays into a single array.                   |
| `InsertAt<T>()`                                   | Inserts an element at a specified index.                                  |
| `IsNullOrEmpty<T>()`, `IsEmpty<T>()`              | Check if an array is empty or null/empty, respectively.                   |
| `IsSorted<T>()`                                   | Checks if the array is sorted according to a specified comparer.          |
| `IsUnique<T>()`                                   | Determines whether all elements in the array are unique.                  |
| `JoinToString<T>()`                               | Concatenates string representations of elements with a delimiter.         |
| `Map<T, TResult>()`                               | Transforms each element of the array using a selector function.           |
| `MaxBy<T, TKey>()`, `MinBy<T, TKey>()`            | Finds the maximum/minimum element based on a specified selector function. |
| `MostCommon<T>()`                                 | Finds the most common element in the array.                               |
| `Permute<T>()`                                    | Generates all possible permutations of the array.                         |
| `RandomSample<T>()`                               | Selects a random sample of elements.                                      |
| `RemoveAt<T>()`                                   | Removes the element at a specified index.                                 |
| `RemoveDuplicates<T>()`                           | Removes duplicate elements from the array.                                |
| `RemoveNulls<T>()`                                | Removes all null items from an array of reference types.                  |
| `ReplaceAll<T>()`                                 | Replaces all occurrences of a specific value with another in the array.   |
| `Resize<T>()`                                     | Resizes an array to a specified new size.                                 |
| `Reverse<T>()`                                    | Reverses the elements of the array.                                       |
| `RotateLeft<T>()`, `RotateRight<T>()`             | Rotates the array left or right by a specified number of positions.       |
| `SafeGet<T>()`                                    | Retrieves an element at a specified index or a default value if out of range. |
| `SafeSet<T>()`                                    | Sets a value at a specified index, resizing the array if necessary.       |
| `Segment<T>()`                                    | Splits an array into segments based on a predicate.                       |
| `SequentialPairs<T>()`                            | Generates a sequence of tuples from sequential pairs of elements.         |
| `Shuffle<T>()`                                    | Randomly shuffles the elements of an array.                               |
| `Slice<T>()`                                      | Returns a portion of the array, similar to substring for strings.         |
| `Subset<T>()`                                     | Returns all possible subsets of the array.                                |
| `SumBy<T>()`                                      | Calculates the sum of array elements based on a selector function.        |
| `TakeWhile<T>()`, `SkipWhile<T>()`                | Takes or skips elements of the array while a condition is true.           |
| `ToHashSet<T>()`                                  | Converts the array to a HashSet, removing duplicates.                     |
| `ZipWith<T, TOther, TResult>()`                   | Combines two arrays into one using a specified selector function.         |

### DateTime Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AllInFuture`| Checks if all dates in the array are in the future.|
|`AllInPast`| Checks if all dates in the array are in the past.|
|`BusinessDaysCount`| Calculates the number of business days between the earliest and latest date in the array.|
|`ClosestTo`| Gets the closest date to a specified reference date.|
|`DateRange`| Gets the range between the earliest and latest date.|
|`EarliestDate`| Finds and returns the earliest date present in the array.|
|`EquidistantDates`| Finds dates that are equidistant from a given reference date.|
|`FilterByDateRange`| Filters dates that fall within a specified date range.|
|`FilterHolidays`| Filters dates that match a provided list of holidays.|
|`FilterLastDayOfWeek`| Filters dates that fall on the last specific day of the week of their month.|
|`FilterNthDayOfWeek`| Filters dates that are the nth occurrence of a specified day of the week in their month.|
|`FilterWeekdays`| Filters dates that are weekdays (Monday to Friday).|
|`FilterWeekends`| Filters dates that are weekends (Saturday or Sunday).|
|`GroupByDay`| Groups dates by day.|
|`GroupByDayOfWeek`| Groups dates by their day of the week.|
|`GroupByMonth`| Groups dates by month.|
|`GroupByYear`| Groups dates by year.|
|`LatestDate`| Finds and returns the latest date present in the array.|

### String Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AllOfLength`| Checks if all strings in the array are of a specified length.|
|`AggregateStrings`| Aggregates the array into a single string using a specified function.|
|`AnyNullOrEmpty`| Checks if any string in the array is null or empty.|
|`AnyNullOrWhiteSpace`| Checks if any string in the array is null or whitespace.|
|`CapitalizeFirstLetter`| Capitalizes the first letter of each string in the array.|
|`ConcatenateWithSeparator`| Concatenates all strings in the array with a given separator.|
|`ContainsSubstring`| Checks if any of the strings in the array contains a specified substring.|
|`CountOccurrencesOfSubstring`| Counts occurrences of a specific substring in all strings of the array.|
|`CountStringsMatchingPattern`| Counts the number of strings that match a regular expression pattern.|
|`EndsWithSubstring`| Checks if any of the strings in the array ends with a specified substring.|
|`FilterByPattern`| Filters strings that match a given regular expression pattern.|
|`HasDuplicates`| Checks if the array contains any duplicate strings.|
|`JoinNonEmpty`| Concatenates non-empty strings in the array with a given separator.|
|`LongestString`| Retrieves the longest string from the array.|
|`NormalizeWhitespace` | Replaces multiple consecutive whitespace characters in each string with a single space. |
|`RemoveNullOrEmpty`| Removes all null or empty strings from the array.|
|`RemoveNullOrWhiteSpace`| Removes all null, empty, or whitespace strings from the array.|
|`ReplaceInAll`| Replaces a specified substring in all strings of the array.|
|`ReverseEach`| Reverses each string in the array.|
|`SortAlphabetically`| Sorts the array of strings in alphabetical order.|
|`StartsWithSubstring`| Checks if any of the strings in the array starts with a specified substring.|
|`ShortestString`| Retrieves the shortest string from the array.|
|`ToLowerCase`| Converts all strings in the array to lowercase.|
|`ToUpperCase`| Converts all strings in the array to uppercase.|
|`TrimAll`| Trims whitespace from all strings in the array.|
|`UniqueStrings`| Returns an array of unique strings, removing duplicates..|

### Integer Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AverageIgnoringZero`| Calculates the average of the elements in the array, ignoring zero values.|
|`FindPrimeNumbers`| Filters the array to include only prime numbers.|
|`IsMonotonicallyIncreasing`| Checks if the array's elements are in a strictly increasing order. |
|`IsMonotonicallyDecreasing`| Checks if the array's elements are in a strictly decreasing order.|
|`MultiplyAll`| Multiplies all elements in the array and returns the product.|
|`Mode`| Finds the most frequently occurring number(s) in the array.|
|`Percentile`| Finds the percentile value in the array.|
|`Randomize`| Randomizes the order of elements in the array.|
|`StandardDeviation`|Calculates the standard deviation of the array elements.|
|`SumAbsoluteDifferences`| Calculates the sum of the absolute differences between all pairs of elements.|
|`SumEvenNumbers`| Sums all the even numbers in the array.|
|`SumOddNumbers`| Sums all the odd numbers in the array.|
|`ToFrequencyMap`| Creates a frequency map (count of each element).|
|`Variance`| Calculates the variance of the array elements.|

## Multi Dimensional Array methods

### Generic Multi Dimensional Array methods

| Name                                | Description                                                          |
|-------------------------------------|----------------------------------------------------------------------|
| `AllEqual<T>()`                     | Checks if all elements in a multi-dimensional array are identical.   |
| `Contains<T>()`                     | Checks if the multi-dimensional array contains a specific element.   |
| `CountOf<T>()`                      | Counts occurrences of a specific item in the multi-dimensional array.|
| `DeepCopy<T>()`                     | Creates a deep copy of the multi-dimensional array.                  |
| `Fill<T>()`                         | Fills the multi-dimensional array with a specific value.             |
| `FindFirst<T>()`                    | Finds the first occurrence of an element that matches a condition.   |
| `Flatten<T>()`                      | Flattens a multi-dimensional array into a single-dimensional array.  |
| `ForEach<T>()`                      | Iterates over each element in a multi-dimensional array and executes the provided action. |
| `GetColumn<T>()`                    | Retrieves a specific column from a multi-dimensional array.          |
| `GetRow<T>()`                       | Retrieves a specific row from a multi-dimensional array.             |
| `Rotate90DegreesClockwise<T>()`     | Rotates the array 90 degrees clockwise.                              |
| `Transpose<T>()`                    | Transposes a two-dimensional array.                                  |

## License

[MIT](https://opensource.org/licenses/MIT)
