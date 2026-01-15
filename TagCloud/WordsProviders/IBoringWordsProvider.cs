namespace TagCloud.WordsProviders;

public interface IBoringWordsProvider
{
    public HashSet<string> GetWords(string path);
}