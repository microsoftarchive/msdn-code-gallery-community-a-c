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
    public partial class AddCategory : System.Web.UI.Page
    {
        #region "Object Initialization"

        businessImgCategoryDetails _ObjBusiness = new businessImgCategoryDetails();

        #endregion

        #region "Variable Declaration"

        //DataSet _dsBind = null;
        int getRowCount = 0;
        int imgCategoryId = 0;
        string strPk_id = string.Empty;

        #endregion

        #region "Page Load"

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region "Add Category"

        protected void btnAddCatgry_Click(object sender, EventArgs e)
        {
            try
            {
                Random rnd = new Random();
                imgCategoryId = rnd.Next(1000, 10000);
                getRowCount = _ObjBusiness.AddCategoryDetails(txtImgCatgryName.Text, imgCategoryId);
                //rows affected 
                if (getRowCount == 1)
                {
                    lblmsg.Text = "Category successfully added!...";
                }
                else {
                    lblmsg.Text = "category already exist!...";
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message.ToString());
            }

        }

        #endregion
    }
}