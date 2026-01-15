using TagCloud.Options;

namespace TagCloud.Colors.Factories;

public class WordSingleColorizerCreator(IColorParser parser) : IWordColorizerCreator
{
    public IWordColorizer Create(TagCloudOptions options)
    {
        var colorText = options.Colors ?? "#cd5b45";
        var color = parser.Parse(colorText);
        
        return new WordSingleColorizer(color);
    }
}