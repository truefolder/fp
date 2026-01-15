using SixLabors.ImageSharp;

namespace TagCloud.Visualizers;

public interface ITagCloudVisualizer
{
    public void Draw(List<DrawnTag> tags, Size canvasSize, string savePath, string fontName, Color backgroundColor);
}