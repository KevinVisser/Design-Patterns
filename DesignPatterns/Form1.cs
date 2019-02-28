using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesignPatterns.Command;

namespace DesignPatterns
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black, 5);

        //Command Pattern
        Size userSize = new Size(50, 50);
        DrawRectangle drawRectangleCommand;
        DrawEllipse drawEllipseCommand;
        Select selectCommand;
        Resize resizeCommand;
        Move moveCommand;

        Graphics g;
        Point location;
        Point putShapeOnPanel;
        Shape selectedItem;
        bool rectangle = false;
        bool ellipse = false;
        bool select = false;
        bool resizeButton = false;
        
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();

            panel1.Tag = "panel1";


            Shape rect = new Rect(userSize);
            Shape ellipse = new Ellipse(userSize);
            drawRectangleCommand = new DrawRectangle(rect);
            drawEllipseCommand = new DrawEllipse(ellipse);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            location = e.Location;
            putShapeOnPanel = e.Location;
        }

        private void EllipseButton_Click(object sender, EventArgs e)
        {
            ellipse = true;
            rectangle = false;
            select = false;
            resizeButton = false;
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            rectangle = true;
            select = false;
            ellipse = false;
            resizeButton = false;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            select = true;
            rectangle = false;
            ellipse = false;
            resizeButton = false;
        }
        private void Resize_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            resizeButton = true;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            
            //Om ervoor te zorgen dat de shape mooi in het midden van de muis wordt afgedrukt.
            putShapeOnPanel.X -= userSize.Width / 2;
            putShapeOnPanel.Y -= userSize.Height / 2;

            //als de rectangle button is geklikt.
            if(rectangle)
            {
                Shape b = new Shape
                {
                    Size = userSize,
                    Location = putShapeOnPanel
                };
                b.Paint += B_Paint;
                b.Click += B_Click;
                b.MouseMove += B_MouseMove;
                p.Controls.Add(b);
            }
            if (ellipse)
            {
                Shape box = new Shape
                {
                    Size = userSize,
                    Location = putShapeOnPanel
                };
                box.Paint += Box_Paint;
                box.Click += B_Click;
                box.MouseMove += B_MouseMove;
                p.Controls.Add(box);
            }
            
        }

        private void B_MouseMove(object sender, MouseEventArgs e)
        {
            if (resizeButton)
            {
                moveCommand = new Move((Shape)sender);
                moveCommand.Execute(e);
                this.Invalidate();
            }
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            drawEllipseCommand.Execute(e);
        }
        
        private void B_Click(object sender, EventArgs e)
        {
            Shape shape = (Shape)sender;
            if (select || resizeButton)
            {
                selectCommand = new Select(shape);
                selectCommand.Execute(e);
            }
            //if (resizeButton)
            //{

            //    switch (mouse.Button)
            //    {

            //        case MouseButtons.Left:
            //            // Left click resize 1.5 bigger
            //            if (selectedItem != null)
            //            {
            //                userSize = new Size(userSize.Width + 10, userSize.Height + 10);
            //                shape.Size = userSize;
            //                //selectedItem = shape;
            //                //clickeven shape 1.5  bigger

            //            }
            //            break;

            //        case MouseButtons.Right:
            //            // Right click resize 1.5 smaller
            //            if (selectedItem != null)
            //            {
            //                userSize = new Size(userSize.Width - 10, userSize.Height - 10);
            //                shape.Size = userSize;
            //            }
            //            break;

            //    }
            //}
        }
        
        private void B_Paint(object sender, PaintEventArgs e)
        {
            drawRectangleCommand.Execute(e);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            
            Panel panel = (Panel)sender;
            panel.Invalidate();
        }
    }
}
