using FluentAssertions;
using SixLabors.ImageSharp;
using TagCloud.CoordinatesProviders.ArchimedesSpiral;
using TagCloud.Layouters;

namespace TagCloudTests;

public class CircularCloudLayouterTests
{
    private ICircularCloudLayouter _layouter;

    [SetUp]
    public void SetUp()
    {
        var center = new Point(0, 0);
        var provider = new ArchimedesSpiral(center, 1, 1);
        _layouter = new CircularCloudLayouter(center, provider);
    }

    [TestCaseSource(nameof(GetInvalidSizes))]
    public void PutNextRectangle_ShouldThrow_WhenInvalidRectangleSizePresent(Size rectangleSize)
    {
        var action = () => _layouter.TryPutNextRectangle(rectangleSize);
        
        action.Should().Throw<ArgumentException>();
    }
    
    [TestCaseSource(nameof(GetValidSizes))]
    public void PutNextRectangle_RectanglesShouldHaveCorrectSizes_WhenValidSizesPresent(Size rectangleSize)
    {
        var rectangle = _layouter.TryPutNextRectangle(rectangleSize);
        
        rectangle.Width.Should().Be(rectangleSize.Width);
        rectangle.Height.Should().Be(rectangleSize.Height);
    }
    
    [Test]
    public void PutNextRectangle_ShouldNotIntersectWithFirstRectangle_WhenTwoRectanglesAreAlreadyPutted()
    {
        var rectangle1 = _layouter.TryPutNextRectangle(new Size(10, 10));
        var rectangle2 = _layouter.TryPutNextRectangle(new Size(10, 10));
        
        rectangle1.IntersectsWith(rectangle2).Should().BeFalse();
    }

    [Test]
    public void PutNextRectangle_RectanglesShouldNotIntersect_WhenMultipleRectanglesGenerated()
    {
        var rectangles = new List<Rectangle>();
        var random = new Random();

        for (var i = 0; i < 100; i++)
            rectangles.Add(_layouter.TryPutNextRectangle(new Size(random.Next(10, 100), random.Next(10, 100))));
        
        foreach (var firstRectangle in rectangles)
            foreach (var secondRectangle in rectangles.Where(r => firstRectangle != r))
                firstRectangle.IntersectsWith(secondRectangle).Should().BeFalse();
    }

    private static IEnumerable<TestCaseData> GetInvalidSizes()
    {
        yield return new TestCaseData(new Size(-100, 100))
            .SetName("PutNextRectangle_ShouldThrow_WhenWidthIsNegative");
        yield return new TestCaseData(new Size(100, -100))
            .SetName("PutNextRectangle_ShouldThrow_WhenHeightIsNegative");
        yield return new TestCaseData(new Size(-100, -100))
            .SetName("PutNextRectangle_ShouldThrow_WhenBothHeightAndWidthAreNegative");
        yield return new TestCaseData(new Size(0, 100))
            .SetName("PutNextRectangle_ShouldThrow_WhenWidthIsZero");
        yield return new TestCaseData(new Size(100, 0))
            .SetName("PutNextRectangle_ShouldThrow_WhenHeightIsZero");
        yield return new TestCaseData(new Size(-100, 0))
            .SetName("PutNextRectangle_ShouldThrow_WhenWidthIsNegativeAndHeightIsZero");
        yield return new TestCaseData(new Size(0, -100))
            .SetName("PutNextRectangle_ShouldThrow_WhenHeightIsNegativeAndWidthIsZero");
        yield return new TestCaseData(new Size(0, 0))
            .SetName("PutNextRectangle_ShouldThrow_WhenBothWidthAndHeightAreZero");
    }

    private static IEnumerable<TestCaseData> GetValidSizes()
    {
        yield return new TestCaseData(new Size(100, 100));
        yield return new TestCaseData(new Size(1, 1));
        yield return new TestCaseData(new Size(1, 2));
        yield return new TestCaseData(new Size(2, 1));
    }
}