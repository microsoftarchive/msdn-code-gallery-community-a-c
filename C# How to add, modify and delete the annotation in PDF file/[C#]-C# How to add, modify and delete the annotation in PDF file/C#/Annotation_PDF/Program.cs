using Spire.Pdf;
using Spire.Pdf.General.Find;
using System.Drawing;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;

namespace Annotation_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and load the file
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"C:\Users\Administrator\Desktop\sample.pdf");

            //Get the first page
            PdfPageBase page = doc.Pages[0];

            //Call the FindText() method to  find the text which is needed to add annotation
            PdfTextFind[] results = page.FindText("IPCC").Finds;

            //Specify the location of annotation
            float x = results[0].Position.X - doc.PageSettings.Margins.Top;
            float y = results[0].Position.Y - doc.PageSettings.Margins.Left + results[0].Size.Height - 23;

            //Create the pop-up annotation
            RectangleF rect = new RectangleF(x, y, 15, 0);
            PdfPopupAnnotation popupAnnotation = new PdfPopupAnnotation(rect);

            //Add the text into the annotation and set the icon and color
            popupAnnotation.Text = "IPCC,This is a scientific and intergovernmental body under the auspices of the United Nations.";
            popupAnnotation.Icon = PdfPopupIcon.Help;
            popupAnnotation.Color = Color.SandyBrown;

            //Add the annotation to the PDF file
            page.AnnotationsWidget.Add(popupAnnotation);

            //Save the file and view
            doc.SaveToFile("Annotation.pdf");
            System.Diagnostics.Process.Start("Annotation.pdf");
        }
    }
}
