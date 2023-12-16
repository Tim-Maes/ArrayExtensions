namespace ArrayExtensions;

public static class MultiDimensionalArrayExtensions
{    /// <summary>
     /// Iterates over each element in a multi-dimensional array and executes the provided action.
     /// </summary>
    public static void ForEach<T>(this T[,] array, Action<T> action)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                action(array[i, j]);
            }
        }
    }

    /// <summary>
    /// Transposes a two-dimensional array.
    /// </summary>
    public static T[,] Transpose<T>(this T[,] array)
    {
        var rows = array.GetLength(0);
        var columns = array.GetLength(1);
        var result = new T[columns, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[j, i] = array[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Flattens a multi-dimensional array into a single-dimensional array.
    /// </summary>
    public static T[] Flatten<T>(this T[,] array)
    {
        var rows = array.GetLength(0);
        var columns = array.GetLength(1);
        var result = new T[rows * columns];
        int index = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[index++] = array[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Creates a deep copy of the multi-dimensional array.
    /// Note: Elements in the array must implement the ICloneable interface.
    /// </summary>
    public static T[,] DeepCopy<T>(this T[,] array) where T : ICloneable
    {
        var rows = array.GetLength(0);
        var columns = array.GetLength(1);
        var result = new T[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = (T)array[i, j].Clone();
            }
        }

        return result;
    }

    /// <summary>
    /// Checks if all elements in the multi-dimensional array are equal.
    /// </summary>
    public static bool AllEqual<T>(this T[,] array)
    {
        var first = array[0, 0];
        return array.Cast<T>().All(element => EqualityComparer<T>.Default.Equals(element, first));
    }

    /// <summary>
    /// Counts occurrences of a specific item in the multi-dimensional array.
    /// </summary>
    public static int CountOf<T>(this T[,] array, T item) where T : IEquatable<T>
    {
        return array.Cast<T>().Count(x => x.Equals(item));
    }

    /// <summary>
    /// Fills the multi-dimensional array with a specific value.
    /// </summary>
    public static void Fill<T>(this T[,] array, T value)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = value;
            }
        }
    }

    /// <summary>
    /// Finds the first occurrence of an element that matches a condition.
    /// </summary>
    public static (int, int)? FindFirst<T>(this T[,] array, Predicate<T> match)
    {
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (match(array[i, j]))
                {
                    return (i, j);
                }
            }
        }

        return null;
    }

    /// <summary>
    /// Retrieves a specific row from a multi-dimensional array.
    /// </summary>
    public static T[] GetRow<T>(this T[,] array, int row)
    {
        var rowLength = array.GetLength(1);
        var result = new T[rowLength];
        for (int i = 0; i < rowLength; i++)
        {
            result[i] = array[row, i];
        }
        return result;
    }

    /// <summary>
    /// Retrieves a specific column from a multi-dimensional array.
    /// </summary>
    public static T[] GetColumn<T>(this T[,] array, int column)
    {
        var columnLength = array.GetLength(0);
        var result = new T[columnLength];
        for (int i = 0; i < columnLength; i++)
        {
            result[i] = array[i, column];
        }
        return result;
    }

    /// <summary>
    /// Rotates the array 90 degrees clockwise.
    /// </summary>
    public static T[,] Rotate90DegreesClockwise<T>(this T[,] array)
    {
        var rows = array.GetLength(0);
        var columns = array.GetLength(1);
        var result = new T[columns, rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[j, rows - 1 - i] = array[i, j];
            }
        }

        return result;
    }

    /// <summary>
    /// Checks if the multi-dimensional array contains a specific element.
    /// </summary>
    public static bool Contains<T>(this T[,] array, T item) where T : IEquatable<T>
    {
        return array.Cast<T>().Any(x => x.Equals(item));
    }
}
