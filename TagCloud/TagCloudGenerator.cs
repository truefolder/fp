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
        return ValidateOptions(options)
            .Then(_ => colorParser.Parse(options.BackgroundColor)
                .RefineError("Invalid background color"))
            .Then(background =>
                colorizerFactory.Create(options).Then(colorizer =>
                    ReadAndPrepareTags(options)
                        .Then(tags => Layout(tags, options, colorizer))
                        .Then(drawnTags => visualizer.Draw(
                                drawnTags,
                                new Size(options.ImageWidth, options.ImageHeight),
                                options.OutputFilePath,
                                options.FontName,
                                background)
                            .RefineError("Can't render/save image"))))
            .RefineError("Tag cloud generation failed");
    }
    
    private Result<List<TextTag>> ReadAndPrepareTags(TagCloudOptions options)
    {
        return wordsProviderResolver.GetProvider(options.InputFilePath)
            .RefineError("Can't select words provider")
            .Then(provider => provider.ReadWords(options.InputFilePath))
                .RefineError("Can't read input file")
            .Then(words => wordProcessor.Process(words, options)
                .RefineError("Can't preprocess words"))
            .Then(processed => frequencyAnalyzer.CalculateFrequencies(processed)
                .RefineError("Can't calculate word frequencies"))
            .Then(frequencies => fontSizeCalculator.CalculateSizes(frequencies, options.MinFontSize, options.MaxFontSize)
                .RefineError("Can't calculate font sizes"))
            .Then(tags => Result.Ok(tags.ToList()));
    }
    
    private Result<List<DrawnTag>> Layout(List<TextTag> tags, TagCloudOptions options, IWordColorizer colorizer)
    {
        return Result.Of(() =>
            {
                var canvasSize = new Size(options.ImageWidth, options.ImageHeight);
                var layouter = layouterFactory.Create(canvasSize);

                var drawn = new List<DrawnTag>(tags.Count);

                foreach (var tag in tags)
                {
                    var sizeRes = tagSizeCalculator.CalculateSize(tag, options.FontName);
                    if (!sizeRes.IsSuccess)
                        return Result.Fail<List<DrawnTag>>(sizeRes.Error);

                    var rectRes = layouter.TryPutNextRectangle(sizeRes.GetValueOrThrow());
                    if (!rectRes.IsSuccess)
                        return Result.Fail<List<DrawnTag>>(rectRes.Error);

                    var rect = rectRes.GetValueOrThrow();
                    var color = colorizer.Colorize(tag);

                    drawn.Add(new DrawnTag(tag, rect, color));
                }

                return Result.Ok(drawn);
            }).Then(x => x)
            .RefineError("Can't layout tags");
    }
    
    private Result<None> ValidateOptions(TagCloudOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.InputFilePath))
            return Result.Fail<None>("InputFilePath is empty.");

        if (string.IsNullOrWhiteSpace(options.OutputFilePath))
            return Result.Fail<None>("OutputFilePath is empty.");

        if (options.ImageWidth <= 0 || options.ImageHeight <= 0)
            return Result.Fail<None>("ImageWidth and ImageHeight must be positive.");

        if (string.IsNullOrWhiteSpace(options.FontName))
            return Result.Fail<None>("FontName is empty.");

        if (options.MinFontSize <= 0 || options.MaxFontSize <= 0)
            return Result.Fail<None>("MinFontSize and MaxFontSize must be positive.");

        if (options.MinFontSize > options.MaxFontSize)
            return Result.Fail<None>("MinFontSize must be <= MaxFontSize.");

        if (string.IsNullOrWhiteSpace(options.BackgroundColor))
            return Result.Fail<None>("BackgroundColorHex is empty.");

        return Result.Ok();
    }
}