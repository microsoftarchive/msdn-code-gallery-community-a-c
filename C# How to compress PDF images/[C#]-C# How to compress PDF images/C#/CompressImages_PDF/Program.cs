using System;
using Spire.Pdf;
using System.Drawing;
using Spire.Pdf.Exporting;


namespace CompressImages_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument class and load the PDF from file
            PdfDocument doc = new PdfDocument(@"C:\Users\Administrator\Desktop\Input.pdf");

            //Disable incremental update
            doc.FileInfo.IncrementalUpdate = false;

            //Traverse all pages of PDF and diagonse whether the images are contained or not
            foreach (PdfPageBase page in doc.Pages)
            {
                if (page != null)
                {
                    if (page.ImagesInfo != null)
                    {
                        foreach (PdfImageInfo info in page.ImagesInfo)
                        {
                            //Call the method TryCompressImage() to compress the images in PDF 
                            page.TryCompressImage(info.Index);
                        }
                    }
                }
            }
            //Save to file
            doc.SaveToFile("Output.pdf");
        }
    }
}
