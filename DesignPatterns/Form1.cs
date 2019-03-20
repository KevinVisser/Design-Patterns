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
using DesignPatterns.Visitor;

namespace DesignPatterns
{
    public partial class Form1 : Form
    {
        Pen pen = new Pen(Color.Black, 5);

        //Command Pattern
        CommandManager commandManager = new CommandManager();

        ShapeVisitor shapeVisitor = new ShapeVisitor();

        Size userSize = new Size(50, 50);

        Graphics g;
        Point location;
        Point putShapeOnPanel;
        Shape selectedItem;
        List<Shape> shapeList = new List<Shape>();

        //Booleans voor de knoppen(kunnen we later enum voor maken misschien)
        bool rectangle = false;
        bool ellipse = false;
        bool select = false;
        bool resize = false;
        bool move = false;
        bool group = false;
        bool accept = false;
        
        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void Panel1_MouseDown(object sender, MouseEventArgs e)
        {
            location = e.Location;
            putShapeOnPanel = e.Location;
        }

        #region Buttons
        private void EllipseButton_Click(object sender, EventArgs e)
        {
            ellipse = true;
            rectangle = false;
            select = false;
            resize = false;
            move = false;
            group = false;
            accept = false;
        }

        private void RectangleButton_Click(object sender, EventArgs e)
        {
            rectangle = true;
            select = false;
            ellipse = false;
            resize = false;
            move = false;
            group = false;
            accept = false;
        }

        private void SelectButton_Click(object sender, EventArgs e)
        {
            select = true;
            rectangle = false;
            ellipse = false;
            resize = false;
            move = false;
            group = false;
            accept = false;
        }
        private void Resize_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            resize = true;
            move = false;
            group = false;
            accept = false;
        }

        private void MoveButton_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            move = true;
            resize = false;
            group = false;
            accept = false;
        }

        private void GroupButton_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            move = false;
            resize = false;
            group = true;
            accept = false;
        }

        private void GroupMoveButton_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            move = false;
            resize = false;
            group = false;
            accept = false;
        }

        private void GroupResizeButton_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            move = false;
            resize = false;
            group = false;
            accept = false;
        }
        #endregion

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            
            //Om ervoor te zorgen dat de shape mooi in het midden van de muis wordt afgedrukt.
            putShapeOnPanel.X -= userSize.Width / 2;
            putShapeOnPanel.Y -= userSize.Height / 2;

            //als de rectangle button is geklikt.
            if(rectangle)
            {
                Shape b = new Rect(userSize)
                {
                    Size = userSize,
                    Location = putShapeOnPanel
                };
                b.Size = userSize;
                b.Location = putShapeOnPanel;
                b.Paint += B_Paint;
                b.Click += B_Click;
                p.Controls.Add(b);
            }
            if (ellipse)
            {
                Shape box = new Ellipse(userSize)
                {
                    Size = userSize,
                    Location = putShapeOnPanel
                };
                box.Paint += Box_Paint;
                box.Click += B_Click;
                p.Controls.Add(box);
            }            
        }   
        
        private void B_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;

            if (select)
            {
                //commandManager.ExecuteCommand(new Select((Shape)sender), e);
                if(sender is Ellipse)
                {
                    Shape s = (Ellipse)sender;
                    selectedItem = s;
                }
                else if (sender is Rect)
                {
                    Shape s = (Rect)sender;
                    selectedItem = s;
                }
                //shape.ListGroup();
            }

            if (move)
            {
                selectedItem = (Shape)sender;
                commandManager.ExecuteCommand(new MoveCommand((Shape)sender), e);
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
            
            if (group)
            {
                shapeList.Add((Shape)sender);
            }
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Shape ellipse = (Shape)sender;
            commandManager.ExecuteCommand(new DrawEllipseCommand(new Ellipse(ellipse.Size)), e);
            this.Invalidate();
        }

        private void B_Paint(object sender, PaintEventArgs e)
        {
            Shape rectangle = (Shape)sender;
            commandManager.ExecuteCommand(new DrawRectangleCommand(new Rect(rectangle.Size)), e);
            this.Invalidate();
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            if(move && selectedItem != null)
            {
                commandManager.ExecuteCommand(new MoveCommand(selectedItem), e);
                selectedItem = null;
            }
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

        private void DoneButton_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            move = false;
            resize = false;
            group = false;
            commandManager.ExecuteCommand(new GroupCommand(shapeList[0], shapeList), e);
            shapeList.Clear();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            select = false;
            rectangle = false;
            ellipse = false;
            move = false;
            resize = false;
            group = false;
            accept = true;
            if(selectedItem is Rect && accept)
            {
                Rect r = (Rect)selectedItem;
                r.Accept(shapeVisitor);
            }
            else if (selectedItem is Ellipse && accept)
            {
                Ellipse r = (Ellipse)selectedItem;
                r.Accept(shapeVisitor);
            }
        }
    }
}
