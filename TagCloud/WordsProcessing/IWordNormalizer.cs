using TagCloud.ResultModel;

namespace TagCloud.WordsProcessing;

public interface IWordNormalizer
{
    public string Normalize(string word);
}