using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class pdf_converter_properties : System.Web.UI.Page
    {
        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

            // get conversion result (contains document info from the web page)
            HtmlToPdfResult result = converter.ConversionResult;

            // set the document properties
            doc.DocumentInformation.Title = result.WebPageInformation.Title;
            doc.DocumentInformation.Subject = result.WebPageInformation.Description;
            doc.DocumentInformation.Keywords = result.WebPageInformation.Keywords;

            doc.DocumentInformation.Author = "Select.Pdf Samples";
            doc.DocumentInformation.CreationDate = DateTime.Now;

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}