using EmployeeManagement.SharedLibraries;
using System.Collections.Generic;

namespace EmployeeManagement.Core
{
    public interface IEmployeeManagementServiceAccess
    {
        bool AddNewEmployee(IEmployee employeeData);

        bool EditEmployee(int id, IEmployee employeeData);

        bool DeleteEmployee(int EmployeeId);

        IList<Employee> GetAllEmployeeDetails();

        IEmployee GetEmployeeDetail(int employeeId);
    }
}
