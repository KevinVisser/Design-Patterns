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
                List<Shape> list = _r.ListGroup(_r);

                foreach (Shape shape in list)
                {
                    shape.IncreaseSize(e);
                }

                list.Clear();
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
                List<Shape> list = _r.ListGroup(_r);

                foreach (Shape shape in list)
                {
                    shape.DecreaseSize(e);
                }

                list.Clear();
            }
            else
            {
                _r.DecreaseSize(e);
            }
        }
    }
}
