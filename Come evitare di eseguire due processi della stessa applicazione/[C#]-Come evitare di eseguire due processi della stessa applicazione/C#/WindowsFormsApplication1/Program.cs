using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    static class Program
    {
        static Mutex m;
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool first = false;
            m = new Mutex(true, Application.ProductName.ToString(), out first);
            if ((first))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                m.ReleaseMutex();
            }
            else
            {
                MessageBox.Show("Applicazione" + " " + Application.ProductName.ToString() + " " + "già in esecuzione");
            }
        }
    }
}
