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

            try
            {
                using (StreamReader reader = new StreamReader("input.txt"))
                {
                    string currentFileLine;

                    while ((currentFileLine = reader.ReadLine()) != null)
                    {
                        stringsFromFile.Add(currentFileLine);
                    }
                }

                foreach (string s in stringsFromFile)
                {
                    Console.WriteLine(s);
                }
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DriveNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (NotSupportedException e)
            {
                Console.WriteLine(e.Message);
            }

            List<int> numbers1 = new List<int> { 4, 4, 1, 6, 5, 4, 3, 9, 11, 8, 80 };

            for (int i = 0; i < numbers1.Count; i++)
            {
                if (numbers1[i] % 2 == 0)
                {
                    numbers1.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine("Список без четных чисел: " + string.Join(", ", numbers1));

            List<int> numbers2 = new List<int> { 1, 1, 1, 1, 6, 5, 5, 4, 3, 9, 11, 5, 1, 1, 1, 5, 1, 1, 1 };
            List<int> noRepeatingNumbersList = new List<int>(numbers2.Count);

            foreach (int e in numbers2)
            {
                if (!noRepeatingNumbersList.Contains(e))
                {
                    noRepeatingNumbersList.Add(e);
                }
            }

            Console.WriteLine("Список без повторяющихся чисел: " + string.Join(", ", noRepeatingNumbersList));
        }
    }
}
