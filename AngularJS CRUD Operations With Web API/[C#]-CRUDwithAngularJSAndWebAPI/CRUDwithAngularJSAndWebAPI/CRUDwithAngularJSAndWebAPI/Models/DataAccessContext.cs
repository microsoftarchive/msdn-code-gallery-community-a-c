

using System.Data.Entity;

namespace CRUDwithAngularJSAndWebAPI.Models
{
    public class DataAccessContext : DbContext
    {
        public DataAccessContext() : base("testconnection")
        {
        }

        public DbSet<EmployeeModel> Employees { get; set; }       
    }
}