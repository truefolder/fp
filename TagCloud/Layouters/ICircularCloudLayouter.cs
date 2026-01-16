using SixLabors.ImageSharp;
using TagCloud.ResultModel;

namespace TagCloud.Layouters;

public interface ICircularCloudLayouter
{
    public Result<Rectangle> TryPutNextRectangle(Size rectangleSize);
}