using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Manim_GUI.Windows
{
    public static class WindowController
    {
        public static List<Window> windows = new();
        public static Window Find(string name)
        {
            return windows.Find(w => w.Name == name);
        }
    }
}
