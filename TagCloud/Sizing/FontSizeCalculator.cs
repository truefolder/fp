using TagCloud.WordsProcessing;

namespace TagCloud.Sizing;

public class FontSizeCalculator : IFontSizeCalculator
{
    public IEnumerable<TextTag> CalculateSizes(IEnumerable<WordFrequency> words, float minSize, float maxSize)
    {
        var wordFrequencies = words.ToList();
        
        var minCount = wordFrequencies.Min(word => word.Count);
        var maxCount = wordFrequencies.Max(word => word.Count);
        
        if (minCount != maxCount)
            return wordFrequencies.Select(word =>
            {
                var normalizedFrequency = (float)(word.Count - minCount) / (maxCount - minCount);
                var size = minSize + normalizedFrequency * (maxSize - minSize);
                return new TextTag(word.Word, word.Count, size, normalizedFrequency);
            });
        
        var singleSize = (minSize + maxSize) / 2f;
        return wordFrequencies.Select(f => new TextTag(f.Word, f.Count, singleSize, 0.5f));
    }
}