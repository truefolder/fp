using System.Collections;
using SixLabors.ImageSharp;
using TagCloud.Utils;

namespace TagCloud.CoordinatesProviders.ArchimedesSpiral;

public class ArchimedesSpiralEnumerator(PointF center, float tightness, float distanceBetweenPoints) : IEnumerator<PointF>
{
    public PointF Current { get; private set; }
    object IEnumerator.Current => Current;
    private float _degree;
    
    public bool MoveNext()
    {
        var degreeStep = distanceBetweenPoints * MathF.PI / 180f;
        var radius = tightness * _degree;

        var coords = PolarCoordinatesUtils.ConvertPolarCoordsToCartesian(radius, _degree);

        Current = new PointF(coords.x + center.X, coords.y + center.Y);

        _degree += degreeStep;
        return true;
    }

    public void Reset()
    {
        _degree = 0f;
    }

    public void Dispose()
    {
        
    }
}