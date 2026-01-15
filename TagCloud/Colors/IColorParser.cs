using SixLabors.ImageSharp;

namespace TagCloud.Colors;

public interface IColorParser
{
    public Color Parse(string color);
    public List<Color> ParseMany(string colors);
}