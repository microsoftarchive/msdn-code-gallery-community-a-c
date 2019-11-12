using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SelectPdf.Samples
{
    public partial class view_http_cookies : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string cookies = string.Empty;
            foreach (string key in Request.Cookies)
            {
                HttpCookie cookie = Request.Cookies[key];
                cookies += "<br/>" + cookie.Name + ": " + cookie.Value;
            }

            LitCookies.Text = cookies;
        }
    }
}