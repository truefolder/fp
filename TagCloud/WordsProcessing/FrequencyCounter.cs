namespace TagCloud.WordsProcessing;

public class FrequencyCounter : IFrequencyCounter
{
    public IEnumerable<WordFrequency> CalculateFrequencies(IEnumerable<string> words) =>
        words.GroupBy(word => word)
            .Select(group => new WordFrequency(group.Key, group.Count()))
            .OrderByDescending(frequency => frequency.Count);
}