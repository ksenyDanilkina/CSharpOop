using System;
using System.Text;

namespace CSharpOop.ArrayLIst
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 5, 7, 8, 5, 6, 9 };

            numbers.Insert(6, 88);
            numbers.RemoveAt(1);
            numbers.Remove(5);

            Console.WriteLine("Список: " + PrintList(numbers));
            Console.WriteLine("Данный список содержит число 99? " + numbers.Contains(99));
            Console.WriteLine("Index элемента 88: " + numbers.IndexOf(88));
            int[] arrayToCopy = new int[10];
            numbers.CopyTo(arrayToCopy, 3);

            Console.WriteLine("Массив с копированными данными: " + string.Join(", ", arrayToCopy));
            numbers.Clear();
            numbers.TrimExcess();

            numbers.Add(0);
            numbers.Add(1);
            Console.WriteLine("Новый список: " + PrintList(numbers));
        }

        public static string PrintList(List<int> list)
        {
            StringBuilder stringBuilder = new StringBuilder();

            if (list.Count == 0)
            {
                return stringBuilder.ToString();
            }

            foreach (double e in list)
            {
                stringBuilder.Append(e).Append(", ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 1).ToString();
        }
    }
}
