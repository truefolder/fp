using SixLabors.ImageSharp;
using TagCloud.ResultModel;

namespace TagCloud.Colors;

public class HexColorParser : IColorParser
{
    public Result<Color> Parse(string color)
    {
        if (string.IsNullOrWhiteSpace(color))
            return Result.Fail<Color>("Color cannot be null or empty");        
        
        if (!Color.TryParse(color, out Color colorResult))
            return Result.Fail<Color>($"Invalid color {color}");

        return Result.Ok(colorResult);
    }

    public Result<List<Color>> ParseMany(string colors)
    { 
        var parts = colors.Split(',');
        
        if (parts.Length == 0)
            return Result.Fail<List<Color>>($"Colors cannot be empty");
        
        var colorList = new List<Color>();
        foreach (var part in parts)
        {
            var color = Parse(part);
            if (!color.IsSuccess)
                return Result.Fail<List<Color>>(color.Error);
            colorList.Add(color.GetValueOrThrow());
        }
        
        return Result.Ok(colorList);
    }
}