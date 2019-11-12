using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Operations
{
    public class DataOperations
    {
        /// <summary>
        /// Replace with your SQL Server name
        /// </summary>
        private string Server = "KARENS-PC";
        /// <summary>
        /// Database in which data resides, see SQL_Script.sql
        /// </summary>
        private string Catalog = "BindingSourceFiltering";
        /// <summary>
        /// Connection string for connecting to the database
        /// </summary>
        private string ConnectionString = "";
        /// <summary>
        /// Setup the connection string
        /// </summary>
        public DataOperations()
        {
            ConnectionString = $"Data Source={Server};Initial Catalog={Catalog};Integrated Security=True";
        }
        /// <summary>
        /// Get all records to show in the CheckedListBox
        /// </summary>
        /// <returns></returns>
        public DataTable GetAll()
        {
            var dt = new DataTable();
            using (var cn = new SqlConnection { ConnectionString = ConnectionString })
            {
                using (var cmd = new SqlCommand { Connection = cn })
                {
                    cmd.CommandText = "SELECT CustomerIdentifier,CompanyName,ContactName,ContactTitle,City,PostalCode,Country " + 
                                      "FROM dbo.Customers";

                    cn.Open();
                    dt.Load(cmd.ExecuteReader());
                }
            }

            return dt;
        }
    }
}
