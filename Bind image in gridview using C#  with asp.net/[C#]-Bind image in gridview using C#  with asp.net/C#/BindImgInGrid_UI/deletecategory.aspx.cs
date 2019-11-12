using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLogic;
using System.Data;
using System.Windows.Forms;

namespace BindImgInGrid_UI
{
    public partial class deletecategory : System.Web.UI.Page
    {
        #region "Object Initialization"

        businessImgCategoryDetails _ObjBusiness = new businessImgCategoryDetails();

        #endregion

        #region "Variable Declaration"
        DataSet _dsBind = null;       
        int getRowCount = 0;
        string strPk_id = string.Empty;

        #endregion

        #region "Page Load"

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {

                    BindCategoryDetails();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion
       
        
        #region "Remove Category"   

        protected void btnremove_Click(object sender, EventArgs e)
        {
            try
            {

                getRowCount = _ObjBusiness.RemoveCategory(Convert.ToInt32(drpSelCategry.SelectedValue));
                if (getRowCount == 1)
                {
                    lblmsg.Text = "Category successfully removed!...";
                    BindCategoryDetails();
                }
                else
                {
                    lblmsg.Text = "something went wrong!...";
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
        }
        #endregion

        #region "Bind Category Details"

        public void BindCategoryDetails()
        {
            _dsBind = new DataSet();
            _dsBind = _ObjBusiness.GetCategoryDetails();
            drpSelCategry.DataTextField = _dsBind.Tables[0].Columns["ImgCategory"].ToString();
            drpSelCategry.DataValueField = _dsBind.Tables[0].Columns["ImgCategoryId"].ToString();
            drpSelCategry.DataSource = _dsBind;
            drpSelCategry.DataBind();
        }

        #endregion
    }
}