using Autofac.Features.Indexed;
using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud.Colors.Factories;

public class WordColorizerFactory(IIndex<string, IWordColorizerCreator> creators) : IWordColorizerFactory
{
    public Result<IWordColorizer> Create(TagCloudOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.ColorizerName))
            return Result.Fail<IWordColorizer>("Colorizer name not specified");
            
        if (!creators.TryGetValue(options.ColorizerName, out var creator))
            return Result.Fail<IWordColorizer>($"Colorizer {options.ColorizerName} not found");

        return creator.Create(options)
            .Then(Result.Ok);
    }
}