using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace csharp_vb_net_scan_twain_wia_scanner_api_app
{
    static class Program
    {
        /// <summary>
        /// C# VB.NET Scan Developer's Guide and API docs: http://asprise.com/c%23-vb.net-scanner-api/twain-wia-document-scan-library-sdk-samples-docs.html
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            Application.Run(new asprise_imaging_api.SampleScanForm()); // ☜ Run SampleScanForm
        }
    }
}
