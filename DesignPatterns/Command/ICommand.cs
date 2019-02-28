using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns.Command
{
    public interface ICommand
    {
        void Execute(EventArgs e);
    }
}
