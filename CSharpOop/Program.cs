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
            Range secondRange = new Range(from2, to2);

            Console.WriteLine("Начало диапазона: " + from);
            Console.WriteLine("Конец диапазона: " + to);
            Console.WriteLine("Длина диапазона: " + range.GetLength());
            Console.WriteLine("Число принадлежит диапазону: " + range.IsInside(number));

            Range intersection = range.GetIntersection(secondRange);

            if (intersection == null)
            {
                Console.WriteLine("Пересечений нет.");
            }
            else
            {
                Console.WriteLine("Интервал - пересечение: " + intersection.ToString());
            }

            Range[] union = range.GetUnion(secondRange);

            if (union.Length == 2)
            {
                Console.WriteLine("Объединение интервалов: " + union[0].ToString() + "; " + union[1].ToString());
            }
            else
            {
                Console.WriteLine("Объединение интервалов: " + union[0].ToString());
            }

            Range[] difference = range.GetDifference(secondRange);

            if (difference.Length == 0)
            {
                Console.WriteLine("Разность интервалов : null");
            }
            else if (difference.Length == 2)
            {
                Console.WriteLine("Разность интервалов: " + difference[0].ToString() + "; " + difference[1].ToString());
            }
            else
            {
                Console.WriteLine("Разность интервалов: " + difference[0].ToString());
            }
        }
    }
}
