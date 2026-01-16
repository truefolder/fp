using TagCloud.ResultModel;

namespace TagCloud.WordsProcessing;

public interface IWordNormalizer
{
    public Result<string> Normalize(string word);
}