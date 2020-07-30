using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOop.RangeTask
{
    class Range
    {
        public double From { get; set; }

        public double To { get; set; }

        public Range(double from, double to)
        {
            From = from;
            To = to;
        }

        public double GetLength()
        {
            return To - From;
        }

        public bool IsInside(double number)
        {
            return number >= From && number <= To;
        }

        public Range GetIntersection(Range range2)
        {
            if (range2.From >= To || From >= range2.To)
            {
                return null;
            }

            return new Range(Math.Max(From, range2.From), Math.Min(To, range2.To));
        }

        public Range[] GetUnion(Range range2)
        {
            if (range2.From > To || From > range2.To)
            {
                return new Range[] { new Range(range2.From, range2.To), new Range(From, To) };
            }

            return new Range[] { new Range(Math.Min(range2.From, From), Math.Max(range2.To, To)) };
        }

        public Range[] GetDifference(Range range2)
        {
            if (range2.From >= To || From >= range2.To)
            {
                return new Range[] { new Range(From, To) };
            }

            if (From < range2.From && range2.To < To)
            {
                return new Range[] { new Range(From, range2.From), new Range(range2.To, To) };
            }

            if (From < range2.From)
            {
                return new Range[] { new Range(From, range2.From) };
            }

            if (range2.To < To)
            {
                return new Range[] { new Range(range2.To, To) };
            }

            return new Range[0];
        }

        public override string ToString()
        {
            return "( " + From + "; " + To + " )";
        }
    }
}
