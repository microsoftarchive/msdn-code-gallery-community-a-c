using Spire.Pdf;
using System;
using System.Drawing;

namespace PDFtoEMF_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument class and load the sample
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"C:\Users\Administrator\Desktop\sample.pdf");
            //Call to use the SaveAsImage method to save all the PDF pages as EMF
            for (int i = 0; i < doc.Pages.Count; i++)
            {
                String fileName = String.Format("Sample-img-{0}.emf", i);
                using (Image image = doc.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Metafile, 300, 300))
                {
                    image.Save(fileName, System.Drawing.Imaging.ImageFormat.Emf);
                }
            }

        }
    }
}
