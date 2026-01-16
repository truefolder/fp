using TagCloud.ResultModel;

namespace TagCloud.WordsProviders;

public class BoringWordsProvider(IWordsProviderResolver wordsProviderResolver) : IBoringWordsProvider
{
    public Result<HashSet<string>> GetWords(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Result.Fail<HashSet<string>>("Boring words path is empty.");

        return wordsProviderResolver.GetProvider(path)
            .Then(provider => provider.ReadWords(path).ToHashSet())
            .RefineError($"Can't read boring words from path {path}");
    }
}