using SixLabors.ImageSharp;
using TagCloud.ResultModel;
using TagCloud.WordsProcessing;

namespace TagCloud.Sizing;

public interface ITextTagSizeCalculator
{
    public Result<Size> CalculateSize(TextTag tag, string fontName);
}