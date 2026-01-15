using FluentAssertions;
using TagCloud.Options;
using TagCloud.WordsProcessing;
using TagCloud.WordsProcessing.Filters;
using TagCloud.WordsProviders;
using TagCloudTests.Utils;

namespace TagCloudTests;

public class WordProcessorTests
{
    [Test]
    public void Process_ShouldNormalizeAndFilterWords_WhenTxtFileProvided()
    {
        var testDir = FilesUtils.CreateTempDir();
        var inputFile = FilesUtils.WriteTextFile(testDir, "test.txt", ["hello", "world"]);
        var boringFile = FilesUtils.WriteTextFile(testDir, "boring.txt", ["world"]);
        var resolver = new WordsProviderResolver([new TxtWordsProvider()]);
        var inputWordsProvider = resolver.GetProvider(inputFile);
        var boringWordsProvider = new BoringWordsProvider(resolver);
        var filterFactory = new WordFilterFactory(boringWordsProvider);
        var normalizer = new WordLowercaser();
        var processor = new WordProcessor(normalizer, filterFactory);
        var options = new TagCloudOptions { BoringWordsFilePath = boringFile };
        
        var processedWords = processor.Process(inputWordsProvider.ReadWords(inputFile), options).ToList();

        processedWords.Should().Contain("hello");
        processedWords.Should().NotContain("world");
    }
}