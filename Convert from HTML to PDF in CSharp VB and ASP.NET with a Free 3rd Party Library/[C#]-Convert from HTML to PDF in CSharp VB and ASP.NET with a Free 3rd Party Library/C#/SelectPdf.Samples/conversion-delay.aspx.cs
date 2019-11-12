using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class conversion_delay : System.Web.UI.Page
    {
        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // read parameters from webpage
            int delay = 0;
            try
            {
                delay = Convert.ToInt32(TxtDelay.Text);
            }
            catch { }

            int timeout = 0;
            try
            {
                timeout = Convert.ToInt32(TxtTimeout.Text);
            }
            catch { }

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // specify the number of seconds the conversion is delayed
            converter.Options.MinPageLoadTime = delay;

            // set the page timeout
            converter.Options.MaxPageLoadTime = timeout;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}