using TagCloud.WordsProcessing;

namespace TagCloud.Sizing;

public interface IFontSizeCalculator
{
    public IEnumerable<TextTag> CalculateSizes(IEnumerable<WordFrequency> words, float minSize, float maxSize);
}