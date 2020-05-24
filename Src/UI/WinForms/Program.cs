using System;
using System.Windows.Forms;
using Tyle.Core;

namespace Tyle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new UI.MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to start {AppMetaData.ApplicationName}; Exception thrown:{Environment.NewLine}\t{ex.Message}{Environment.NewLine}{ex.StackTrace}");
            }
        }
    }
}
