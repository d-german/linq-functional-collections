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
    public static int CustomHashFunction(int hashSize, string value) => value.Sum(c => c) % hashSize;

    /// <summary>
    /// Inserts a string value into a pre-sized hash table using a custom hash function.
    /// </summary>
    /// <param name="values">The hash table, represented as a list of strings.</param>
    /// <param name="value">The string value to insert.</param>
    /// <remarks>
    /// This method computes the hash value for the string, and places the string at the corresponding index in the hash table.
    /// If there's already a value at the computed index, it will be replaced (collision resolution by overwriting).
    /// </remarks>
    public static void Insert(this IList<string> values, string value) => values[CustomHashFunction(values.Count, value)] = value;

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
    public static string? Retrieve(this IList<string> values, string value) => (values[CustomHashFunction(values.Count, value)] == value ? value : null);
}

public class HashFunctionDemoTests
{
    private const int HashTableSize = 10;
    private IList<string> _hashTable = null!;

    [SetUp]
    public void SetUp()
    {
        _hashTable = new string[HashTableSize]; // Pre-size the table
    }

    [Test]
    public void InsertAndRetrieveTest()
    {
        _hashTable.Insert("apple");
        _hashTable.Insert("banana");

        Assert.Multiple(() =>
        {
            Assert.That(_hashTable.Retrieve("apple"), Is.EqualTo("apple"));
            Assert.That(_hashTable.Retrieve("banana"), Is.EqualTo("banana"));
        });
    }

    [Test]
    public void CollisionTest()
    {
        _hashTable.Insert("apple");
        _hashTable.Insert("elppa"); // These two strings have the same sum of ASCII values

        Assert.Multiple(() =>
        {
            // Since they hash to the same position, "elppa" will replace "apple"
            Assert.That(_hashTable.Retrieve("elppa"), Is.EqualTo("elppa"));
            Assert.That(_hashTable.Retrieve("apple"), Is.Null);
        });
    }

    [Test]
    public void EmptySpaceTest()
    {
        _hashTable.Insert("apple");

        // Check all positions in the table
        for (var i = 0; i < HashTableSize; i++)
        {
            if (i != StringHashTableUtility.CustomHashFunction(HashTableSize, "apple")) // Except the position where "apple" is stored
            {
                Assert.That(_hashTable[i], Is.Null); // All other positions should be null
            }
        }
    }
}