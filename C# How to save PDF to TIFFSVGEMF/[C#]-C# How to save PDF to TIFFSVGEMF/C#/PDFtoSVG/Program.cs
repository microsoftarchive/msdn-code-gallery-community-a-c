using Spire.Pdf;

namespace PDFtoSVG_PDF
{
    class Program
    {
        static void Main(string[] args)
        {
            //Initialize an instance of PdfDocument class and load the sample from file
            PdfDocument document = new PdfDocument();
            document.LoadFromFile(@"C:\Users\Administrator\Desktop\sample.pdf");
            //Save the file to SVG
            document.SaveToFile("Result.svg", FileFormat.SVG);
        }
    }
}
