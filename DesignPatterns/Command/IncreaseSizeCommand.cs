using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class IncreaseSizeCommand : IUndoableCommand
    {
        private Shape _r;

        public IncreaseSizeCommand(Shape r)
        {
            _r = r;
        }

        public void Execute(EventArgs e)
        {
            if (_r.IsPartOfGroup())
            {
                Group group = _r.BelongsToGroup();
                foreach (Shape shape in group.GetShapesInGroup())
                {
                    shape.IncreaseSize(e);
                }
            }
            else
            {
                _r.IncreaseSize(e);
            }
        }

        public void Undo(EventArgs e)
        {
            if (_r.IsPartOfGroup())
            {
                Group group = _r.BelongsToGroup();
                foreach (Shape shape in group.GetShapesInGroup())
                {
                    shape.DecreaseSize(e);
                }
            }
            else
            {
                _r.DecreaseSize(e);
            }
        }
    }
}
