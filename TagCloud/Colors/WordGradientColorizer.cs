using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using TagCloud.WordsProcessing;

namespace TagCloud.Colors;

public class WordGradientColorizer(Color gradientFrom, Color gradientTo) : IWordColorizer
{
    public Color Colorize(TextTag tag) =>
        Lerp(gradientFrom, gradientTo, tag.NormalizedFrequency);
    
    private Color Lerp(Color from, Color to, float frequency)
    {
        var fromRgb = from.ToPixel<Rgba32>();
        var toRgb = to.ToPixel<Rgba32>();

        return Color.FromRgba(
            LerpChannel(fromRgb.R, toRgb.R, frequency),
            LerpChannel(fromRgb.G, toRgb.G, frequency),
            LerpChannel(fromRgb.B, toRgb.B, frequency),
            255);
    }

    private byte LerpChannel(byte from, byte to, float frequency)
    {
        return (byte)(from + (to - from) * frequency);
    }
}