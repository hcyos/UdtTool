using System;
using System.Text.RegularExpressions;

public class Example
{
    public static void Main()
    {
        string pattern = @"Struct((\s+\w+\s:\s.+))+\s+END_STRUCT";
        string input =
            @"TYPE type_2
   STRUCT
      Element_1 : Bool
      Element_2 : Array[0..1] of Struct
         Element_1 : Array[0..1] of String[20]
    Element_1 : Array[0..1] of String[20]
    Element_1 : Array[0..1] of String[20]
    Element_1 : Array[0..1] of String[20]
      END_STRUCT
   END_STRUCT
END_TYPE
DATA_BLOCK db_1

   STRUCT 
      bool : Bool
      Static_1  : type_1
      b1 : Array[0..1] of Struct
         i : Real
      END_STRUCT
      Static_2 : Struct
         bb : Bool
      END_STRUCT
   END_STRUCT
BEGIN
END_DATA_BLOCK
";
        RegexOptions options = RegexOptions.Multiline;

        Console.WriteLine("输出匹配的内容:");
        var math = Regex.Matches(input, pattern, options).Cast<Match>();

        Console.WriteLine(math.Count());
        foreach (Match m in math)
        {
            foreach (Capture g in m.Groups[0].Captures)
            {
                Console.WriteLine(g.Value);
            }
        }
    }
}
