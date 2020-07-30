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
            double from1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец числового диапазона: ");
            double to1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите начало второго числового диапазона: ");
            double from2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец второго числового диапазона: ");
            double to2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите число, для проверки принадлежности диапазону: ");
            double number = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(from1, to1);
            Range range2 = new Range(from2, to2);

            Console.WriteLine("Начало диапазона: " + from1);
            Console.WriteLine("Конец диапазона: " + to1);
            Console.WriteLine("Длина диапазона: " + range1.GetLength());
            Console.WriteLine("Число принадлежит диапазону: " + range1.IsInside(number));

            Range intersection = range1.GetIntersection(range2);

            if (intersection == null)
            {
                Console.WriteLine("Пересечений нет.");
            }
            else
            {
                Console.WriteLine("Интервал - пересечение: " + intersection);
            }

            Range[] union = range1.GetUnion(range2);

            if (union.Length == 2)
            {
                Console.WriteLine("Объединение интервалов: " + union[0] + "; " + union[1]);
            }
            else
            {
                Console.WriteLine("Объединение интервалов: " + union[0]);
            }

            Range[] difference = range1.GetDifference(range2);

            if (difference.Length == 0)
            {
                Console.WriteLine("Разность интервалов : null");
            }
            else if (difference.Length == 2)
            {
                Console.WriteLine("Разность интервалов: " + difference[0] + "; " + difference[1]);
            }
            else
            {
                Console.WriteLine("Разность интервалов: " + difference[0]);
            }
        }
    }
}
