namespace TagCloud.WordsProviders;

public class TxtWordsProvider : IWordsProvider
{
    public bool CanRead(string path) =>
        Path.GetExtension(path) == ".txt";

    public IEnumerable<string> ReadWords(string path) =>
        File.ReadLines(path);
}