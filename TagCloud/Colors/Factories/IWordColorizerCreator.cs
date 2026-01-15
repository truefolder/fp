using TagCloud.Options;

namespace TagCloud.Colors.Factories;

public interface IWordColorizerCreator
{
    public IWordColorizer Create(TagCloudOptions options);
}