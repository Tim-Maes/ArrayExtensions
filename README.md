# ArrayExtensions

A collection of useful extension methods for arrays in C#. 

## Features

- **Add:** Append a single item to the end of an array.
- **AddRange:** Append multiple items at the end of an array.
- **AllEqual:** Check if all items in the array are equal.
- **AnyNull:** Check if there is a null value present in the array.
- **RemoveAt:** Remove an item at a specified index.
- **InsertAt:** Insert an item at a specified index.
- **Shuffle:** Shuffle the array elements randomly.
- **IsEmpty:** Check if the array is empty.
- **IsNullOrEmpty:** Check if the array is null or empty.
- **SafeGet:** Get the element at the given index if it exists, otherwise return a default value.
- **FindIndices:** Find all indices of items that match a given predicate.
- **ForEach:** Execute an action for each element in the array.
- ...

## Installation

Install via NuGet:

```bash
Install-Package ArrayExtensions
```

## Usage

To leverage the power of `ArrayExtensions`, simply add the namespace and apply the desired extensions to your arrays. Here's a comprehensive example of the extensions in action:

```csharp
using ArrayExtensions;

// Sample data
string[] fruits = { "apple", "banana", "", "cherry", null, "apple", "date" };

// 1. Adding an item
fruits = fruits.Add("elderberry");
Console.WriteLine(string.Join(", ", fruits));  // Output: apple, banana, , cherry, , apple, date, elderberry

// 2. Checking for any null or empty strings
bool hasNullOrEmpty = fruits.AnyNullOrEmpty();  // true

// 3. Trimming all elements (removes any spaces if present)
var trimmedFruits = fruits.TrimAll();
Console.WriteLine(string.Join(", ", trimmedFruits));  // Output remains same as no fruits had extra spaces

// 4. Checking if all items are the same
bool areAllEqual = fruits.AllEqual();  // false

// 5. Checking for the presence of any null values
bool hasNulls = fruits.AnyNull();  // true

// 6. Remove an item at a specified index (3rd index in this case)
fruits = fruits.RemoveAt(3);
Console.WriteLine(string.Join(", ", fruits));  // Output: apple, banana, , , apple, date, elderberry

// 7. Insert an item at a specified index (3rd index in this case)
fruits = fruits.InsertAt(3, "grape");
Console.WriteLine(string.Join(", ", fruits));  // Output: apple, banana, , grape, , apple, date, elderberry

// 8. Shuffle the array (result varies due to randomness)
fruits = fruits.Shuffle();
Console.WriteLine(string.Join(", ", fruits));  // Varying output

// 9. Check if the array is empty
bool isEmpty = fruits.IsEmpty();  // false

// 10. Safely get an element by index (if exists)
string fifthFruit = fruits.SafeGet(5);  // Value depends on the shuffle operation

// 11. Find indices of items that match a predicate (e.g., items that are 'apple')
var appleIndices = fruits.FindIndices(f => f == "apple");
Console.WriteLine(string.Join(", ", appleIndices));  // Varying indices based on shuffle

// 12. Execute an action for each element in the array
fruits.ForEach(f => Console.WriteLine(f.ToUpper()));
```

## License

[MIT](https://opensource.org/licenses/MIT)
