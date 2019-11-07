using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;

namespace WebApplication_UserInterface
{
    public partial class _Default : System.Web.UI.Page
    {
        #region "Object Initialization"
        businessStudentDetails _ObjBusiness = new businessStudentDetails();
        #endregion

        #region "Variable Declaration"
        DataSet _dsBind = null;
        int getRowCount = 0;
        string strName = string.Empty;

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindData();
                lblmsg.Text = "";
            }
         

        }

        #region "Bind Grid Details"
        public void BindData()
        {
            _dsBind = new DataSet();
            _dsBind = _ObjBusiness.GetBindDetails();
            //Gridview Control code to Bind
            GridView1.DataSource = _dsBind;
            GridView1.DataBind();
            //Chart Control code to Bind
            Chart1.DataSource = _dsBind;
            Chart1.Legends.Add("average_marks").Title = "Student Sample";       
            Chart1.ChartAreas["ChartArea1"].AxisX.Title = "Student Name";
            Chart1.ChartAreas["ChartArea1"].AxisY.Title = "Total";
            Chart1.Series["Series1"].XValueMember = "StudName";
            Chart1.Series["Series1"].YValueMembers = "StudTotal";
            Chart1.DataBind();
        }
        #endregion



        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
           

            GridViewRow _row = GridView1.Rows[e.RowIndex];
            TextBox txtSName = (TextBox)_row.FindControl("txtSName");
            TextBox txtSTotal = (TextBox)_row.FindControl("txtSTotal");
            Label lblPk_id = (Label)_row.FindControl("lblPk_id");

            getRowCount = _ObjBusiness.UpdateDetails(txtSName.Text,Convert.ToInt32(txtSTotal.Text),Convert.ToInt32(lblPk_id.Text));
            GridView1.EditIndex = -1;
            BindData();
            strName = txtSName.Text;
            lblmsg.Text = "Student Name " + strName + " Successfully Updated!...";
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
            lblmsg.Text = "";
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow _row = GridView1.Rows[e.RowIndex];           
            Label lblPk_id = (Label)_row.FindControl("lblPk_id");           
            getRowCount = _ObjBusiness.DeleteDetails(Convert.ToInt32(lblPk_id.Text));
            GridView1.EditIndex = -1;
            BindData();
           
            lblmsg.Text = "Successfully Deleted!...";
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
            lblmsg.Text = "";

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            getRowCount = _ObjBusiness.AddDetails(txtStudName.Text, Convert.ToInt32(txtStudTotal.Text));
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = false;
            BindData();
            strName = txtStudName.Text;
            txtStudName.Text = "";
            txtStudTotal.Text = "";
            lblmsg.Text = "Student Name " + strName + " Successfully Added!...";
        }
       
    }
}
