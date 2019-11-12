using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Test.Helper
{
    public class Global
    {
        public static string EmpConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["EmpConnectionString"].ToString(); }
        }
    }

}
