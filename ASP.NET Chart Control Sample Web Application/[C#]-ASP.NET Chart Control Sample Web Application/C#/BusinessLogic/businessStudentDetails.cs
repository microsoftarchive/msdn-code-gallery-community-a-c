using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using CommonLayer;
using DBAccess;
using System.Data;

namespace BusinessLogic
{
   public class businessStudentDetails
    {
        #region "Variable Declaration"

        DataSet _ds_AllDetails = null;
        string _get_query = string.Empty;

        #endregion       
        
        #region "Object Initialization"

        commonfunction _CmnFuncObj = new commonfunction();
        DALStudentDetails _DataAccessOBj = new DALStudentDetails();
        int rowCount = 0;

        #endregion

        #region "Get Grid Bind Details"
        public DataSet GetBindDetails()
        {

            _ds_AllDetails = new DataSet();
            _get_query = _DataAccessOBj.GetDetais();
            _ds_AllDetails = _CmnFuncObj.GetDataSet(_get_query);
            return _ds_AllDetails;

        }

        #endregion

        #region "Add Details"
        public int AddDetails(string SName, int STotal)
        {
            try
            {
                _get_query = _DataAccessOBj.AddDetails(SName, STotal);
                rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
                return rowCount;
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        #endregion

        #region "Update Details"
        public int UpdateDetails(string SName, int STotal, int SPk_id)
        {
            try
            {
                _get_query = _DataAccessOBj.UpdateDetails(SName, STotal, SPk_id);
                rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
                return rowCount;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion


        #region "Delete Details"
        public int DeleteDetails(int SPk_id)
        {
            try
            {
                _get_query = _DataAccessOBj.DeleteDetails(SPk_id);
                rowCount = _CmnFuncObj.ExecuteQuery(_get_query);
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
