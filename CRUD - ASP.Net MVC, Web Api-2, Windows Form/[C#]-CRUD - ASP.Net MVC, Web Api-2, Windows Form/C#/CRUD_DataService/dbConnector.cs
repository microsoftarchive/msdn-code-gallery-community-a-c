using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace CRUD_DataService
{
    // Database Connection
    public class dbConnector
    {
        private SqlConnection SqlConn = null;

        public SqlConnection GetConnection
        {
            get { return SqlConn; }
            set { SqlConn = value; }
        }

        public dbConnector()
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["dbConn"].ConnectionString;
            SqlConn = new SqlConnection(ConnectionString);
        }
    }
}
