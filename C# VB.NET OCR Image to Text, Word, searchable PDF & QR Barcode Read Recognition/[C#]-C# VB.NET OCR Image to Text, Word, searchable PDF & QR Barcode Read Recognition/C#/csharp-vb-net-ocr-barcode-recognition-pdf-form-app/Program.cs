using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace csharp_vb_net_ocr_barcode_recognition_pdf_form_app
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
            //Application.Run(new Form1());
            Application.Run(new asprise_ocr_api.OcrSampleForm()); // ☜ Run OcrSampleForm
        }
    }
}
