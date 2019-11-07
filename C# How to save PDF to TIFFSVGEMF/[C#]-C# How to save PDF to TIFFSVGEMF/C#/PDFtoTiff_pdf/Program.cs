using System;
using System.Drawing;
using System.Drawing.Imaging;
using Spire.Pdf;

namespace SavePdfAsTiff
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument and load a PDF sample from file
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"C:\Users\Administrator\Desktop\sample.pdf");
            //Call JoinTiffImages() method to save the PDF to Tiff and open the result
            JoinTiffImages(SaveAsImage(document), "result.tiff", EncoderValue.CompressionLZW);
            System.Diagnostics.Process.Start("result.tiff");
        }
        //Define SaveAsImage() method to save the PDF document as image array
        private static Image[] SaveAsImage(PdfDocument document)
        {
            Image[] images = new Image[document.Pages.Count];
            for (int i = 0; i < document.Pages.Count; i++)
            {
                images[i] = document.SaveAsImage(i);
            }
            return images;
        }
        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            for (int j = 0; j < encoders.Length; j++)
            {
                if (encoders[j].MimeType == mimeType)
                    return encoders[j];
            }
            throw new Exception(mimeType + " mime type not found in ImageCodecInfo");
        }
        //Define JoinTiffImages() method to save the images from PDF pages to tiff image type, with the specified encoder and image-encoder parameters.
        public static void JoinTiffImages(Image[] images, string outFile, EncoderValue compressEncoder)
        {
            Encoder enc = Encoder.SaveFlag;
            EncoderParameters ep = new EncoderParameters(2);
            ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.MultiFrame);
            ep.Param[1] = new EncoderParameter(Encoder.Compression, (long)compressEncoder);
            Image pages = images[0];
            int frame = 0;
            ImageCodecInfo info = GetEncoderInfo("image/tiff");
            foreach (Image img in images)
            {
                if (frame == 0)
                {
                    pages = img;
                    pages.Save(outFile, info, ep);
                }

                else
                {
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.FrameDimensionPage);

                    pages.SaveAdd(img, ep);
                }
                if (frame == images.Length - 1)
                {
                    ep.Param[0] = new EncoderParameter(enc, (long)EncoderValue.Flush);
                    pages.SaveAdd(ep);
                }
                frame++;
            }
        }
    }
}