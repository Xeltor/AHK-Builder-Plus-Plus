using System;
using System.Windows.Forms;

namespace AHK_Builder_Plus_Plus
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new AhkBuilderPlusPlus());
        }
    }
}
