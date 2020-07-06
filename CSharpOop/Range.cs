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
    }
}
