using TagCloud.Options;
using TagCloud.ResultModel;
using TagCloud.WordsProviders;

namespace TagCloud.WordsProcessing.Filters;

public class WordFilterFactory(IBoringWordsProvider boringWordsProvider) : IWordFilterFactory
{
    public Result<IWordFilter> Create(TagCloudOptions options)
    {
        return boringWordsProvider.GetWords(options.BoringWordsFilePath)
            .Then(words => Result.Ok<IWordFilter>(new BoringWordsFilter(words)))
            .RefineError("Can't create word filter");
    }
}