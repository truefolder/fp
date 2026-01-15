using Autofac.Features.Indexed;
using TagCloud.Options;

namespace TagCloud.Colors.Factories;

public class WordColorizerFactory(IIndex<string, IWordColorizerCreator> creators) : IWordColorizerFactory
{
    public IWordColorizer Create(TagCloudOptions options) =>
        creators[options.ColorizerName].Create(options);
}