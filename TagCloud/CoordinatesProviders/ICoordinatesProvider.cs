using SixLabors.ImageSharp;
using TagCloud.ResultModel;

namespace TagCloud.CoordinatesProviders;

public interface ICoordinatesProvider
{
    public IEnumerable<PointF> GetPoints();
}