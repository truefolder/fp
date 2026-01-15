using FluentAssertions;
using SixLabors.ImageSharp;
using TagCloud.Visualizers;
using TagCloud.WordsProcessing;

namespace TagCloudTests;

public class TagCloudVisualizerTests
{
    private ITagCloudVisualizer _visualizer = new TagCloudVisualizer();
    
    [Test]
    public void Draw_ShouldSavePngImageInPath_WhenCorrectPathIsProvided()
    {
        var items = new List<DrawnTag>
        {
            new(new TextTag("Hello world!", 10, 30, 0.5f), new Rectangle(100, 100, 200, 100), Color.Black),
        };

        var savePath =
            $"{AppDomain.CurrentDomain.BaseDirectory}/{nameof(Draw_ShouldSavePngImageInPath_WhenCorrectPathIsProvided)}.png";
        
        _visualizer.Draw(items, new Size(1920, 1080), 
            savePath, "Arial", Color.White);

        File.Exists(savePath).Should().Be(true);
    }
    
    [Test]
    public void Draw_ShouldSaveJpgImageInPath_WhenCorrectPathIsProvided()
    {
        var items = new List<DrawnTag>
        {
            new(new TextTag("Hello world!", 10, 30, 0.5f), new Rectangle(100, 100, 200, 100), Color.Black),
        };

        var savePath =
            $"{AppDomain.CurrentDomain.BaseDirectory}/{nameof(Draw_ShouldSaveJpgImageInPath_WhenCorrectPathIsProvided)}.jpg";
        
        _visualizer.Draw(items, new Size(1920, 1080), 
            savePath, "Arial", Color.White);

        File.Exists(savePath).Should().Be(true);
    }
}