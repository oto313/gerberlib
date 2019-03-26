using System;
using System.Collections.Generic;
using System.Text;

namespace GerberLib.FunctionCodeCommands
{

    public class D02Command : XYFunctionCodeCommand
    {
        public D02Command(GerberContext context, string data) : base(context, data)
        {
        }
    }
}
