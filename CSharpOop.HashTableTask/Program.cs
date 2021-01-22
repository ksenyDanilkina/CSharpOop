using System;

namespace CSharpOop.HashTableTask
{
    class Program
    {
        static void Main(string[] args)
        {
            HashTable<int> hashTable1 = new HashTable<int> { 4, 6, 7, 9, 77, 8, 99 };

            Console.WriteLine("Коллекция содержит элемент = 7? " + hashTable1.Contains(7));
            Console.WriteLine("Элемент со значением = 7 удален из коллекции? " + hashTable1.Remove(7));

            int[] arrayForCopy = new int[10];
            hashTable1.CopyTo(arrayForCopy, 2);

            Console.WriteLine("Массив со скопированными элементами: " + String.Join(", ", arrayForCopy));

            Console.WriteLine(hashTable1);

            HashTable<string> hashTable2 = new HashTable<string> { null, "hello" };
            Console.WriteLine("Коллекция содержит элемент = null? " + hashTable2.Contains(null));

            Console.WriteLine(hashTable2);           
        }
    }
}
