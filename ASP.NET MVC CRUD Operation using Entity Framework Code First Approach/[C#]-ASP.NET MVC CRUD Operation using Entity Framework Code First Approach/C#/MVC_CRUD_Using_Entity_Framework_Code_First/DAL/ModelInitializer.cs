using MVC_CRUD_Using_Entity_Framework_Code_First.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_CRUD_Using_Entity_Framework_Code_First.DAL
{
    public class ModelInitializer: DropCreateDatabaseIfModelChanges<EmployeeDetailsDbContext>
    {
        protected override void Seed(EmployeeDetailsDbContext context)
        {
            List<EmployeeDetails> empdtls = new List<EmployeeDetails>
            {
                new EmployeeDetails { EmpName="Test",EmpEmailId="Test@Test.com",EmpAddress="Address"}
            };
            empdtls.ForEach(x => context.employeeDetails.Add(x));
            context.SaveChanges();
        }
    }
}