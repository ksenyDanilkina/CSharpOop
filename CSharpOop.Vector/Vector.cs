using System;
using System.Text;

namespace CSharpOop.Vector
{
    class Vector
    {
        private double[] components;

        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("dimension должно быть больше 0.", nameof(dimension));
            }

            components = new double[dimension];
        }

        public Vector(Vector vector)
        {
            components = new double[vector.components.Length];
            Array.Copy(vector.components, components, vector.components.Length);
        }

        public Vector(double[] components)
        {
            if (components.Length == 0)
            {
                throw new ArgumentException("components.Length должно быть больше 0.", nameof(components.Length));
            }

            this.components = new double[components.Length];
            Array.Copy(components, this.components, components.Length);
        }

        public Vector(int dimension, double[] components)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("dimension должно быть больше 0.", nameof(dimension));
            }

            this.components = new double[dimension];

            Array.Copy(components, this.components, Math.Min(components.Length, dimension));
        }

        public int GetSize()
        {
            return components.Length;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append("{ ");

            foreach (double e in components)
            {
                stringBuilder.Append(e).Append(", ");
            }

            return stringBuilder.Remove(stringBuilder.Length - 2, 2).Append(" }").ToString();
        }

        public Vector Add(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] += vector.components[i];
            }

            return this;
        }

        public Vector Subtract(Vector vector)
        {
            if (components.Length < vector.components.Length)
            {
                Array.Resize(ref components, vector.components.Length);
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector.components[i];
            }

            return this;
        }

        public Vector Multiply(double scalar)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= scalar;
            }

            return this;
        }

        public Vector Revert()
        {
            return Multiply(-1);
        }

        public double GetLength()
        {
            double squaredComponentsSum = 0;

            foreach (double e in components)
            {
                squaredComponentsSum += Math.Pow(e, 2);
            }

            return Math.Sqrt(squaredComponentsSum);
        }

        public double GetComponent(int index)
        {
            return components[index];
        }

        public void SetComponent(int index, double value)
        {
            components[index] = value;
        }

        public static Vector GetAddition(Vector vector1, Vector vector2)
        {
            Vector vectorForAddition = new Vector(vector1);

            return vectorForAddition.Add(vector2);
        }

        public static Vector GetSubtraction(Vector vector1, Vector vector2)
        {
            Vector vectorForSubtraction = new Vector(vector1);

            return vectorForSubtraction.Subtract(vector2);
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            double scalarMultiplicationResult = 0;

            for (int i = 0; i < Math.Min(vector1.components.Length, vector2.components.Length); i++)
            {
                scalarMultiplicationResult += vector1.components[i] * vector2.components[i];
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

            if (components.Length != vector.components.Length)
            {
                return false;
            }

            for (int i = 0; i < components.Length; i++)
            {
                if (components[i] != vector.components[i])
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

            foreach (double e in components)
            {
                hash = prime * hash + e.GetHashCode();
            }

            return hash;
        }
    }
}
