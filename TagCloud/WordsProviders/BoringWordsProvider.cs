namespace TagCloud.WordsProviders;

public class BoringWordsProvider(IWordsProviderResolver wordsProviderResolver) : IBoringWordsProvider
{
    public HashSet<string> GetWords(string path) =>
        wordsProviderResolver.GetProvider(path).ReadWords(path).ToHashSet();
}