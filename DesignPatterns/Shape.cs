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
        protected string type;
        protected Shape selectedItem = null;
        protected Point mouseLocation;
        private List<Shape> shapes = new List<Shape>();

        public virtual void Draw(PaintEventArgs e, Size s){}
        public virtual string GetTypeBack()
        {
            return "shape";
        }

        public virtual void IncreaseSize(Shape r, EventArgs e)
        {
            _userSize = r.Size;
            _userSize = new Size(_userSize.Width + 10, _userSize.Height + 10);
            r.Size = _userSize;
        }

        public virtual void DecreaseSize(Shape r, EventArgs e)
        {
            _userSize = r.Size;
            _userSize = new Size(_userSize.Width - 10, _userSize.Height - 10);
            r.Size = _userSize;
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
            return _userSize;
        }

        public void Add(Shape s)
        {
            this.shapes.Add(s);
        }

        public void Remove(Shape s)
        {
            this.shapes.Remove(s);
        }

        public List<Shape> GetShapesInGroup()
        {
            return this.shapes;
        }

        public string toString()
        {
            return "Hallo";
        }

        public void MakeGroup(Shape group, List<Shape> groupShapes)
        {
            for (int i = 1; i < groupShapes.Count(); i++)
            {
                if(groupShapes[i].shapes.Count() == 0)
                {
                    group.Add(groupShapes[i]);
                }
            }
        }

        public void ListGroup()
        {
            foreach (Shape shape in this.GetShapesInGroup())
            {
                Console.WriteLine("Hoi");
                foreach (Shape item in shape.GetShapesInGroup())
                {
                    Console.WriteLine("\tHallo");
                }
            }
        }
    }
}
