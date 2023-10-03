# ArrayExtensions

A collection of useful extension methods for arrays in C#. 

## Features

- **ForEach**: Execute an action for each item in the array.
- **MostCommon**: Find the most common item in the array.
- **Add Items**: Easily append a single item or multiple items to an array.
- **All Equal**: Check if all items in the array are equivalent.
- **DeepCopy**: A new array that is a deep copy of the source array.
- **Remove/Insert**: Remove an item at a specific index or insert one.
- **Shuffle**: Randomly rearrange the elements of an array.
- **Array Checks**: Check if the array is empty, or contains any null values.
- **Chunking**: Break the array into smaller arrays of a specified size.
- **LastN**: Retrieve the last 'n' items from the array.
- **Slice**: Returns a portion of the array.
- **ReplaceAll**: Replace all occurrences of a value in the array.
- **Rotate**: Rotate the array left or right by a specified number of positions.
- **Flatten**: Convert a 2D array into a single-dimensional array.
- **FindIndices**: Find all indices of items that match a given predicate.
- .. and more

## Installation

Install via NuGet:

```bash
Install-Package ArrayExtensions
```

## Usage

Some examples:

```csharp
using ArrayExtensions;

string[] fruits = { "apple", "banana", "cherry" };

// Add a single item and multiple items
fruits = fruits.Add("date");
fruits = fruits.AddRange("fig", "grape");

// Insert and remove
fruits = fruits.InsertAt(2, "blueberry");
fruits = fruits.RemoveAt(3);  // Removes "cherry"

// Shuffle, check equality and null checks
var shuffledFruits = fruits.Shuffle();
bool allSame = fruits.AllEqual();  // Returns false
bool hasNull = fruits.AnyNull();   // Returns false

// Chunking and replacing
var chunkedFruits = fruits.Chunk(3);
fruits = fruits.ReplaceAll("apple", "apricot");

// Safe retrieval and finding indices
var fruit = fruits.SafeGet(10, "unknown");  // Returns "unknown" as the 10th index doesn't exist
var indices = fruits.FindIndices(f => f.StartsWith("a"));

// ForEach example to print fruits
fruits.ForEach(f => Console.WriteLine(f));

// Extra examples:

string[] fruits = { "apple", "banana", "cherry", "date", "fig", "grape", "blueberry" };

// Check if all items in the array are equal
bool allEqual = fruits.AllEqual();  // Returns false

// Check if any fruit name is empty or null
bool hasEmptyOrNull = fruits.AnyNullOrEmpty();  // Returns false

// Trim all items
string[] trimmedFruits = { " apple ", "banana ", " cherry", " date " };
trimmedFruits = trimmedFruits.TrimAll();

// Find indices of all fruits that start with "b"
int[] bFruitIndices = fruits.FindIndices(f => f.StartsWith("b"));  // Returns indices for "banana" and "blueberry"

// Get the first three fruits without creating a new array 
string[] firstThree = fruits.Slice(0, 3);  // Returns { "apple", "banana", "cherry" }

// Retrieve items in a safe manner
var tenthFruit = fruits.SafeGet(9, "unknown");  // Index 9 doesn't exist, so it returns "unknown"

// Execute an action for each fruit, for example, print them
fruits.ForEach(Console.WriteLine);

// Count occurrences of a particular fruit
int appleCount = fruits.CountOf("apple");  // Returns 1

// Replace all occurrences of a fruit with another
fruits = fruits.ReplaceAll("banana", "mango");  // Replaces "banana" with "mango"

// Get distinct items in the array
var distinctFruits = fruits.DistinctValues();

// Get the most common fruit (or any most common string in an array)
var mostCommonFruit = fruits.MostCommon();
```

## License

[MIT](https://opensource.org/licenses/MIT)
