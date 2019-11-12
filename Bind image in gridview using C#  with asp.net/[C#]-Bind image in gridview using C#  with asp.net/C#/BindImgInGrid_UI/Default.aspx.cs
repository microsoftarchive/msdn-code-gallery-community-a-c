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
    public partial class _Default : System.Web.UI.Page
    {
        #region "Object Initialization"

        businessImgCategoryDetails _ObjBusiness = new businessImgCategoryDetails();

        #endregion

        #region "Variable Declaration"

        DataSet _dsBind = null;        
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

        protected void btnfetch_Click(object sender, EventArgs e)
        {
            try
            {
                
                _dsBind = new DataSet();
                _dsBind = _ObjBusiness.ViewCategory(Convert.ToInt32(drpSelCategry.SelectedValue));
                GridView1.DataSource = _dsBind;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }
           
        }
    }
}
