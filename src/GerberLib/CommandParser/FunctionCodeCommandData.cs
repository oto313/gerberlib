using System;
using System.Collections.Generic;
using System.Text;

namespace GerberLib.CommandParser
{
    public class FunctionCodeCommandData
    {
        public FunctionCodeCommandData(char code, int number, string data)
        {
            Code = code;
            Number = number;
            Data = data;
        }

        public char Code { get; }
        public int Number { get; }
        public string Data { get; }
    }
}
