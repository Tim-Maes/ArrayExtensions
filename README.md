# ArrayExtensions

A comprehensive collection of extension methods for arrays in C#.

## Index

- [Array Extension Methods](#features-star)
- [Generic Array Methods](#generic-array-methods) (44 methods)
- [DateTime Array Methods](#datetime-array-methods) (31 methods)
- [String Array Methods](#string-array-methods) (43 methods
- [Integer Array Methods](#integer-array-methods) (33 methods)
- [Double Array Methods](#double-array-methods) (20 methods)
- [Boolean Array Methods](#boolean-array-methods) (24 methods)
- [Character Array Methods](#character-array-methods) (29 methods)
- [Byte Array Methods](#byte-array-methods) (26 methods)
- [GUID Array Methods](#guid-array-methods) (22 methods)
- [Multi-Dimensional Array Methods](#multi-dimensional-array-methods) (12 methods)

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
|`AverageTimeBetweenDates`| Calculates the average time span between consecutive dates (when sorted).|
|`BusinessDaysCount`| Calculates the number of business days between the earliest and latest date in the array.|
|`CalculateAges`| Calculates ages (in years) for all dates relative to a reference date.|
|`ClosestTo`| Gets the closest date to a specified reference date.|
|`DateRange`| Gets the range between the earliest and latest date.|
|`EarliestDate`| Finds and returns the earliest date present in the array.|
|`EquidistantDates`| Finds dates that are equidistant from a given reference date.|
|`FilterByDateRange`| Filters dates that fall within a specified date range.|
|`FilterByDecade`| Filters dates that fall within a specific decade.|
|`FilterByQuarter`| Filters dates that fall within a specific quarter of any year.|
|`FilterBySeason`| Filters dates that fall within a specific season in the Northern Hemisphere.|
|`FilterHolidays`| Filters dates that match a provided list of holidays.|
|`FilterLastDayOfWeek`| Filters dates that fall on the last specific day of the week of their month.|
|`FilterNthDayOfWeek`| Filters dates that are the nth occurrence of a specified day of the week in their month.|
|`FilterWeekdays`| Filters dates that are weekdays (Monday to Friday).|
|`FilterWeekends`| Filters dates that are weekends (Saturday or Sunday).|
|`FindBirthdays`| Finds dates that are birthdays (same month and day) for a given reference date.|
|`FindMaximumGap`| Finds the dates with the maximum gap between consecutive dates.|
|`GroupByDay`| Groups dates by day.|
|`GroupByDayOfWeek`| Groups dates by their day of the week.|
|`GroupByMonth`| Groups dates by month.|
|`GroupByQuarter`| Groups dates by quarter of the year.|
|`GroupByTimePeriod`| Groups dates by time of day periods.|
|`GroupByYear`| Groups dates by year.|
|`LatestDate`| Finds and returns the latest date present in the array.|
|`RoundTo`| Rounds all dates to the nearest specified time unit.|
|`SortChronologically`| Sorts the dates in chronological order (earliest to latest).|
|`SortReverseChronologically`| Sorts the dates in reverse chronological order (latest to earliest).|
|`ToLocalTime`| Converts all dates to local timezone.|
|`ToUtc`| Converts all dates to UTC timezone.|

### String Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AggregateStrings`| Aggregates the array into a single string using a specified function.|
|`AllNumeric`| Checks if all strings are numeric.|
|`AllOfLength`| Checks if all strings in the array are of a specified length.|
|`AllValidEmails`| Checks if all strings are valid email addresses.|
|`AnyNullOrEmpty`| Checks if any string in the array is null or empty.|
|`AnyNullOrWhiteSpace`| Checks if any string in the array is null or whitespace.|
|`CapitalizeFirstLetter`| Capitalizes the first letter of each string in the array.|
|`ConcatenateWithSeparator`| Concatenates all strings in the array with a given separator.|
|`ContainsSubstring`| Checks if any of the strings in the array contains a specified substring.|
|`CountOccurrencesOfSubstring`| Counts occurrences of a specific substring in all strings of the array.|
|`CountStringsMatchingPattern`| Counts the number of strings that match a regular expression pattern.|
|`EndsWithSubstring`| Checks if any of the strings in the array ends with a specified substring.|
|`ExtractEmailAddresses`| Extracts all email addresses from the strings in the array.|
|`ExtractPhoneNumbers`| Extracts all phone numbers from the strings in the array.|
|`ExtractUrls`| Extracts all URLs from the strings in the array.|
|`FilterByLength`| Filters strings by minimum and maximum length.|
|`FilterByPattern`| Filters strings that match a given regular expression pattern.|
|`GetCharacterFrequency`| Gets character frequency across all strings in the array.|
|`GetWordCounts`| Gets the word count for each string in the array.|
|`HasDuplicates`| Checks if the array contains any duplicate strings.|
|`JoinNonEmpty`| Concatenates non-empty strings in the array with a given separator.|
|`LongestString`| Retrieves the longest string from the array.|
|`MostCommonWords`| Finds the most common words across all strings in the array.|
|`NormalizeWhitespace`| Replaces multiple consecutive whitespace characters in each string with a single space.|
|`PadToSameLength`| Pads all strings to the same length using a specified character.|
|`RemoveNullOrEmpty`| Removes all null or empty strings from the array.|
|`RemoveNullOrWhiteSpace`| Removes all null, empty, or whitespace strings from the array.|
|`ReplaceInAll`| Replaces a specified substring in all strings of the array.|
|`ReverseEach`| Reverses each string in the array.|
|`ShortestString`| Retrieves the shortest string from the array.|
|`SortAlphabetically`| Sorts the array of strings in alphabetical order.|
|`StartsWithSubstring`| Checks if any of the strings in the array starts with a specified substring.|
|`StripHtmlTags`| Removes HTML tags from all strings in the array.|
|`ToCamelCase`| Converts all strings to camelCase.|
|`ToDoubles`| Converts numeric strings to doubles, filtering out non-numeric strings.|
|`ToIntegers`| Converts numeric strings to integers, filtering out non-numeric strings.|
|`ToKebabCase`| Converts all strings to kebab-case.|
|`ToLowerCase`| Converts all strings in the array to lowercase.|
|`ToPascalCase`| Converts all strings to PascalCase.|
|`ToSnakeCase`| Converts all strings to snake_case.|
|`ToTitleCase`| Converts all strings to title case (capitalizes the first letter of each word).|
|`ToUpperCase`| Converts all strings in the array to uppercase.|
|`TotalWordCount`| Counts the total number of words in all strings.|
|`TrimAll`| Trims whitespace from all strings in the array.|
|`TruncateAll`| Truncates all strings to a specified maximum length.|
|`UniqueStrings`| Returns an array of unique strings, removing duplicates.|

### Integer Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AverageIgnoringZero`| Calculates the average of the elements in the array, ignoring zero values.|
|`CalculateFactorials`| Calculates the factorial of each element in the array.|
|`CountNegative`| Counts the number of negative numbers in the array.|
|`CountPositive`| Counts the number of positive numbers in the array.|
|`CountZeros`| Counts the number of zero values in the array.|
|`CumulativeProduct`| Calculates the cumulative product of the array elements.|
|`CumulativeSum`| Calculates the cumulative sum of the array elements.|
|`FilterFibonacci`| Filters the array to include only Fibonacci numbers.|
|`FilterNegative`| Filters the array to include only negative numbers.|
|`FilterPerfectSquares`| Filters the array to include only perfect squares.|
|`FilterPositive`| Filters the array to include only positive numbers.|
|`FilterZeros`| Filters the array to include only zero values.|
|`FindPairsSumToTarget`| Finds all pairs of indices whose elements sum to a target value.|
|`FindPrimeNumbers`| Filters the array to include only prime numbers.|
|`GeometricMean`| Calculates the geometric mean of the array elements.|
|`HarmonicMean`| Calculates the harmonic mean of the array elements.|
|`IsFibonacci`| Checks if each number in the array is a Fibonacci number.|
|`IsMonotonicallyDecreasing`| Checks if the array's elements are in a strictly decreasing order.|
|`IsMonotonicallyIncreasing`| Checks if the array's elements are in a strictly increasing order.|
|`IsPerfectSquare`| Checks if each number in the array is a perfect square.|
|`Median`| Calculates the median of the array elements.|
|`Mode`| Finds the most frequently occurring number(s) in the array.|
|`MultiplyAll`| Multiplies all elements in the array and returns the product.|
|`Percentile`| Finds the percentile value in the array.|
|`Randomize`| Randomizes the order of elements in the array.|
|`Range`| Finds the range (difference between max and min) of the array.|
|`StandardDeviation`| Calculates the standard deviation of the array elements.|
|`SumAbsoluteDifferences`| Calculates the sum of the absolute differences between all pairs of elements.|
|`SumEvenNumbers`| Sums all the even numbers in the array.|
|`SumOddNumbers`| Sums all the odd numbers in the array.|
|`ToBinaryStrings`| Converts integers to their binary string representations.|
|`ToFrequencyMap`| Creates a frequency map (count of each element).|
|`ToHexStrings`| Converts integers to their hexadecimal string representations.|
|`Variance`| Calculates the variance of the array elements.|

### Double Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AllFinite`| Checks if all values in the array are finite (not NaN or infinity).|
|`CalculateEntropy`| Calculates entropy of the array (measure of randomness).|
|`CorrelationWith`| Calculates the correlation coefficient between two arrays.|
|`CumulativeSum`| Calculates the cumulative sum of the array elements.|
|`Diff`| Calculates the differences between consecutive elements.|
|`FindLocalMaxima`| Finds local maxima in the array.|
|`FindLocalMinima`| Finds local minima in the array.|
|`FindOutliers`| Finds values that are outliers using the IQR method.|
|`Kurtosis`| Calculates the kurtosis of the distribution.|
|`Median`| Calculates the median value of the array.|
|`Normalize`| Normalizes the array values to a range between 0 and 1.|
|`Percentile`| Calculates the percentile value in the array.|
|`Range`| Finds the range (difference between maximum and minimum values) of the array.|
|`RemoveNaNAndInfinity`| Removes NaN and infinity values from the array.|
|`RoundAll`| Rounds all values in the array to the specified number of decimal places.|
|`Skewness`| Calculates the skewness of the distribution.|
|`SmoothMovingAverage`| Applies a smoothing filter (moving average) to the array.|
|`Standardize`| Standardizes the array values (z-score normalization).|
|`StandardDeviation`| Calculates the standard deviation of the array elements.|
|`Variance`| Calculates the variance of the array elements.|

### Boolean Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AllFalse`| Checks if all values in the array are false.|
|`AllTrue`| Checks if all values in the array are true.|
|`And`| Performs logical AND operation with another boolean array.|
|`AnyFalse`| Checks if any value in the array is false.|
|`AnyTrue`| Checks if any value in the array is true.|
|`CountFalse`| Counts the number of false values in the array.|
|`CountTrue`| Counts the number of true values in the array.|
|`FalsePercentage`| Calculates the percentage of false values (0-100).|
|`FindConsecutiveFalseSequences`| Groups consecutive false values and returns their start indices and lengths.|
|`FindConsecutiveTrueSequences`| Groups consecutive true values and returns their start indices and lengths.|
|`FindFalseIndices`| Finds the indices of all false values in the array.|
|`FindTrueIndices`| Finds the indices of all true values in the array.|
|`FirstFalseIndex`| Finds the first index where the value is false.|
|`FirstTrueIndex`| Finds the first index where the value is true.|
|`Invert`| Inverts all boolean values in the array.|
|`LastFalseIndex`| Finds the last index where the value is false.|
|`LastTrueIndex`| Finds the last index where the value is true.|
|`LongestFalseSequence`| Finds the longest sequence of consecutive false values.|
|`LongestTrueSequence`| Finds the longest sequence of consecutive true values.|
|`Or`| Performs logical OR operation with another boolean array.|
|`ToBinaryString`| Converts the boolean array to a binary string representation.|
|`ToIntArray`| Converts the boolean array to an integer array (true = 1, false = 0).|
|`TruePercentage`| Calculates the percentage of true values (0-100).|
|`Xor`| Performs logical XOR operation with another boolean array.|

### Character Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AsString`| Converts the character array to a string.|
|`CapitalizeFirst`| Capitalizes the first character if it's a letter.|
|`CountConsonants`| Counts the number of consonants in the character array.|
|`CountDigits`| Counts the number of digits in the character array.|
|`CountLetters`| Counts the number of letters in the character array.|
|`CountLowercase`| Counts the number of lowercase letters in the character array.|
|`CountPunctuation`| Counts the number of punctuation characters in the character array.|
|`CountUppercase`| Counts the number of uppercase letters in the character array.|
|`CountVowels`| Counts the number of vowels in the character array.|
|`CountWhitespace`| Counts the number of whitespace characters in the character array.|
|`Encode`| Encodes the character array using the specified encoding.|
|`FindAllIndices`| Finds all indices where a specific character occurs.|
|`GetCharacterFrequency`| Creates a frequency map of all characters in the array.|
|`GroupByUnicodeCategory`| Groups characters by their Unicode category.|
|`IsAsciiOnly`| Checks if the character array contains only ASCII characters.|
|`IsPalindrome`| Checks if the character array represents a palindrome.|
|`KeepAlphanumericOnly`| Removes all non-alphanumeric characters from the character array.|
|`KeepDigitsOnly`| Removes all non-digit characters from the character array.|
|`KeepLettersOnly`| Removes all non-letter characters from the character array.|
|`MostFrequentChar`| Finds the most frequently occurring character in the array.|
|`RemoveDuplicates`| Removes duplicate characters while preserving order.|
|`RemoveWhitespace`| Removes all whitespace characters from the character array.|
|`ReplaceAll`| Replaces all occurrences of a character with another character.|
|`Reverse`| Reverses the character array.|
|`RotateLeft`| Rotates the character array to the left by the specified number of positions.|
|`RotateRight`| Rotates the character array to the right by the specified number of positions.|
|`SortAlphabetically`| Sorts the character array alphabetically.|
|`ToLowercase`| Converts all letters in the character array to lowercase.|
|`ToTitleCase`| Converts the character array to title case (capitalizes first letter of each word).|
|`ToUppercase`| Converts all letters in the character array to uppercase.|

### Byte Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`And`| ANDs the byte array with another byte array.|
|`CalculateEntropy`| Calculates entropy of the byte array (measure of randomness).|
|`CalculateMD5`| Calculates the MD5 hash of the byte array.|
|`CalculateSHA1`| Calculates the SHA1 hash of the byte array.|
|`CalculateSHA256`| Calculates the SHA256 hash of the byte array.|
|`CalculateSHA512`| Calculates the SHA512 hash of the byte array.|
|`CompressGZip`| Compresses the byte array using GZip compression.|
|`DecompressGZip`| Decompresses the byte array using GZip decompression.|
|`EndsWith`| Checks if the byte array ends with the specified pattern.|
|`FindPattern`| Finds patterns in the byte array.|
|`GenerateSecureRandom`| Generates a secure random byte array of the specified length.|
|`GetByteFrequency`| Creates a frequency map of all bytes in the array.|
|`MostFrequentByte`| Finds the most frequently occurring byte in the array.|
|`Not`| Inverts all bits in the byte array (NOT operation).|
|`Or`| ORs the byte array with another byte array.|
|`ReplacePattern`| Replaces all occurrences of a byte pattern with another pattern.|
|`ShiftLeft`| Shifts all bytes in the array left by the specified number of bits.|
|`ShiftRight`| Shifts all bytes in the array right by the specified number of bits.|
|`SplitIntoChunks`| Splits the byte array into chunks of the specified size.|
|`StartsWith`| Checks if the byte array starts with the specified pattern.|
|`ToAsciiString`| Converts the byte array to an ASCII string.|
|`ToBase64String`| Converts the byte array to a Base64 string.|
|`ToHexString`| Converts the byte array to a hexadecimal string representation.|
|`ToHexStringLower`| Converts the byte array to a hexadecimal string with lowercase letters.|
|`ToString`| Converts the byte array to a string using the specified encoding.|
|`ToUtf8String`| Converts the byte array to a UTF-8 string.|
|`Xor`| XORs the byte array with another byte array.|

### GUID Array methods

|Name                               | Description                                       |
|-----------------------------------|---------------------------------------------------|
|`AllEmpty`| Checks if all GUIDs in the array are empty.|
|`AllUnique`| Checks if all GUIDs in the array are unique.|
|`AllValid`| Validates that all GUIDs in the array are properly formatted.|
|`AnyEmpty`| Checks if any GUID in the array is empty.|
|`Contains`| Checks if a GUID is in the array.|
|`FilterByVersion`| Filters GUIDs that match a specific version.|
|`FindDuplicates`| Finds duplicate GUIDs in the array.|
|`GenerateRandomGuids`| Generates a new array of random GUIDs with the specified length.|
|`GetVersions`| Gets the version of each GUID in the array.|
|`GroupByVersion`| Groups GUIDs by their version.|
|`IndexOf`| Finds the index of a specific GUID in the array.|
|`Max`| Finds the latest GUID (largest value) in the array.|
|`Min`| Finds the earliest GUID (smallest value) in the array.|
|`RemoveEmpty`| Removes all empty GUIDs (Guid.Empty) from the array.|
|`ReplaceEmptyWithNew`| Replaces all empty GUIDs with new random GUIDs.|
|`SortAscending`| Sorts the GUIDs in ascending order.|
|`SortDescending`| Sorts the GUIDs in descending order.|
|`ToByteArrays`| Converts all GUIDs to their byte array representations.|
|`ToCommaSeparatedString`| Converts the GUID array to a comma-separated string.|
|`ToDelimitedString`| Converts the GUID array to a delimited string with custom separator.|
|`ToHashSet`| Creates a hash set from the GUID array for fast lookups.|
|`ToStringArray`| Converts all GUIDs to their string representation.|

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
