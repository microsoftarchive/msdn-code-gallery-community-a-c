using System;
using Spire.Pdf;
using Spire.Pdf.Bookmarks;
using Spire.Pdf.General;
using System.Drawing;

namespace ModifyBookmark_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and load the PDF file
            PdfDocument pdf = new PdfDocument();
            pdf.LoadFromFile(@"C:\Users\Administrator\Desktop\Bookmark.pdf");

            //Get the first bookmark
            PdfBookmarkCollection bookmarks = pdf.Bookmarks;
            PdfBookmark childbookmark = bookmarks[0];

            //Modify the bookmark font and color in the appointed bookmark of the page
            childbookmark.Destination = new PdfDestination(pdf.Pages[1]);
            childbookmark.DisplayStyle = PdfTextStyle.Bold;
            childbookmark.Color = Color.Brown;
            //Modify the title of bookmark
            childbookmark.Title = "CHAPER Ⅰ";

            //Save to file and open the document
            pdf.SaveToFile("ModifyBookmark.pdf");
            System.Diagnostics.Process.Start("ModifyBookmark.pdf");
        }
    }
}
