using System;
using System.Windows.Forms;
using Spire.Pdf;

namespace XPStoPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //xps file
            String file = "Sample.xps";

            //open xps document
            PdfDocument doc = new PdfDocument();
            doc.LoadFromXPS(file);

            //convert to pdf file.
            doc.SaveToFile("Sample.pdf");
            doc.Close();

            //Launching the Pdf file.
            PDFDocumentViewer("Sample.pdf");
        }

        private void PDFDocumentViewer(string fileName)
        {
            try
            {
                System.Diagnostics.Process.Start(fileName);
            }
            catch { }
        }

    }
}
