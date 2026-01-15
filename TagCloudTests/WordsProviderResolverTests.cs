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

        resolver.GetProvider(testFile).GetType().Should().Be(typeof(TxtWordsProvider));
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

        resolver.GetProvider(testFile).GetType().Should().Be(typeof(DocxWordsProvider));
    }
}