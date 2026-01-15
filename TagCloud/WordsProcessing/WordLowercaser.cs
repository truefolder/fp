namespace TagCloud.WordsProcessing;

public class WordLowercaser : IWordNormalizer
{
    public string Normalize(string word) =>
        word.ToLower();
}