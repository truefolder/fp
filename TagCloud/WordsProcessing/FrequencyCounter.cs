using TagCloud.ResultModel;

namespace TagCloud.WordsProcessing;

public class FrequencyCounter : IFrequencyCounter
{
    public Result<IEnumerable<WordFrequency>> CalculateFrequencies(IEnumerable<string> words)
    {
        return Result.Of<IEnumerable<WordFrequency>>(() =>
        {
            return words.GroupBy(word => word)
                .Select(group => new WordFrequency(group.Key, group.Count()))
                .OrderByDescending(frequency => frequency.Count);
        }).RefineError("Can't calculate frequencies");
    }
}