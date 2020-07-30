using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOop.Shape
{
    class ShapesPerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if (shape1.GetPerimeter() > shape2.GetPerimeter())
            {
                return -1;
            }

            if (shape1.GetArea() < shape2.GetArea())
            {
                return 1;
            }

            return 0;
        }
    }
}
