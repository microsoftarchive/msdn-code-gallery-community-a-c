using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Threading;

public partial class About : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected override void InitializeCulture()
    {
        CultureInfo c = CultureInfo.CurrentCulture;
        Thread.CurrentThread.CurrentCulture = c;
        Thread.CurrentThread.CurrentUICulture = c;
        base.InitializeCulture();
    }

}
