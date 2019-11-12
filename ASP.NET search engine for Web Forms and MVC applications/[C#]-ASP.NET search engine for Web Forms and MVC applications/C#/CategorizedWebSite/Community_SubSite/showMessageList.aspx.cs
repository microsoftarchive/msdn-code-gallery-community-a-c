using System;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace SearchUnit_Basics_CSharp.CategorizedWebSite.Community_SubSite
{
    public partial class ShowMessageList : System.Web.UI.Page
    {

        protected void Page_Load(object sender, System.EventArgs e)
        {
            string[] messages = readMessages(Request.MapPath("messages.txt"));
            ArrayList ds = CreateDataSource(messages);
            foreach (string message in ds)
            {
                Panel1.Controls.Add(new LiteralControl("<p>"));
                Panel1.Controls.Add(new LiteralControl(message));
                Panel1.Controls.Add(new LiteralControl("</p>"));
            }
        }

        ArrayList CreateDataSource(string[] messages)
        {
            ArrayList r = new ArrayList();
            foreach (string mes in messages)
            {
                r.Add(mes.Split('|')[1].Replace("\\r\\n", "<br />"));
            }
            return r;
        }

        string[] readMessages(string path)
        {
            StreamReader r = new StreamReader(path);
            string body = r.ReadToEnd();
            r.Close();
            return body.Split(new char[] { '\n' });
        }
    }
}
