using TagCloud.Options;

namespace TagCloud.WordsProcessing.Filters;

public interface IWordFilterFactory
{
    IWordFilter Create(TagCloudOptions options);
}