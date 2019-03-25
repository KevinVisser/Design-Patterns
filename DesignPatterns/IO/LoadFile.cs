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
        private List<string> LoadList = new List<string>();

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
        }
    }
}
