using System.Collections.Generic;
using System.Linq;
using EmployeeManagement.SharedLibraries;


namespace EmployeeManagement.Core
{
    public class EmployeeManagementServiceAccess : IEmployeeManagementServiceAccess
    {
        ServiceConsumer obj = new ServiceConsumer();
        public EmployeeManagementServiceAccess()
        {
        }

        public bool AddNewEmployee(IEmployee employeeData)
        {

            return obj.AddNewEmployee(employeeData);
        }

        public bool DeleteEmployee(int EmployeeId)
        {
            return obj.DeleteEmployee(EmployeeId);
        }

        public bool EditEmployee(int id, IEmployee employeeData)
        {
            return obj.EditEmployeeDetails(id, employeeData);
        }

        public IList<Employee> GetAllEmployeeDetails()
        {

            return obj.GetAllEmployeeData().ToList();

        }

        public IEmployee GetEmployeeDetail(int employeeId)
        {
            return obj.GetEmployee(employeeId).Result;
        }
    }
}
