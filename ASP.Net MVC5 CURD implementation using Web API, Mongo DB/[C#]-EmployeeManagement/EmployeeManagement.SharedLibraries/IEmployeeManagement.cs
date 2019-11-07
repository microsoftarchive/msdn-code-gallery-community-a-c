
using System.Collections.Generic;

namespace EmployeeManagement.SharedLibraries
{
    /// <summary>
    /// This interface structure used for handle employee process implementation.
    /// </summary>
    public interface IEmployeeManagement
    {
        bool AddNewEmployee(IEmployee employeeData);

        bool EditEmployee( int id, IEmployee employeeData);

        bool DeleteEmployee(int EmployeeId);

        List<IEmployee> GetAllEmployeeDetails();

        IEmployee GetEmployeeDetail(int employeeId);
    }
}
