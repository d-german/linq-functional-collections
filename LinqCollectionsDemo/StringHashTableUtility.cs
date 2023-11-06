namespace LinqCollectionsDemo;

public static class StringHashTableUtility
{
    /// <summary>
    /// Computes a custom hash value for a given string.
    /// </summary>
    /// <param name="hashSize">The size of the hash table.</param>
    /// <param name="value">The string value to hash.</param>
    /// <returns>
    /// The hash value, computed as the sum of the ASCII values of the characters in the string,
    /// modulo the size of the hash table.
    /// </returns>
    public static int CustomHashFunction(int hashSize, string value)
    {
        var sum = 0;
        for (var index = 0; index < value.Length; index++)
        {
            sum += value[index];
        }

        return sum % hashSize;
    }

    /// <summary>
    /// Inserts a string value into a pre-sized hash table using a custom hash function.
    /// </summary>
    /// <param name="values">The hash table, represented as a list of strings.</param>
    /// <param name="value">The string value to insert.</param>
    /// <remarks>
    /// This method computes the hash value for the string, and places the string at the corresponding index in the hash table.
    /// If there's already a value at the computed index, it will be replaced (collision resolution by overwriting).
    /// </remarks>
    public static void Insert(this IList<string> values, string value)
    {
        values[CustomHashFunction(values.Count, value)] = value;
    }

    /// <summary>
    /// Retrieves a string value from a hash table using a custom hash function.
    /// </summary>
    /// <param name="values">The hash table, represented as a list of strings.</param>
    /// <param name="value">The string value to retrieve.</param>
    /// <returns>
    /// The string value from the hash table if it matches the input value; null otherwise.
    /// </returns>
    /// <remarks>
    /// This method computes the hash value for the string, and returns the string 
    /// at the corresponding index in the hash table if it matches the input value.
    /// </remarks>
    public static string? Retrieve(this IList<string> values, string value)
    {
        return values[CustomHashFunction(values.Count, value)] == value ? value : null;
    }
}