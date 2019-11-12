using System;
using System.Security.Permissions;
using System.Windows.Forms;
using Chess.Forms;


[assembly : FileIOPermission(SecurityAction.RequestMinimum)]
[assembly : CLSCompliant(true)]

namespace Chess
{
    internal class Program
    {
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
         

            MainForm mainForm = new MainForm();


            Application.Run(mainForm);

           
        }
    }
}