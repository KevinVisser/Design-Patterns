using DesignPatterns.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Visitor
{
    public abstract class ShapeVisitor
    {
        protected CommandManager commandManager = CommandManager.getInstance();

        public virtual void Visit(Shape s, EventArgs e) { }
    }
}
