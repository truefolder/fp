using Autofac;
using TagCloud.Colors;
using TagCloud.Colors.Factories;
using TagCloud.Layouters;
using TagCloud.Sizing;
using TagCloud.Visualizers;
using TagCloud.WordsProcessing;
using TagCloud.WordsProcessing.Filters;
using TagCloud.WordsProviders;

namespace TagCloud.Client.DI;

public class TagCloudModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<WordsProviderResolver>().As<IWordsProviderResolver>().SingleInstance();
        builder.RegisterType<TxtWordsProvider>().As<IWordsProvider>().SingleInstance();
        builder.RegisterType<DocWordsProvider>().As<IWordsProvider>().SingleInstance();
        builder.RegisterType<DocxWordsProvider>().As<IWordsProvider>().SingleInstance();
        builder.RegisterType<WordLowercaser>()
            .As<IWordNormalizer>()
            .SingleInstance();
        builder.RegisterType<BoringWordsProvider>()
            .As<IBoringWordsProvider>()
            .SingleInstance();
        builder.RegisterType<WordFilterFactory>()
            .As<IWordFilterFactory>()
            .SingleInstance();
        builder.RegisterType<WordProcessor>()
            .As<IWordProcessor>()
            .SingleInstance();
        builder.RegisterType<FrequencyCounter>()
            .As<IFrequencyCounter>()
            .SingleInstance();
        builder.RegisterType<FontSizeCalculator>()
            .As<IFontSizeCalculator>()
            .SingleInstance();
        builder.RegisterType<TextTagSizeCalculator>()
            .As<ITextTagSizeCalculator>()
            .SingleInstance();
        builder.RegisterType<CircularCloudLayouterFactory>()
            .As<ICircularCloudLayouterFactory>()
            .SingleInstance();
        builder.RegisterType<WordColorizerFactory>()
            .As<IWordColorizerFactory>()
            .SingleInstance();
        builder.RegisterType<WordSingleColorizerCreator>()
            .Keyed<IWordColorizerCreator>("single")
            .SingleInstance();
        builder.RegisterType<WordPaletteColorizerCreator>()
            .Keyed<IWordColorizerCreator>("palette")
            .SingleInstance();
        builder.RegisterType<WordGradientColorizerCreator>()
            .Keyed<IWordColorizerCreator>("gradient")
            .SingleInstance();
        builder.RegisterType<HexColorParser>()
            .As<IColorParser>()
            .SingleInstance();
        builder.RegisterType<TagCloudVisualizer>()
            .As<ITagCloudVisualizer>()
            .SingleInstance();
        builder.RegisterType<TagCloudGenerator>()
            .As<ITagCloudGenerator>()
            .InstancePerDependency();
    }
}