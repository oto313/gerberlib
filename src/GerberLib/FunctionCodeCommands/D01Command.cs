using System;
using System.Collections.Generic;
using System.Text;

namespace GerberLib.FunctionCodeCommands
{
    public class D01Command : XYIJFunctionCodeCommand
    {
        public D01Command(GerberContext context, string data) : base(context, data)
        {
        }
    }
}
