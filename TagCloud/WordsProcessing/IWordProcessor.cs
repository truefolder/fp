using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud.WordsProcessing;

public interface IWordProcessor
{
    public Result<IEnumerable<string>> Process(IEnumerable<string> words, TagCloudOptions options);
}