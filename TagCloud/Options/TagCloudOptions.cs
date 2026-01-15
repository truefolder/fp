namespace TagCloud.Options;

public class TagCloudOptions
{
    public string InputFilePath { get; set; } = null!;
    public string BoringWordsFilePath { get; set; } = null!;
    public string OutputFilePath { get; set; } = "tagcloud.png";

    public int ImageWidth { get; set; } = 1920;
    public int ImageHeight { get; set; } = 1080;

    public string FontName { get; set; } = "Arial";
    public float MinFontSize { get; set; } = 10;
    public float MaxFontSize { get; set; } = 60;
    
    public string ColorizerName { get; set; } = "gradient";
    public string? Colors { get; set; }
    public string BackgroundColor { get; set; } = "#000000";
    public string? GradientFrom { get; set; }
    public string? GradientTo { get; set; }
}