using System;
using System.Collections.Generic;
using System.Text;

namespace GerberLib.FunctionCodeCommands
{
    public class D03Command : XYFunctionCodeCommand
    {
        public D03Command(GerberContext context, string data) : base(context, data)
        {
        }
    }
}
