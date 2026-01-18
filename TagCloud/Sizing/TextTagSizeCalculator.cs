using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using TagCloud.ResultModel;
using TagCloud.Utils;
using TagCloud.WordsProcessing;

namespace TagCloud.Sizing;

public class TextTagSizeCalculator : ITextTagSizeCalculator
{
    private const int Padding = 4;
    
    public Result<Size> CalculateSize(TextTag tag, string fontName)
    {
        if (tag.FontSize <= 0)
            return Result.Fail<Size>($"Invalid font size {tag.FontSize} for word {tag.Word}.");

        var fontFamily = FontUtils.TryGetFontFamily(fontName);
        
        if (!fontFamily.IsSuccess)
            return Result.Fail<Size>(fontFamily.Error);
        
        var font = fontFamily.GetValueOrThrow().CreateFont(tag.FontSize);

        var measured = TextMeasurer.MeasureSize(tag.Word, new RichTextOptions(font));

        var metrics = font.FontMetrics;
        var lineHeight = (float)metrics.VerticalMetrics.LineHeight / metrics.UnitsPerEm * font.Size;

        var width = (int)Math.Ceiling(measured.Width) + Padding * 2;
        var height = (int)Math.Ceiling(lineHeight) + Padding * 2;

        if (width <= 0 || height <= 0)
            return Result.Fail<Size>($"Failed to measure text size for {tag.Word}. Width and height must be greater than zero.");

        return new Size(width, height);
    }
}