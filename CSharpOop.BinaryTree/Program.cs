using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharpOop.BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree<int> tree = new BinaryTree<int>();

            tree.Add(10);
            tree.Add(18);
            tree.Add(26);
            tree.Add(11);
            tree.Add(13);
            tree.Add(20);
            tree.Add(29);
            tree.Add(12);
            tree.Add(7);
            tree.Add(6);
            tree.Add(9);
            tree.Add(4);
            tree.Add(21);
            tree.Add(31);
                     
            Console.WriteLine("Элемент со значением 26 удален: " + tree.Remove(26));
        
            Console.WriteLine("Дерево содержит элемент со значением 31? " + tree.Contains(31));
            
            Console.WriteLine("Обход дерева в ширину: "+ GetNodesString(tree.WidthTraversal()));
            Console.WriteLine("Обход дерева в глубину: " + GetNodesString(tree.DepthTraversal()));

            Console.WriteLine("Количество элементов дерева: " + tree.Count);
        }

        public static string GetNodesString(IEnumerable<int> enumerable)
        {     
            return string.Join(", ", enumerable);            
        }
    }
}
