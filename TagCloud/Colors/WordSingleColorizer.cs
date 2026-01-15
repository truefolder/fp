using SixLabors.ImageSharp;
using TagCloud.WordsProcessing;

namespace TagCloud.Colors;

public class WordSingleColorizer(Color color) : IWordColorizer
{
    public Color Colorize(TextTag tag) => color;
}