using System;
using System.Web.UI;

namespace GleamTech.DocumentUltimateExamples.WebForms.CS.DocumentViewer
{
    public partial class ClientEventsPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            documentViewer.Document = exampleFileSelector.SelectedFile;
        }
    }
}