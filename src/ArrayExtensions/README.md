# ArrayExtensions

A collection of useful extension methods for arrays in C#. 

## Installation

Install via NuGet:

```bash
Install-Package ArrayExtensions
```

Or just copy whatever you need from this repository :) 

## Features

### Generic Array methods

`Add<T>()` and AddRange<T>(): Appends single or multiple items to the end of an array.
`AllEqual<T>()`: Checks if all elements in an array are identical.
`AnyNull<T>()`: Determines if any element in an array of reference types is null.
`BinarySearch<T>()`: Performs a binary search on a sorted array.
`CountOf<T>()`: Counts occurrences of a specific item in the array.
`Chunk<T>()`: Divides an array into smaller arrays of a specified maximum size.
`DeepCopy<T>()`: Creates a deep copy of an array, where elements implement ICloneable.
`DistinctBy<T, TKey>()`: Returns distinct elements based on a specified selector function.
`DistinctValues<T>()`: Returns distinct values from the array.
`FindIndices<T>()`: Finds indices of all elements that match a given predicate.
`Flatten<T>()`: Flattens a multi-dimensional array into a single-dimensional array.
`ForEach<T>()`: Executes an action on each element of an array.
`IsEmpty<T>()` and `IsNullOrEmpty<T>()`: Check if an array is empty or null/empty, respectively.
`Interleave<T>()`: Interleaves elements of two arrays into a single array.
`InsertAt<T>()`: Inserts an element at a specified index.
`Shuffle<T>()`: Randomly shuffles the elements of an array.
`MostCommon<T>()`: Finds the most common element in the array.
`MaxBy<T, TKey>() and MinBy<T, TKey>()`: Finds the maximum/minimum element based on a specified selector function.
`RandomSample<T>()`: Selects a random sample of elements.
`RemoveNulls<T>()`: Removes all null items from an array of reference types.
`RemoveAt<T>()`: Removes the element at a specified index.
`ReplaceAll<T>()`: Replaces all occurrences of a specific value with another in the array.
`Resize<T>()`: Resizes an array to a specified new size.
`RotateLeft<T>()` and `RotateRight<T>()`: Rotates the array left or right by a specified number of positions.
`SafeGet<T>()`: Retrieves an element at a specified index or a default value if out of range.
`SafeSet<T>()`: Sets a value at a specified index, resizing the array if necessary.
`Segment<T>()`: Splits an array into segments based on a predicate.
`SequentialPairs<T>()`: Generates a sequence of tuples from sequential pairs of elements.
`Slice<T>()`: Returns a portion of the array, similar to substring for strings.
`Tail<T>()`, `Head<T>()`, `LastN<T>()`, `FirstN<T>()`: Provide various ways to slice and access elements.

### DateTime Array methods

`AllInFuture`: Checks if all dates in the array are in the future.
`AllInPast`: Checks if all dates in the array are in the past.
`BusinessDaysCount`: Calculates the number of business days between the earliest and latest date in the array.
`ClosestTo`: Gets the closest date to a specified reference date.
`DateRange`: Gets the range between the earliest and latest date.
`EarliestDate`: Finds and returns the earliest date present in the array.
`EquidistantDates`: Finds dates that are equidistant from a given reference date.
`FilterByDateRange`: Filters dates that fall within a specified date range.
`FilterHolidays`: Filters dates that match a provided list of holidays.
`FilterLastDayOfWeek`: Filters dates that fall on the last specific day of the week of their month.
`FilterNthDayOfWeek`: Filters dates that are the nth occurrence of a specified day of the week in their month.
`FilterWeekdays`: Filters dates that are weekdays (Monday to Friday).
`FilterWeekends`: Filters dates that are weekends (Saturday or Sunday).
`GroupByDay`: Groups dates by day.
`GroupByDayOfWeek`: Groups dates by their day of the week.
`GroupByMonth`: Groups dates by month.
`GroupByYear`: Groups dates by year.
`LatestDate`: Finds and returns the latest date present in the array.

### String Array methods

