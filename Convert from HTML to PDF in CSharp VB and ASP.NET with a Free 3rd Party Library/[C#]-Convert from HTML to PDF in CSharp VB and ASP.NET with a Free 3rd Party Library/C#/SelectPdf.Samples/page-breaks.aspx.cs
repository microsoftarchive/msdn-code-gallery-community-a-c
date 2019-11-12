using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class page_breaks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtHtmlCode.Text = Helper.PageBreaksText();
            }
        }

        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // read parameters from the webpage
            string htmlString = TxtHtmlCode.Text;
            string baseUrl = TxtBaseUrl.Text;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            converter.Options.MarginTop = 10;
            converter.Options.MarginBottom = 10;
            converter.Options.MarginLeft = 10;
            converter.Options.MarginRight = 10;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}