using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;

namespace iDiTect.Converter.Demo
{
    public static class DocxToImageHelper
    {
        public static void Convert()
        {
            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            DocxToImageConverter converter = new DocxToImageConverter();

            converter.Load(File.ReadAllBytes("sample.docx"));

            //The resolution of output image, higher dpi makes bigger size image, default is 72
            converter.DPI = 96;
            //The value between 1 to 100. If set to 100, the image will be converted with the
            //original quality by less time/memory. If set to 1, the image will be compressed 
            //with minimum size by more time/memory.
            //converter.CompressedRatio = 80;

            for (int i = 0; i < converter.PageCount; i++)
            {
                //Convert Office.Word to image with the original size of page
                Image pageImage = converter.PageToImage(i);
                //Customize the width and height of output image
                //Image pageImage = converter.PageToImage(i, 100, 150);
                //Support save docx to jpeg, tiff and png format.
                pageImage.Save(i.ToString() + ".jpg", ImageFormat.Jpeg);
            }

            converter.Dispose(); 
        }

        public static void Convert2()
        {
            //Copy "x86" and "x64" folders from download package to your .NET project Bin folder.
            DocxToImageConverter converter = new DocxToImageConverter();

            //The resolution of output image, higher dpi makes bigger size image, default is 72
            converter.DPI = 96;

            using (Stream stream = File.OpenRead("sample.docx"))
            {
                converter.Load(stream);
                //Save Office.Word to multiple pages tiff to local file
                converter.DocumentToMultiPageTiff("convert.tiff");
                //Or save the multiple pages tiff in memory to other use
                //Image multipageTif = converter.DocumentToMultiPageTiff();
            }
        }
    }
}
