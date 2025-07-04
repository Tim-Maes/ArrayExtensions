using System.Security.Cryptography;
using System.Text;

namespace ArrayExtensions;

public static class ByteArrayExtensions
{
    /// <summary>
    /// Converts the byte array to a hexadecimal string representation.
    /// </summary>
    /// <param name="arr">The byte array to convert.</param>
    /// <returns>A hexadecimal string representation.</returns>
    public static string ToHexString(this byte[] arr)
        => Convert.ToHexString(arr);

    /// <summary>
    /// Converts the byte array to a hexadecimal string with lowercase letters.
    /// </summary>
    /// <param name="arr">The byte array to convert.</param>
    /// <returns>A lowercase hexadecimal string representation.</returns>
    public static string ToHexStringLower(this byte[] arr)
        => Convert.ToHexString(arr).ToLowerInvariant();

    /// <summary>
    /// Converts the byte array to a Base64 string.
    /// </summary>
    /// <param name="arr">The byte array to convert.</param>
    /// <returns>A Base64 string representation.</returns>
    public static string ToBase64String(this byte[] arr)
        => Convert.ToBase64String(arr);

    /// <summary>
    /// Converts the byte array to a string using the specified encoding.
    /// </summary>
    /// <param name="arr">The byte array to convert.</param>
    /// <param name="encoding">The encoding to use for conversion.</param>
    /// <returns>A string representation using the specified encoding.</returns>
    public static string ToString(this byte[] arr, Encoding encoding)
        => encoding.GetString(arr);

    /// <summary>
    /// Converts the byte array to a UTF-8 string.
    /// </summary>
    /// <param name="arr">The byte array to convert.</param>
    /// <returns>A UTF-8 string representation.</returns>
    public static string ToUtf8String(this byte[] arr)
        => Encoding.UTF8.GetString(arr);

    /// <summary>
    /// Converts the byte array to an ASCII string.
    /// </summary>
    /// <param name="arr">The byte array to convert.</param>
    /// <returns>An ASCII string representation.</returns>
    public static string ToAsciiString(this byte[] arr)
        => Encoding.ASCII.GetString(arr);

    /// <summary>
    /// Calculates the MD5 hash of the byte array.
    /// </summary>
    /// <param name="arr">The byte array to hash.</param>
    /// <returns>A byte array containing the MD5 hash.</returns>
    public static byte[] CalculateMD5(this byte[] arr)
    {
        using var md5 = MD5.Create();
        return md5.ComputeHash(arr);
    }

    /// <summary>
    /// Calculates the SHA1 hash of the byte array.
    /// </summary>
    /// <param name="arr">The byte array to hash.</param>
    /// <returns>A byte array containing the SHA1 hash.</returns>
    public static byte[] CalculateSHA1(this byte[] arr)
    {
        using var sha1 = SHA1.Create();
        return sha1.ComputeHash(arr);
    }

    /// <summary>
    /// Calculates the SHA256 hash of the byte array.
    /// </summary>
    /// <param name="arr">The byte array to hash.</param>
    /// <returns>A byte array containing the SHA256 hash.</returns>
    public static byte[] CalculateSHA256(this byte[] arr)
    {
        using var sha256 = SHA256.Create();
        return sha256.ComputeHash(arr);
    }

    /// <summary>
    /// Calculates the SHA512 hash of the byte array.
    /// </summary>
    /// <param name="arr">The byte array to hash.</param>
    /// <returns>A byte array containing the SHA512 hash.</returns>
    public static byte[] CalculateSHA512(this byte[] arr)
    {
        using var sha512 = SHA512.Create();
        return sha512.ComputeHash(arr);
    }

