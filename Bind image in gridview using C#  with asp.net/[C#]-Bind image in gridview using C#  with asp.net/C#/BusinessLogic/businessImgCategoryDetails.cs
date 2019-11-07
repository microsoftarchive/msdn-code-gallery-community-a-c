using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CommonLayer;
using DBAccess;


namespace BusinessLogic
{
    public class businessImgCategoryDetails
    {
        #region "Variable Declaration"

        DataSet _ds_AllDetails = null;
        string _get_query = string.Empty;

        #endregion

        #region "Object Initialization"

        commonfunction _CmnFuncObj = new commonfunction();
        DALImgCategoryDetails _DataAccessOBj = new DALImgCategoryDetails();
        int rowCount = 0;

        #endregion

        #region "Get Grid Category Details"
        public DataSet GetCategoryDetails()
        {

            _ds_AllDetails = new DataSet();
            _get_query = _DataAccessOBj.GetDetais();
            _ds_AllDetails = _CmnFuncObj.GetDataSet(_get_query);
            return _ds_AllDetails;

        }

        #endregion

        #region "View Category"
        public DataSet ViewCategory(int ImgCategoryId)
        {

            _ds_AllDetails = new DataSet();
            _get_query = _DataAccessOBj.ViewCategory(ImgCategoryId);
            _ds_AllDetails = _CmnFuncObj.GetDataSet(_get_query);
            return _ds_AllDetails;

        }

        #endregion

        #region "Add Category Details"
        public int AddCategoryDetails(string CategoryName, int CategoryId)
        {
            try
            {
                rowCount = ChkCategorAlrdyExist(CategoryName);
                if (rowCount ==0)
                {
                    _get_query = _DataAccessOBj.AddCategoryDetails(CategoryName, CategoryId);
                    rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
                }
                else
                {
                    rowCount = 0;
                }


                return rowCount;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Upload Image"
        public int UploadImage(string ImgName, string ImgPath, string ImgDescr, int ImgCategoryId)
        {
            try
            {

                _get_query = _DataAccessOBj.UploadImage(ImgName, ImgPath, ImgDescr, ImgCategoryId);
                   rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
                


                return rowCount;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion       

        #region "Romove Category"
        public int RemoveCategory(int CategoryId)
        {
            try
            {
                _get_query = _DataAccessOBj.RemoveCategory(CategoryId);
                rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
                return rowCount;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        #region "Check Category Already Exist"

        public int ChkCategorAlrdyExist(string CategoryName)
        {
            try
            {
                _ds_AllDetails = new DataSet();
                _get_query = _DataAccessOBj.ChkCategorAlrdyExist(CategoryName);
                _ds_AllDetails = _CmnFuncObj.GetDataSet(_get_query);
                rowCount = _ds_AllDetails.Tables[0].Rows.Count;
                return rowCount;
            }
            catch (Exception)
            {

                throw;
            }

        }
        #endregion
    }
}
