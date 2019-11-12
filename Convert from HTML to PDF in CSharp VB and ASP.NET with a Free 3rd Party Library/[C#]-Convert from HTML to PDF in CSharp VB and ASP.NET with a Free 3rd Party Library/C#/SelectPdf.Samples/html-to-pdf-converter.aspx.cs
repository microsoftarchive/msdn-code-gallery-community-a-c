using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class html_to_pdf_converter : System.Web.UI.Page
    {
        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}