using Autofac;
using FluentAssertions;
using TagCloud;
using TagCloud.Client.DI;
using TagCloud.Colors;
using TagCloud.Colors.Factories;
using TagCloud.Layouters;
using TagCloud.Sizing;
using TagCloud.Visualizers;
using TagCloud.WordsProcessing;
using TagCloud.WordsProviders;

namespace TagCloudTests;

public class DiTests
{
    [Test]
    public void Build_ShouldResolveTypes()
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule(new TagCloudModule());

        using var container = builder.Build();
        
        container.Resolve<ITagCloudGenerator>().Should().NotBeNull();
        container.Resolve<IWordsProviderResolver>().Should().NotBeNull();
        container.Resolve<IWordProcessor>().Should().NotBeNull();
        container.Resolve<IFrequencyCounter>().Should().NotBeNull();
        container.Resolve<IFontSizeCalculator>().Should().NotBeNull();
        container.Resolve<ITextTagSizeCalculator>().Should().NotBeNull();
        container.Resolve<ICircularCloudLayouterFactory>().Should().NotBeNull();
        container.Resolve<ITagCloudVisualizer>().Should().NotBeNull();
        container.Resolve<IWordColorizerFactory>().Should().NotBeNull();
        container.Resolve<IColorParser>().Should().NotBeNull();
        container.Resolve<IWordsProvider>().Should().NotBeNull();
        container.Resolve<IWordNormalizer>().Should().NotBeNull();
    }

    [Test]
    public void Build_ShouldResolveKeyedTypes()
    {
        var builder = new ContainerBuilder();
        builder.RegisterModule(new TagCloudModule());

        using var container = builder.Build();
        
        container.ResolveKeyed<IWordColorizerCreator>("single").Should().NotBeNull();
        container.ResolveKeyed<IWordColorizerCreator>("palette").Should().NotBeNull();
        container.ResolveKeyed<IWordColorizerCreator>("gradient").Should().NotBeNull();
    }
}