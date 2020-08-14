using System;

namespace CSharpOop.Shape.Shapes
{
    class Triangle : IShape
    {
        public double X1 { get; set; }
        public double Y1 { get; set; }
        public double X2 { get; set; }
        public double Y2 { get; set; }
        public double X3 { get; set; }
        public double Y3 { get; set; }

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            X3 = x3;
            Y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3));
        }

        public double GetHeight()
        {
            return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
        }

        public double GetArea()
        {
            return Math.Abs((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3)) / 2;
        }

        private static double GetSideLength(double startX, double startY, double endX, double endY)
        {
            return Math.Sqrt(Math.Pow((startX - endX), 2) + Math.Pow((startY - endY), 2));
        }

        public double GetPerimeter()
        {
            double length12 = GetSideLength(X1, Y1, X2, Y2);
            double length23 = GetSideLength(X2, Y2, X3, Y3);
            double length31 = GetSideLength(X3, Y3, X1, Y1);

            return length12 + length23 + length31;
        }

        public override string ToString()
        {
            return "Треугольник: " + X1 + ", " + Y1 + ", " + X2 + ", " + Y2 + ", " + X3 + ", " + Y3;
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

            Triangle triangle = (Triangle)o;

            return X1 == triangle.X1 && Y1 == triangle.Y1 && X2 == triangle.X2 && Y2 == triangle.Y2 && X3 == triangle.X3 && Y3 == triangle.Y3;
        }

        public override int GetHashCode()
        {
            int prime = 37;
            int hash = 1;

            hash = prime * hash + X1.GetHashCode();
            hash = prime * hash + Y1.GetHashCode();
            hash = prime * hash + X2.GetHashCode();
            hash = prime * hash + Y2.GetHashCode();
            hash = prime * hash + X3.GetHashCode();
            hash = prime * hash + Y3.GetHashCode();

            return hash;
        }
    }
}
