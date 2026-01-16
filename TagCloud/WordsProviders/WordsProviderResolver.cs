using TagCloud.ResultModel;

namespace TagCloud.WordsProviders;

public class WordsProviderResolver(IEnumerable<IWordsProvider> providers) : IWordsProviderResolver
{
    public Result<IWordsProvider> GetProvider(string path)
    {
        var provider = providers.FirstOrDefault(s => s.CanRead(path).Value);

        if (provider == null)
            return Result.Fail<IWordsProvider>($"Can't find valid words provider for path {path}");
        
        return Result.Ok(provider);
    }
}