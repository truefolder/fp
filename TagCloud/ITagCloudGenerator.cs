using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud;

public interface ITagCloudGenerator
{
    public Result<None> Generate(TagCloudOptions options);
}