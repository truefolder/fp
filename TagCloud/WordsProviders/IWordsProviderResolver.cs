namespace TagCloud.WordsProviders;

public interface IWordsProviderResolver
{
    IWordsProvider GetProvider(string path);
}