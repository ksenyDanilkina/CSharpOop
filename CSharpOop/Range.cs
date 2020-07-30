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

        public Range GetIntersection(Range range)
        {
            if (range.From >= To || From >= range.To)
            {
                return null;
            }

            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        public Range[] GetUnion(Range range)
        {
            if (range.From > To || From > range.To)
            {
                return new Range[] { new Range(range.From, range.To), new Range(From, To) };
            }

            return new Range[] { new Range(Math.Min(range.From, From), Math.Max(range.To, To)) };
        }

        public Range[] GetDifference(Range range)
        {
            if (range.From >= To || From >= range.To)
            {
                return new Range[] { new Range(From, To) };
            }

            if (From < range.From && range.To < To)
            {
                return new Range[] { new Range(From, range.From), new Range(range.To, To) };
            }

            if (From < range.From)
            {
                return new Range[] { new Range(From, range.From) };
            }

            if (range.To < To)
            {
                return new Range[] { new Range(range.To, To) };
            }

            return new Range[0];
        }

        public override string ToString()
        {
            return "( " + From + "; " + To + " )";
        }
    }
}
