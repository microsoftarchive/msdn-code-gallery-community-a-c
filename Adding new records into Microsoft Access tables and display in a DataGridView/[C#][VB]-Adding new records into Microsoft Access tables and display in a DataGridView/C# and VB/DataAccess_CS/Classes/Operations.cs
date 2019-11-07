using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    /// <summary>
    /// Responsible for all database loading and inserting
    /// </summary>
    /// <remarks>
    /// LoadSingleRow and AddNewRow(ByVal CompanyName As String, ByVal ContactName As String...)
    /// were added in for assisting with a online question where the person was using VS2008
    /// so there are differences with object initialization to fit into VS2008 syntax
    /// </remarks>
    public class Operations
    {

        /// <summary>
        /// Creates our connection string to the database which is easy to follow
        /// and there is no string concatenation done here
        /// </summary>
        /// <remarks></remarks>
        private OleDbConnectionStringBuilder Builder = new OleDbConnectionStringBuilder { Provider = "Microsoft.ACE.OLEDB.12.0", DataSource = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Database1.accdb") };

        /// <summary>
        /// Used to get all customers at program startup
        /// </summary>
        /// <remarks></remarks>
        private string SelectStatement = "SELECT Identifier, CompanyName, ContactName, ContactTitle FROM Customer;";

        /// <summary>
        /// Responsible for inserting rows into the customer table
        /// </summary>
        /// <remarks></remarks>
        private string InsertStatement = "INSERT INTO Customer (CompanyName, ContactName, ContactTitle) Values (@CompanyName, @ContactName, @ContactTitle)";

        /// <summary>
        /// Used to open the database in Windows Explorer
        /// </summary>
        /// <remarks></remarks>
        public void ViewDatabase()
        {
            Process.Start(Builder.DataSource);
        }

        /// <summary>
        /// Load existing customers into a BindingSource which becomes
        /// the DataSource for a DataGridView
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public DataTable LoadCustomers()
        {
            using (OleDbConnection cn = new OleDbConnection { ConnectionString = Builder.ConnectionString })
            {
                using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT Identifier, CompanyName, ContactName, ContactTitle FROM Customer;";

                    DataTable dt = new DataTable { TableName = "Customer" };

                    cn.Open();
                    dt.Load(cmd.ExecuteReader());

                    return dt;

                }
            }
        }
        public string LoadSingleRow(int Identifier)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            using (OleDbConnection cn = new OleDbConnection(Builder.ConnectionString))
            {
                using (OleDbCommand cmd = new OleDbCommand("", cn))
                {
                    cmd.CommandText = "SELECT CompanyName, ContactName, ContactTitle FROM Customer WHERE Identifier =" + Identifier.ToString();
                    cn.Open();
                    OleDbDataReader Reader = cmd.ExecuteReader();
                    if (Reader.HasRows)
                    {
                        Reader.Read();

                        sb.AppendLine("Company name [" + Reader.GetString(0) + "]");
                        sb.AppendLine("Contact [" + Reader.GetString(1) + "]");
                        sb.AppendLine("Contact name [" + Reader.GetString(2) + "]");
                    }
                    else
                    {
                        sb.AppendLine("Operation failed");
                    }
                }
            }

            return sb.ToString();
        }
        /// <summary>
        /// Used to add one row to the Customer table and on success
        /// return the new primary key.
        /// 
        /// Here we pass in a customer but could have very well passed in
        /// an object array or one parameter for each field.
        /// 
        /// All fields are of type string but you can add other types
        /// too.
        /// 
        /// AddWithValue is used here but we could also use Add and
        /// control the parameters.
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="Identfier"></param>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool AddNewRow(Customer sender, ref int Identfier)
        {
            bool Success = true;

            try
            {
                using (OleDbConnection cn = new OleDbConnection { ConnectionString = Builder.ConnectionString })
                {
                    using (OleDbCommand cmd = new OleDbCommand { Connection = cn })
                    {

                        cmd.CommandText = InsertStatement;

                        cmd.Parameters.AddWithValue("@CompanyName", sender.CompanyName);
                        cmd.Parameters.AddWithValue("@ContactName", sender.ContactName);
                        cmd.Parameters.AddWithValue("@ContactTitle", sender.ContactTitle);

                        cn.Open();

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "Select @@Identity";
                        Identfier = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                }

            }
            catch (Exception ex)
            {
                Success = false;
            }

            return Success;

        }
        public bool AddNewRow(string CompanyName, string ContactName, string ContactTitle, ref int Identfier)
        {
            bool Success = true;

            try
            {
                using (OleDbConnection cn = new OleDbConnection(Builder.ConnectionString))
                {
                    using (OleDbCommand cmd = new OleDbCommand("", cn))
                    {

                        cmd.CommandText = "INSERT INTO Customer (CompanyName,ContactName,ContactTitle) Values (@CompanyName,@ContactName,@ContactTitle)";

                        cmd.Parameters.AddWithValue("@CompanyName", CompanyName.Trim());
                        cmd.Parameters.AddWithValue("@ContactName", ContactName.Trim());
                        cmd.Parameters.AddWithValue("@ContactTitle", ContactTitle.Trim());

                        cn.Open();

                        cmd.ExecuteNonQuery();

                        cmd.CommandText = "Select @@Identity";
                        Identfier = Convert.ToInt32(cmd.ExecuteScalar());

                    }
                }

            }
            catch (Exception ex)
            {
                Success = false;
            }

            return Success;

        }
        public Operations()
        {
        }

        public override string ToString()
        {
            return "Demo adding rows";
        }
    }
}
