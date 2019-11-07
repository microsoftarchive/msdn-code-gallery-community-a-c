using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class PdfToImageHelper
    {
        public static void Convert()
        {
            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            PdfToImageConverter converter = new PdfToImageConverter();
          
            converter.Load(File.ReadAllBytes("sample.pdf"));

            //Default is 72, the higher DPI, the bigger size out image will be
            converter.DPI = 96;
            //The value need to be 1-100. If set to 100, the converted image will take the
            //original quality with less time and memory. If set to 1, the converted image 
            //will be compressed to minimum size with more time and memory.
            //converter.CompressedRatio = 80;

            for (int i = 0; i < converter.PageCount; i++)
            {
                //The converted image will keep the original size of PDF page
                Image pageImage = converter.PageToImage(i);
                //To specific the converted image size by width and height
                //Image pageImage = converter.PageToImage(i, 100, 150);
                //You can save this Image object to jpeg, tiff and png format to local file.
                //Or you can make it in memory to other use.
                pageImage.Save(i.ToString() + ".jpg", ImageFormat.Jpeg);
            }

            converter.Dispose();
        }

        public static void Convert2()
        {
            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            PdfToImageConverter converter = new PdfToImageConverter();

            //Default is 72, the higher DPI, the bigger size out image will be
            converter.DPI = 96;

            using (Stream stream = File.OpenRead("sample.pdf"))
            {
                converter.Load(stream);
                //Save pdf to multiple pages tiff to local file
                converter.DocumentToMultiPageTiff("convert.tiff");
                //Or save the multiple pages tiff in memory to other use
                //Image multipageTif = converter.DocumentToMultiPageTiff();
            }

        }
    }
}
