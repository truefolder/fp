using SixLabors.ImageSharp;
using TagCloud.ResultModel;

namespace TagCloud.Layouters;

public interface ICircularCloudLayouterFactory
{
    public ICircularCloudLayouter Create(Size canvasSize);
}