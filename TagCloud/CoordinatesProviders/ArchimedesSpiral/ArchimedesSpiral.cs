using SixLabors.ImageSharp;
using TagCloud.ResultModel;

namespace TagCloud.CoordinatesProviders.ArchimedesSpiral;

public class ArchimedesSpiral(PointF center, float tightness, float distanceBetweenPoints) : ICoordinatesProvider
{
    public IEnumerable<PointF> GetPoints() =>
        new ArchimedesSpiralEnumerable(center, tightness, distanceBetweenPoints);
}