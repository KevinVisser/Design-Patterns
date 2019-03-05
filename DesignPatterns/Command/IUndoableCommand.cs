using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    interface IUndoableCommand : ICommand
    {
        void Undo(EventArgs e);
    }
}
