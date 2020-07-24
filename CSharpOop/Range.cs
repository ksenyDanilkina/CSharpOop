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

        public Range GetIntersection(Range secondRange)
        {
            if ((secondRange.From >= To) || (From >= secondRange.To))
            {
                return null;
            }

            return new Range(Math.Max(From, secondRange.From), Math.Min(To, secondRange.To));
        }

        public Range[] GetUnion(Range secondRange)
        {
            if ((secondRange.From > To) || (From > secondRange.To))
            {
                return new Range[] { new Range(secondRange.From, secondRange.To), new Range(From, To) };
            }

            return new Range[] { new Range(Math.Min(secondRange.From, From), Math.Max(secondRange.To, To)) };
        }

        public Range[] GetDifference(Range secondRange)
        {
            if ((secondRange.From >= To) || (From >= secondRange.To))
            {
                return new Range[] { new Range(From, To) };
            }

            if (From < secondRange.From && secondRange.To < To)
            {
                return new Range[] { new Range(From, secondRange.From), new Range(secondRange.To, To) };
            }

            if (From < secondRange.From)
            {
                return new Range[] { new Range(From, secondRange.From) };
            }

            if (secondRange.To < To)
            {
                return new Range[] { new Range(secondRange.To, To) };
            }

            return new Range[0];
        }

        public override string ToString()
        {
            return "( " + From + "; " + To + " )";
        }
    }
}
