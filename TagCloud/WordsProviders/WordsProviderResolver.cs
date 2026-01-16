using TagCloud.ResultModel;

namespace TagCloud.WordsProviders;

public class WordsProviderResolver(IEnumerable<IWordsProvider> providers) : IWordsProviderResolver
{
    public Result<IWordsProvider> GetProvider(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return Result.Fail<IWordsProvider>("Input file path is empty");

        if (!File.Exists(path))
            return Result.Fail<IWordsProvider>($"Input file not found: {path}");

        var provider = providers.FirstOrDefault(p => p.CanRead(path));

        if (provider is null)
            return Result.Fail<IWordsProvider>(
                $"Unsupported input format '{Path.GetExtension(path)}'. Supported: .txt, .doc, .docx");

        return Result.Ok(provider);
    }
}