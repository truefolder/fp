using TagCloud.Options;

namespace TagCloud.WordsProcessing;

public interface IWordProcessor
{
    public IEnumerable<string> Process(IEnumerable<string> words, TagCloudOptions options);
}