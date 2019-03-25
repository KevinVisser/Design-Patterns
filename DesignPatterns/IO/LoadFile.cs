using DesignPatterns.Command;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignPatterns.IO
{
    public class LoadFile
    {
        private string fileName = "";
        private Point location;
        private Size userSize;
        CommandManager commandManager = CommandManager.getInstance();
        private List<string> LoadList = new List<string>();

        public void OpenFile()
        {
            OpenFileDialog choofdlog = new OpenFileDialog
            {
                Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*",
                FilterIndex = 1,
                Multiselect = true
            };

            if (choofdlog.ShowDialog() == DialogResult.OK)
            {
                fileName = choofdlog.FileName;
                Console.WriteLine(fileName);
            }

            //LoadFileContents(fileName);
        }

        public List<string> LoadFileContents(string file, Graphics g, Panel panel)
        {
            if (file == "")
            {
                Console.WriteLine("error");
                return LoadList;
            }

            foreach (string line in File.ReadLines(file, Encoding.UTF8))
            {
                LoadList.Add(line);
            }

            return LoadList;
            //foreach (string line in File.ReadLines(file, Encoding.UTF8))
            //{
            //    string[] words = line.Split(' ');
            //    if (words[0] == "ellipse")
            //    {
            //        location = new Point(Convert.ToInt32(words[1]), Convert.ToInt32(words[2]));
            //        userSize = new Size(Convert.ToInt32(words[3]), Convert.ToInt32(words[4]));

            //        Shape ellipse = new Ellipse(location, userSize)
            //        {
            //            Size = userSize,
            //            Location = location
            //        };

            //        g.FillEllipse(new SolidBrush(Color.Black), new Rectangle(location, userSize));
            //        //commandManager.ExecuteCommand(new DrawEllipseCommand(ellipse), e);

            //        Console.WriteLine(location + " " + userSize);
            //    }
            //    else if (words[0] == "rectangle")
            //    {
            //        location = new Point(Convert.ToInt32(words[1]), Convert.ToInt32(words[2]));
            //        userSize = new Size(Convert.ToInt32(words[3]), Convert.ToInt32(words[4]));
            //        Shape rectangle = new Rect(location, userSize)
            //        {
            //            Size = userSize,
            //            Location = location
            //        };

            //        panel.Controls.Add(rectangle);
            //        rectangle.Draw(g, userSize);

            //        //g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(location, userSize));

            //        //Rectangle clipRect = new Rectangle(0, 0, userSize.Width, userSize.Height);
            //        //paintEventArgs = new PaintEventArgs(g, clipRect);

            //        //commandManager.ExecuteCommand(new DrawRectangleCommand(rectangle), paintEventArgs);

            //        Console.WriteLine(location + " " + userSize);
            //        Console.WriteLine("Rectangle jongen");
            //    }
            //}
        }
    }
}
