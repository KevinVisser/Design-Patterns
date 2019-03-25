using DesignPatterns.Visitor;
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
        public Rect(Point location, Size userSize)
        {
            this.type = "Rectangle";
            this._location = location;
            this._userSize = userSize;
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }

        public override void Draw(PaintEventArgs e, Size size)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, this._userSize.Width, this._userSize.Height));
        }

        public override void Draw(Graphics g, Size size)
        {
            g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(this.Location.X, this.Location.Y, this._userSize.Width, this._userSize.Height));
        }

        public override string GetTypeBack()
        {
            return type;
        }

        public override void Accept(ShapeVisitor visitor, EventArgs e)
        {
            visitor.Visit(this, e);
        }

        public override List<Shape> ListOfShapes()
        {
            return shapes;
        }
    }
}
