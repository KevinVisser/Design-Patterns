using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    public class ShapeVisitor : IShapeVisitor
    {
        public void Visit(Rect r)
        {
            Console.WriteLine("Hallo");
        }

        public void Visit(Ellipse e)
        {
            throw new NotImplementedException();
        }
    }
}
