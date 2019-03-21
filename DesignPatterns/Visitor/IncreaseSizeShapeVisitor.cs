using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    class IncreaseSizeShapeVisitor : IShapeVisitor
    {
        public void Visit(Rect r)
        {
            throw new NotImplementedException();
        }

        public void Visit(Ellipse e)
        {
            throw new NotImplementedException();
        }
    }
}
