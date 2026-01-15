using SixLabors.ImageSharp;

namespace TagCloud.Layouters;

public interface ICircularCloudLayouter
{
    public Rectangle PutNextRectangle(Size rectangleSize);
}