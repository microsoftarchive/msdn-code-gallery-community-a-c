using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using System.Linq;
using System.Web;
/// <summary>
/// Author      : Shanu
/// Create date : 2015-05-09
/// Description : Biz Class
/// Latest
/// Modifier    : 
/// Modify date : 
/// </summary>
namespace ShanuVS2015.DBClass.shanuBizClass
{
    public class shanuBizClasscs
    {
        shanuMYSQLHelper.shanuMySqlHelper objDAL = new shanuMYSQLHelper.shanuMySqlHelper();
        //All Business Method here
        #region ALL Business method here
        public DataSet SelectList(String SP_NAME, SortedDictionary<string, string> sd)
        {
            try
            {
                return objDAL.SP_DataTable_return(SP_NAME, GetSdParameter(sd));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable SelectQuery(String query)
        {
            try
            {
                return objDAL.DataTable_return(query);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Insert /update and Delete by Query
        public int ExecuteNonQuery_IUD(String Query)
        {
            return objDAL.ExecuteNonQuery_IUD(Query);
        }


        #endregion

        #region Methods Parameter

        /// <summary>
        /// This method Sorted-Dictionary key values to an array of SqlParameters
        /// </summary>
        public static MySqlParameter[] GetSdParameter(SortedDictionary<string, string> sortedDictionary)
        {
            MySqlParameter[] paramArray = new MySqlParameter[] { };

            foreach (string key in sortedDictionary.Keys)
            {
                AddParameter(ref paramArray, new MySqlParameter(key, sortedDictionary[key]));
            }

            return paramArray;
        }


        public static void AddParameter(ref MySqlParameter[] paramArray, string parameterName, object parameterValue)
        {
            MySqlParameter parameter = new MySqlParameter(parameterName, parameterValue);

            AddParameter(ref paramArray, parameter);
        }


        public static void AddParameter(ref MySqlParameter[] paramArray, string parameterName, object parameterValue, object parameterNull)
        {
            MySqlParameter parameter = new MySqlParameter();
            parameter.ParameterName = parameterName;

            if (parameterValue.ToString() == parameterNull.ToString())
                parameter.Value = DBNull.Value;
            else
                parameter.Value = parameterValue;

            AddParameter(ref paramArray, parameter);
        }

        public static void AddParameter(ref MySqlParameter[] paramArray, string parameterName, SqlDbType dbType, object parameterValue)
        {
            MySqlParameter parameter = new MySqlParameter(parameterName, dbType);
            parameter.Value = parameterValue;

            AddParameter(ref paramArray, parameter);
        }

        public static void AddParameter(ref MySqlParameter[] paramArray, string parameterName, SqlDbType dbType, ParameterDirection direction, object parameterValue)
        {
            MySqlParameter parameter = new MySqlParameter(parameterName, dbType);
            parameter.Value = parameterValue;
            parameter.Direction = direction;

            AddParameter(ref paramArray, parameter);
        }

        ////public static void AddParameter(ref MySqlParameter[] paramArray, string parameterName, SqlDbType dbType, int size, object parameterValue)
        ////{
        ////    MySqlParameter parameter = new MySqlParameter(parameterName, dbType, size);
        ////    parameter.Value = parameterValue;

        ////    AddParameter(ref paramArray, parameter);
        ////}

        ////public static void AddParameter(ref MySqlParameter[] paramArray, string parameterName, SqlDbType dbType, int size, ParameterDirection direction, object parameterValue)
        ////{
        ////    MySqlParameter parameter = new MySqlParameter(parameterName, dbType, size);
        ////    parameter.Value = parameterValue;
        ////    parameter.Direction = direction;

        ////    AddParameter(ref paramArray, parameter);
        ////}

        public static void AddParameter(ref MySqlParameter[] paramArray, params MySqlParameter[] newParameters)
        {
            MySqlParameter[] newArray = Array.CreateInstance(typeof(MySqlParameter), paramArray.Length + newParameters.Length) as MySqlParameter[];
            paramArray.CopyTo(newArray, 0);
            newParameters.CopyTo(newArray, paramArray.Length);

            paramArray = newArray;
        }

        #endregion
    }
}