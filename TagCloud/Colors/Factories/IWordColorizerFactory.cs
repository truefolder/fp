using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud.Colors.Factories;

public interface IWordColorizerFactory
{
    public Result<IWordColorizer> Create(TagCloudOptions options);
}