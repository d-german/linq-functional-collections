using System.Text;

namespace LinqCollectionsDemo;

// ReSharper disable UseObjectOrCollectionInitializer
public class DictionaryOperationsTests
{
    [Test]
    public void TestAddUpdateDictTest()
    {
        var dictionary = new Dictionary<string, int>();

        dictionary.Add("One", 1);
        dictionary["Two"] = 2; // adds to dictionary because "two" not already present
        dictionary["Two"] = 22; // updates dictionary because "two" is now present
        dictionary["Three"] = 3;
        Assert.Multiple(() =>
        {
            Assert.That(dictionary["Two"], Is.EqualTo(22));
            Assert.That(dictionary.ContainsKey("One")); // true (fast operation)
            Assert.That(dictionary.ContainsValue(3)); // true (slow operation)
        });
    }

    [Test]
    public void EnumerateDictionaryTest()
    {
        var dictionary = new Dictionary<string, int>
        {
            {
                "One", 1
            },
            {
                "Two", 2
            },
            {
                "Three", 3
            }
        };

        dictionary["Two"] = 22; // updates dictionary because "two" is now present

        var buf = new StringBuilder();
        
        foreach (var (key, value) in dictionary) // tuple deconstruction
        {
            buf.Append($"{key}; {value} ");
        }

        Assert.That(buf.ToString(), Is.EqualTo("One; 1 Two; 22 Three; 3 "));

        buf.Clear();
        
        foreach (var str in dictionary.Keys)
        {
            buf.Append(str);
        }

        Assert.That(buf.ToString(), Is.EqualTo("OneTwoThree"));

        buf.Clear();
        
        foreach (var value in dictionary.Values)
        {
            buf.Append(value);
        }

        Assert.That(buf.ToString(), Is.EqualTo("1223"));
    }
}