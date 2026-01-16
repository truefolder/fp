using TagCloud.ResultModel;

namespace TagCloud.WordsProviders;

public interface IWordsProvider
{
    public Result<bool> CanRead(string path);
    public Result<IEnumerable<string>> ReadWords(string path);
}