`AllOfLength`: Checks if all strings in the array are of a specified length.
`AnyNullOrEmpty`: Checks if any string in the array is null or empty.
`AnyNullOrWhiteSpace`: Checks if any string in the array is null or whitespace.
`ConcatenateWithSeparator`: Concatenates all strings in the array with a given separator.
`CountOccurrencesOfSubstring`: Counts occurrences of a specific substring in all strings of the array.
`FilterByPattern`: Filters strings that match a given regular expression pattern.
`HasDuplicates`: Checks if the array contains any duplicate strings.
`LongestString`: Retrieves the longest string from the array.
`RemoveNullOrEmpty`: Removes all null or empty strings from the array.
`RemoveNullOrWhiteSpace`: Removes all null, empty, or whitespace strings from the array.
`ReplaceInAll`: Replaces a specified substring in all strings of the array.
`ReverseEach`: Reverses each string in the array.
`ShortestString`: Retrieves the shortest string from the array.
`ToLowerCase`: Converts all strings in the array to lowercase.
`ToUpperCase`: Converts all strings in the array to uppercase.
`TrimAll`: Trims whitespace from all strings in the array.

## Usage

Some examples:

```csharp
using ArrayExtensions;

// Basic array of fruits
string[] fruits = { "apple", "banana", "cherry" };

// Add items
fruits = fruits.Add("date").AddRange("fig", "grape");

// Manipulate array
fruits = fruits.InsertAt(2, "blueberry").RemoveAt(3).Shuffle();

// Analyze array
bool allSame = fruits.AllEqual();
bool hasEmptyOrNull = fruits.AnyNullOrEmpty();

// String utilities
string[] trimmedFruits = { " apple ", "banana ", " cherry", " date " };
trimmedFruits = trimmedFruits.TrimAll();
fruitsWithValues = fruitsWithValues.RemoveNullOrEmpty();  // Removes empty and null values, resulting in { "apple", "cherry" }
string[] fruitsWithSpaces = { "apple", "   ", "cherry", null };
fruitsWithSpaces = fruitsWithSpaces.RemoveNullOrWhiteSpace();  // Removes whitespace-only and null values, resulting in { "apple", "cherry" }
bool hasDuplicateFruits = fruits.HasDuplicates();  // Checks if there are any duplicate fruit names
string fruitSentence = fruits.ConcatenateWithSeparator(", ");  // Joins all fruit names with a comma separator
string[] fruitsWithPattern = fruits.FilterByPattern("^a.*");  // Filters fruits that start with the letter 'a'
bool allOfLengthFive = fruits.AllOfLength(5);  // Checks if all fruit names have a length of 5
string longestFruit = fruits.LongestString();  // Gets the longest fruit name
string shortestFruit = fruits.ShortestString();  // Gets the shortest fruit name

// DateTime utilities
DateTime[] holidays = { new DateTime(2023, 12, 25), new DateTime(2023, 1, 1) };
var holidayDates = dates.FilterHolidays(holidays);
var weekdays = dates.FilterWeekdays();

// Safe operations
var fruit = fruits.SafeGet(10, "unknown");
var indices = fruits.FindIndices(f => f.StartsWith("a"));

// Functional programming
fruits.ForEach(Console.WriteLine);

// More advanced operations
var chunkedFruits = fruits.Chunk(2);  // Splits the array into chunks of 2
var rotatedFruits = fruits.RotateLeft(2);  // Rotates the array to the left by 2 positions
var lastThreeFruits = fruits.LastN(3);  // Retrieves the last 3 fruits
var distinctFruits = fruits.DistinctValues();  // Gets distinct fruit values
var mostCommonFruit = fruits.MostCommon();  // Finds the most common fruit

// DateTime specific operations
DateTime[] dateArray = { new DateTime(2023, 1, 1), new DateTime(2023, 2, 14), new DateTime(2023, 12, 25) };
var range = dateArray.DateRange();  // Gets the range between the earliest and latest date
var closestToNewYear = dateArray.ClosestTo(new DateTime(2023, 1, 15));  // Finds the date closest to Jan 15, 2023
```

## License

[MIT](https://opensource.org/licenses/MIT)
