using MVC_CRUD_Using_Entity_Framework_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CRUD_Using_Entity_Framework_Code_First.DAL
{
    public class EmployeeDetailsDbContext : DbContext
    {
        public EmployeeDetailsDbContext() : base("MyConnection")
        {
        }

        public DbSet<EmployeeDetails> employeeDetails { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
