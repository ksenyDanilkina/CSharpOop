using System;
using System.Text;

namespace CSharpOop.Vector
{
    class Vector
    {
        private double[] components;

        public double[] Components
        {
            get
            {
                return components;
            }

            set
            {
                if (value.Length <= 0)
                {
                    throw new ArgumentException("value должно быть больше 0.", nameof(value));
                }

                components = value;
            }
        }

        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("dimension должно быть больше 0.", nameof(dimension));
            }

            Components = new double[dimension];
        }

        public Vector(Vector vector)
        {
            Components = new double[vector.Components.Length];
            Array.Copy(vector.Components, Components, vector.Components.Length);
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException("components.Length должно быть больше 0.", nameof(components.Length));
            }

            Components = new double[components.Length];
            Array.Copy(components, Components, components.Length);
        }

        public Vector(int dimension, double[] components)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("dimension должно быть больше 0.", nameof(dimension));
            }

            if (components.Length == 0)
            {
                throw new ArgumentException("components.Length должно быть больше 0.", nameof(components.Length));
            }

            Components = new double[dimension];

            Array.Copy(components, Components, Math.Min(components.Length, dimension));
        }

        public int GetSize()
        {
            return Components.Length;
        }

        public override string ToString()
        {
            StringBuilder resultString = new StringBuilder();

            for (int i = 0; i < Components.Length; i++)
            {
                if (i == 0)
                {
                    resultString.Append("{ ").Append(Components[i]).Append(", ");
                    continue;
                }

                if (i == Components.Length - 1)
                {
                    resultString.Append(Components[i]).Append(" }");
                    continue;
                }

                resultString.Append(Components[i]).Append(", ");
            }

            return resultString.ToString();
        }

        public Vector Addition(Vector vector)
        {
            if (Components.Length < vector.Components.Length)
            {
                double[] tmp = new double[vector.Components.Length];
                Array.Copy(Components, tmp, Components.Length);
                Components = tmp;
            }

            if (Components.Length > vector.Components.Length)
            {
                double[] tmp = new double[Components.Length];
                Array.Copy(vector.Components, tmp, vector.Components.Length);
                vector.Components = tmp;
            }

            for (int i = 0; i < Math.Max(Components.Length, vector.Components.Length); i++)
            {
                Components[i] += vector.Components[i];
            }

            return this;
        }

        public Vector Subtraction(Vector vector)
        {
            if (Components.Length < vector.Components.Length)
            {
                double[] tmp = new double[vector.Components.Length];
                Array.Copy(Components, tmp, Components.Length);
                Components = tmp;
            }

            if (Components.Length > vector.Components.Length)
            {
                double[] tmp = new double[Components.Length];
                Array.Copy(vector.Components, tmp, vector.Components.Length);
                vector.Components = tmp;
            }

            for (int i = 0; i < Math.Max(Components.Length, vector.Components.Length); i++)
            {
                Components[i] -= vector.Components[i];
            }

            return this;
        }

        public Vector Multiplication(double scalar)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i] *= scalar;
            }

            return this;
        }

        public Vector GetRevert()
        {
            return Multiplication(-1);
        }

        public double GetLength()
        {
            double squaredComponentsSum = 0;

            foreach (double e in Components)
            {
                squaredComponentsSum += Math.Pow(e, 2);
            }

            return Math.Sqrt(squaredComponentsSum);
        }

        public double GetComponent(int index)
        {
            return Components[index];
        }

        public void SetComponent(int index, double value)
        {
            Components[index] = value;
        }

        public static Vector GetAddition(Vector vector1, Vector vector2)
        {
            Vector resultVector = vector1.Addition(vector2);

            return resultVector;
        }

        public static Vector GetSubtraction(Vector vector1, Vector vector2)
        {
            Vector resultVector = vector1.Subtraction(vector2);

            return resultVector;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            int maxArrayLength = Math.Max(vector2.Components.Length, vector1.Components.Length);

            Vector resultVector = new Vector(maxArrayLength);
            Array.Copy(vector1.Components, resultVector.Components, vector1.Components.Length);

            if (vector2.Components.Length < vector1.Components.Length)
            {
                double[] tmp = new double[vector1.Components.Length];
                Array.Copy(vector2.Components, tmp, vector2.Components.Length);
                vector2.Components = tmp;
            }

            double scalarMultiplicationResult = 0;

            for (int i = 0; i < maxArrayLength; i++)
            {
                scalarMultiplicationResult += resultVector.Components[i] * vector2.Components[i];
            }

            return scalarMultiplicationResult;
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

            if (Components.Length != vector.Components.Length)
            {
                return false;
            }

            for (int i = 0; i < Components.Length; i++)
            {
                if (Components[i] != vector.Components[i])
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

            foreach (double e in Components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }
    }
}
