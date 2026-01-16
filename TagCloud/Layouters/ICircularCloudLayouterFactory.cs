using SixLabors.ImageSharp;
using TagCloud.ResultModel;

namespace TagCloud.Layouters;

public interface ICircularCloudLayouterFactory
{
    public Result<ICircularCloudLayouter> Create(Size canvasSize);
}