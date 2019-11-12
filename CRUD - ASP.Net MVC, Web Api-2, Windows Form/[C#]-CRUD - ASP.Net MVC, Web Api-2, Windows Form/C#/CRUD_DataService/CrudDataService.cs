using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD_Model;

namespace CRUD_DataService
{
    // Database Service
    public class CrudDataService
    {
        public List<tblCustomer> GetCustomerList(int PageNo, int RowCountPerPage, int IsPaging)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                List<tblCustomer> _listCustomer = new List<tblCustomer>();

                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand("READ_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@PageNo", PageNo);
                objCommand.Parameters.AddWithValue("@RowCountPerPage", RowCountPerPage);
                objCommand.Parameters.AddWithValue("@IsPaging", IsPaging);
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    tblCustomer objCust = new tblCustomer();
                    objCust.CustID = Convert.ToInt32(_Reader["CustID"]);
                    objCust.CustName = _Reader["CustName"].ToString();
                    objCust.CustEmail = _Reader["CustEmail"].ToString();
                    objCust.CustAddress = _Reader["CustAddress"].ToString();
                    objCust.CustContact = _Reader["CustContact"].ToString();
                    _listCustomer.Add(objCust);
                }

                return _listCustomer;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public tblCustomer GetCustomerDetails(long? id)
        {

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                tblCustomer objCust = new tblCustomer();

                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand("VIEW_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@CustID", id);
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    objCust.CustID = Convert.ToInt32(_Reader["CustID"]);
                    objCust.CustName = _Reader["CustName"].ToString();
                    objCust.CustEmail = _Reader["CustEmail"].ToString();
                    objCust.CustAddress = _Reader["CustAddress"].ToString();
                    objCust.CustContact = _Reader["CustContact"].ToString();
                }

                return objCust;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 InsertCustomer(tblCustomer objCust)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand("CREATE_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@CustName", objCust.CustName);
                objCommand.Parameters.AddWithValue("@CustEmail", objCust.CustEmail);
                objCommand.Parameters.AddWithValue("@CustAddress", objCust.CustAddress);
                objCommand.Parameters.AddWithValue("@CustContact", objCust.CustContact);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 UpdateCustomer(tblCustomer objCust)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand("UPDATE_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@CustID", objCust.CustID);
                objCommand.Parameters.AddWithValue("@CustName", objCust.CustName);
                objCommand.Parameters.AddWithValue("@CustEmail", objCust.CustEmail);
                objCommand.Parameters.AddWithValue("@CustAddress", objCust.CustAddress);
                objCommand.Parameters.AddWithValue("@CustContact", objCust.CustContact);

                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }

        public Int32 DeleteCustomer(long? id)
        {
            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            int result = 0;

            try
            {
                if (Conn.State != System.Data.ConnectionState.Open)
                    Conn.Open();

                SqlCommand objCommand = new SqlCommand("DELETE_CUSTOMER", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@CustID", id);
                result = Convert.ToInt32(objCommand.ExecuteScalar());

                if (result > 0)
                {
                    return result;
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }
    }
}
