using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ColorCode;

namespace SelectPdf.Samples
{
    public partial class Samples : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Url.AbsolutePath.ToLower().Contains("default.aspx"))
            {
                LitCode.Visible = false;
            }
            else
            {
                try
                {
                    LitCode.Text = @"<h1>Sample Code C#</h1><br/><br/>";
                    string code = System.IO.File.ReadAllText(Server.MapPath(Request.Url.AbsolutePath) + ".cs");
                    LitCode.Text += "<div style='width=90%; overflow: auto; border: 1px solid #DDDDDD; padding: 10px;'>" + new CodeColorizer().Colorize(code, Languages.CSharp) + "</div>";
                }
                catch
                {
                    LitCode.Visible = false;
                }
            }
        }
    }
}