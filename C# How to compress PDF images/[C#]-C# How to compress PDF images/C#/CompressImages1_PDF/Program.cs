using System.Drawing;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace CompressImages1_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument class and load the PDF from file
            PdfDocument doc = new PdfDocument(@"C:\Users\Administrator\Desktop\Input.pdf");

            //Disable incremental update
            doc.FileInfo.IncrementalUpdate = false;

            //Traverse all PDF pages and extract images
            foreach (PdfPageBase page in doc.Pages)
            {
                Image[] images = page.ExtractImages();
                //Traverse all images
                if (images != null && images.Length > 0)
                {
                    for (int j = 0; j < images.Length; j++)
                    {
                        Image image = images[j];
                        PdfBitmap bp = new PdfBitmap(image);
                        //Set bp.Quality values to compress images
                        bp.Quality = 20;
                        //Replace the images with newly compressed images
                        page.ReplaceImage(j, bp);
                    }
                }
            }
            //Save to file
            doc.SaveToFile("Output2.pdf");

        }
    }
}
