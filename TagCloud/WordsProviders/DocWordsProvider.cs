using NPOI.HWPF;
using NPOI.HWPF.Extractor;

namespace TagCloud.WordsProviders;

public class DocWordsProvider : IWordsProvider
{
    public bool CanRead(string path) =>
        Path.GetExtension(path) == ".doc";

    public IEnumerable<string> ReadWords(string path)
    {
        using var fs = File.OpenRead(path);
        
        var doc = new HWPFDocument(fs);
        var extractor = new WordExtractor(doc);
        
        var text = extractor.Text ?? string.Empty;
        
        return text.Split(' ', '\n');
    }
}