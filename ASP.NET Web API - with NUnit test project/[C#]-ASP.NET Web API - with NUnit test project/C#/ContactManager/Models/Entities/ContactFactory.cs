using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ContactManager.Models.Entities;
using System.Web.Configuration;

namespace ContactManager.Models
{
    public class ContactFactory
    {
        private static string connectionString = string.Empty;

        static ContactFactory()
        {
            string connectionStringName = WebConfigurationManager.AppSettings["ContactManagerConnectionStringName"];
            connectionString = WebConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
        }

        public static ContactManagerEntities CreateContext()
        {
            return new ContactManagerEntities(connectionString);
        }
    }
}