using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Spire.Pdf;
using System.Threading;

namespace HtmlToPDF
{
    class Program
    {
        static void Main(string[] args)
        {
            // create a pdf document.
            PdfDocument doc = new PdfDocument();

            String url = "http://www.e-iceblue.com/";
            Thread thread = new Thread(() =>
            { doc.LoadFromHTML(url, false, true, true); });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            // save pdf file.
            doc.SaveToFile(@"..\..\sample.pdf");
            doc.Close();

            System.Diagnostics.Process.Start(@"..\..\sample.pdf");
        }
    }
}
