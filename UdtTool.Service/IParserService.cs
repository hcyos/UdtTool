using UdtTool.Core.TiaPortalModels;

namespace UdtTool.Service
{
    public interface IParserService
    {
        DataBlockModel ParseDataBlocks(string content);
    }
}
