using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data;
using ShanuVS2015.DBClass.shanuBizClass;
using System.Data;
/// <summary>
/// Author      : Shanu
/// Create date : 2015-05-09
/// Description : Biz Class
/// Latest
/// Modifier    : 
/// Modify date : 
/// </summary>
namespace ShanuVS2015
{
    public partial class _Default : Page
    {
        #region Attribute 
        //All Page event of the  page 
        shanuBizClasscs bizObj = new shanuBizClasscs();
        #endregion

        #region Page Events
        //All Page event of the  page 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SelectList();
            }
        }

        #endregion

        #region Methods
        //All Page event of the  page 


        //This Method is used for the search result bind in Grid
        private void SelectList()
        {
           

            SortedDictionary<string, string> sd = new SortedDictionary<string, string>() { };
            sd.Add("@P_ItemCode", txtSitemCDE.Text.Trim());
            sd.Add("@P_ItemName", txtSItemNme.Text.Trim());
            DataSet ds = new DataSet();
            ds = bizObj.SelectList("USP_SelectItemmaster", sd);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }

        private void clearControls()
        {
            txtitemCode.Text = "";
            txtitemName.Text = "";
            txtPrice.Text = "0";
            txtTax.Text = "";
            txtuser.Text = "";
            txtdescription.Text = "";
            tdADD.Visible = false;
            hidsaveType.Value = "Add";
            btnAdd.ImageUrl = "~/Images/btnNew.jpg";

        }

        // This method will delete the selected Rocord from DB
        private void DeleteItem(String ItemCode)
        {
            int inserStatus = bizObj.ExecuteNonQuery_IUD("update ItemMaster SET DeleteStatus='Y' where Item_Code='" + ItemCode + "'");

            SelectList();
        }

        private void InsertCall()
        {

            SortedDictionary<string, string> sd = new SortedDictionary<string, string>() { };
         
            sd.Add("@P_Item_Name", txtitemName.Text.Trim());
            sd.Add("@P_Price", txtPrice.Text.Trim());
            sd.Add("@P_TAX1", txtTax.Text.Trim());
            sd.Add("@P_Description", txtdescription.Text.Trim());
            sd.Add("@P_IN_USR_ID", txtuser.Text.Trim());

            DataSet ds = new DataSet();
            ds =  bizObj.SelectList("USP_InsertItemmaster", sd);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows[0].ItemArray[0].ToString() == "Exists")
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('Item already Exist !')", true);
                    txtitemName.Focus();
                }
            }
            else
            {
             
                clearControls();
            }
            SelectList();

        }
        private void UpdateCall()
        {
            SortedDictionary<string, string> sd = new SortedDictionary<string, string>() { };
            sd.Add("@P_Item_Code", txtitemCode.Text.Trim());
            sd.Add("@P_Item_Name", txtitemName.Text.Trim());
            sd.Add("@P_Price", txtPrice.Text.Trim());
            sd.Add("@P_TAX1", txtTax.Text.Trim());
            sd.Add("@P_Description", txtdescription.Text.Trim());
            sd.Add("@P_IN_USR_ID", txtuser.Text.Trim());

            DataSet ds = new DataSet();
            ds =  bizObj.SelectList("USP_UpdateItemmaster", sd);
            SelectList();
            clearControls();

        }


        #endregion


        #region Page Events
        //All Page event of the  page 
        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            SelectList();
        }
       

        protected void btnAdd_Click(object sender, ImageClickEventArgs e)
        {
            if (hidsaveType.Value == "Edit")
            {
                return;
            }

            tdADD.Visible = true;
            btnAdd.ImageUrl = "~/Images/btnNew.jpg";
        }

        protected void btnSave_Click(object sender, ImageClickEventArgs e)
        {

            if (!IsValid)
            {
                return;
            }
            if (hidsaveType.Value == "Add")
            {
                InsertCall();

            }
            else if (hidsaveType.Value == "Edit")
            {
                UpdateCall();
            }
        }

        protected void btnCancel_Click(object sender, ImageClickEventArgs e)
        {
            clearControls();
        }
      

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            clearControls();
            if (e.CommandName == "edits")
            {
                hidsaveType.Value = "Edit";
                // To get the Current Row Number
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = row.RowIndex;
                txtitemCode.Text = row.Cells[2].Text;
                txtitemName.Text = row.Cells[3].Text;
                txtPrice.Text = row.Cells[4].Text;
                txtTax.Text = row.Cells[5].Text;
                txtdescription.Text = row.Cells[6].Text;
                txtuser.Text = row.Cells[7].Text;
             
                tdADD.Visible = true;
                btnAdd.ImageUrl = "~/Images/btnEdit.jpg";
            }
            else if (e.CommandName == "deletes")
            {
                // To get the Current Row Number
                GridViewRow row = (GridViewRow)((Control)e.CommandSource).NamingContainer;
                int rowIndex = row.RowIndex;
                DeleteItem(row.Cells[2].Text);
            }
        }

        #endregion
    }
}