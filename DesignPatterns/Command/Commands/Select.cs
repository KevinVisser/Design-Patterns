using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns.Command
{
    class Select : ICommand
    {
        private Shape _r;

        public Select(Shape r)
        {
            _r = r;
        }

        public void Execute(EventArgs e)
        {
            _r.Select();
        }
    }
}
