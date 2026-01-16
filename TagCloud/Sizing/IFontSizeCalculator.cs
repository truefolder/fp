using TagCloud.ResultModel;
using TagCloud.WordsProcessing;

namespace TagCloud.Sizing;

public interface IFontSizeCalculator
{
    public Result<IEnumerable<TextTag>> CalculateSizes(IEnumerable<WordFrequency> words, float minSize, float maxSize);
}