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
                throw new ArgumentException("RowsCount = " + rowsCount + ". RowsCount должно быть больше 0.", nameof(rowsCount));
            }

            if (columnsCount <= 0)
            {
                throw new ArgumentException("ColumnsCount = " + columnsCount + ". ColumnsCount должно быть больше 0.", nameof(columnsCount));
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
            Array.Copy(matrix.rows, rows, matrix.rows.Length);
        }

        public Matrix(double[,] matrix)
        {
            rows = new Vector[matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                Vector row = new Vector(matrix.GetLength(1));

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    row.SetComponent(j, matrix[i, j]);
                }

                rows[i] = new Vector(row);
            }
        }

        public Matrix(Vector[] vectors)
        {
            rows = new Vector[vectors.Length];
            Array.Copy(vectors, rows, vectors.Length);

            int maxRowLength = vectors[0].GetSize();
            bool isNeedAddZero = false;

            for (int i = 1; i < vectors.Length; i++)
            {
                if (vectors[i].GetSize() < maxRowLength)
                {
                    isNeedAddZero = true;
                    continue;
                }

                if (vectors[i].GetSize() > maxRowLength)
                {
                    maxRowLength = vectors[i].GetSize();
                    isNeedAddZero = true;
                }
            }

            if (isNeedAddZero)
            {
                for (int i = 0; i < vectors.Length; i++)
                {
                    if (vectors[i].GetSize() < maxRowLength)
                    {
                        Vector newRow = new Vector(maxRowLength);

                        for (int j = 0; j < vectors[i].GetSize(); j++)
                        {
                            newRow.SetComponent(j, vectors[i].GetComponent(j));
                        }

                        SetRow(i, newRow);
                    }
                }
            }
        }

        public void SetRow(int index, Vector value)
        {
            rows[index] = value;
        }

        public Vector GetRow(int index)
        {
            return rows[index];
        }

        public int GetHorizontalSize()
        {
            return rows[0].GetSize();
        }

        public int GetVerticalSize()
        {
            return rows.Length;
        }

        public Vector GetVectorColumn(int index)
        {
            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("Index = " + index + ". Index  должен быть > 0", nameof(index));
            }

            if (index > GetHorizontalSize() - 1)
            {
                throw new ArgumentOutOfRangeException("Index = " + index + ". Index  должен быть < " + (GetHorizontalSize() - 1), nameof(index));
            }

            Vector columnVector = new Vector(rows.Length);

            for (int i = 0; i < rows.Length; i++)
            {
                double component = rows[i].GetComponent(index);
                columnVector.SetComponent(i, component);
            }

            return columnVector;
        }

        public Matrix Transpose()
        {
            Vector[] tmp = new Vector[GetHorizontalSize()];

            for (int i = 0; i < GetHorizontalSize(); i++)
            {
                Vector transposedMatrixRow = new Vector(GetVerticalSize());

                for (int j = 0; j < GetVerticalSize(); j++)
                {
                    transposedMatrixRow.SetComponent(j, rows[j].GetComponent(i));
                }

                tmp[i] = transposedMatrixRow;
            }

            if (tmp.Length != rows.Length)
            {
                Array.Resize(ref rows, tmp.Length);
            }

            Array.Copy(tmp, rows, tmp.Length);

            return this;
        }

        public Matrix Multiply(double scalar)
        {
            for (int i = 0; i < GetVerticalSize(); i++)
            {
                rows[i].Multiply(scalar);
            }

            return this;
        }

        private Matrix GetMatrixMinor(int rowForDelete, int columnForDelete)
        {
            Vector[] minorRows = new Vector[GetHorizontalSize() - 1];

            int rowOffset = 0;

            for (int i = 0; i < GetVerticalSize(); i++)
            {
                if (i == rowForDelete)
                {
                    rowOffset = 1;
                    continue;
                }

                int columnOffset = 0;

                Vector tmp = new Vector(GetVerticalSize() - 1);

                for (int j = 0; j < GetHorizontalSize(); j++)
                {
                    if (j == columnForDelete)
                    {
                        columnOffset = 1;
                        continue;
                    }

                    tmp.SetComponent(j - columnOffset, rows[i].GetComponent(j));
                }

                minorRows[i - rowOffset] = tmp;
            }

            return new Matrix(minorRows);
        }

        public double GetDeterminant()
        {
            if (GetHorizontalSize() != GetVerticalSize())
            {
                throw new NotSupportedException("Матрица - не квадратная, невозможно найти определитель.");
            }

            double determinant = 0;

            if (GetHorizontalSize() == 1)
            {
                return rows[0].GetComponent(0);
            }

            if (GetHorizontalSize() == 2)
            {
                return rows[0].GetComponent(0) * rows[1].GetComponent(1) - rows[0].GetComponent(1) * rows[1].GetComponent(0);
            }

            for (int j = 0; j < GetHorizontalSize(); j++)
            {
                if (j % 2 == 0)
                {
                    determinant += rows[0].GetComponent(j) * GetMatrixMinor(0, j).GetDeterminant();
                }
                else
                {
                    determinant -= rows[0].GetComponent(j) * GetMatrixMinor(0, j).GetDeterminant();
                }
            }

            return determinant;
        }

        public Vector GetMultiplicationOnVector(Vector vector)
        {
            if (GetHorizontalSize() != vector.GetSize())
            {
                throw new NotSupportedException("Длина вектора должна быть равна количеству столбцов в матрице");
            }

            Vector resultVector = new Vector(GetVerticalSize());

            double resultVectorComponent = 0;

            for (int i = 0; i < GetVerticalSize(); i++)
            {
                for (int j = 0; j < GetHorizontalSize(); j++)
                {
                    resultVectorComponent += rows[i].GetComponent(j) * vector.GetComponent(j);
                }

                resultVector.SetComponent(i, resultVectorComponent);
                resultVectorComponent = 0;
            }

            return resultVector;
        }

        public Matrix GetAddition(Matrix matrix)
        {
            if (GetHorizontalSize() != matrix.GetHorizontalSize() || GetVerticalSize() != matrix.GetVerticalSize())
            {
                throw new NotSupportedException("Сложение доступно только для матриц одного размера.");
            }

            Matrix resultMatrix = new Matrix(GetVerticalSize(), GetHorizontalSize());

            for (int i = 0; i < GetVerticalSize(); i++)
            {
                for (int j = 0; j < GetHorizontalSize(); j++)
                {
                    double resultComponent = rows[i].GetComponent(j) + matrix.rows[i].GetComponent(j);
                    resultMatrix.rows[i].SetComponent(j, resultComponent);
                }
            }

            return resultMatrix;
        }

        public Matrix GetSubstraction(Matrix matrix)
        {
            if (GetHorizontalSize() != matrix.GetHorizontalSize() || GetVerticalSize() != matrix.GetVerticalSize())
            {
                throw new NotSupportedException("Вычитание доступно только для матриц одного размера.");
            }

            Matrix resultMatrix = new Matrix(GetVerticalSize(), GetHorizontalSize());

            for (int i = 0; i < GetVerticalSize(); i++)
            {
                for (int j = 0; j < GetHorizontalSize(); j++)
                {
                    double resultComponent = rows[i].GetComponent(j) - matrix.rows[i].GetComponent(j);
                    resultMatrix.rows[i].SetComponent(j, resultComponent);
                }
            }

            return resultMatrix;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{ ");

            foreach (Vector e in rows)
            {
                stringBuilder.Append(e).Append(", ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append(" }").ToString();
        }

        public static Matrix GetAdd(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixForAddition = new Matrix(matrix1);

            return matrixForAddition.GetAddition(matrix2);
        }

        public static Matrix GetSubstract(Matrix matrix1, Matrix matrix2)
        {
            Matrix matrixForSubstract = new Matrix(matrix1);

            return matrixForSubstract.GetSubstraction(matrix2);
        }

        public static Matrix GetMultiply(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetHorizontalSize() != matrix2.GetVerticalSize())
            {
                throw new NotSupportedException("Умножение доступно только для согласованных матриц.");
            }

            Matrix resultMatrix = new Matrix(matrix1.GetVerticalSize(), matrix2.GetHorizontalSize());

            for (int i = 0; i < matrix1.GetVerticalSize(); i++)
            {
                for (int j = 0; j < matrix2.GetHorizontalSize(); j++)
                {
                    double component = 0;

                    for (int k = 0; k < matrix1.GetHorizontalSize(); k++)
                    {
                        component += matrix1.rows[i].GetComponent(k) * matrix2.rows[k].GetComponent(j);
                    }

                    resultMatrix.rows[i].SetComponent(j, component);
                }
            }

            return resultMatrix;
        }
    }
}

