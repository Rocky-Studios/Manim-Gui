using System.Xml.Linq;

namespace ManimGUI
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
