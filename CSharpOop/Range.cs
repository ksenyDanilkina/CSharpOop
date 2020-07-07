using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOop.RangeTask
{
    class Range
    {
        public double From
        {
            get;
            set;
        }

        public double To
        {
            get;
            set;
        }

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

        public Range GetIntersectionInterval(Range range2)
        {
            double from;
            double to;

            if ((range2.From - To) * (range2.To - From) >= 0)
            {
                return null;
            }

            if (range2.From > From)
            {
                from = range2.From;
            }
            else
            {
                from = From;
            }

            if (range2.To > To)
            {
                to = To;
            }
            else
            {
                to = range2.To;
            }

            return new Range(from, to);
        }

        public Range[] GetIntervalsUnion(Range range2)
        {
            double from;
            double to;

            if ((range2.From - To) * (range2.To - From) > 0)
            {
                return new Range[] { range2, this };
            }

            if (range2.From <= From)
            {
                from = range2.From;
            }
            else
            {
                from = From;
            }

            if (range2.To >= To)
            {
                to = range2.To;
            }
            else
            {
                to = To;
            }

            return new Range[] { new Range(from, to) };
        }

        public Range[] GetIntervalsDifference(Range range2)
        {
            double from;
            double to;
            double from2;
            double to2;

            if ((range2.From - To) * (range2.To - From) >= 0)
            {
                return new Range[] { this };
            }

            if (From < range2.From && range2.To < To)
            {
                from = From;
                to = range2.From;
                from2 = range2.To;
                to2 = To;

                return new Range[] { new Range(from, to), new Range(from2, to2) };
            }

            if (From < range2.From)
            {
                from = From;
                to = range2.From;

                return new Range[] { new Range(from, to) };
            }

            if (range2.To < To)
            {
                from = range2.To;
                to = To;

                return new Range[] { new Range(from, to) };
            }

            return null;
        }
    }
}
