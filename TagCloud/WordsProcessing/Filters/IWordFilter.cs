namespace TagCloud.WordsProcessing.Filters;

public interface IWordFilter
{
    public bool IsValid(string word);
}