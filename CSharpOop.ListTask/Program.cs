using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            list.AddByIndex(1, 55);

            Console.WriteLine("Размер списка: " + list.GetSize());
            Console.WriteLine("Удаленный первый элемент: " + list.GetRemovedFirstElement());
            Console.WriteLine("Значение первого элемента: " + list.GetFirstElementData());
            Console.WriteLine("Измененный элемент: " + list.GetChangedElementData(3, 50));
            Console.WriteLine("Удаленный элемент: " + list.GetRemovedElementData(2));
            Console.WriteLine("Элемент удален: " + list.IsRemoved(2));

            list.Revert();
            Console.WriteLine("Перевернутый список: " + PrintList(list));

            SinglyLinkedList<int> copyList = list.GetCopy();
            Console.WriteLine("Копия списка: " + PrintList(copyList));
        }

        public static string PrintList(SinglyLinkedList<int> list)
        {
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < list.GetSize(); i++)
            {
                if (i < list.GetSize() - 1)
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
