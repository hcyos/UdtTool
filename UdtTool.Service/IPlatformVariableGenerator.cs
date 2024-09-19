using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdtTool.Core.TiaPortalModels;

namespace UdtTool.Service
{
    public interface IPlatformVariableGenerator
    {
        void GenerateVariables(DataBlockModel dataBlock, string Connection, string filePath);
    }
}
