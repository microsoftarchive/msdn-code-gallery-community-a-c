using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelectPdf.Samples
{
    public partial class view_http_headers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string headers = string.Empty;
            foreach (string name in Request.Headers)
            {
                string value = Request.Headers[name];
                headers += "<br/>" + name + ": " + value;
            }

            LitHeaders.Text = headers;
        }
    }
}