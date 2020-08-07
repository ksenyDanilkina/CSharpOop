using System;
using CSharpOop.Shape.Comparers;
using CSharpOop.Shape.Shapes;

namespace CSharpOop.Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes =
            {
                new Square(6),
                new Circle(5),
                new Circle(67),
                new Square(450),
                new Triangle(-1, -9, 88, 58, 122, 280),
                new Rectangle(20, 20)
            };

            Console.WriteLine("Фигура с большей площадью - " + GetMaxAreaShape(shapes));
            Console.WriteLine("Фигура со вторым по величине периметром - " + GetSecondPerimeterShape(shapes));
        }

        public static IShape GetMaxAreaShape(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesAreaComparer());

            return shapes[shapes.Length - 1];
        }

        public static IShape GetSecondPerimeterShape(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesPerimeterComparer());

            return shapes[shapes.Length - 2];
        }
    }
}
