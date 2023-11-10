using System.Text.RegularExpressions;

namespace UdtTool.Core
{
    public class DataBlock
    {
        #region Fields

        #endregion

        #region Properties
        public string? Name { get; set; }
        public int Number { get; set; } = 50002;
        public List<Structure> Structures { get; private set; } = new();
        public List<Tag> Tags { get; set; } = new List<Tag>();
        #endregion

        #region Public Methods
        public static DataBlock Load(string path)
        {
            DataBlock dataBlock = new();

            if (string.IsNullOrWhiteSpace(path))
                throw new ArgumentNullException(nameof(path));

            var lines = Standardize(File.ReadAllText(path))
                .Split(Environment.NewLine, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                // 以TYPE开头的行为结构体定义
                if (lines[i].StartsWith("TYPE"))
                {
                    // 获取结构体名称
                    var structure = new Structure { Name = GetTypeName(lines[i]) };
                    // 以END_TYPE结尾的行为结构体定义结束
                    while (!lines[++i].Contains("END_TYPE"))
                    {
                        // 获取标签名称和类型
                        var (varName, varType) = GetTag(lines[i]);
                        switch (varType)
                        {
                            case "Real":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new Real() });
                                break;
                            case "Int":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new Int() });
                                break;
                            case "UInt":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new UInt() });
                                break;
                            case "DInt":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new DInt() });
                                break;
                            case "UDInt":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new UDInt() });
                                break;
                            case "Bool":
                                new Tag { Name = varName }.DataType = new Bool();
                                structure.Tags.Add(new Tag { Name = varName, DataType = new Bool() });
                                break;
                            case "Byte":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new Byte() });
                                break;
                            case "Char":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new Char() });
                                break;
                            case "Word":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new Word() });
                                break;
                            case "DWord":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new DWord() });
                                break;
                            case "Time":
                                structure.Tags.Add(new Tag { Name = varName, DataType = new UDInt() });
                                break;
                            case "Date":
                                throw new NotSupportedException("Date is not supported");
                            default:
                                structure.Tags.Add(
                                    new Tag
                                    {
                                        Name = varName,
                                        DataType = new UDT { Name = varName }
                                    }
                                );
                                break;
                        }
                    }
                    dataBlock.Structures.Add(structure);
                }
                // 以DATA_BLOCK开头的行为数据块定义
                if (lines[i].StartsWith("DATA_BLOCK"))
                {
                    // 获取数据块名称
                    var dbName = GetDbName(lines[i]);
                    // 如果名称为空，则跳过
                    if (string.IsNullOrEmpty(dbName))
                        continue;
                    // 设置数据块名称
                    dataBlock.Name = dbName;
                    // 获取数据块成员
                    while (!lines[++i].Contains("END_DATA_BLOCK"))
                    {
                        // 获取标签名称和类型
                        var (varName, varType) = GetTag(lines[i]);
                        switch (varType)
                        {
                            case "Real":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new Real() });
                                break;
                            case "Int":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new Int() });
                                break;
                            case "UInt":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new UInt() });
                                break;
                            case "DInt":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new DInt() });
                                break;
                            case "UDInt":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new UDInt() });
                                break;
                            case "Bool":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new Bool() });
                                break;
                            case "Byte":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new Byte() });
                                break;
                            case "Char":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new Char() });
                                break;
                            case "Word":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new Word() });
                                break;
                            case "DWord":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new DWord() });
                                break;
                            case "Time":
                                dataBlock.Tags.Add(new Tag { Name = varName, DataType = new UDInt() });
                                break;
                            case "Date":
                                throw new NotSupportedException("Date is not supported");
                            default:
                                dataBlock.Tags.Add(
                                    new Tag
                                    {
                                        Name = varName,
                                        DataType = new UDT { Name = varName }
                                    }
                                );
                                break;
                        }
                    }
                }
            }
            return dataBlock;
        }

        public void AssignAddress() { }

        #endregion

        #region Regex Methods

        /// <summary>
        /// 标准化字符串
        /// </summary>
        private static string Standardize(string s1)
        {
            // 去除无用的字符
            var temp = s1.Replace(";", string.Empty)
                .Replace("VERSION : 0.1", string.Empty)
                .Replace("END_STRUCT", string.Empty)
                .Replace("STRUCT", string.Empty)
                .Replace("{ S7_Optimized_Access := 'FALSE' }", string.Empty)
                .Replace("{ S7_SetPoint := 'True'}", string.Empty)
                .Replace("{ S7_SetPoint := 'False'}", string.Empty)
                .Replace("\"", string.Empty);

            // 去除数据块中初始化的内容
            var (start, end) = (temp.IndexOf("BEGIN"), temp.IndexOf("END_DATA_BLOCK"));
            return temp.Remove(start, end - start);
        }

        /// <summary>
        /// 获取类型名称
        /// </summary>
        private static string GetTypeName(string s1)
        {
            var match = Regex.Match(s1, @"^TYPE\s+(?<name>\w+)", RegexOptions.Compiled);
            var result = match.Groups["name"].Value;
            return result;
        }

        /// <summary>
        /// 获取标签名称和类型
        /// </summary>
        private static (string varName, string varType) GetTag(string s1)
        {
            var match = Regex.Match(s1, @"(?<VarName>\w+)\s+:\s+(?<varType>\w+)", RegexOptions.Compiled);
            var result = (match.Groups["VarName"].Value, match.Groups["varType"].Value);
            return result;
        }

        /// <summary>
        /// 获取数据块名称
        /// </summary>
        /// <param name="s1"></param>
        /// <returns></returns>
        private static string GetDbName(string s1)
        {
            var match = Regex.Match(s1, @"^DATA_BLOCK\s+(?<dbName>\w+)", RegexOptions.Compiled);
            var result = match.Groups["dbName"].Value;
            return result;
        }
        #endregion
    }
}
