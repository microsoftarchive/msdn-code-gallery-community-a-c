using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace 传统异步编程解决界面卡死
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
