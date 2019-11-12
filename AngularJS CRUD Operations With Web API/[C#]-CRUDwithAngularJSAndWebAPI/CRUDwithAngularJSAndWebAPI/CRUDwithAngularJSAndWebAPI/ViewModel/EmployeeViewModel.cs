using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDwithAngularJSAndWebAPI.ViewModel
{
    public class EmployeeViewModel
    {
        public int EmployeeID { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public float Salary { get; set; }
        public DateTime DOB { get; set; }
        public int DepartmentID { get; set; }        
        public string DepartmentName { get; set; }
    }
}