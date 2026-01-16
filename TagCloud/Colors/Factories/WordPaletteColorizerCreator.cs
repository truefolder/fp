using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud.Colors.Factories;

public class WordPaletteColorizerCreator(IColorParser parser) : IWordColorizerCreator
{
    public Result<IWordColorizer> Create(TagCloudOptions options)
    {
        var colorsText = options.Colors ?? "#cd5b45,#c51d34,#ffb28b,#cdb891";
        return parser.ParseMany(colorsText)
            .Then(c => Result.Ok<IWordColorizer>(new WordPaletteColorizer(c)))
            .RefineError("Can't create palette colorizer");
    }
}