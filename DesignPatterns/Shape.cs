using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns
{
    public class Shape : Panel
    {
        protected Size _userSize;
        protected Shape selectedItem = null;
        protected Point mouseLocation;

        public virtual void Draw(PaintEventArgs e, Size s){}

        public new virtual void Resize(Shape r, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            _userSize = r.Size;
            switch (mouse.Button)
            {
                case MouseButtons.Left:
                    _userSize = new Size(_userSize.Width + 10, _userSize.Height + 10);
                    r.Size = _userSize;
                    break;
                case MouseButtons.Right:
                    _userSize = new Size(_userSize.Width - 10, _userSize.Height - 10);
                    r.Size = _userSize;
                    break;
            }
        }

        public virtual void Select(Shape r)
        {
            if (selectedItem == null)
            {
                selectedItem = r;
            }
            else
            {
                selectedItem = null;
            }
            
        }

        public new virtual void Move()
        {
            if(selectedItem == null)
            {
                Console.WriteLine("Null");
            }
            else
            {
                mouseLocation = MousePosition;
                mouseLocation.X -= (selectedItem.Width / 2);
                mouseLocation.Y -= (selectedItem.Height / 2);
                selectedItem.Location = selectedItem.Parent.PointToClient(mouseLocation);
            }
        }

        public Size GetUserSize()
        {
            return this._userSize;
        }
    }
}
