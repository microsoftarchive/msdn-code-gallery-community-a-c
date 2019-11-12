using System;
using Spire.Pdf;
using System.Drawing;
using Spire.Pdf.Bookmarks;
using Spire.Pdf.General;

namespace AddBookmark1_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and load the PDF file
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"C:\Users\Administrator\Desktop\sample.pdf");
            //Traverse all pages
            for (int i = 0; i < pdf.Pages.Count; i++)
            {
                //Add bookmark to the appointed location in the page
                PdfBookmark bookmark = pdf.Bookmarks.Add(string.Format("Chaper{0}", i + 1));
                bookmark.Destination = new PdfDestination(pdf.Pages[i]);
                bookmark.Destination.Location = new PointF(0, 2);

                //Set the bookmark font style and color
                bookmark.DisplayStyle = PdfTextStyle.Bold;
                bookmark.Color = Color.Black;
            }
            //Save to file and open the document
            pdf.SaveToFile("Bookmark1.pdf");
            System.Diagnostics.Process.Start("Bookmark1.pdf");

        }
    }
}
