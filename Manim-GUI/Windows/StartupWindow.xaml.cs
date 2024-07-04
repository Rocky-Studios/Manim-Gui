using Manim_GUI.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Manim_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
            WindowController.windows.Add(this);
        }

        private void OpenProjectButtonClick(object sender, RoutedEventArgs e)
        {
            // Configure open file dialog box
            var dialog = new Microsoft.Win32.OpenFileDialog();
            dialog.FileName = "Project.mgui"; // Default file name
            dialog.DefaultExt = ".mgui"; // Default file extension
            dialog.Filter = "Manim GUI Project Files(.mgui)|*.mgui"; // Filter files by extension

            // Show open file dialog box
            bool? result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                string filename = dialog.FileName;
            }
        }

        private void NewProjectButtonClick(object sender, RoutedEventArgs e)
        {
            var window = new NewProjectWindow();

            window.Owner = this;
            window.Show();
            this.Hide();
        }
    }
}
