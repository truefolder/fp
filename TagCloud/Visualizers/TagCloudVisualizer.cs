using SixLabors.Fonts;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace TagCloud.Visualizers;

public class TagCloudVisualizer : ITagCloudVisualizer
{
    private const int Padding = 4;
    
    public void Draw(List<DrawnTag> tags, Size canvasSize, string savePath, string fontName, Color backgroundColor)
    {
        var image = new Image<Rgba32>(canvasSize.Width, canvasSize.Height);
        image.Mutate(ctx => ctx.Fill(backgroundColor));

        var fontFamily = SystemFonts.Families.FirstOrDefault(f => f.Name == fontName);
        
        foreach (var drawnTag in tags)
        {
            var font = fontFamily.CreateFont(drawnTag.Tag.FontSize);
            var options = new RichTextOptions(font)
            {
                Origin = new PointF(drawnTag.Rectangle.Left + Padding, drawnTag.Rectangle.Top + Padding),
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
            };

            image.Mutate(ctx => ctx.DrawText(options, drawnTag.Tag.Word, drawnTag.Color));
        }
        image.Save(savePath);
    }
}