using System.Windows;
using System.Windows.Controls;
using ManimGUI;

namespace ManimGUI.AppWindows
{
    /// <summary>
    /// Interaction logic for NewProjectWindow.xaml
    /// </summary>
    public partial class NewProjectWindow : Window
    {
        string projectName = "";
        string projectLocation = "";
        public NewProjectWindow()
        {
            InitializeComponent();
            WindowController.windows.Add(this);
        }

        private void ProjectLocationButtonClick(object sender, RoutedEventArgs e)
        {
            // Configure save file dialog box
            var dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.FileName = projectName; // Default file name
            dialog.DefaultExt = ".mgui"; // Default file extension
            dialog.Filter = "Manim GUI Project File (.mgui)|*.mgui"; // Filter files by extension

            // Show save file dialog box
            bool? result = dialog.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                projectLocation = dialog.FileName;
                string[] pathAsArray = projectLocation.Split('\\');
               ((Button)sender).Content = "Choose (" + pathAsArray[pathAsArray.Length - 2] + "/" + pathAsArray[pathAsArray.Length-1] +")";
            }

            Project project = new Project(projectName, projectLocation);
        }

        private void ProjectNameBoxTextChange(object sender, TextChangedEventArgs e)
        {
            projectName = ((TextBox)sender).Text;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            Close();
            WindowController.Find("StartupWindow1").Show();
        }

        private void CreateButtonClick(object sender, RoutedEventArgs e)
        {
            //ManimGUI.New(project);

            
        }
    }
}
