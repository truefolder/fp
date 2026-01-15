using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using TagCloud.WordsProcessing;

namespace TagCloud.Sizing;

public class TextTagSizeCalculator : ITextTagSizeCalculator
{
    private const int Padding = 4;
    
    public Size CalculateSize(TextTag tag, string fontName)
    {
        var fontFamily = SystemFonts.Families.FirstOrDefault(f => f.Name == fontName);

        var font = fontFamily.CreateFont(tag.FontSize);
        
        var measured = TextMeasurer.MeasureSize(tag.Word, new RichTextOptions(font));
        
        var metrics = font.FontMetrics;
        var lineHeight = (float)metrics.VerticalMetrics.LineHeight / metrics.UnitsPerEm * font.Size;

        var width = (int)Math.Ceiling(measured.Width) + Padding * 2;
        var height = (int)Math.Ceiling(lineHeight) + Padding * 2;

        return new Size(width, height);
    }
}