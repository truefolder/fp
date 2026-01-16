using SixLabors.ImageSharp;
using TagCloud.Colors;
using TagCloud.Colors.Factories;
using TagCloud.Layouters;
using TagCloud.Options;
using TagCloud.ResultModel;
using TagCloud.Sizing;
using TagCloud.Visualizers;
using TagCloud.WordsProcessing;
using TagCloud.WordsProviders;

namespace TagCloud;

public class TagCloudGenerator(IWordsProviderResolver wordsProviderResolver,
    IWordProcessor wordProcessor,
    IFrequencyCounter frequencyAnalyzer,
    IFontSizeCalculator fontSizeCalculator,
    ITextTagSizeCalculator tagSizeCalculator,
    ICircularCloudLayouterFactory layouterFactory,
    IWordColorizerFactory colorizerFactory,
    ITagCloudVisualizer visualizer,
    IColorParser colorParser) : ITagCloudGenerator
{
    public Result<None> Generate(TagCloudOptions options)
    {
        var canvasSize = new Size(options.ImageWidth, options.ImageHeight);
        
        var colorizer = colorizerFactory.Create(options);
        var wordsProvider = wordsProviderResolver.GetProvider(options.InputFilePath);
        var words = wordsProvider.ReadWords(options.InputFilePath);
        var processed = wordProcessor.Process(words, options);
        var frequencies = frequencyAnalyzer.CalculateFrequencies(processed);
        var tags = fontSizeCalculator.CalculateSizes(frequencies, options.MinFontSize, options.MaxFontSize).ToList();

        var layouter = layouterFactory.Create(canvasSize);

        var drawnTags = new List<DrawnTag>();
        foreach (var tag in tags)
        {
            var size = tagSizeCalculator.CalculateSize(tag, options.FontName);
            var rect = layouter.TryPutNextRectangle(size);
            var color = colorizer.Colorize(tag);
            drawnTags.Add(new DrawnTag(tag, rect, color));
        }

        visualizer.Draw(drawnTags, canvasSize, options.OutputFilePath, options.FontName, colorParser.Parse(options.BackgroundColor));
    }
}