# ArrayExtensions

A collection of useful extension methods for arrays in C#. Enhance your arrays with additional utility functions!

## Installation

Install via NuGet:

\```bash
Install-Package ArrayExtensions
\```

## Usage

Here's how you can use the extensions:

\```csharp
using ArrayExtensions;

string[] data = { "apple", "banana", "cherry" };
data = data.Add("date");
bool allEqual = data.AllEqual();
\```

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

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Ensure to update tests as appropriate.

## License

[MIT](https://opensource.org/licenses/MIT)
