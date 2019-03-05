using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns.Command
{
    class SaveCommand : ICommand
    {
        private Panel p;

        public SaveCommand(Panel p)
        {
            this.p = p;
        }

        public void Execute(EventArgs e)
        {
            Save.SaveImage(this.p);
        }
    }
}
