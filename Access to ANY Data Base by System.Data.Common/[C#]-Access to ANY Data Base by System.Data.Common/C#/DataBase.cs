using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Globalization;

using System.Data.Common;

namespace WpfCommonDataAccess
{


    // https://msdn.microsoft.com/en-us/library/9hy8csk1(v=vs.110).aspx
    // https://msdn.microsoft.com/en-us/library/dd0w4a2z(v=vs.110).aspx
    // https://msdn.microsoft.com/en-us/library/wda6c36e(v=vs.110).aspx


    class DataBase
    {

        private System.Data.Common.DbConnection conn;


        // Given a provider name and connection string, 
        // create the DbProviderFactory and DbConnection.
        // Returns a DbConnection on success; null on failure.

        private DbConnection CreateDbConnection(string providerName, string connectionString, out string strError)
        {
            // Assume failure.
            conn = null;
            strError = "";

            // Create the DbProviderFactory and DbConnection.
            if (connectionString != null)
            {
                try
                {
                    DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);

                    conn  = factory.CreateConnection();
                    conn.ConnectionString = connectionString;
                }
                catch (Exception ex)
                {
                    // Set the connection to null if it was created.
                    if (conn  != null)
                    {
                        conn  = null;
                    }
                    strError = ex.Message;
                }
            }
            // Return the connection.
            return conn ;
        }


        public int ExecuteSqlNonQuery(StringBuilder sbSql, string providerName, string connectionString, out string strError)
        {
            int intEffected = -1;  // return number rows effected 
            strError = "";

            try
            {
                conn = CreateDbConnection(providerName, connectionString, out strError);
                conn.Open();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

            try
            {
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sbSql.ToString();
                cmd.CommandType = CommandType.Text;  
                cmd.Connection = conn;

                intEffected = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }
            return intEffected;

        }


        public DataSet GetDataSet(ref StringBuilder sbSql, string providerName, string connectionString, out string strError, out int intEffected)
        {
            intEffected = -1;
            strError = "";

            try
            {
                conn = CreateDbConnection(providerName, connectionString, out strError);
                conn.Open();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return null;
            }

            DataSet dataSet = new DataSet();
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            
            try
            {    //System.Data.Common.DbCommand
                DbDataAdapter dbAdapter = factory.CreateDataAdapter();

                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sbSql.ToString();   
                cmd.CommandType = CommandType.Text;   // If procedure you can use -> CALL procName (@param1,...,@paramN)
                cmd.Connection = conn;

                dbAdapter.SelectCommand = cmd;
                dbAdapter.FillLoadOption = LoadOption.PreserveChanges;
                intEffected = dbAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                strError = ex.Message;
            }
            return dataSet;

        }

        public bool TestConnection(string providerName, string connectionString, out string strError)
        {
            strError = "";
            try
            {
                conn = CreateDbConnection(providerName, connectionString, out strError);
                conn.Open();
                conn.Close();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }
     
        public void closeConnection() // Use it if you need to brake long RUN;
        {
            try
            {
                conn.Close();
            }
            catch
            {
            }
        }
      
    }
}


