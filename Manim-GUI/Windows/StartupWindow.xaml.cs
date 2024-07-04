using Manim_GUI.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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

            // Create a Task to run the Python version check logic asynchronously
            Task<bool> checkPythonTask = Task.Run(() =>
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "python";
                    process.StartInfo.Arguments = "--version";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.Start();

                    // Asynchronously read the standard output of the spawned process
                    string output = process.StandardOutput.ReadToEndAsync().Result;

                    bool hasPython = output.Contains("3.11");

                    process.WaitForExit();

                    return hasPython;
                }
            });
            checkPythonTask.ContinueWith(task =>
            {
                bool hasPython = task.Result;
                if (!hasPython)
                {
                    // Update UI on the main thread using Dispatcher
                    Dispatcher.Invoke(() =>
                    {
                        string messageBoxText = "It looks like you don't have Python 3.11 installed, which is required to run Manim. Please install Python 3.11 and restart your computer.";
                        string caption = "Manim GUI";
                        MessageBoxButton button = MessageBoxButton.OK;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult result;

                        result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);
                        Application.Current.Shutdown();
                    });
                }
            });
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
            window.Show();
            Close();
        }
    }
}
