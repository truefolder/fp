namespace TagCloud.WordsProviders;

public class WordsProviderResolver(IEnumerable<IWordsProvider> providers) : IWordsProviderResolver
{
    public IWordsProvider GetProvider(string path)
        => providers.First(s => s.CanRead(path));
}