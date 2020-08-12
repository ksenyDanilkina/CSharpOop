using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOop.ArrayListHome
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> stringsFromFile = new List<string>();

            using (StreamReader reader = new StreamReader("input.txt"))
            {
                string currentFileLine;

                while ((currentFileLine = reader.ReadLine()) != null)
                {
                    stringsFromFile.Add(currentFileLine);
                }
            }

            List<int> numbers1 = new List<int> { 1, 6, 5, 4, 3, 9, 11 };

            for (int i = 0; i < numbers1.Count; i++)
            {
                if (numbers1[i] % 2 == 0)
                {
                    numbers1.RemoveAt(i);
                }
            }

            Console.WriteLine("Список без четных чисел: " + String.Join(", ", numbers1));

            List<int> numbers2 = new List<int> { 1, 1, 1, 1, 6, 5, 5, 4, 3, 9, 11, 5, 1, 1, 1, 5, 1, 1, 1 };
            List<int> resultList = new List<int>();

            for (int i = 0; i < numbers2.Count; i++)
            {
                if (!resultList.Contains(numbers2[i]))
                {
                    resultList.Add(numbers2[i]);
                }
            }

            Console.WriteLine("Список без повторяющихся чисел: " + String.Join(", ", resultList));
        }
    }
}
