using System;
using System.Windows.Forms;

namespace Suoja
{
    static class Program
    {
        /// <summary>
        /// Der Haupteinstiegspunkt für die Anwendung.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string[] args = Environment.GetCommandLineArgs(); //Get start-up parameters 
            if (args.Length > 1) //Check if Suoja has been opened via "File > Open With"
            {
                Application.Run(new MainWindow(args[1])); //Instantly show a new "Add Job"-dialogue for the desired file
            }
            else
            {
                Application.Run(new MainWindow()); //Start normally
            }
        }
    }
}
