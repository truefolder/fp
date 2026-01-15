using SixLabors.ImageSharp;
using TagCloud.CoordinatesProviders.ArchimedesSpiral;

namespace TagCloud.Layouters;

public class CircularCloudLayouterFactory(float tightness, float distanceBetweenPoints) : ICircularCloudLayouterFactory
{
    public CircularCloudLayouterFactory() : this(3, 1)
    {
    }
    
    public ICircularCloudLayouter Create(Size canvasSize)
    {
        var center = new Point(canvasSize.Width / 2, canvasSize.Height / 2);
        var coordinatesProvider = new ArchimedesSpiral(
            new PointF(center.X, center.Y),
            tightness,
            distanceBetweenPoints);

        return new CircularCloudLayouter(center, coordinatesProvider);
    }
}