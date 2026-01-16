using Autofac;
using TagCloud.Client.DI;
using TagCloud.Options;

namespace TagCloud.Client.CLI;

public class Runner
{
    public int Run(CliOptions options)
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule(new TagCloudModule());
        
        var container = builder.Build();

        var tagCloud = container.Resolve<ITagCloudGenerator>();

        var tagCloudOptions = new TagCloudOptions
        {
            InputFilePath = options.InputFilePath,
            BoringWordsFilePath = options.BoringWordsFilePath,
            OutputFilePath = options.OutputFilePath,
            ImageWidth = options.ImageWidth,
            ImageHeight = options.ImageHeight,
            FontName = options.FontName,
            MinFontSize = options.MinFontSize,
            MaxFontSize = options.MaxFontSize,
            ColorizerName = options.ColorizerName,
            Colors = options.Colors,
            GradientFrom = options.GradientFrom,
            GradientTo = options.GradientTo,
            BackgroundColor = options.BackgroundColor
        };

        var result = tagCloud.Generate(tagCloudOptions);

        if (!result.IsSuccess)
        {
            Console.WriteLine(result.Error);
            return 1;
        }

        Console.WriteLine($"Tag cloud saved to {options.OutputFilePath}");
        return 0;
    }
}