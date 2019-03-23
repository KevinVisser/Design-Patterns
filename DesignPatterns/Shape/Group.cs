using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    public class Group : Shape
    {
        private List<Shape> shapes;
        public static int id = 0;

        public Group()
        {
            id += 1;
            this.shapes = new List<Shape>();
        }

        public void Add(Shape s)
        {
            this.shapes.Add(s);
        }

        public void Add(Group g)
        {
            this.shapes.Add(g);
        }

        public void Remove(Shape s)
        {
            this.shapes.Add(s);
        }

        public List<Shape> GetShapesInGroup()
        {
            return this.shapes;
        }

        public override List<Shape> ListOfShapes()
        {
            return shapes;
        }

        public int toString()
        {
            return id;
        }

        public int count()
        {
            return this.shapes.Count();
        }
    }
}
