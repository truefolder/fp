using TagCloud.ResultModel;

namespace TagCloud.WordsProviders;

public interface IBoringWordsProvider
{
    public Result<HashSet<string>> GetWords(string path);
}