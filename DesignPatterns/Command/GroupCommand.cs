using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class GroupCommand : ICommand
    {
        private Shape shape;
        private List<Shape> groupShapes = new List<Shape>();

        public GroupCommand(List<Shape> groupShapes)
        {
            shape = new Shape();
            this.groupShapes = groupShapes;
        }

        public void Execute(EventArgs e)
        {
            shape.MakeGroup(groupShapes);
        }
    }
}
