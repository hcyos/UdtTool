using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace UdtTool.Core.TiaPortalModels
{
    public class UserDefinedTypeModel
    {
        public string? Name { get; set; }
        public string? Version { get; set; }
        public Collection<TagModel> Tags { get; set; } = [];
        public string? Comment { get; set; }
    }
}
