using SixLabors.ImageSharp;
using TagCloud.CoordinatesProviders;
using TagCloud.ResultModel;
using TagCloud.Utils;

namespace TagCloud.Layouters;

public class CircularCloudLayouter(Point center, ICoordinatesProvider coordinatesProvider) : ICircularCloudLayouter
{
    public readonly List<Rectangle> Rectangles = [];
    private readonly IEnumerator<PointF> _pointsEnumerator = coordinatesProvider.GetPoints().GetEnumerator();
    
    public Result<Rectangle> TryPutNextRectangle(Size rectangleSize)
    {
        return ValidateSize(rectangleSize)
            .Then(_ => GetNextRectanglePoint(rectangleSize))
            .Then(location =>
            {
                var rect = new Rectangle(location, rectangleSize);
                var shifted = RectangleUtils.ShiftToCenter(rect, center, Rectangles);

                Rectangles.Add(shifted);
                return Result.Ok(shifted);
            });
    }

    private Result<None> ValidateSize(Size size)
    {
        if (size.Width <= 0 || size.Height <= 0)
            return Result.Fail<None>($"Invalid rectangle size: {size.Width}x{size.Height}. Both must be > 0.");

        return Result.Ok();
    }
    
    private Result<Point> GetNextRectanglePoint(Size rectangleSize)
    {
        return Result.Of(() =>
        {
            while (_pointsEnumerator.MoveNext())
            {
                var point = Point.Round(_pointsEnumerator.Current);

                var possibleValidPoint =
                    new Point(point.X - rectangleSize.Width / 2, point.Y - rectangleSize.Height / 2);
                var possibleValidRectangle = new Rectangle(possibleValidPoint, rectangleSize);
                var isIntersects = Rectangles.Any(existingRectangle =>
                    possibleValidRectangle.IntersectsWith(existingRectangle));

                if (!isIntersects)
                    return possibleValidPoint;
            }

            return Result.Fail<Point>(
                $"Can't find valid point for next rectangle with width: {rectangleSize.Width} and height: {rectangleSize.Height}");
        }).Then(x => x);
    }
}