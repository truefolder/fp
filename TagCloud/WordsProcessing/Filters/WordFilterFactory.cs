using TagCloud.Options;
using TagCloud.WordsProviders;

namespace TagCloud.WordsProcessing.Filters;

public class WordFilterFactory(IBoringWordsProvider boringWordsProvider) : IWordFilterFactory
{
    public IWordFilter Create(TagCloudOptions options) =>
        new BoringWordsFilter(boringWordsProvider.GetWords(options.BoringWordsFilePath));
}