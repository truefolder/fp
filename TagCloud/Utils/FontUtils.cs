using SixLabors.Fonts;
using TagCloud.ResultModel;

namespace TagCloud.Utils;

public static class FontUtils
{
    public static Result<FontFamily> TryGetFontFamily(string fontName)
    {
        if (string.IsNullOrWhiteSpace(fontName))
            return Result.Fail<FontFamily>("Font name cannot be empty.");
        
        var family = SystemFonts.Families.FirstOrDefault(f => f.Name == fontName);
        
        return family == default 
            ? Result.Fail<FontFamily>($"Font '{fontName}' not found.") 
            : Result.Ok(family);
    }
}