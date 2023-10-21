using System.Diagnostics;

namespace LinqCollectionsDemo;

[TestFixture]
public class WeatherDataCachingTests
{
    private static readonly IDictionary<string, string> WeatherCache = new Dictionary<string, string>();

    private static string ExpensiveWeatherFetch(string location)
    {
        Thread.Sleep(2000);  // Simulate network delay
        return $"Weather data for {location}: Sunny, 25°C";  // Simplified weather data
    }

    private static string GetWeatherData(string location)
    {
        throw new NotImplementedException();
    }
    
   // [Test]
    public void FetchWeatherData_WithCache_Test()
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();

        // First fetch, data will be cached
        var data1 = GetWeatherData("New York");
        
        stopwatch.Stop();
        Console.WriteLine($"First fetch with cache took {stopwatch.ElapsedMilliseconds} ms.");
        Assert.That(data1, Is.Not.Null);

        stopwatch.Reset();
        stopwatch.Start();

        // Second fetch, data will be retrieved from cache
        var data2 = GetWeatherData("New York");

        stopwatch.Stop();
        Console.WriteLine($"Second fetch with cache took {stopwatch.ElapsedMilliseconds} ms.");
        Assert.That(data2, Is.Not.Null);
    }
}