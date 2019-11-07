using System;
using Spire.Pdf;
using System.Drawing;
using Spire.Pdf.Bookmarks;
using Spire.Pdf.General;

namespace AddBookmark_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument class and add page to the document
            PdfDocument pdf = new PdfDocument();
            PdfPageBase page = pdf.Pages.Add();

            //Add bookmark to the appointed location in the page
            PdfBookmark bookmark = pdf.Bookmarks.Add("Introduction:");
            bookmark.Destination = new PdfDestination(page);
            bookmark.Destination.Location = new PointF(0, 0);

            //Set the bookmark font style and color
            bookmark.DisplayStyle = PdfTextStyle.Bold;
            bookmark.Color = Color.SeaGreen;

            //Add childbookmark to the appointed location in the page
            PdfBookmark childBookmark = bookmark.Insert(0, "PREFACE");
            childBookmark.Destination = new PdfDestination(page);
            childBookmark.Destination.Location = new PointF(400, 300);

            //Set the childbookmark font style and color
            childBookmark.DisplayStyle = PdfTextStyle.Regular;
            childBookmark.Color = Color.Black;

            //Save to file and open the document
            pdf.SaveToFile("Bookmark.pdf");
            System.Diagnostics.Process.Start("Bookmark.pdf");





        }
    }
}
