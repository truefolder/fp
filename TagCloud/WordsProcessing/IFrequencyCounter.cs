using TagCloud.ResultModel;

namespace TagCloud.WordsProcessing;

public interface IFrequencyCounter
{
    public Result<IEnumerable<WordFrequency>> CalculateFrequencies(IEnumerable<string> words);
}