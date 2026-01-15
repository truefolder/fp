using TagCloud.Options;

namespace TagCloud;

public interface ITagCloudGenerator
{
    public void Generate(TagCloudOptions options);
}