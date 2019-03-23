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
        CommandManager commandManager = CommandManager.getInstance();

        //Visitors
        //IShapeVisitor shapeVisitor = new ShapeVisitor();
        ShapeVisitor increaseSizeShapeVisitor = new IncreaseSizeShapeVisitor();
        ShapeVisitor decreaseSizeShapeVisitor = new DecreaseSizeShapeVisitor();
        ShapeVisitor moveShapeVisitor = new MoveShapeVisitor();
        ShapeVisitor saveFileVisitor = new SaveFileVisitor();

        Size userSize = new Size(50, 50);

        Graphics g;
        Point location;
        Point putShapeOnPanel;
        Shape selectedItem;
        Shape shape;
        List<Shape> shapeList = new List<Shape>();

        //Booleans voor de knoppen(kunnen we later enum voor maken misschien)
        enum ButtonSelected {RECTANGLE, ELLIPSE, SELECT, RESIZE, MOVE, GROUP, ACCEPT, NONE};
        ButtonSelected buttonSelected = ButtonSelected.NONE;
        
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
                case "Undo":
                    buttonSelected = ButtonSelected.NONE;
                    commandManager.Undo(e);
                    this.Refresh();
                    break;
                case "Redo":
                    buttonSelected = ButtonSelected.NONE;
                    commandManager.Redo(e);
                    this.Refresh();
                    break;
                case "Done":
                    buttonSelected = ButtonSelected.NONE;
                    commandManager.ExecuteCommand(new GroupCommand(shapeList), e);
                    shapeList.Clear();
                    break;
            }
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
        }   
        
        private void B_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouse = (MouseEventArgs)e;

            if(sender is Ellipse)
            {
                shape = (Ellipse)sender;
            }
            else if(sender is Rect)
            {
                shape = (Rect)sender;
            }

            switch (buttonSelected)
            {
                case ButtonSelected.SELECT:
                    selectedItem = shape;
                    break;
                case ButtonSelected.MOVE:

                    selectedItem = (Shape)sender;
                    selectedItem.Accept(moveShapeVisitor, e);
                    break;
                case ButtonSelected.RESIZE:

                    if (mouse.Button == MouseButtons.Left)
                    {
                        shape.Accept(increaseSizeShapeVisitor, e);
                    }
                    else if (mouse.Button == MouseButtons.Right)
                    {
                        shape.Accept(decreaseSizeShapeVisitor, e);
                    }
                    this.Refresh();
                    break;
                case ButtonSelected.GROUP:

                    shapeList.Add((Shape)sender);
                    break;
                case ButtonSelected.ACCEPT:
                    shape.ListGroup(shape);
                    break;
            }
        }

        private void Box_Paint(object sender, PaintEventArgs e)
        {
            Shape ellipse = (Ellipse)sender;
            commandManager.ExecuteCommand(new DrawEllipseCommand(ellipse), e);
            this.Invalidate();
        }

        private void B_Paint(object sender, PaintEventArgs e)
        {
            Shape rectangle = (Rect)sender;
            commandManager.ExecuteCommand(new DrawRectangleCommand(rectangle), e);
            this.Invalidate();
        }

        private void Panel1_Click(object sender, EventArgs e)
        {
            if(buttonSelected == ButtonSelected.MOVE && selectedItem != null)
            {
                selectedItem.Accept(moveShapeVisitor, e);
                selectedItem = null;
            }
            Panel panel = (Panel)sender;
            panel.Invalidate();
        }        
    }
}