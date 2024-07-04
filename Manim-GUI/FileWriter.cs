using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Manim_GUI
{
    public static class FileWriter
    {
        public static XDocument CreateProjectFile(Project project)
        {
            XDocument doc = new XDocument(
                new XElement("Project")
            );

            doc.Root.SetAttributeValue("Name", project.Name);
            doc.Root.SetAttributeValue("Version", project.LastOpenedVersion);
            return doc;
        }
    }
}
