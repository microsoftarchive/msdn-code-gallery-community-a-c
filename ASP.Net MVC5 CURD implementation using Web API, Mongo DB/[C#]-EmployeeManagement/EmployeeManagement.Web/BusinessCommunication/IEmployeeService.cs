using EmployeeManagement.SharedLibraries;
using System.Collections.Generic;

namespace EmployeeManagement.Web.BusinessCommunication
{
    public interface IEmployeeService
    {
        IEnumerable<IEmployee> GetAllEmployeeCollection();
        bool UpdateEmployeeInformation(IEmployee updatedEmpInfo, int employeeId);
        bool AddNewEmployee(IEmployee newEmpInfo);
        bool DeleteEmployee(int employeeId);
    }
}
