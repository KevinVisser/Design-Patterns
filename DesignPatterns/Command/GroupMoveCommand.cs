using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class GroupMoveCommand : ICommand
    {
        private Shape group;

        public GroupMoveCommand(Shape group)
        {
            this.group = group;
        }

        public void Execute(EventArgs e)
        {
            foreach (Shape shape in group.GetShapesInGroup())
            {
                shape.Move();
            }
            group.Move();
        }
    }
}
