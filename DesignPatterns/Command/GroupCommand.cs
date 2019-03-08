using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class GroupCommand : ICommand
    {
        private Shape group;
        private List<Shape> groupShapes = new List<Shape>();

        public GroupCommand(Shape group, List<Shape> groupShapes)
        {
            this.group = group;
            this.groupShapes = groupShapes;
        }

        public void Execute(EventArgs e)
        {
            group.MakeGroup(group, groupShapes);
        }
    }
}
