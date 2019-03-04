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
            this._r.IncreaseSize(_r, e);
        }

        public void Undo(EventArgs e)
        {
            this._r.DecreaseSize(_r, e);
        }
    }
}
