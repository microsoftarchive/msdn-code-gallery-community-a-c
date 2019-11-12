using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Graphics;
using System.Drawing;

namespace ModifyAnnotation_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and  load the file
            PdfDocument pdf = new PdfDocument(@"C:\Users\Administrator\Desktop\Annotation.pdf");

            //Get the first annotation in the first page
            PdfAnnotation annotation = pdf.Pages[0].AnnotationsWidget[0];

            //Add the modified text and set the formatting
            annotation.Text = " Dedicate to the task of providing the world with an objective, scientific view of climate change and its political and economic impacts.";
            annotation.Border = new PdfAnnotationBorder(1f);
            annotation.Color = new PdfRGBColor(Color.LightGreen);
            annotation.Flags = PdfAnnotationFlags.Locked;

            //Save the file and view
            pdf.SaveToFile("result.pdf");
            System.Diagnostics.Process.Start("result.pdf");
        }
    }
}
