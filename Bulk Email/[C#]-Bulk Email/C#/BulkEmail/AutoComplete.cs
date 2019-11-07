using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Data;
using System.Linq;
using System.Configuration;
using System.Data.SqlClient;

[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.Web.Script.Services.ScriptService]
public class AutoComplete : WebService
{
    public AutoComplete()
    {
    }

    [WebMethod]
    public string[] GetCompletionList(string prefixText, int count)
    {
        List<string> recipients = new List<string>();
        DataSet ds = GetContacts();

        foreach (DataRow row in ds.Tables[0].Rows)
        {
            recipients.Add(row["EmailAddress"].ToString());
        }

        return (from r in recipients where r.StartsWith(prefixText, StringComparison.CurrentCultureIgnoreCase) select r).Take(count).ToArray();
    }

    private DataSet GetContacts()
    {
        string cs = ConfigurationManager.ConnectionStrings["BulkSMS"].ConnectionString;
        SqlConnection con = new SqlConnection(cs);
        SqlDataAdapter myDataAdapter = new SqlDataAdapter("GetRecipients", con);
        DataSet myDataSet = new DataSet("Recipients");
        myDataAdapter.Fill(myDataSet, "Recipients");
        return myDataSet;
    }
}