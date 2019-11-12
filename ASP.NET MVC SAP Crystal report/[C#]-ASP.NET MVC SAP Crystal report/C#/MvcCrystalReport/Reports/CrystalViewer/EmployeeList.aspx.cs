using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace MvcCrystalReport.Reports.CrystalViewer
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        public string thisConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringOther"].ConnectionString;
        CrystalDecisions.CrystalReports.Engine.ReportDocument reportDocument = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                LoadReport();
            }
        }
        protected void Preview_Click(object sender, EventArgs e)
        {
            LoadReport();
        }
        private void LoadReport()
        {
            if (this.reportDocument != null)
            {
                this.reportDocument.Close();
                this.reportDocument.Dispose();
            }
            SqlConnectionStringBuilder SConn = new SqlConnectionStringBuilder(ConfigurationManager.ConnectionStrings["ConnectionStringOther"].ConnectionString);
            SqlConnection thisConnection = new SqlConnection(thisConnectionString);
            // store procedure
            SqlCommand mySelectCommand = new System.Data.SqlClient.SqlCommand("PIS_GetAllEmployeeInfo", thisConnection);
            mySelectCommand.CommandType = CommandType.StoredProcedure;
            reportDocument = new ReportDocument();
            //Report path
            string reportPath = Server.MapPath("~/Reports/Crystal/EmployeeListCrystalReport.rpt");
            reportDocument.Load(reportPath);
            // Report connection
            ConnectionInfo connInfo = new ConnectionInfo();
            connInfo.ServerName = SConn.DataSource;
            connInfo.DatabaseName = SConn.InitialCatalog;
            connInfo.UserID = SConn.UserID;
            connInfo.Password = SConn.Password;
            TableLogOnInfo tableLogOnInfo = new TableLogOnInfo();
            tableLogOnInfo.ConnectionInfo = connInfo;
            foreach (CrystalDecisions.CrystalReports.Engine.Table table in reportDocument.Database.Tables)
            {
                table.ApplyLogOnInfo(tableLogOnInfo);
                table.LogOnInfo.ConnectionInfo.ServerName = connInfo.ServerName;
                table.LogOnInfo.ConnectionInfo.DatabaseName = connInfo.DatabaseName;
                table.LogOnInfo.ConnectionInfo.UserID = connInfo.UserID;
                table.LogOnInfo.ConnectionInfo.Password = connInfo.Password;
                table.Location = "dbo." + table.Location;
            }
           // You can pass parameter in your store procedure if you need
            //reportDocument.SetParameterValue("@FromDate", ProjectUtilities.ConvertToDate(txtFromDate.Text));
            //reportDocument.SetParameterValue("@ToDate", ProjectUtilities.ConvertToDate(txtToDate.Text));

            EmployeeListCrystalReport.ReportSource = reportDocument;
            EmployeeListCrystalReport.DataBind();
        }
    }
}