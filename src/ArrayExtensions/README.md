# ArrayExtensions

A collection of useful extension methods for arrays in C#. 

## Features

- **Basic Operations**: Easily `Add`, `Insert`, `Remove`, and `Replace` items.
- **Array Manipulation**: `Shuffle`, `Rotate`, `Chunk`, `Flatten`, and `Resize` your arrays.
- **Array Analysis**: Check if arrays are `AllEqual`, `AnyNull`, `IsEmpty`, or even find the `MostCommon` element.
- **String Array Utilities**: Methods like `TrimAll`, `AnyNullOrEmpty`, `ConcatenateWithSeparator` and filters.
- **DateTime Array Utilities**: Filter by `Weekdays`, `Weekends`, `Holidays`, and more.
- **Safe Operations**: Safely `Get`, `Set`, and `FindIndices` without worrying about out-of-range errors.
- **Functional Programming**: Use `ForEach` to apply actions directly on array elements.
- ... and many more

## Installation

Install via NuGet:

```bash
Install-Package ArrayExtensions
```

Or just copy whatever you need from this repository :) 

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
