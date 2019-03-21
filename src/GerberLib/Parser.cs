using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GerberLib.CommandParser;
using GerberLib.Commands;
using Sprache;
//using Superpower;
//using Superpower.Parsers;

namespace GerberLib
{
    public class ExtendedCommandParser<P>
    {


        public void ParseCmd()
        {

        }
    }

    public class Parser
    {
        private StreamReader _streamReader;
        private char[] buffer = new char[1024];
        public Parser(string filepath)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write("af54651g1232*");
            writer.Flush();
            stream.Position = 0;
            _streamReader = new StreamReader(stream);
        }


        public Command GetNextCommand()
        {
            var cmdParser = Parse.IgnoreCase('G').Or(Parse.IgnoreCase('D')).Or(Parse.IgnoreCase('M'));
            Parser<FunctionCodeCommandData> functionCodeCommandParser =
                from data in Parse.LetterOrDigit.Until(cmdParser).Text()
                from cmd in cmdParser
                from number in Parse.Digit.Many().Text()
                from end in Parse.Char('*')
                select new FunctionCodeCommandData(cmd, Convert.ToInt32(number), data);



            var strCmd = GetNextCommandString();
            var functionCmd = functionCodeCommandParser.TryParse(strCmd);
            if (functionCmd.WasSuccessful)
            {

            }
            var extendedCmd = new ExtendedCommandParser().GetParser().TryParse(strCmd);
            if (extendedCmd.WasSuccessful)
            {

            }

            return null;
        }

       
        public string GetNextCommandString()
        {
            bool percentage = false;
            int i = 0;
            while (_streamReader.Peek() >= 0)
            {
                char ch = (char)_streamReader.Read();
                buffer[i] = ch;
                if (ch == '%' && !percentage)
                {
                    if(i != 0)
                        throw new Exception("Percentage must be first command character");
                    percentage = true;
                }else if (ch == '%' && percentage || ch == '*')
                {
                    break;
                }
                i++;
            }
            if(buffer[i] != '%' && buffer[i] != '*')
                throw new Exception("Command must end with * or %");
            return new string(buffer.Take(i + 1)
                .Where(c => !char.IsWhiteSpace(c))
                .ToArray());
        }
    }
}
