using DesignPatterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    class MoveShapeVisitor : ShapeVisitor
    {
        public override void Visit(Shape s, EventArgs e)
        {
            commandManager.ExecuteCommand(new MoveCommand(s), e);
        }
    }
}
