using TagCloud.Options;
using TagCloud.ResultModel;

namespace TagCloud.WordsProcessing.Filters;

public interface IWordFilterFactory
{ 
    Result<IWordFilter> Create(TagCloudOptions options);
}