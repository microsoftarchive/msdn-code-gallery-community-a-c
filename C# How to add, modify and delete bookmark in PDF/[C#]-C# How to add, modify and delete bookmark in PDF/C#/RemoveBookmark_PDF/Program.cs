using System;
using Spire.Pdf;
using Spire.Pdf.Bookmarks;


namespace RemoveBookmark_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and load the PDF file
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"C:\Users\Administrator\Desktop\Bookmark1.pdf");

            //Get all bookmarks and remove the first one
            PdfBookmarkCollection bookmarks = pdf.Bookmarks;
            bookmarks.RemoveAt(0);

            //Save to file and open the document
            pdf.SaveToFile("DemoveBookmark.pdf");
            System.Diagnostics.Process.Start("DemoveBookmark.pdf");
        }
    }
}
