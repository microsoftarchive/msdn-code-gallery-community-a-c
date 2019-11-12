using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContaNet.Tools;

namespace CSharpDemo
{
    public partial class Template : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            var rv = new NSCore(Page, "", style(), Menu(), ToolBar());
            var rs = new ContaNet.Tools.NSShow(Page);
            switch (rv.Funct)
            {
            }

        }
        protected NSStyles style()
        {
            var nstyle = new ContaNet.Tools.NSStyles();
            return nstyle;
        }

        protected NSDropDownMenu Menu()
        {
            var m = new NSDropDownMenu();
            return m;
        }
        public NSToolBar ToolBar()
        {
            var tb = new NSToolBar();
            return tb;
        }
    }
}