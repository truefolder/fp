using FluentAssertions;
using TagCloud.WordsProcessing;

namespace TagCloudTests;

public class FrequencyCounterTests
{
    [Test]
    public void CalculateFrequencies_ShouldCountFrequenciesCorrect()
    {
        var counter = new FrequencyCounter();
        var symbols = new[] {"a", "b", "c", "a", "b", "a"};
        
        var frequencies = counter.CalculateFrequencies(symbols).ToList();

        frequencies.Should().Contain(f => f.Word == "a" && f.Count == 3);
        frequencies.Should().Contain(f => f.Word == "b" && f.Count == 2);
        frequencies.Should().Contain(f => f.Word == "c" && f.Count == 1);
    }
}