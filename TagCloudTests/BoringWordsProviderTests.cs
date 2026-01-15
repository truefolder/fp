using FluentAssertions;
using TagCloud.WordsProviders;
using TagCloudTests.Utils;

namespace TagCloudTests;

public class BoringWordsProviderTests
{
    [Test]
    public void GetWords_ShouldLoadWords_WhenTxtFileProvided()
    {
        var testDir = FilesUtils.CreateTempDir();
        var testFile = FilesUtils.WriteTextFile(testDir, "test.txt", ["hello", "world"]);
        var resolver = new WordsProviderResolver([new TxtWordsProvider()]);
        
        var provider = resolver.GetProvider(testFile);
        
        var words = provider.ReadWords(testFile);
        words.Should().Contain(["hello", "world"]);
    }
}