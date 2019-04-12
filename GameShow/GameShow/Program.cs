using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameShow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DateTime limitDate = Convert.ToDateTime("Apr 30, 2019 12:00:00 AM");
            if (DateTime.Today <= limitDate)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Menu());
            }
            else
                MessageBox.Show("Please Purchase the Complete Version");
        }
    }
}
