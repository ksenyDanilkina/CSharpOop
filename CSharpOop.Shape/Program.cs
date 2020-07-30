using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOop.Shape
{
    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes = { new Square(6), new Circle(5), new Circle(67), new Square(450), new Triangle(-1, -9, 88, 58, 122, 280), new Rectangle(20, 20) };

            Console.WriteLine("Фигура с большей площадью - " + GetMaxAreaShape(shapes));
            Console.WriteLine("Фигура со вторым по величине периметром - " + GetSecondPerimeterShape(shapes));
        }

        public static IShape GetMaxAreaShape(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesAreaComparer());

            return shapes[0];
        }

        public static IShape GetSecondPerimeterShape(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapesPerimeterComparer());

            return shapes[1];
        }
    }
}
