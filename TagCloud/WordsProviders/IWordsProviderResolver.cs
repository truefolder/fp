using TagCloud.ResultModel;

namespace TagCloud.WordsProviders;

public interface IWordsProviderResolver
{
    public Result<IWordsProvider> GetProvider(string path);
}