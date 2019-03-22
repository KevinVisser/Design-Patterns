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
    public class Shape : Panel
    {
        protected Size _userSize;
        protected Point location;
        protected Group group;
        protected string type;
        protected Shape selectedItem = null;
        protected Point mouseLocation;
        private List<Shape> shapes = new List<Shape>();
        protected bool isPartOfGroup = false;

        public virtual void Accept(ShapeVisitor visitor, EventArgs e) { }

        public virtual void Draw(PaintEventArgs e, Size s){}
        public virtual string GetTypeBack()
        {
            return "shape";
        }

        public virtual void IncreaseSize(EventArgs e)
        {
            _userSize = this.Size;
            _userSize = new Size(_userSize.Width + 10, _userSize.Height + 10);
            this.Size = _userSize;
        }

        public virtual void DecreaseSize(EventArgs e)
        {
            _userSize = this.Size;
            _userSize = new Size(_userSize.Width - 10, _userSize.Height - 10);
            this.Size = _userSize;
        }

        public new virtual void Select()
        {
            if (selectedItem == null)
            {
                selectedItem = this;
            }
            else
            {
                selectedItem = null;
            }
        }

        public new virtual void Move()
        {
            if (selectedItem == null)
            {
                selectedItem = this;
            }
            else
            {
                mouseLocation = this.Parent.PointToClient(MousePosition);
                mouseLocation.X -= (selectedItem.Width / 2);
                mouseLocation.Y -= (selectedItem.Height / 2);
                this.Location = mouseLocation;
                selectedItem = null;
            }
        }

        public virtual void GroupMove()
        {
            if(selectedItem == null)
            {
                selectedItem = this;
            }
            else
            {
                Group group = this.BelongsToGroup();
                Point offset = new Point();
                mouseLocation = this.Parent.PointToClient(MousePosition);
                Console.WriteLine(mouseLocation);

                mouseLocation.X = mouseLocation.X - (this.Width / 2);
                mouseLocation.Y = mouseLocation.Y - (this.Height / 2);
                
                offset.X = mouseLocation.X - this.Location.X;
                offset.Y = mouseLocation.Y - this.Location.Y;
                
                foreach (Shape shape in group.GetShapesInGroup())
                {
                    Point newloc = shape.Location;
                    newloc.X += offset.X;
                    newloc.Y += offset.Y;

                    shape.Location = newloc;
                }
                selectedItem = null;
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

        public bool IsPartOfGroup()
        {
            return isPartOfGroup;
        }

        public Group BelongsToGroup()
        {
            return group;
        }

        public void MakeGroup(Shape groupie, List<Shape> groupShapes)
        {
            Group group1 = new Group();
            for (int i = 0; i < groupShapes.Count(); i++)
            {
                if(groupShapes[i].shapes.Count() == 0)
                {
                    groupShapes[i].isPartOfGroup = true;
                    groupShapes[i].group = group1;
                    group1.Add(groupShapes[i]);
                }
            }
        }

        public void ListGroup()
        {
            if(this.isPartOfGroup)
            {
                Console.WriteLine("True");
                Console.WriteLine(this.group.count());
            }
            else
            {
                Console.WriteLine("false");
            }
            Console.WriteLine(this.type);
            //foreach (Shape shape in this.GetShapesInGroup())
            //{
            //    Console.WriteLine("Hoi");
            //    foreach (Shape item in shape.GetShapesInGroup())
            //    {
            //        Console.WriteLine("\tHallo");
            //    }
            //}
        }
    }
}
