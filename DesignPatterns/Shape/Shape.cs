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
        protected List<Shape> shapes = new List<Shape>();
        protected List<Shape> shapeList = new List<Shape>();
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
            else if(selectedItem.group == null)
            {
                mouseLocation = this.Parent.PointToClient(MousePosition);
                mouseLocation.X -= (selectedItem.Width / 2);
                mouseLocation.Y -= (selectedItem.Height / 2);
                this.Location = mouseLocation;
                selectedItem = null;
            }
            else if(selectedItem.group != null)
            {
                List<Shape> list = selectedItem.ListGroup(selectedItem);

                Group group = this.BelongsToGroup();
                Point offset = new Point();
                mouseLocation = this.Parent.PointToClient(MousePosition);
                Console.WriteLine(mouseLocation);

                mouseLocation.X = mouseLocation.X - (this.Width / 2);
                mouseLocation.Y = mouseLocation.Y - (this.Height / 2);

                offset.X = mouseLocation.X - this.Location.X;
                offset.Y = mouseLocation.Y - this.Location.Y;

                foreach (Shape shape in list)
                {
                    Point newloc = shape.Location;
                    newloc.X += offset.X;
                    newloc.Y += offset.Y;

                    shape.Location = newloc;
                }
                list.Clear();
                selectedItem = null;
            }
        }

        public bool IsPartOfGroup()
        {
            return isPartOfGroup;
        }

        public virtual List<Shape> ListOfShapes()
        {
            return shapes;
        }

        public Group BelongsToGroup()
        {
            return group;
        }

        public void MakeGroup(List<Shape> groupShapes)
        {
            Group group1 = new Group();
            if(groupShapes[0].group != null)
            {
                group1 = groupShapes[0].group;
                for (int i = 1; i < groupShapes.Count; i++)
                {
                    if(groupShapes[i].group != group1)
                    {
                        group1.Add(groupShapes[i].group);
                    }
                }
            }
            else
            {
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
        }

        public List<Shape> ListGroup(Shape shape)
        {
            Group group = shape.BelongsToGroup();
            foreach (Shape s in group.GetShapesInGroup())
            {
                if (s is Group)
                {
                    ListGroup(s.ListOfShapes().First());
                }
                else
                {
                    shapeList.Add(s);
                }
            }

            return shapeList;
        }
    }
}
