using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud.Colors.Factories;

public class WordGradientColorizerCreator(IColorParser parser) : IWordColorizerCreator
{
    public Result<IWordColorizer> Create(TagCloudOptions options)
    {
        var fromRaw = options.GradientFrom ?? "#1E3A8A";
        var toRaw = options.GradientTo ?? "#B91C1C";

        return parser.Parse(fromRaw)
            .Then(from => parser.Parse(toRaw).Then(to =>
                Result.Ok<IWordColorizer>(new WordGradientColorizer(from, to))))
            .RefineError("Can't create gradient colorizer");
    }
}