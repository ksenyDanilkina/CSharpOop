using System;
using CSharpOop.VectorsTask;

namespace CSharpOop.MatrixTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector vector1 = new Vector(new double[] { 1, 2, -1 });
            Vector vector2 = new Vector(new double[] { 5, 9, 1 });
            Vector vector3 = new Vector(new double[] { 1, 2, 8 });
            Vector vector4 = new Vector(new double[] { 5, 5, 6 });
            Vector[] vectors = new Vector[] { vector1, vector2, vector3, vector4 };
            Matrix matrix1 = new Matrix(vectors);

            Console.WriteLine("Третья строка матрицы 1: " + matrix1.GetRow(2));
            Console.WriteLine("Второй столбец матрицы 1: " + matrix1.GetVectorColumn(1));
            Console.WriteLine("Транспонированная матрица:" + matrix1.Transpose());

            double[,] array = new double[,] { { 2, 3, 1, 5 }, { 3, 1, 3, 4 }, { 3, 2, 0, 1 }, { 2, 3, 0, 5 } };
            Matrix matrix2 = new Matrix(array);

            Console.WriteLine("Определитель матрицы 2: " + matrix2.GetDeterminant());
            Console.WriteLine("Матрица 2, умноженная на скаляр равный 5: " + matrix2.Multiply(5));

            Matrix matrix3 = new Matrix(matrix1);
            Vector vector5 = new Vector(new double[] { 1, 2, -1, 0 });
            Console.WriteLine("Результат умножения матрицы 3 на вектор: " + matrix3.GetMultiplicationOnVector(vector5));

            Console.WriteLine("Сумма матриц 1 и 3:" + matrix1.GetAddition(matrix3));
            Console.WriteLine("Разность матриц 2 и 3:" + matrix1.GetSubstraction(matrix3));
            Console.WriteLine("Произведение матриц 1 и 2: " + Matrix.GetMultiply(matrix1, matrix2));
        }
    }
}
