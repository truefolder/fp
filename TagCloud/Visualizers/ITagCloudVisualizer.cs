using SixLabors.ImageSharp;
using TagCloud.ResultModel;

namespace TagCloud.Visualizers;

public interface ITagCloudVisualizer
{
    public Result<None> Draw(List<DrawnTag> tags, Size canvasSize, string savePath, string fontName, Color backgroundColor);
}