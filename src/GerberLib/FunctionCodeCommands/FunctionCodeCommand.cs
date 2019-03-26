using GerberLib.Commands;
using Sprache;
using System;
using System.Globalization;

namespace GerberLib.FunctionCodeCommands
{
    public class CoordinatesXY
    {
        public CoordinatesXY(decimal? x, decimal? y)
        {
            X = x;
            Y = y;
        }
        public decimal? X { get; }
        public decimal? Y { get; }
    }

    public class CoordinatesXYIJ : CoordinatesXY
    {
        public CoordinatesXYIJ(decimal? x, decimal? y, decimal? i, decimal? j) : base(x, y)
        {
            I = i;
            J = j;
        }
        public decimal? I { get; }
        public decimal? J { get; }
    }

    public class FunctionCodeCommand : Command
    {
        Parser<string> xParser = from xStart in Parse.IgnoreCase('X')
            from xValue in Parse.Digit.Many().Text()
            select xValue;
        Parser<string> yParser = from xStart in Parse.IgnoreCase('X')
            from xValue in Parse.Digit.Many().Text()
            select xValue;
        Parser<string> iParser = from xStart in Parse.IgnoreCase('I')
            from xValue in Parse.Digit.Many().Text()
            select xValue;
        Parser<string> jParser = from xStart in Parse.IgnoreCase('J')
            from xValue in Parse.Digit.Many().Text()
            select xValue;

        public FunctionCodeCommand()
        {
        }

        protected CoordinatesXYIJ ParseXYIJ(GerberContext context, string data)
        {
            var parser = 
                from xVal in Parse.Optional(xParser)
                from yVal in Parse.Optional(yParser)
                from iVal in Parse.Optional(iParser)
                from jVal in Parse.Optional(jParser)
                select (X: xVal, Y: yVal, I: iVal, J: jVal);
            var xy = parser.Parse(data);
            decimal? x = null, y = null,i = null, j = null;
            if (xy.X.IsDefined)
            {
                x = ParseDigits(xy.X.Get(), context.XUnitFormat);
            }
            if (xy.Y.IsDefined)
            {
                y = ParseDigits(xy.Y.Get(), context.YUnitFormat);
            }
            if (xy.I.IsDefined)
            {
                x = ParseDigits(xy.I.Get(), context.XUnitFormat);
            }
            if (xy.J.IsDefined)
            {
                y = ParseDigits(xy.J.Get(), context.YUnitFormat);
            }

            return new CoordinatesXYIJ(x, y, i, j);
        }

        protected CoordinatesXY ParseXY(GerberContext context, string data)
        {
            var r = ParseXYIJ(context, data);
            return new CoordinatesXY(r.X, r.Y);
        }


        protected decimal ParseDigits(string value, UnitFormat format)
        {
            string prepend = "";
            if (value[0] == '-')
                prepend = "-";
            var padded = value.PadLeft(format.DecimalDigits);
            return decimal.Parse($"{prepend}{padded.Substring(0, format.IntegerDigits)}.{padded.Substring(format.IntegerDigits)}",
                NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture);
        }
    }
}
