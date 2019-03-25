using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    class SaveFileVisitor : ShapeVisitor
    {
        public override void Visit(Shape s, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
