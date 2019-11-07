using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace CustomHitCounterWebPart.HitCounter
{
    [ToolboxItemAttribute(false)]
    public class HitCounter : System.Web.UI.WebControls.WebParts.WebPart
    {
        string cLoginName = string.Empty;
        string cDate = string.Empty;
        string cURL = string.Empty;
        SPList myList;
        protected override void Render(HtmlTextWriter writer)
        {
            //SPSite mySite = SPControl.GetContextSite(Context);
            //SPWeb myWeb = SPControl.GetContextWeb(Context);
            SPSite mySite = SPContext.Current.Site;// SPControl.GetContextSite(Context);
            SPWeb myWeb = SPContext.Current.Web;// SPControl.GetContextWeb(Context);

            string cMonth = System.DateTime.Today.Month.ToString();
            string cDay = System.DateTime.Today.Day.ToString();
            string cYear = System.DateTime.Today.Year.ToString();

            cLoginName = myWeb.CurrentUser.LoginName.ToString();
            cDate = cMonth + "/" + cDay + "/" + cYear;
            string cMonYear = cMonth + "-" + cYear;
            cURL = System.Web.HttpContext.Current.Request.Url.AbsoluteUri.ToString();

            if (cLoginName != "" && cDate != "" && cURL != "")
            {
                myList = myWeb.Lists[Constants.listName];
                SPQuery myQuery = new SPQuery();
                myQuery.Query = " <OrderBy>" +
                    "<FieldRef Name='ID' />" +
                        "<FieldRef Name=" + Constants.fieldUrl+ " />" +
                            "<FieldRef Name=" + Constants.fieldUser + " />" +
                                "<FieldRef Name=" + Constants.fieldDate + " /></OrderBy><Where><And><And><Eq>" +
                                "<FieldRef Name=" + Constants.fieldUrl + " />" +
                                    "<Value Type='Note'>" + cURL + "</Value></Eq>" +
                                        "<Eq><FieldRef Name=" + Constants.fieldUser + " />" +
                                            "<Value Type='Text'>" + cLoginName + "</Value></Eq></And>" +
                                                "<Eq><FieldRef Name=" + Constants.fieldDate + " /><Value Type='Text'>" + cDate + "</Value>" +
                                                    "</Eq></And></Where>";
                SPListItemCollection myItemcol = myList.GetItems(myQuery);
                if (myItemcol.Count > 0)
                {
                    writer.Write(myList.ItemCount.ToString());
                    return;
                }
                else
                {
                    SPListItem myItem = myList.Items.Add();
                    myItem[Constants.fieldUrl] = cURL.ToString();
                    myItem[Constants.fieldDate] = cDate.ToString();
                    myItem[Constants.fieldUser] = cLoginName.ToString();
                    myWeb.AllowUnsafeUpdates = true;
                    myItem.Update();
                    myWeb.AllowUnsafeUpdates = false;
                    writer.Write(myList.ItemCount.ToString());
                }
            }
        }
    }
}