    /// <summary>
    /// XORs the byte array with another byte array.
    /// </summary>
    /// <param name="arr1">The first byte array.</param>
    /// <param name="arr2">The second byte array.</param>
    /// <returns>A new byte array containing the XOR result.</returns>
    public static byte[] Xor(this byte[] arr1, byte[] arr2)
    {
        if (arr1 == null || arr2 == null)
            throw new ArgumentNullException("Arrays cannot be null.");

        if (arr1.Length != arr2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return arr1.Zip(arr2, (a, b) => (byte)(a ^ b)).ToArray();
    }

    /// <summary>
    /// ANDs the byte array with another byte array.
    /// </summary>
    /// <param name="arr1">The first byte array.</param>
    /// <param name="arr2">The second byte array.</param>
    /// <returns>A new byte array containing the AND result.</returns>
    public static byte[] And(this byte[] arr1, byte[] arr2)
    {
        if (arr1 == null || arr2 == null)
            throw new ArgumentNullException("Arrays cannot be null.");

        if (arr1.Length != arr2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return arr1.Zip(arr2, (a, b) => (byte)(a & b)).ToArray();
    }

    /// <summary>
    /// ORs the byte array with another byte array.
    /// </summary>
    /// <param name="arr1">The first byte array.</param>
    /// <param name="arr2">The second byte array.</param>
    /// <returns>A new byte array containing the OR result.</returns>
    public static byte[] Or(this byte[] arr1, byte[] arr2)
    {
        if (arr1 == null || arr2 == null)
            throw new ArgumentNullException("Arrays cannot be null.");

        if (arr1.Length != arr2.Length)
            throw new ArgumentException("Arrays must have the same length.");

        return arr1.Zip(arr2, (a, b) => (byte)(a | b)).ToArray();
    }

    /// <summary>
    /// Inverts all bits in the byte array (NOT operation).
    /// </summary>
    /// <param name="arr">The byte array to invert.</param>
    /// <returns>A new byte array with inverted bits.</returns>
    public static byte[] Not(this byte[] arr)
        => arr.Select(b => (byte)~b).ToArray();

    /// <summary>
    /// Shifts all bytes in the array left by the specified number of bits.
    /// </summary>
    /// <param name="arr">The byte array to shift.</param>
    /// <param name="positions">The number of bit positions to shift left.</param>
    /// <returns>A new byte array with shifted bits.</returns>
    public static byte[] ShiftLeft(this byte[] arr, int positions)
    {
        if (positions < 0 || positions > 7)
            throw new ArgumentOutOfRangeException(nameof(positions), "Positions must be between 0 and 7.");

        return arr.Select(b => (byte)(b << positions)).ToArray();
    }

    /// <summary>
    /// Shifts all bytes in the array right by the specified number of bits.
    /// </summary>
    /// <param name="arr">The byte array to shift.</param>
    /// <param name="positions">The number of bit positions to shift right.</param>
    /// <returns>A new byte array with shifted bits.</returns>
    public static byte[] ShiftRight(this byte[] arr, int positions)
    {
        if (positions < 0 || positions > 7)
            throw new ArgumentOutOfRangeException(nameof(positions), "Positions must be between 0 and 7.");

        return arr.Select(b => (byte)(b >> positions)).ToArray();
    }

    /// <summary>
    /// Finds the most frequently occurring byte in the array.
    /// </summary>
    /// <param name="arr">The byte array to analyze.</param>
    /// <returns>The most frequent byte.</returns>
    public static byte MostFrequentByte(this byte[] arr)
    {
        if (arr == null || arr.Length == 0)
            throw new ArgumentException("Array is null or empty.", nameof(arr));

        return arr.GroupBy(b => b)
                  .OrderByDescending(g => g.Count())
                  .First()
                  .Key;
    }

    /// <summary>
    /// Creates a frequency map of all bytes in the array.
    /// </summary>
    /// <param name="arr">The byte array to analyze.</param>
    /// <returns>A dictionary with byte frequencies.</returns>
    public static Dictionary<byte, int> GetByteFrequency(this byte[] arr)
        => arr.GroupBy(b => b).ToDictionary(g => g.Key, g => g.Count());

    /// <summary>
    /// Calculates entropy of the byte array (measure of randomness).
    /// </summary>
    /// <param name="arr">The byte array to analyze.</param>
    /// <returns>The entropy value.</returns>
    public static double CalculateEntropy(this byte[] arr)
    {
        if (arr == null || arr.Length == 0)
            return 0;

        var frequencies = arr.GetByteFrequency();
        double entropy = 0;

        foreach (var freq in frequencies.Values)
        {
            double probability = (double)freq / arr.Length;
            entropy -= probability * Math.Log2(probability);
        }

        return entropy;
    }

    /// <summary>
    /// Compresses the byte array using GZip compression.
    /// </summary>
    /// <param name="arr">The byte array to compress.</param>
    /// <returns>A compressed byte array.</returns>
    public static byte[] CompressGZip(this byte[] arr)
    {
        using var input = new MemoryStream(arr);
        using var output = new MemoryStream();
        using var gzip = new System.IO.Compression.GZipStream(output, System.IO.Compression.CompressionMode.Compress);
        
        input.CopyTo(gzip);
        gzip.Close();
        
        return output.ToArray();
    }

    /// <summary>
    /// Decompresses the byte array using GZip decompression.
    /// </summary>
    /// <param name="arr">The compressed byte array to decompress.</param>
    /// <returns>A decompressed byte array.</returns>
    public static byte[] DecompressGZip(this byte[] arr)
    {
        using var input = new MemoryStream(arr);
        using var output = new MemoryStream();
        using var gzip = new System.IO.Compression.GZipStream(input, System.IO.Compression.CompressionMode.Decompress);
        
        gzip.CopyTo(output);
        
        return output.ToArray();
    }

    /// <summary>
    /// Finds patterns in the byte array.
    /// </summary>
    /// <param name="arr">The byte array to search.</param>
    /// <param name="pattern">The byte pattern to find.</param>
    /// <returns>An array of starting indices where the pattern occurs.</returns>
    public static int[] FindPattern(this byte[] arr, byte[] pattern)
    {
        if (arr == null || pattern == null || pattern.Length == 0)
            return Array.Empty<int>();

        var indices = new List<int>();

        for (int i = 0; i <= arr.Length - pattern.Length; i++)
        {
            bool found = true;
            for (int j = 0; j < pattern.Length; j++)
            {
                if (arr[i + j] != pattern[j])
                {
                    found = false;
                    break;
                }
            }

            if (found)
                indices.Add(i);
        }

        return indices.ToArray();
    }

    /// <summary>
    /// Replaces all occurrences of a byte pattern with another pattern.
    /// </summary>
    /// <param name="arr">The byte array to process.</param>
    /// <param name="oldPattern">The pattern to replace.</param>
    /// <param name="newPattern">The replacement pattern.</param>
    /// <returns>A new byte array with replacements.</returns>
    public static byte[] ReplacePattern(this byte[] arr, byte[] oldPattern, byte[] newPattern)
    {
        if (arr == null || oldPattern == null || newPattern == null)
            throw new ArgumentNullException("Arrays cannot be null.");

        var result = new List<byte>();
        int i = 0;

        while (i < arr.Length)
        {
            bool patternFound = false;

            if (i <= arr.Length - oldPattern.Length)
            {
                bool matches = true;
                for (int j = 0; j < oldPattern.Length; j++)
                {
                    if (arr[i + j] != oldPattern[j])
                    {
                        matches = false;
                        break;
                    }
                }

                if (matches)
                {
                    result.AddRange(newPattern);
                    i += oldPattern.Length;
                    patternFound = true;
                }
            }

            if (!patternFound)
            {
                result.Add(arr[i]);
                i++;
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Splits the byte array into chunks of the specified size.
    /// </summary>
    /// <param name="arr">The byte array to split.</param>
    /// <param name="chunkSize">The size of each chunk.</param>
    /// <returns>An array of byte arrays representing the chunks.</returns>
    public static byte[][] SplitIntoChunks(this byte[] arr, int chunkSize)
    {
        if (chunkSize <= 0)
            throw new ArgumentOutOfRangeException(nameof(chunkSize), "Chunk size must be positive.");

        if (arr == null || arr.Length == 0)
            return Array.Empty<byte[]>();

        var chunks = new List<byte[]>();
        
        for (int i = 0; i < arr.Length; i += chunkSize)
        {
            int remainingBytes = Math.Min(chunkSize, arr.Length - i);
            var chunk = new byte[remainingBytes];
            Array.Copy(arr, i, chunk, 0, remainingBytes);
            chunks.Add(chunk);
        }

        return chunks.ToArray();
    }

    /// <summary>
    /// Generates a secure random byte array of the specified length.
    /// </summary>
    /// <param name="length">The length of the random byte array.</param>
    /// <returns>A cryptographically secure random byte array.</returns>
    public static byte[] GenerateSecureRandom(int length)
    {
        if (length < 0)
            throw new ArgumentOutOfRangeException(nameof(length), "Length cannot be negative.");

        using var rng = RandomNumberGenerator.Create();
        var bytes = new byte[length];
        rng.GetBytes(bytes);
        return bytes;
    }

    /// <summary>
    /// Checks if the byte array starts with the specified pattern.
    /// </summary>
    /// <param name="arr">The byte array to check.</param>
    /// <param name="pattern">The pattern to look for.</param>
    /// <returns>True if the array starts with the pattern, otherwise false.</returns>
    public static bool StartsWith(this byte[] arr, byte[] pattern)
    {
        if (arr == null || pattern == null || pattern.Length > arr.Length)
            return false;

        for (int i = 0; i < pattern.Length; i++)
        {
            if (arr[i] != pattern[i])
                return false;
        }

        return true;
    }

    /// <summary>
    /// Checks if the byte array ends with the specified pattern.
    /// </summary>
    /// <param name="arr">The byte array to check.</param>
    /// <param name="pattern">The pattern to look for.</param>
    /// <returns>True if the array ends with the pattern, otherwise false.</returns>
    public static bool EndsWith(this byte[] arr, byte[] pattern)
    {
        if (arr == null || pattern == null || pattern.Length > arr.Length)
            return false;

        int startIndex = arr.Length - pattern.Length;
        for (int i = 0; i < pattern.Length; i++)
        {
            if (arr[startIndex + i] != pattern[i])
                return false;
        }

        return true;
    }
}