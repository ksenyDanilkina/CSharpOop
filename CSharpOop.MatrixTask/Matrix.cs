using System;
using System.Text;
using CSharpOop.VectorsTask;

namespace CSharpOop.MatrixTask
{
    class Matrix
    {
        private Vector[] rows;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (rowsCount <= 0)
            {
                throw new ArgumentException("RowsCount = " + rowsCount + ". RowsCount должно быть > 0.", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException("ColumnsCount = " + columnsCount + ". ColumnsCount должно быть > 0.", nameof(columnsCount));
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.rows.Length];

            for (int i = 0; i < GetRowsCount(); i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.GetLength(0) == 0 && array.GetLength(1) == 0)
            {
                throw new ArgumentException("Размерность массива = " + array.GetLength(0) + ". Нельзя создать матрицу размера 0", nameof(array));
            }

            rows = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                rows[i] = new Vector(array.GetLength(1));

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    rows[i].SetComponent(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length == 0)
            {
                throw new ArgumentException("Размерность массива = " + vectors.Length + ". Нельзя создать матрицу размера 0", nameof(vectors));
            }

            int maxVectorSize = vectors[0].GetSize();

            for (int i = 1; i < vectors.Length; i++)
            {
                if (vectors[i].GetSize() > maxVectorSize)
                {
                    maxVectorSize = vectors[i].GetSize();
                }
            }

            rows = new Vector[vectors.Length];

            for (int i = 0; i < GetRowsCount(); i++)
            {
                if (vectors[i].GetSize() < maxVectorSize)
                {
                    rows[i] = new Vector(maxVectorSize);

                    rows[i].Add(vectors[i]);
                }
                else
                {
                    rows[i] = new Vector(vectors[i]);
                }
            }
        }

        public Vector GetRow(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index = " + index + ". Index  должен быть >= 0", nameof(index));
            }

            if (index >= GetRowsCount())
            {
                throw new ArgumentOutOfRangeException("Index = " + index + ". Index должен быть < " + GetRowsCount(), nameof(index));
            }

            return rows[index];
        }

