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
        Size userSize = new Size(50, 50);
        Point location;
        Point putShapeOnPanel;
        Point loc2;
        Test selectedItem;
        bool rectangle = false;
        bool ellipse = false;
        bool select = false;
        bool resizeButton = false;
        
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            
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
            Test p = sender as Test;
            
            //Om ervoor te zorgen dat de shape mooi in het midden van de muis wordt afgedrukt.
            putShapeOnPanel.X -= userSize.Width / 2;
            putShapeOnPanel.Y -= userSize.Height / 2;

            //als de rectangle button is geklikt.
            if(rectangle)
            {
                Test b = new Test
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
                Test box = new Test
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
            location = e.Location;
            if (select && selectedItem != null)
            {
                Point posPanel1 = panel1.PointToScreen(panel1.Location);
                Point posMouse = MousePosition;

                location.X = posMouse.X - posPanel1.X;
                location.Y = posMouse.Y - posPanel1.Y;
                selectedItem.Location = location;
                Invalidate();
            }
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Test p = (Test)sender;
            e.Graphics.FillEllipse(new SolidBrush(Color.Black), new Rectangle(0, 0, p.Width, p.Height));
        }
        
        private void B_Click(object sender, EventArgs e)
        {
            Test shape = (Test)sender;
            MouseEventArgs mouse = e as MouseEventArgs;
            if(selectedItem == null)
            {
                selectedItem = shape;
            }
            else
            {
                selectedItem = null;
            }
            if (resizeButton)
            {

                switch (mouse.Button)
                {

                    case MouseButtons.Left:
                        // Left click resize 1.5 bigger
                        if (selectedItem != null)
                        {
                            userSize = new Size(userSize.Width + 10, userSize.Height + 10);
                            shape.Size = userSize;
                            //selectedItem = shape;
                            //clickeven shape 1.5  bigger

                        }
                        else
                        {
                            selectedItem = null;
                        }
                        break;

                    case MouseButtons.Right:
                        // Right click resize 1.5 smaller
                        if (selectedItem != null)
                        {
                            userSize = new Size(userSize.Width - 10, userSize.Height - 10);
                            shape.Size = userSize;
                        }
                        else
                        {
                            selectedItem = null;
                        }
                        break;

                }
            }
        }
        
        private void B_Paint(object sender, PaintEventArgs e)
        {
            Test p = sender as Test;
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, p.Width, p.Height));
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Test panel = (Test)sender;
            if(selectedItem != null)
            {
                selectedItem = null;
            }
            panel.Invalidate();
        }
        private void Control1_MouseClick(Object sender, MouseEventArgs e)
        {
            Test shape = (Test)sender;
            

        }

    }
}
