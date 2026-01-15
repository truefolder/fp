namespace TagCloud.WordsProcessing;

public interface IFrequencyCounter
{
    public IEnumerable<WordFrequency> CalculateFrequencies(IEnumerable<string> words);
}