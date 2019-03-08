using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    class Group
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

        public void Remove(Shape s)
        {
            this.shapes.Add(s);
        }

        public List<Shape> GetShapesInGroup()
        {
            return this.shapes;
        }

        public int toString()
        {
            return id;
        }
    }
}
