using CommandLine;

namespace TagCloud.Client.CLI;

public class CliOptions
{
    [Option("inputFile")] 
    public string InputFilePath { get; set; } = null!;

    [Option("boringWordsFile")] 
    public string BoringWordsFilePath { get; set; } = null!;

    [Option("outputFile")]
    public string OutputFilePath { get; set; } = "tagcloud.png";

    [Option("width")] 
    public int ImageWidth { get; set; } = 1920;

    [Option("height")] 
    public int ImageHeight { get; set; } = 1080;

    [Option("font")]
    public string FontName { get; set; } = "Arial";

    [Option("min-font-size")] 
    public float MinFontSize { get; set; } = 10;

    [Option("max-font-size")] 
    public float MaxFontSize { get; set; } = 60;
    
    [Option("colorizer")]
    public string ColorizerName { get; set; } = "gradient";
    
    [Option("colors")] 
    public string Colors { get; set; } = "#ff0000";
    
    [Option("background-color")]
    public string BackgroundColor { get; set; } = "#000000";

    [Option("gradient-from")] 
    public string GradientFrom { get; set; } = "#ff0000";
    
    [Option("gradient-to")]
    public string GradientTo { get; set; } = "#000000";
}