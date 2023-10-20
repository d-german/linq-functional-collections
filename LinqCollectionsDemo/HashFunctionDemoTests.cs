namespace LinqCollectionsDemo;

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