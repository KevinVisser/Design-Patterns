using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns.Command
{
    class Move : ICommand
    {
        private Shape _r;

        public Move(Shape r)
        {
            _r = r;
        }

        public void Execute(EventArgs e)
        {
            if(_r.IsPartOfGroup())
            {
                _r.GroupMove();
                //Group group = _r.BelongsToGroup();
                //foreach (Shape shape in group.GetShapesInGroup())
                //{
                //    shape.GroupMove();
                //}
            }
            else
            {
                _r.Move();
            }
        }
    }
}
