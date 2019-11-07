using System.Data.Entity;

namespace EmployeeManagement.Models
{
    public class EmployeeContext :DbContext
    {
        public EmployeeContext():base("DefaultConnection")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}