using Sprache;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace GerberLib.Commands
{
    public class ExtendedCommandParser: Command
    {
        protected static readonly Parser<char> AdditionalDataCellSeparatorParser = Parse.Char(',');
        protected static readonly Parser<char> AdditionalDataSeparatorParser = Parse.Char('*');
        protected static readonly Parser<string> Cell = Parse.AnyChar.Except(AdditionalDataCellSeparatorParser).Many().Text();
        protected static readonly Parser<IEnumerable<string>> AdditionalCommandDataParser =
            from leading in Cell
            from rest in AdditionalDataCellSeparatorParser.Then(_ => Cell).Many()
            from terminator in AdditionalDataSeparatorParser
            select Cons(leading, rest);

        protected static IEnumerable<D> Cons<D>(D head, IEnumerable<D> rest)
        {
            yield return head;
            foreach (var item in rest)
                yield return item;
        }


        protected virtual Parser<char> ParseStart()
        {
            return Parse.Char('%');
        }

        protected virtual Parser<string> ParseCommandCode()
        {
            return Parse.Letter.Repeat(2).Text();
        }

        protected virtual Parser<string> ParseCommandData()
        {
            return Parse.Letter.Many().Text();
        }

        protected virtual Parser<IEnumerable<IEnumerable<string>>> ParseAdditionalCommandData()
        {
            return AdditionalCommandDataParser.XMany();
        }

        protected virtual Parser<char> ParseEnd()
        {
            return Parse.Char('%');
        }

        public virtual Parser<ExtendedCommandData> GetParser()
        {
            return 
                from start in ParseStart()
                from cmd in ParseCommandCode()
                from cmdData in ParseCommandData()
                from star in Parse.Char('*')
                from addData in ParseAdditionalCommandData()
                from end in ParseEnd()
                select CreateExtendedCommandData(cmd, cmdData, addData);
        }

        protected virtual ExtendedCommandData CreateExtendedCommandData(string cmd, string cmdData, IEnumerable<IEnumerable<string>> additionalData)
        {
            return new ExtendedCommandData(cmd, cmdData, additionalData);
        }
    }
}
