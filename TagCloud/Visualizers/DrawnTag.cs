using SixLabors.ImageSharp;
using TagCloud.WordsProcessing;

namespace TagCloud.Visualizers;

public record DrawnTag(TextTag Tag, Rectangle Rectangle, Color Color);