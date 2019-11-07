using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using CnetSDK.PDFtoImage.Converter.Trial;

namespace PDFToImageDemo4._0
{
    class Program
    {
        static void Main(string[] args)
        {
            //toSinglePageImage();
            //toMultipageImage();
            //PDFToJPG();
            PDFToJPGStream();
        }

        private static void PDFToJPGStream()
        {
            // Make a new instance of CnetSDK.PDFtoImage.Converter.Trial.PDFDocument object.
            PdfFile pdf = new PdfFile();

            // Create a file stream with PDF information
            FileStream stream = new FileStream("CnetSDK.pdf", FileMode.Open);

            // Load PDF document from file stream.
            pdf.LoadPdfFile(stream);

            // Set the width of output jpeg image.
            int width = 2 * pdf.GetPageSetWidth(0);

            // Set the height output jpeg image.
            int height = pdf.GetPageSetHeight(0) / 2;

            // Convert the first PDF page to image with the expected size.
            Bitmap jpg = pdf.ConvertToImage(0, width, height);

            // Save image to jpg format.
            jpg.Save("CnetSDK.jpeg", ImageFormat.Jpeg);
        }
        private static void PDFToJPG()
        {
            // Create an instance of CnetSDK.PDFtoImage.Converter.Trial.PDFDocument object.
            PdfFile pdfDoc = new PdfFile();

            // Load PDF document from local file.
            pdfDoc.LoadPdfFile("CnetSDK.pdf");

            // Get the total page count.
            int count = pdfDoc.FilePageCount;

            for (int i = 0; i < count; i++)
            {
                // Convert PDF page to image.
                Bitmap jpgImage = pdfDoc.ConvertToImage(i);

                // Save image with jpg file type.
                jpgImage.Save("CnetSDK" + i + ".jpg", ImageFormat.Jpeg);
            }
        }
        private static void toSinglePageImage()
        {
            PdfFile doc = new PdfFile();

            doc.LoadPdfFile("F:/CnetSDK.pdf");

            doc.SetDPI = 150;

            int count = doc.FilePageCount;

            for (int i = 0; i < count; i++)
            {
                Bitmap bmp = doc.ConvertToImage(i);
                bmp.Save("F:/CnetSDK" + i + ".bmp", ImageFormat.Bmp);

                Bitmap bmp1 = doc.ConvertToImage(i, 768, 1024);
                bmp1.Save("F:/CnetSDK" + i + ".jpeg", ImageFormat.Jpeg);
            }

        }

        private static void toMultipageImage()
        {
            PdfFile doc = new PdfFile();

            doc.LoadPdfFile("F:/CnetSDK.pdf");

            doc.SetDPI = 150;

            doc.ConvertToMultipageTiff("F:/CnetSDK.tiff");
        }
    }
}
