using SixLabors.ImageSharp;

namespace TagCloud.Colors;

public class HexColorParser : IColorParser
{
    public Color Parse(string color)
    {
        if (!Color.TryParse(color, out Color colorResult))
            throw new ArgumentException($"Invalid color {color}");
        
        return colorResult;
    }

    public List<Color> ParseMany(string colors) =>
        colors.Split(',').Select(Parse).ToList();
}