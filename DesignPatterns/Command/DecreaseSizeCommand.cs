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
            this._r.DecreaseSize(_r, e);
        }

        public void Undo(EventArgs e)
        {
            this._r.IncreaseSize(_r, e);
        }
    }
}
