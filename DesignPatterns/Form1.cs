using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DesignPatterns
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black, 5);
        Graphics g;
        Rectangle rect;
        Size userSize = new Size(50, 50);
        Point location;
        bool rectangle = true;
        bool ellipse = false;
        bool select = false;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            location = e.Location;
            panel1.Invalidate();
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            ellipse = true;
            rectangle = false;
            select = false;
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            rectangle = true;
            select = false;
            ellipse = false;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            select = true;
            rectangle = false;
            ellipse = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            location.X -= userSize.Width / 2;
            location.Y -= userSize.Height / 2;
            if(rectangle)
            {
                rect = new Rectangle(location, userSize);
                e.Graphics.FillRectangle(new SolidBrush(Color.Black), rect);
                Console.WriteLine(this.HasChildren);
            }
            if (ellipse)
            {
                rect = new Rectangle(location, userSize);
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), rect);
                Console.WriteLine(this.HasChildren);
            }
            if (select)
            {
                if (panel1.HasChildren)
                {
                    Console.WriteLine(panel1.GetChildAtPoint(location));
                    Console.WriteLine("Hallo");
                }
            }
            
        }
    }
}
