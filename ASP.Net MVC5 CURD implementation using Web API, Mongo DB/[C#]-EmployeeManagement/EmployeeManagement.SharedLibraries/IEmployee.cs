
using System;
namespace EmployeeManagement.SharedLibraries
{
    /// <summary>
    /// This interface structure used for hold Employee information.
    /// </summary>
    public interface IEmployee
    {
        Address AddressInfo { get; set; }

        DateTime BirthDate { get; set; }

        string Comments { get; set; }

        DateTime DateHired { get; set; }

        int DepartmentID { get; set; }

        string Email { get; set; }

        int EmployeeID { get; set; }

        int Extension { get; set; }

        string FirstName { get; set; }

        string LastName { get; set; }

        string SocialSecurityNumber { get; set; }

        string Title { get; set; }

        string Voice { get; set; }
    }
}
