using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud.Colors.Factories;

public class WordSingleColorizerCreator(IColorParser parser) : IWordColorizerCreator
{
    public Result<IWordColorizer> Create(TagCloudOptions options)
    {
        var colorText = options.Colors ?? "#cd5b45";
        return parser.Parse(colorText)
            .Then(c => Result.Ok<IWordColorizer>(new WordSingleColorizer(c)))
            .RefineError("Can't create single colorizer");
    }
}