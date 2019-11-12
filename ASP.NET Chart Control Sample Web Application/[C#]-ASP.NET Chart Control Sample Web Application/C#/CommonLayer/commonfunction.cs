using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CommonLayer
{
    public class commonfunction
    {
        #region Variable Declaration

        SqlConnection _connection;
        SqlCommand _command;
        SqlDataAdapter _Adapter;
        DataSet _DS;
        int _count;

        #endregion

        #region Get DataSet

        public DataSet GetDataSet(string _query)
        {

            try
            {
                _DS = new DataSet();
                _connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                _command = new SqlCommand(_query, _connection);
                _Adapter = new SqlDataAdapter(_command);
                _Adapter.Fill(_DS);
                return _DS;

            }
            catch (Exception)
            {

                throw;

            }
            finally
            {
                _DS.Dispose();
            }

        }
        #endregion

        #region Execute Query

        public int ExecuteQuery(string _query)
        {
            try
            {
                _connection =  new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
                _connection.Open();
                _command = new SqlCommand(_query, _connection);
                _count = _command.ExecuteNonQuery();
                _connection.Close();
                return _count;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                _connection.Close();
            }

        }

        #endregion
    }
}
