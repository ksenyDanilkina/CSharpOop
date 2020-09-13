using System;
using System.Text;

namespace CSharpOop.ListTask
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList<int> list = new SinglyLinkedList<int>();

            list.AddFirst(3);
            list.AddFirst(4);
            list.AddFirst(7);
            list.AddFirst(9);
            list.AddFirst(0);

            list.AddByIndex(4, 55);

            Console.WriteLine("Размер списка: " + list.Count);
            Console.WriteLine("Удаленный первый элемент: " + list.RemoveFirstElement());
            Console.WriteLine("Значение первого элемента: " + list.GetFirstElementData());
            Console.WriteLine("Измененный элемент: " + list.GetChangedElementData(3, 50));
            Console.WriteLine("Удаленный элемент: " + list.RemoveElementByIndex(2));
            Console.WriteLine("Элемент удален: " + list.RemoveElementByData(0));

            list.Revert();
            Console.WriteLine("Перевернутый список: " + PrintList(list));

            SinglyLinkedList<int> copyList = list.GetCopy();
            Console.WriteLine("Копия списка: " + PrintList(copyList));
        }

        public static string PrintList(SinglyLinkedList<int> list)
        {
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                if (i < list.Count - 1)
                {
                    resultString.Append(list.GetElementData(i)).Append(", ");
                }
                else
                {
                    resultString.Append(list.GetElementData(i));
                }
            }

            return resultString.ToString();
        }
    }
}
