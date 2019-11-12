using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DBAccess
{
    public class DALImgCategoryDetails
    {
        #region "Variable Declaration"

        string str_SqlQuery = string.Empty;

        #endregion

        #region "Get Details"

        public string GetDetais()
        {
            try
            {
                str_SqlQuery = " select 'Select' as ImgCategory ,'0' as ImgCategoryId from BindImage union ";
                str_SqlQuery += "select ImgCategory,ImgCategoryId from bindCategory order BY ImgCategoryId  ";

                return str_SqlQuery;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "view Catogery Details"

        public string ViewCategory(int ImgCategoryId)
        {
            try
            {
                str_SqlQuery = " select  ImgName,ImgPath,ImgDesc from BindImage where ImgCategoryId='" + ImgCategoryId + "'";
              

                return str_SqlQuery;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Check Category Already Exist"
        public string ChkCategorAlrdyExist(string CategoryName)
        {
            try
            {
                str_SqlQuery = "select ImgCategory from bindCategory where ImgCategory='" + CategoryName + "'";
                return str_SqlQuery;

            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region "Add Details"
        public string AddCategoryDetails(string CategoryName, int CategoryId)
        {
            try
            {
                str_SqlQuery = "insert into bindCategory (ImgCategory,ImgCategoryId) values ('" + CategoryName + "','" + CategoryId + "') ";

                return str_SqlQuery;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Upload Image"
        public string UploadImage(string ImageName, string ImagePath, string ImageDescr, int ImgCategoryId)
        {
            try
            {
                str_SqlQuery = "insert into bindimage (ImgName,ImgPath,ImgDesc,ImgCategoryId) values('" + ImageName + "','" + ImagePath + "','" + ImageDescr + "','" + ImgCategoryId + "') ";

                return str_SqlQuery;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Remove Category"
        public string RemoveCategory(int CategoryId)
        {
            try
            {
                str_SqlQuery = "delete from  bindCategory  where ImgCategoryId='" + CategoryId + "'";

                return str_SqlQuery;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
