using System;
using System.Windows.Forms;

namespace wjkYouTupe
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
            splash form = new splash();
            form.ShowDialog();
            Application.Run(new start());
        }

        
    }
}
