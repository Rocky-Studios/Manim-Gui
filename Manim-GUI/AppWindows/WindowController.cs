using System.Collections.Generic;
using System.Windows;

namespace ManimGUI.AppWindows
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
