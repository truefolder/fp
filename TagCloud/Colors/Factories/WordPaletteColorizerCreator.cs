using TagCloud.Options;

namespace TagCloud.Colors.Factories;

public class WordPaletteColorizerCreator(IColorParser parser) : IWordColorizerCreator
{
    public IWordColorizer Create(TagCloudOptions options)
    {
        var colorsText = options.Colors ?? "#cd5b45,#c51d34,#ffb28b,#cdb891";
        var colors = parser.ParseMany(colorsText);
        
        return new WordPaletteColorizer(colors);
    }
}