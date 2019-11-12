
using System;

namespace EmployeeManagement.SharedLibraries
{
    /// <summary>
    /// This class structure used for handle Employee information.
    /// </summary>
    public class Employee : IEmployee
    {
        public Address AddressInfo { get; set; }

        public DateTime BirthDate { get; set; }

        public string Comments { get; set; }

        public DateTime DateHired { get; set; }

        public int DepartmentID { get; set; }

        public string Email { get; set; }

        public int EmployeeID { get; set; }

        public int Extension { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string SocialSecurityNumber { get; set; }

        public string Title { get; set; }

        public string Voice { get; set; }
    }
}
