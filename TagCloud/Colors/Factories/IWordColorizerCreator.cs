using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud.Colors.Factories;

public interface IWordColorizerCreator
{
    public Result<IWordColorizer> Create(TagCloudOptions options);
}