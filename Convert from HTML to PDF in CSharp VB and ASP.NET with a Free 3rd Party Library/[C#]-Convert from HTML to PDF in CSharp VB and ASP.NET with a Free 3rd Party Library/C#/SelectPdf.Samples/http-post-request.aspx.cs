using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelectPdf.Samples
{
    public partial class http_post_request : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = Page.ResolveUrl("~/view-http-post-data.aspx");
                TxtUrl.Text = (new Uri(Request.Url, url)).AbsoluteUri;
                LnkTest.NavigateUrl = url;
            }
        }

        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set the HTTP POST parameters
            converter.Options.HttpPostParameters.Add(TxtName1.Text, TxtValue1.Text);
            converter.Options.HttpPostParameters.Add(TxtName2.Text, TxtValue2.Text);
            converter.Options.HttpPostParameters.Add(TxtName3.Text, TxtValue3.Text);
            converter.Options.HttpPostParameters.Add(TxtName4.Text, TxtValue4.Text);

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}