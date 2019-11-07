using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SelectPdf;

namespace SelectPdf.Samples
{
    public partial class pdf_converter_viewer_preferences : System.Web.UI.Page
    {
        protected void BtnCreatePdf_Click(object sender, EventArgs e)
        {
            // read parameters from the webpage
            string url = TxtUrl.Text;

            string page_layout = DdlPageLayout.SelectedValue;
            PdfViewerPageLayout pageLayout = (PdfViewerPageLayout)Enum.Parse(
                typeof(PdfViewerPageLayout), page_layout, true);

            string page_mode = DdlPageMode.SelectedValue;
            PdfViewerPageMode pageMode = (PdfViewerPageMode)Enum.Parse(
                typeof(PdfViewerPageMode), page_mode, true);

            bool centerWindow = ChkCenterWindow.Checked;
            bool displayDocTitle = ChkDisplayDocTitle.Checked;
            bool fitWindow = ChkFitWindow.Checked;
            bool hideMenuBar = ChkHideMenuBar.Checked;
            bool hideToolbar = ChkHideToolbar.Checked;
            bool hideWindowUI = ChkHideWindowUI.Checked;

            // instantiate a html to pdf converter object
            HtmlToPdf converter = new HtmlToPdf();

            // set converter options
            converter.Options.ViewerPreferences.CenterWindow = centerWindow;
            converter.Options.ViewerPreferences.DisplayDocTitle = displayDocTitle;
            converter.Options.ViewerPreferences.FitWindow = fitWindow;
            converter.Options.ViewerPreferences.HideMenuBar = hideMenuBar;
            converter.Options.ViewerPreferences.HideToolbar = hideToolbar;
            converter.Options.ViewerPreferences.HideWindowUI = hideWindowUI;

            converter.Options.ViewerPreferences.PageLayout = pageLayout;
            converter.Options.ViewerPreferences.PageMode = pageMode;
            converter.Options.ViewerPreferences.NonFullScreenPageMode = 
                PdfViewerFullScreenExitMode.UseNone;

            // create a new pdf document converting an url
            PdfDocument doc = converter.ConvertUrl(url);

            // save pdf document
            doc.Save(Response, false, "Sample.pdf");

            // close pdf document
            doc.Close();
        }
    }
}