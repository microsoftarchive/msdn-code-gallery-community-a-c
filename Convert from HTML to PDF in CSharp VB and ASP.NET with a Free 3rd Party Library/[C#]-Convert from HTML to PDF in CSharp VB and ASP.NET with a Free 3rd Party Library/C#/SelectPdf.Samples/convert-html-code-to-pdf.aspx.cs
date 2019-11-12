using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class convert_html_code_to_pdf : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtHtmlCode.Text = @"<html>
 <body>
  Hello World from selectpdf.com.
 </body>
</html>
";
            }
        }

        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // read parameters from the webpage
            string htmlString = TxtHtmlCode.Text;
            string baseUrl = TxtBaseUrl.Text;

            string pdf_page_size = DdlPageSize.SelectedValue;
            PdfPageSize pageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), 
                pdf_page_size, true);

            string pdf_orientation = DdlPageOrientation.SelectedValue;
            PdfPageOrientation pdfOrientation = 
                (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), 
                pdf_orientation, true);

            int webPageWidth = 1024;
            try
            {
                webPageWidth = Convert.ToInt32(TxtWidth.Text);
            }
            catch { }

            int webPageHeight = 0;
            try
            {
                webPageHeight = Convert.ToInt32(TxtHeight.Text);
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.PdfPageSize = pageSize;
            converter.Options.PdfPageOrientation = pdfOrientation;
            converter.Options.WebPageWidth = webPageWidth;
            converter.Options.WebPageHeight = webPageHeight;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}