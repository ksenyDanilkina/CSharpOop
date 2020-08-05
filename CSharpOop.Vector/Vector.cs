using System;

namespace CSharpOop.Vector
{
    class Vector
    {
        public double[] VectorComponents { get; set; }

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше 0.");
            }

            VectorComponents = new double[n];
        }
        public Vector(Vector vector)
        {
            VectorComponents = new double[vector.VectorComponents.Length];
            Array.Copy(vector.VectorComponents, VectorComponents, vector.VectorComponents.Length);
        }

        public Vector(double[] vectorComponents)
        {
            VectorComponents = new double[vectorComponents.Length];
            Array.Copy(vectorComponents, VectorComponents, vectorComponents.Length);
        }

        public Vector(int n, double[] vectorComponents)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность вектора должна быть больше 0.");
            }

            VectorComponents = new double[n];

            if (n >= vectorComponents.Length)
            {
                Array.Copy(vectorComponents, VectorComponents, vectorComponents.Length);
            }
            else
            {
                Array.Copy(vectorComponents, VectorComponents, n);
            }
        }

        public int GetSize()
        {
            return VectorComponents.Length;
        }

        public override string ToString()
        {
            string resultString = null;

            for (int i = 0; i < VectorComponents.Length; i++)
            {
                if (i == 0)
                {
                    resultString += "{ " + VectorComponents[i] + ", ";
                    continue;
                }

                if (i == VectorComponents.Length - 1)
                {
                    resultString += VectorComponents[i] + " }";
                    continue;
                }

                resultString += VectorComponents[i] + ", ";
            }

            return resultString;
        }

        public Vector GetVectorsAddition(Vector vector)
        {
            if (VectorComponents.Length < vector.VectorComponents.Length)
            {
                double[] tmp = new double[vector.VectorComponents.Length];
                Array.Copy(VectorComponents, tmp, VectorComponents.Length);
                VectorComponents = tmp;
            }
            else
            {
                double[] tmp = new double[VectorComponents.Length];
                Array.Copy(vector.VectorComponents, tmp, vector.VectorComponents.Length);
                vector.VectorComponents = tmp;
            }

            for (int i = 0; i < Math.Max(VectorComponents.Length, vector.VectorComponents.Length); i++)
            {
                VectorComponents[i] += vector.VectorComponents[i];
            }

            return this;
        }

        public Vector GetVectorsSubtraction(Vector vector)
        {
            if (VectorComponents.Length < vector.VectorComponents.Length)
            {
                double[] tmp = new double[vector.VectorComponents.Length];
                Array.Copy(VectorComponents, tmp, VectorComponents.Length);
                VectorComponents = tmp;
            }
            else
            {
                double[] tmp = new double[VectorComponents.Length];
                Array.Copy(vector.VectorComponents, tmp, vector.VectorComponents.Length);
                vector.VectorComponents = tmp;
            }

            for (int i = 0; i < Math.Max(VectorComponents.Length, vector.VectorComponents.Length); i++)
            {
                VectorComponents[i] -= vector.VectorComponents[i];
            }

            return this;
        }

        public Vector GetScalarMultiplication(double scalar)
        {
            for (int i = 0; i < VectorComponents.Length; i++)
            {
                VectorComponents[i] *= scalar;
            }

            return this;
        }

        public Vector GetRevertVector()
        {
            for (int i = 0; i < VectorComponents.Length; i++)
            {
                VectorComponents[i] *= -1;
            }

            return this;
        }

        public double GetVectorLength()
        {
            double vectorLength = 0;

            for (int i = 0; i < VectorComponents.Length; i++)
            {
                vectorLength += Math.Pow(VectorComponents[i], 2);
            }

            return Math.Sqrt(vectorLength);
        }

        public double GetVectorComponent(int index)
        {
            return VectorComponents[index];
        }

        public void SetVectorComponent(int index, double value)
        {
            VectorComponents[index] = value;
        }

        public static Vector GetStaticVectorsAddition(Vector vector1, Vector vector2)
        {
            int maxArrayLength = Math.Max(vector2.VectorComponents.Length, vector1.VectorComponents.Length);

            Vector resultVector = new Vector(maxArrayLength);
            Array.Copy(vector1.VectorComponents, resultVector.VectorComponents, vector1.VectorComponents.Length);

            if (vector2.VectorComponents.Length < vector1.VectorComponents.Length)
            {
                double[] tmp = new double[vector1.VectorComponents.Length];
                Array.Copy(vector2.VectorComponents, tmp, vector2.VectorComponents.Length);
                vector2.VectorComponents = tmp;
            }

            for (int i = 0; i < maxArrayLength; i++)
            {
                resultVector.VectorComponents[i] += vector2.VectorComponents[i];
            }

            return resultVector;
        }

        public static Vector GetStaticVectorsSubtraction(Vector vector1, Vector vector2)
        {
            int maxArrayLength = Math.Max(vector2.VectorComponents.Length, vector1.VectorComponents.Length);

            Vector resultVector = new Vector(maxArrayLength);
            Array.Copy(vector1.VectorComponents, resultVector.VectorComponents, vector1.VectorComponents.Length);

            if (vector2.VectorComponents.Length < vector1.VectorComponents.Length)
            {
                double[] tmp = new double[vector1.VectorComponents.Length];
                Array.Copy(vector2.VectorComponents, tmp, vector2.VectorComponents.Length);
                vector2.VectorComponents = tmp;
            }

            for (int i = 0; i < maxArrayLength; i++)
            {
                resultVector.VectorComponents[i] -= vector2.VectorComponents[i];
            }

            return resultVector;
        }

        public static Vector GetStaticVectorsScalarMultiplication(Vector vector1, Vector vector2)
        {
            int maxArrayLength = Math.Max(vector2.VectorComponents.Length, vector1.VectorComponents.Length);

            Vector resultVector = new Vector(maxArrayLength);
            Array.Copy(vector1.VectorComponents, resultVector.VectorComponents, vector1.VectorComponents.Length);

            if (vector2.VectorComponents.Length < vector1.VectorComponents.Length)
            {
                double[] tmp = new double[vector1.VectorComponents.Length];
                Array.Copy(vector2.VectorComponents, tmp, vector2.VectorComponents.Length);
                vector2.VectorComponents = tmp;
            }

            for (int i = 0; i < maxArrayLength; i++)
            {
                resultVector.VectorComponents[i] *= vector2.VectorComponents[i];
            }

            return resultVector;
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != GetType())
            {
                return false;
            }

            Vector vector = (Vector)o;

            if (VectorComponents.Length != vector.VectorComponents.Length)
            {
                return false;
            }

            for (int i = 0; i < VectorComponents.Length; i++)
            {
                if (VectorComponents[i] != vector.VectorComponents[i])
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            for (int i = 0; i < VectorComponents.Length; i++)
            {
                hash = prime * hash + VectorComponents[i].GetHashCode();
            }

            return hash;
        }
    }
}
