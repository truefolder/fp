using SixLabors.ImageSharp;
using TagCloud.ResultModel;
using TagCloud.WordsProcessing;

namespace TagCloud.Colors;

public interface IWordColorizer
{
    public Color Colorize(TextTag tag);
}