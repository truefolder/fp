namespace TagCloud.WordsProcessing.Filters;

public class BoringWordsFilter(HashSet<string> boringWords) : IWordFilter
{
    public bool IsValid(string word) =>
        !boringWords.Contains(word);
}