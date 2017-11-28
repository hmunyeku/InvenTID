using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvenTID.Properties;

namespace InvenTID
{
    static class Program
    {
        static Mutex mutex;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string appName = Path.GetFileName(Application.ExecutablePath);
            try
            {
                Program.mutex = Mutex.OpenExisting(appName);
                MessageBox.Show(String.Format("L'application {0} est dejà lancée.", appName), "Oops!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                Program.mutex = new Mutex(true,appName);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FrmMain());
            }

        }
    }
}
