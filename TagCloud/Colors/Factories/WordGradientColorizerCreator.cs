using TagCloud.Options;

namespace TagCloud.Colors.Factories;

public class WordGradientColorizerCreator(IColorParser parser) : IWordColorizerCreator
{
    public IWordColorizer Create(TagCloudOptions options)
    {
        var colorFrom = parser.Parse(options.GradientFrom ?? "#ff0000");
        var colorTo = parser.Parse(options.GradientTo ?? "#000000");
        
        return new WordGradientColorizer(colorFrom, colorTo);
    }
}