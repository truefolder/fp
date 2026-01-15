using TagCloud.Options;

namespace TagCloud.Colors.Factories;

public interface IWordColorizerFactory
{
    public IWordColorizer Create(TagCloudOptions options);
}