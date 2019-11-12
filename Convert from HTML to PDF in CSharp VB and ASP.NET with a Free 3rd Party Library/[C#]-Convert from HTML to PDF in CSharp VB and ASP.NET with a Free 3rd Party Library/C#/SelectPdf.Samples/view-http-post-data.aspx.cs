using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Text;

namespace SelectPdf.Samples
{
    public partial class view_http_post_data : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LitText.Text = GetPostData();
        }

        private string GetPostData()
        {
            StringBuilder output = new StringBuilder();
            output.Append("<br/>Request method: " +
                Request.HttpMethod + "<br/>");

            // Load POST form fields collection.
            NameValueCollection form = Request.Form;

            // Put the names of all keys into a string array.
            String[] keys = form.AllKeys;
            for (int i = 0; i < keys.Length; i++)
            {
                output.Append("Name: " + keys[i] + "<br/>");

                // Get all values under this key.
                String[] values = form.GetValues(keys[i]);
                for (int j = 0; j < values.Length; j++)
                {
                    output.Append("Value: " + values[j] + "<br/>");
                }
                output.Append("<br/>");
            }

            return output.ToString();
        }
    }
}