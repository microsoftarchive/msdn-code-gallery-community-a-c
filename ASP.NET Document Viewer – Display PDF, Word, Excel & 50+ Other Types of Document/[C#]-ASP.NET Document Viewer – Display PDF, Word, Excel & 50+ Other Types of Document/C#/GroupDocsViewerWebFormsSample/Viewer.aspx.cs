using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GroupDocsViewerWebFormsSample
{
    public partial class Viewer : System.Web.UI.Page
    {
        public String Filename;

        public Boolean Mode;

        protected void Page_Load(object sender, EventArgs e)
        {
            String doc_name = this.Request.QueryString["Doc"].ToString();
            if (String.IsNullOrWhiteSpace(doc_name))
            {
                throw new HttpException(403, "Document name is invalid");
            }
            if (FileRepository.IsPresent(doc_name) == false)
            {
                throw new HttpException(404, "Document is absent");
            }
            String raw_mode = this.Request.QueryString["Mode"].ToString().Trim();
            Boolean HTML_mode;
            if (raw_mode == "1")
            {
                HTML_mode = false;
            }
            else if (raw_mode == "2")
            {
                HTML_mode = true;
            }
            else
            {
                throw new HttpException(403, "'Mode' parameter is invalid");
            }
            this.Filename = doc_name;
            this.Mode = HTML_mode;
        }
    }
}