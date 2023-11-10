using System;

namespace UdtTool.Core
{
    public class PLCAddress
    {
        private int dbNumber;
        private int startByte;
        private int bitNumber;
        private VarType varType;

        public int DBNumber
        {
            get => dbNumber;
            set => dbNumber = value;
        }
        public int StartByte
        {
            get => startByte;
            set => startByte = value;
        }

        public int BitNumber
        {
            get => bitNumber;
            set => bitNumber = value;
        }

        public VarType VarType
        {
            get => varType;
            set => varType = value;
        }

        public PLCAddress() { }

        public string ToAddress()
        {
            switch (VarType)
            {
                case VarType.Bit:
                    return $"DB{DBNumber}.DB{StartByte}.{BitNumber}";
                case VarType.Byte:
                    return $"DB{DBNumber}.DB{StartByte}";
                case VarType.Word:
                    return $"DB{DBNumber}.DBW{StartByte}";
                case VarType.DWord:
                    return $"DB{DBNumber}.DBD{StartByte}";
                case VarType.Int:
                    return $"DB{DBNumber}.DBW{StartByte}";
                case VarType.Real:
                    return $"DB{DBNumber}.DBD{StartByte}";
                case VarType.LReal:
                    return $"DB{DBNumber}.DBD{StartByte}";
                case VarType.String:
                    throw new NotImplementedException();
                case VarType.S7String:
                    throw new NotImplementedException();
                case VarType.S7WString:
                    throw new NotImplementedException();
                case VarType.Timer:
                    throw new NotImplementedException();
                case VarType.Counter:
                    throw new NotImplementedException();
                case VarType.DateTime:
                    throw new NotImplementedException();
                case VarType.Date:
                    throw new NotImplementedException();
                case VarType.DateTimeLong:
                    throw new NotImplementedException();
                case VarType.Time:
                    return $"DB{DBNumber}.DB{StartByte}";
                case VarType.UDT:
                    return string.Empty;
            }
            return string.Empty;
        }
    }
}
