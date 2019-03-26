using System;
using System.Collections.Generic;
using System.Text;

namespace GerberLib
{
    public class UnitFormat
    {
        public UnitFormat(int integerDigits, int decimalDigits)
        {
            IntegerDigits = integerDigits;
            DecimalDigits = decimalDigits;
        }

        public int IntegerDigits { get; }
        public int DecimalDigits { get; }
    }
}
