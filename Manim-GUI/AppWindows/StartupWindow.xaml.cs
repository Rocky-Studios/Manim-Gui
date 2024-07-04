using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;

namespace ManimGUI.AppWindows
{
    public partial class StartupWindow : Window
    {
        public StartupWindow()
        {
            InitializeComponent();
            WindowController.windows.Add(this);

            // Create a Task to run the Python version check
            Task<bool> checkPythonTask = Task.Run(() =>
            {
                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "python";
                    process.StartInfo.Arguments = "--version";
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();

                    // Read the standard output of the spawned process
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
            OpenFileDialog dialog = new()
            {
                FileName = "Project.mgui", // Default file name
                DefaultExt = ".mgui", // Default file extension
                Filter = "Manim GUI Project Files(.mgui)|*.mgui" // Filter files by extension
            };

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
