using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EmployeeMgrMvc.Models
{
    [MetadataType(typeof(EmployeeMetadata))]
    public partial class Employee
    {
    }

    public class EmployeeMetadata
    {
        [Required(ErrorMessage = "Employee id is required.")]
        public object EmployeeID { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public object FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public object LastName { get; set; }

        [StringLength(60, ErrorMessage="Address must be 60 characters or less")]
        public object Address { get; set; }

        [RegularExpression(@"((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}",
            ErrorMessage = "Phone number should be in the format, 123-123-1234.")]
        public object HomePhone { get; set; }        
    }

}