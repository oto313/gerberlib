using System;
using System.Collections.Generic;
using System.Text;

namespace GerberLib.Commands
{
    public class ExtendedCommand
    {
        public ExtendedCommand(ExtendedCommandData data)
        {
            Data = data;
        }

        public ExtendedCommandData Data { get; }
    }
}
