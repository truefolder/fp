using SixLabors.ImageSharp;
using TagCloud.WordsProcessing;

namespace TagCloud.Sizing;

public interface ITextTagSizeCalculator
{
    public Size CalculateSize(TextTag tag, string fontName);
}