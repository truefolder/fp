using SixLabors.ImageSharp;
using TagCloud.WordsProcessing;

namespace TagCloud.Colors;

public class WordPaletteColorizer(IEnumerable<Color> palette) : IWordColorizer
{
    private readonly List<Color> _palette = palette.ToList();
    private int _index;
    public Color Colorize(TextTag tag)
    {
        var color = _palette[_index % _palette.Count];
        _index++;
        return color;
    }
}