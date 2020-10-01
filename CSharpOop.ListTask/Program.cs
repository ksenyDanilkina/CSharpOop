using System;

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
            Console.WriteLine("Измененный элемент: " + list.SetElementData(3, 50));
            Console.WriteLine("Удаленный элемент: " + list.RemoveElementByIndex(2));
            Console.WriteLine("Элемент удален: " + list.RemoveElementByData(0));

            list.Revert();
            Console.WriteLine("Перевернутый список: " + list);

            SinglyLinkedList<int> copyList = list.GetCopy();
            Console.WriteLine("Копия списка: " + copyList);            
        }
    }
}
