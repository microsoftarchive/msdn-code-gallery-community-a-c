using Spire.Pdf;

namespace DeleteAnnotation_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an object of PdfDocument class and load the PDF 
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"C:\Users\Administrator\Desktop\Annotation.pdf");
            //Get the first annotation in the first page and remove it
            document.Pages[0].AnnotationsWidget.RemoveAt(0);
            //Save the file and view
            document.SaveToFile("output.pdf");
            System.Diagnostics.Process.Start("output.pdf");
        }
    }
}
