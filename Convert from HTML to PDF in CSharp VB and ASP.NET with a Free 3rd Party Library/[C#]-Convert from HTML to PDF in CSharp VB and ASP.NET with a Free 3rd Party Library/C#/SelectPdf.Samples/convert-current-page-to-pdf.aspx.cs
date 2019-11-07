using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class convert_current_page_to_pdf : System.Web.UI.Page
    {
        private bool startConversion = false;

        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            startConversion = true;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (startConversion)
            {
                // get html of the page
                TextWriter myWriter = new StringWriter();
                HtmlTextWriter htmlWriter = new HtmlTextWriter(myWriter);
                base.Render(htmlWriter);

                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // create a new pdf document converting the html string of the page
                PdfDocument doc = converter.ConvertHtmlString(
                    myWriter.ToString(), Request.Url.AbsoluteUri);

                // save pdf document
                doc.Save(Response, false, "Sample.pdf");

                // close pdf document
                doc.Close();
            }
            else
            {
                // render web page in browser
                base.Render(writer);
            }
        }
    }
}