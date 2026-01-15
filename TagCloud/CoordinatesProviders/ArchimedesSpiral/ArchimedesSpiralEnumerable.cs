using System.Collections;
using SixLabors.ImageSharp;

namespace TagCloud.CoordinatesProviders.ArchimedesSpiral;

public class ArchimedesSpiralEnumerable(PointF center, float tightness, float distanceBetweenPoints) : IEnumerable<PointF>
{
    public IEnumerator<PointF> GetEnumerator()
        => new ArchimedesSpiralEnumerator(center, tightness, distanceBetweenPoints);

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}