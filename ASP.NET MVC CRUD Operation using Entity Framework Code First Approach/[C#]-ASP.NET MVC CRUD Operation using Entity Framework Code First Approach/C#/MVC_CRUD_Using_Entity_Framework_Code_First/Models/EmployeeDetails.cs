using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_CRUD_Using_Entity_Framework_Code_First.Models
{
    public class EmployeeDetails
    {
        public int EmployeeDetailsId { get; set; }
        public string EmpName { get; set; }
        public string EmpAddress { get; set; }
        public string EmpEmailId { get; set; }
    }
}