﻿using System;
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
        CommandManager commandManager = new CommandManager();

        Size userSize = new Size(50, 50);

        Graphics g;
        Point location;
        Point putShapeOnPanel;
        
        //Booleans voor de knoppen(kunnen we later enum voor maken misschien)
        bool rectangle = false;
        bool ellipse = false;
        bool select = false;
        bool resize = false;
        bool move = false;
        
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
            resize = false;
            move = false;
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            rectangle = true;
            select = false;
            ellipse = false;
            resize = false;
            move = false;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            select = true;
            rectangle = false;
            ellipse = false;
            resize = false;
            move = false;
        }
        private void Resize_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            resize = true;
            move = false;
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            move = true;
            resize = false;
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
            if (move)
            {
                commandManager.ExecuteCommand(new Move((Shape)sender), e);
            }
        }        
        
        private void B_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;
            if (select || move)
            {
                commandManager.ExecuteCommand(new Select((Shape)sender), e);
            }
            if (resize)
            {
                if(mouse.Button == MouseButtons.Left)
                {
                    commandManager.ExecuteCommand(new IncreaseSizeCommand((Shape)sender), e);
                }
                else if(mouse.Button == MouseButtons.Right)
                {
                    commandManager.ExecuteCommand(new DecreaseSizeCommand((Shape)sender), e);
                }
                this.Refresh();
            }
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Shape ellipse = (Shape)sender;
            commandManager.ExecuteCommand(new DrawEllipse(new Ellipse(ellipse.Size)), e);
            this.Invalidate();
        }

        private void B_Paint(object sender, PaintEventArgs e)
        {
            Shape rectangle = (Shape)sender;
            commandManager.ExecuteCommand(new DrawRectangle(new Rect(rectangle.Size)), e);
            this.Invalidate();
        }

        private void panel1_Click(object sender, EventArgs e)
        {            
            Panel panel = (Panel)sender;
            panel.Invalidate();
        }

        private void UndoButton_Click(object sender, EventArgs e)
        {
            commandManager.Undo(e);
            this.Refresh();
        }

        private void RedoButton_Click(object sender, EventArgs e)
        {
            commandManager.Redo(e);
            this.Refresh();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            commandManager.ExecuteCommand(new SaveCommand(panel1), e);
        }
    }
}
