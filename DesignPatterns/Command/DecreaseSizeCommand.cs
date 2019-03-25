using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class DecreaseSizeCommand : IUndoableCommand
    {
        private Shape _r;

        public DecreaseSizeCommand(Shape r)
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
                    shape.DecreaseSize(e);
                }

                list.Clear();
            }
            else
            {
                _r.DecreaseSize(e);
            }
        }

        public void Undo(EventArgs e)
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
    }
}
