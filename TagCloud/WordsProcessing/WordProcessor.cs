using System.Text.RegularExpressions;
using TagCloud.Options;
using TagCloud.ResultModel;
using TagCloud.WordsProcessing.Filters;

namespace TagCloud.WordsProcessing;

public class WordProcessor(IWordNormalizer normalizer, IWordFilterFactory filterFactory) : IWordProcessor
{
    public Result<IEnumerable<string>> Process(IEnumerable<string> words, TagCloudOptions options)
    {
        return filterFactory.Create(options)
            .Then(filter => Result.Of(() =>
            {
                return words.SelectMany(text => Regex.Split(text, @"\P{L}+")) // защита от мусора в docx/doc файлах, сплитим только по небуквенным символам
                    .Select(normalizer.Normalize)
                    .Where(word => !string.IsNullOrWhiteSpace(word))
                    .Where(filter.IsValid);
            })).RefineError("Can't preprocess words");
    }
}