using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class GroupIncreaseSizeCommand : IUndoableCommand
    {
        Shape group;

        public GroupIncreaseSizeCommand(Shape group)
        {
            this.group = group;
        }

        public void Execute(EventArgs e)
        {
            foreach (Shape shape in group.GetShapesInGroup())
            {
                shape.IncreaseSize(e);
            }
            group.IncreaseSize(e);
        }

        public void Undo(EventArgs e)
        {
            foreach (Shape shape in group.GetShapesInGroup())
            {
                shape.DecreaseSize(e);
            }
            group.DecreaseSize(e);
        }
    }
}
