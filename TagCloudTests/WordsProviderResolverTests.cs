using FluentAssertions;
using TagCloud.WordsProviders;
using TagCloudTests.Utils;

namespace TagCloudTests;

public class WordsProviderResolverTests
{
    [Test]
    public void Resolve_ShouldPickTxtProvider_WhenTxtFileProvided()
    {
        var testDir = FilesUtils.CreateTempDir();
        var testFile = FilesUtils.WriteTextFile(testDir, "test.txt", ["hello", "world"]);
        var resolver = new WordsProviderResolver([
            new TxtWordsProvider(),
            new DocxWordsProvider(),
            new DocxWordsProvider()
        ]);

        var result = resolver.GetProvider(testFile);
        
        result.IsSuccess.Should().BeTrue();
        
        result.GetValueOrThrow().GetType().Should().Be(typeof(TxtWordsProvider));
    }
    
    [Test]
    public void Resolve_ShouldPickDocxProvider_WhenDocxFileProvided()
    {
        var testDir = FilesUtils.CreateTempDir();
        var testFile = FilesUtils.WriteDocxFile(testDir, "test.docx", "hello\nworld");
        var resolver = new WordsProviderResolver([
            new TxtWordsProvider(),
            new DocxWordsProvider(),
            new DocxWordsProvider()
        ]);
        
        var result = resolver.GetProvider(testFile);
        
        result.IsSuccess.Should().BeTrue();
        
        result.GetValueOrThrow().GetType().Should().Be(typeof(DocxWordsProvider));
    }
}