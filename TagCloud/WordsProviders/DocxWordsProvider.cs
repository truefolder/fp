using System.Text;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace TagCloud.WordsProviders;

public class DocxWordsProvider : IWordsProvider
{
    public bool CanRead(string path) =>
        Path.GetExtension(path) == ".docx";

    public IEnumerable<string> ReadWords(string path)
    {
        using var doc = WordprocessingDocument.Open(path, false);

        var body = doc.MainDocumentPart?.Document.Body;
        if (body is null)
            return [];

        var sb = new StringBuilder();

        foreach (var paragraph in body.Descendants<Paragraph>())
        {
            AppendParagraphText(sb, paragraph);
            sb.Append(' ');
        }

        return sb.ToString().Split(' ');
    }

    private void AppendParagraphText(StringBuilder sb, Paragraph paragraph)
    {
        foreach (var element in paragraph.Descendants())
        {
            switch (element)
            {
                case Text t:
                    sb.Append(t.Text);
                    break;

                case TabChar:
                case Break:
                    sb.Append(' ');
                    break;
            }
        }
    }
}