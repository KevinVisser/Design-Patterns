using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Command
{
    class MoveCommand : ICommand
    {
        private Shape _r;

        public MoveCommand(Shape r)
        {
            _r = r;
        }

        public void Execute(EventArgs e)
        {
            _r.Move();
        }
    }
}
