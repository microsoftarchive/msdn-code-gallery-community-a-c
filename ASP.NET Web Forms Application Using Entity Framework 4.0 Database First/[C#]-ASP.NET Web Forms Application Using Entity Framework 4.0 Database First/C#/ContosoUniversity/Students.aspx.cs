using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ContosoUniversity.DAL;

namespace ContosoUniversity
{
    public partial class Students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Init(object sender, EventArgs e)
        {
            StudentsGridView.EnableDynamicData(typeof(Student));
            SearchGridView.EnableDynamicData(typeof(Student));
        }
    }
}