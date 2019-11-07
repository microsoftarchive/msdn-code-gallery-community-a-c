using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class automatic_bookmarks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string url = Page.ResolveUrl("~/files/document.html");
                TxtUrl.Text = (new Uri(Request.Url, url)).AbsoluteUri;
                LnkTest.NavigateUrl = url;
            }
        }

        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set the css selectors for the automatic bookmarks
            converter.Options.PdfBookmarkOptions.CssSelectors = 
                TxtElements.Text.Split(new char[] { ',' });

            // display the bookmarks when the document is opened in a viewer
            converter.Options.ViewerPreferences.PageMode = PdfViewerPageMode.UseOutlines;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(TxtUrl.Text);

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}