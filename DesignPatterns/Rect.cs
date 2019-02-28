using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns
{
    public class Rect : Shape
    {
        public Rect(Size userSize)
        {
            this._userSize = userSize;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public override void Draw(EventArgs e)
        {
            PaintEventArgs paint = (PaintEventArgs)e;
            paint.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, _userSize.Width, _userSize.Height));
        }
    }
}
