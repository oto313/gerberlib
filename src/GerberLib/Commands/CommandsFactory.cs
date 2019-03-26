using System;
using System.Collections.Generic;
using System.Text;
using GerberLib.CommandParser;
using GerberLib.FunctionCodeCommands;

namespace GerberLib.Commands
{
    public class CommandsFactory
    {

        public Command GetExtendedCommand(ExtendedCommandData data)
        {
            return null;
        }

        public Command GetFunctionCodeCommand(GerberContext context, FunctionCodeCommandData data)
        {
            switch (data.Code)
            {
                case 'D':
                    if(data.Number == 1)
                        return new D01Command(context, data.Data);
                    else if (data.Number == 2)
                        return new D02Command(context, data.Data);
                    else if (data.Number == 3)
                        return new D03Command(context, data.Data);
                    else
                        return new D0XCommand();
                case 'G':
                case 'M':
                    break;
            }
            return null;
        }
    }
}