        public void SetRow(int index, Vector vector)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index = " + index + ". Index  должен быть >= 0", nameof(index));
            }

            if (index >= GetRowsCount())
            {
                throw new ArgumentOutOfRangeException("Index = " + index + ". Index должен быть <= " + GetRowsCount(), nameof(index));
            }

            if (vector.GetSize() != GetColumnsCount())
            {
                throw new ArgumentException("Размер вектора = " + vector.GetSize() + ". Размер веткора должен быть равен количеству столбцов в матрице: " + GetColumnsCount(), nameof(vector));
            }

            rows[index] = new Vector(vector);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index = " + index + ". Index  должен быть >= 0", nameof(index));
            }

            if (index >= GetColumnsCount())
            {
                throw new ArgumentOutOfRangeException("Index = " + index + ". Index  должен быть < " + GetColumnsCount(), nameof(index));
            }

            Vector columnVector = new Vector(rows.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                columnVector.SetComponent(i, rows[i].GetComponent(index));
            }

            return columnVector;
        }

        public int GetRowsCount()
        {
            return rows.Length;
        }

        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        public Matrix Transpose()
        {
            Vector[] transposedMatrixRows = new Vector[GetColumnsCount()];

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                transposedMatrixRows[i] = GetColumn(i);
            }

            rows = transposedMatrixRows;

            return this;
        }

        public Matrix Multiply(double scalar)
        {
            foreach (Vector e in rows)
            {
                e.Multiply(scalar);
            }

            return this;
        }

        private Matrix GetMatrixMinor(int rowIndexForDelete, int columnIndexForDelete)
        {
            Vector[] minorRows = new Vector[GetColumnsCount() - 1];

            int rowOffset = 0;

            for (int i = 0; i < GetRowsCount(); i++)
            {
                if (i == rowIndexForDelete)
                {
                    rowOffset = 1;
                    continue;
                }

                int columnOffset = 0;

                Vector vector = new Vector(GetRowsCount() - 1);

                for (int j = 0; j < GetColumnsCount(); j++)
                {
                    if (j == columnIndexForDelete)
                    {
                        columnOffset = 1;
                        continue;
                    }

                    vector.SetComponent(j - columnOffset, rows[i].GetComponent(j));
                }

                minorRows[i - rowOffset] = vector;
            }

            return new Matrix(minorRows);
        }

        public double GetDeterminant()
        {
            if (GetColumnsCount() != GetRowsCount())
            {
                throw new NotSupportedException("Размер матрицы : " + GetRowsCount() + " на " + GetColumnsCount() + ". Матрица - не квадратная, невозможно найти определитель.");
            }

            if (GetColumnsCount() == 1)
            {
                return rows[0].GetComponent(0);
            }

            if (GetColumnsCount() == 2)
            {
                return rows[0].GetComponent(0) * rows[1].GetComponent(1) - rows[0].GetComponent(1) * rows[1].GetComponent(0);
            }

            double determinant = 0;

            for (int i = 0; i < GetColumnsCount(); i++)
            {
                if (i % 2 == 0)
                {
                    determinant += rows[0].GetComponent(i) * GetMatrixMinor(0, i).GetDeterminant();
                }
                else
                {
                    determinant -= rows[0].GetComponent(i) * GetMatrixMinor(0, i).GetDeterminant();
                }
            }

            return determinant;
        }

        public Vector GetProduct(Vector vector)
        {
            if (GetColumnsCount() != vector.GetSize())
            {
                throw new ArgumentException("Длина вектора: " + vector.GetSize() + ". Длина вектора должна быть равна количеству столбцов в матрице = " + GetColumnsCount(), nameof(vector));
            }

            Vector resultVector = new Vector(GetRowsCount());

            for (int i = 0; i < GetRowsCount(); i++)
            {
                resultVector.SetComponent(i, Vector.GetScalarMultiplication(rows[i], vector));
            }

            return resultVector;
        }

        private bool IsSameSize(Matrix matrix)
        {
            return GetColumnsCount() == matrix.GetColumnsCount() && GetRowsCount() == matrix.GetRowsCount();
        }

        public Matrix Add(Matrix matrix)
        {
            if (!IsSameSize(matrix))
            {
                throw new ArgumentException("Размер матрицы 1: " + GetRowsCount() + " на " + GetColumnsCount()
                   + ". Размер матрицы 2: " + matrix.GetRowsCount() + " на " + matrix.GetColumnsCount() + ". Сложение доступно только для матриц одного размера.", nameof(matrix));
            }

            for (int i = 0; i < GetRowsCount(); i++)
            {
                rows[i].Add(matrix.rows[i]);
            }

            return this;
        }

        public Matrix Subtract(Matrix matrix)
        {
            if (!IsSameSize(matrix))
            {
                throw new ArgumentException("Размер матрицы 1: " + GetRowsCount() + " на " + GetColumnsCount()
                   + ". Размер матрицы 2: " + matrix.GetRowsCount() + " на " + matrix.GetColumnsCount() + ". Вычитание доступно только для матриц одного размера.", nameof(matrix));
            }

            for (int i = 0; i < GetRowsCount(); i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }

            return this;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{");

            foreach (Vector e in rows)
            {
                stringBuilder.Append(e).Append(", ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append("}").ToString();
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (!matrix1.IsSameSize(matrix2))
            {
                throw new ArgumentException("Размер матрицы 1: " + matrix1.GetRowsCount() + " на " + matrix1.GetColumnsCount()
                     + ". Размер матрицы 2: " + matrix2.GetRowsCount() + " на " + matrix2.GetColumnsCount() + ". Сложение доступно только для матриц одного размера.", nameof(matrix2));
            }

            Matrix result = new Matrix(matrix1);

            return result.Add(matrix2);
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (!matrix1.IsSameSize(matrix2))
            {
                throw new ArgumentException("Размер матрицы 1: " + matrix1.GetRowsCount() + " на " + matrix1.GetColumnsCount()
                    + ". Размер матрицы 2: " + matrix2.GetRowsCount() + " на " + matrix2.GetColumnsCount() + ". Вычитание доступно только для матриц одного размера.", nameof(matrix2));
            }

            Matrix result = new Matrix(matrix1);

            return result.Subtract(matrix2);
        }

        public static Matrix GetProduct(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException("Размер матрицы 1: " + matrix1.GetRowsCount() + " на " + matrix1.GetColumnsCount()
                    + ". Размер матрицы 2: " + matrix2.GetRowsCount() + " на " + matrix2.GetColumnsCount() + ". Умножение доступно только для согласованных матриц.", nameof(matrix2));
            }

            Matrix resultMatrix = new Matrix(matrix1.GetRowsCount(), matrix2.GetColumnsCount());

            for (int i = 0; i < matrix1.GetRowsCount(); i++)
            {
                for (int j = 0; j < matrix2.GetColumnsCount(); j++)
                {
                    double component = Vector.GetScalarMultiplication(matrix1.rows[i], matrix2.GetColumn(j));

                    resultMatrix.rows[i].SetComponent(j, component);
                }
            }

            return resultMatrix;
        }
    }
}

