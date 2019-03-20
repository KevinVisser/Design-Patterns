using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    public interface IShapeVisitor
    {
        void Visit(Rect r);
        void Visit(Ellipse e);
    }
}