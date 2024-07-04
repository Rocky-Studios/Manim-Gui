using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Manim_GUI
{
    public static class ManimGUI
    {
        public static readonly string VERSION = "0.0.1";
        public static void New(Project project)
        {
            string path = project.Path;
            XDocument doc = FileWriter.CreateProjectFile(project);
            doc.Save(path);
        }
    }
}
