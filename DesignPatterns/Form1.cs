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
        //Pen pen = new Pen(Color.Black, 5);

        //Command Pattern
        CommandManager commandManager = new CommandManager();

        //Visitors
        IShapeVisitor shapeVisitor = new ShapeVisitor();
        IShapeVisitor IncreaseSizeShapeVisitor = new IncreaseSizeShapeVisitor();
        IShapeVisitor DecreaseSizeShapeVisitor = new DecreaseSizeShapeVisitor();
        IShapeVisitor MoveShapeVisitor = new MoveShapeVisitor();
        IShapeVisitor SaveFileVisitor = new SaveFileVisitor();

        Size userSize = new Size(50, 50);

        Graphics g;
        Point location;
        Point putShapeOnPanel;
        Shape selectedItem;
        List<Shape> shapeList = new List<Shape>();

        //Booleans voor de knoppen(kunnen we later enum voor maken misschien)
        enum ButtonSelected {RECTANGLE, ELLIPSE, SELECT, RESIZE, MOVE, GROUP, ACCEPT};
        ButtonSelected buttonSelected = ButtonSelected.MOVE;
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
        private void IOButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(sender);
            Button btn = (Button)sender;
            switch (btn.Text)
            {
                case "Rectangle":
                    buttonSelected = ButtonSelected.RECTANGLE;
                    break;
                case "Ellipse":
                    buttonSelected = ButtonSelected.ELLIPSE;
                    break;
                case "Select":
                    buttonSelected = ButtonSelected.SELECT;
                    break;
                case "Resize":
                    buttonSelected = ButtonSelected.RESIZE;
                    break;
                case "Move":
                    buttonSelected = ButtonSelected.MOVE;
                    break;
                case "Group":
                    buttonSelected = ButtonSelected.GROUP;
                    break;
                case "Accept":
                    buttonSelected = ButtonSelected.ACCEPT;
                    break;
                
            }
        }
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

        }
        #endregion

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;
            
            //Om ervoor te zorgen dat de shape mooi in het midden van de muis wordt afgedrukt.
            putShapeOnPanel.X -= userSize.Width / 2;
            putShapeOnPanel.Y -= userSize.Height / 2;

            //als de rectangle button is geklikt.
            switch (buttonSelected)
            {
                case ButtonSelected.RECTANGLE:

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
                    break;
                case ButtonSelected.ELLIPSE:

                    Shape box = new Ellipse(userSize)
                    {
                        Size = userSize,
                        Location = putShapeOnPanel
                    };
                    box.Paint += Box_Paint;
                    box.Click += B_Click;
                    p.Controls.Add(box);
                    break;
            }
            //if(rectangle)
            //{
            //    Shape b = new Rect(userSize)
            //    {
            //        Size = userSize,
            //        Location = putShapeOnPanel
            //    };
            //    b.Size = userSize;
            //    b.Location = putShapeOnPanel;
            //    b.Paint += B_Paint;
            //    b.Click += B_Click;
            //    p.Controls.Add(b);
            //}
            //if (ellipse)
            //{
            //    Shape box = new Ellipse(userSize)
            //    {
            //        Size = userSize,
            //        Location = putShapeOnPanel
            //    };
            //    box.Paint += Box_Paint;
            //    box.Click += B_Click;
            //    p.Controls.Add(box);
            //}            
        }   
        
        private void B_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;

            switch (buttonSelected)
            {
                case ButtonSelected.SELECT:

                    if (sender is Ellipse)
                    {
                        Shape s = (Ellipse)sender;
                        selectedItem = s;
                    }
                    else if (sender is Rect)
                    {
                        Shape s = (Rect)sender;
                        selectedItem = s;
                    }
                    break;
                case ButtonSelected.MOVE:

                    selectedItem = (Shape)sender;
                    commandManager.ExecuteCommand(new MoveCommand((Shape)sender), e);
                    break;
                case ButtonSelected.RESIZE:

                    if (mouse.Button == MouseButtons.Left)
                    {
                        commandManager.ExecuteCommand(new IncreaseSizeCommand((Shape)sender), e);
                    }
                    else if (mouse.Button == MouseButtons.Right)
                    {
                        commandManager.ExecuteCommand(new DecreaseSizeCommand((Shape)sender), e);
                    }
                    this.Refresh();
                    break;
                case ButtonSelected.GROUP:

                    shapeList.Add((Shape)sender);
                    break;
            }

            //if (select)
            //{
            //    //commandManager.ExecuteCommand(new Select((Shape)sender), e);
            //    if(sender is Ellipse)
            //    {
            //        Shape s = (Ellipse)sender;
            //        selectedItem = s;
            //    }
            //    else if (sender is Rect)
            //    {
            //        Shape s = (Rect)sender;
            //        selectedItem = s;
            //    }
            //    //shape.ListGroup();
            //}

            //if (move)
            //{
            //    selectedItem = (Shape)sender;
            //    commandManager.ExecuteCommand(new MoveCommand((Shape)sender), e);
            //}

            //if (resize)
            //{
            //    if(mouse.Button == MouseButtons.Left)
            //    {
            //        commandManager.ExecuteCommand(new IncreaseSizeCommand((Shape)sender), e);
            //    }
            //    else if(mouse.Button == MouseButtons.Right)
            //    {
            //        commandManager.ExecuteCommand(new DecreaseSizeCommand((Shape)sender), e);
            //    }
            //    this.Refresh();
            //}
            
            //if (group)
            //{
            //    shapeList.Add((Shape)sender);
            //}
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
            if(buttonSelected == ButtonSelected.MOVE && selectedItem != null)
            {
                commandManager.ExecuteCommand(new MoveCommand(selectedItem), e);
                selectedItem = null;
            }
            Panel panel = (Panel)sender;
            panel.Invalidate();
        }        
    }
}
