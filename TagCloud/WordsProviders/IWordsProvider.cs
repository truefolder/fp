namespace TagCloud.WordsProviders;

public interface IWordsProvider
{
    public bool CanRead(string path);
    public IEnumerable<string> ReadWords(string path);
}