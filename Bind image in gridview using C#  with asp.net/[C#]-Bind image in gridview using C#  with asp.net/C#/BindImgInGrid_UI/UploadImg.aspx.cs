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
    public partial class UploadImg : System.Web.UI.Page
    {

        #region "Object Initialization"

        businessImgCategoryDetails _ObjBusiness = new businessImgCategoryDetails();

        #endregion

        #region "Variable Declaration"

        DataSet _dsBind = null;
        int getRowCount = 0;       
        string strPk_id = string.Empty;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    _dsBind = new DataSet();
                    _dsBind = _ObjBusiness.GetCategoryDetails();
                    drpSelCategry.DataTextField = _dsBind.Tables[0].Columns["ImgCategory"].ToString();
                    drpSelCategry.DataValueField = _dsBind.Tables[0].Columns["ImgCategoryId"].ToString();
                    drpSelCategry.DataSource = _dsBind;
                    drpSelCategry.DataBind();
 
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message.ToString());
            }
        }

        protected void btnAddCatgry_Click(object sender, EventArgs e)
        {
            try
            {

                string filename = System.IO.Path.GetFileName(FileUpload1.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/Images/") + filename);

                getRowCount = _ObjBusiness.UploadImage(txtImgNme.Text, "~/Images/" + filename, txtImgDescr.Text, Convert.ToInt32(drpSelCategry.SelectedValue));
                //rows affected 
                if (getRowCount == 1)
                {
                    lblmsg.Text = "successfully image uploaded!...";
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
    }
}