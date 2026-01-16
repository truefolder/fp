using SixLabors.ImageSharp;
using TagCloud.ResultModel;

namespace TagCloud.Colors;

public interface IColorParser
{
    public Result<Color> Parse(string color);
    public Result<List<Color>> ParseMany(string colors);
}