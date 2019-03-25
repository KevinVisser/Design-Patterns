using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns.Command
{
    class DrawRectangleCommand : ICommand
    {
        private Shape _r;

        public DrawRectangleCommand(Shape r)
        {
            _r = r;
        }

        public void Execute(EventArgs e)
        {
            PaintEventArgs paint = e as PaintEventArgs;
            _r.Draw(paint, _r.Size);
        }
    }
}
