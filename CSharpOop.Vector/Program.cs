using System;

namespace CSharpOop.Vector
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array1 = { 1.0, -2.0, 10.0, -4.0 };
            double[] array2 = { 1.0, 2.0, 10.0 };

            Vector vector1 = new Vector(6);
            Vector vector2 = new Vector(array1);
            Vector vector3 = new Vector(5, array2);
            Vector vector4 = new Vector(vector2);
            Vector vector5 = new Vector(array2);
            Vector vector6 = new Vector(3, array1);
            Vector vector7 = new Vector(3, array2);
            Vector vector8 = new Vector(1, array1);

            Console.WriteLine("Размер вектора 4: " + vector4.GetSize());
            Console.WriteLine("Сумма векторов 3 и 4: " + vector3.GetVectorsAddition(vector4));
            Console.WriteLine("Разность веткоров 5 и 1: " + vector5.GetVectorsSubtraction(vector1));
            Console.WriteLine("Произведение вектора 2 на скаляр = 5.0: " + vector2.GetScalarMultiplication(5));
            Console.WriteLine("Разворот вектора 6: " + vector6.GetRevertVector());
            Console.WriteLine("Длина вектора 6: " + vector6.GetVectorLength());

            vector1.SetVectorComponent(4, 4.77);
            Console.WriteLine("Значение компонента ветора 1 с индексом 4: " + vector1.GetVectorComponent(4));

            Console.WriteLine("Сумма векторов 1 и 7: " + Vector.GetStaticVectorsAddition(vector1, vector7));
            Console.WriteLine("Разность векторов 7 и 1: " + Vector.GetStaticVectorsSubtraction(vector7, vector1));
            Console.WriteLine("Скалярное произведение векторов 7 и 8: " + Vector.GetStaticVectorsScalarMultiplication(vector8, vector7));
        }
    }
}
