using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Browser
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // High DPI settings from here:  
            // https://docs.microsoft.com/en-au/dotnet/framework/winforms/high-dpi-support-in-windows-forms
            //Application.SetHighDpiMode(HighDpiMode.SystemAware); // <-- this works for .NET Core only
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}
