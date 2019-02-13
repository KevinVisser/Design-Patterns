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
        Point putShapeOnPanel;
        bool rectangle = false;
        bool ellipse = false;
        bool select = false;

        /// <summary>
        /// Maak het form
        /// </summary>
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
            Panel p = sender as Panel;
            
            //Om ervoor te zorgen dat de shape mooi in het midden van de muis wordt afgedrukt.
            putShapeOnPanel.X -= userSize.Width / 2;
            putShapeOnPanel.Y -= userSize.Height / 2;

            //als de rectangle button is geklikt.
            if(rectangle)
            {                
                PictureBox b = new PictureBox();
                b.Size = userSize;                
                b.Location = putShapeOnPanel;
                b.Paint += B_Paint;
                b.Click += B_Click;
                b.MouseDown += B_MouseDown;
                p.Controls.Add(b);
            }
            if (ellipse)
            {
                rect = new Rectangle(putShapeOnPanel, userSize);
                e.Graphics.FillEllipse(new SolidBrush(Color.Black), rect);
                Console.WriteLine(p.HasChildren);
            }
            
        }

        /// <summary>
        /// Als je op select klikt en je klikt op een figuur(wat eigenlijk een picturebox is)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Click(object sender, EventArgs e)
        {
            PictureBox shape = (PictureBox)sender;
            //dus wanneer je op een shape drukt gaat hij kijken of je panel children heeft(dus pictureboxes) en daarna verplaatst hij hem ergens.
            
        }


        private void B_MouseDown(object sender, MouseEventArgs e)
        {
            PictureBox shape = (PictureBox)sender;
            Console.WriteLine(shape.Parent.PointToClient(Cursor.Position));
            location = e.Location;
            location = shape.Parent.PointToClient(Cursor.Position);
            Console.WriteLine(e.Location);
            //location = e.Location;
            Console.WriteLine(location);

            if (select)
            {
                shape.Location = location;

                if (panel1.HasChildren)
                {
                    //Dit moet nog even dat wanneer je hem selecteert dat je dan een 2e point moet krijgen(via de muis) zodat hij daar naar toe verplaatst
                }
            }
        }

        /// <summary>
        /// Om de shape die je hebt ingeladen in het panel om die in de picturebox te stoppen en op het scherm laten zien.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void B_Paint(object sender, PaintEventArgs e)
        {
            PictureBox p = sender as PictureBox;
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(0, 0, p.Width, p.Height));            
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.Refresh();
        }
    }
}
