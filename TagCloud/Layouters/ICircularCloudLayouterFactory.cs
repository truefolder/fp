using SixLabors.ImageSharp;

namespace TagCloud.Layouters;

public interface ICircularCloudLayouterFactory
{
    ICircularCloudLayouter Create(Size canvasSize);
}