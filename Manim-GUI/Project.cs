using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manim_GUI
{
    public class Project
    {
        public string Name;
        public string Path;
        public string LastOpenedVersion;

        public Project(string name, string path)
        {
            Name = name;
            Path = path;
            LastOpenedVersion = ManimGUI.VERSION;
        }
    }
}
