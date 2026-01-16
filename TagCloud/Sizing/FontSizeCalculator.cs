using TagCloud.ResultModel;
using TagCloud.WordsProcessing;

namespace TagCloud.Sizing;

public class FontSizeCalculator : IFontSizeCalculator
{
    public Result<IEnumerable<TextTag>> CalculateSizes(IEnumerable<WordFrequency> words, float minSize, float maxSize)
    {
        if (minSize <= 0 || maxSize <= 0)
            return Result.Fail<IEnumerable<TextTag>>("Font sizes must be positive.");

        if (minSize > maxSize)
            return Result.Fail<IEnumerable<TextTag>>("MinFontSize must be <= MaxFontSize.");        
        
        var wordFrequencies = words.ToList();
        
        var minCount = wordFrequencies.Min(word => word.Count);
        var maxCount = wordFrequencies.Max(word => word.Count);

        if (minCount != maxCount)
        {
            var tags = wordFrequencies.Select(word =>
            {
                var normalizedFrequency = (float)(word.Count - minCount) / (maxCount - minCount);
                var size = minSize + normalizedFrequency * (maxSize - minSize);
                return new TextTag(word.Word, word.Count, size, normalizedFrequency);
            });
            return Result.Ok(tags);
        }
           
        
        var singleSize = (minSize + maxSize) / 2f;
        return Result.Ok(wordFrequencies.Select(f => new TextTag(f.Word, f.Count, singleSize, 0.5f)));
    }
}