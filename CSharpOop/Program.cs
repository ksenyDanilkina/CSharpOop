using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOop.RangeTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начало числового диапазона: ");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец числового диапазона: ");
            double to = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите начало второго числового диапазона: ");
            double from2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец второго числового диапазона: ");
            double to2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число, для проверки принадлежности диапазону: ");
            double number = Convert.ToDouble(Console.ReadLine());

            Range range = new Range(from, to);
            Range range2 = new Range(from2, to2);

            Console.WriteLine("Начало диапазона: " + from);
            Console.WriteLine("Конец диапазона: " + to);
            Console.WriteLine("Длина диапазона: " + range.GetLength());
            Console.WriteLine("Число принадлежит диапазону: " + range.IsInside(number));

            Range intersectionInterval = range.GetIntersectionInterval(range2);

            if (intersectionInterval == null)
            {
                Console.WriteLine("Пересечений нет.");
            }
            else
            {
                Console.WriteLine("Интервал - пересечение: ( " + intersectionInterval.From + " ; " + intersectionInterval.To + " )");
            }

            Range[] intervalsUnionArray = range.GetIntervalsUnion(range2);

            if (intervalsUnionArray.Length == 2)
            {
                Console.WriteLine("Объединение интервалов: ( " + intervalsUnionArray[0].From + " ; " + intervalsUnionArray[0].To + " ) ," +
                    " ( " + intervalsUnionArray[1].From + " ; " + intervalsUnionArray[1].To + " )");
            }
            else
            {
                Console.WriteLine("Объединение интервалов: ( " + intervalsUnionArray[0].From + " ; " + intervalsUnionArray[0].To + " )");
            }

            Range[] intervalsDifferenceArray = range.GetIntervalsDifference(range2);

            if (intervalsDifferenceArray == null)
            {
                Console.WriteLine("Разность интервалов : null");
            }
            else if (intervalsDifferenceArray.Length == 2)
            {
                Console.WriteLine("Разность интервалов: ( " + intervalsDifferenceArray[0].From + " ; " + intervalsDifferenceArray[0].To + " ) ," +
                    " ( " + intervalsDifferenceArray[1].From + " ; " + intervalsDifferenceArray[1].To + " )");
            }
            else
            {
                Console.WriteLine("Разность интервалов: ( " + intervalsDifferenceArray[0].From + " ; " + intervalsDifferenceArray[0].To + " )");
            }
        }
    }
}
