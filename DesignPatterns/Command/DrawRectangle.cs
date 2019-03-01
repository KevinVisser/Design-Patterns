using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns.Command
{
    public class DrawRectangle : ICommand
    {
        private Shape _r;

        public DrawRectangle(Shape r)
        {
            _r = r;
        }

        public void Execute(EventArgs e)
        {
            PaintEventArgs paint = e as PaintEventArgs;
            _r.Draw(paint, _r.GetUserSize());
        }
    }
}
