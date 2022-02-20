using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;

namespace task5
{
    internal static class Program
    {

        public static void CSVtoXmLConverter(string fileNameOpen)
        {
            string[] lines = File.ReadAllLines(fileNameOpen);
            string[] headers = { "Name", "Surname", "University", "Faculty", "Department", "Age", "Course", "Group", "City" };

            var xml = new XElement("Students",
               lines.Where((line, index) => index > 0).Select(line => new XElement("StudentIndo",
                  line.Split(';').Select((column, index) => new XElement(headers[index], column)))));
            string fileNameSave = fileNameOpen.Substring(0,fileNameOpen.LastIndexOf('.')) + ".xml";
            xml.Save(fileNameSave);
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
