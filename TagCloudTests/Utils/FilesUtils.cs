using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace TagCloudTests.Utils;

public static class FilesUtils
{
    public static string CreateTempDir()
    {
        var path = $"{AppDomain.CurrentDomain.BaseDirectory}/testTmp/{TestContext.CurrentContext.Test.Name}";
        Directory.CreateDirectory(path);
        return path;
    }

    public static string WriteTextFile(string dir, string fileName, IEnumerable<string> lines)
    {
        var path = Path.Combine(dir, fileName);
        File.WriteAllLines($"{dir}/{fileName}", lines);
        return path;
    }

    public static string WriteDocxFile(string dir, string fileName, string text)
    {
        var path = Path.Combine(dir, fileName);

        using var doc = WordprocessingDocument.Create(path, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
        var main = doc.AddMainDocumentPart();
        main.Document = new Document(new Body(new Paragraph(new Run(new Text(text)))));

        main.Document.Save();
        return path;
    }
}