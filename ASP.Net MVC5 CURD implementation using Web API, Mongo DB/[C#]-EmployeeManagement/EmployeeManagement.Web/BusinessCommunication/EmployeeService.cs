using System;
using System.Collections.Generic;
using EmployeeManagement.Core;
using EmployeeManagement.SharedLibraries;

namespace EmployeeManagement.Web.BusinessCommunication
{
    public class EmployeeService : IEmployeeService
    {
        public IEnumerable<IEmployee> GetAllEmployeeCollection()
        {
            try
            {
                IEmployeeManagementServiceAccess businessAccess = new EmployeeManagementServiceAccess();
                return businessAccess.GetAllEmployeeDetails();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public bool UpdateEmployeeInformation(IEmployee updatedEmpInfo, int employeeId)
        {
            try
            {
                IEmployeeManagementServiceAccess businessAccess = new EmployeeManagementServiceAccess();
                return businessAccess.EditEmployee(employeeId, updatedEmpInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool AddNewEmployee(IEmployee newEmpInfo)
        {
            try
            {
                IEmployeeManagementServiceAccess businessAccess = new EmployeeManagementServiceAccess();
                return businessAccess.AddNewEmployee(newEmpInfo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                IEmployeeManagementServiceAccess businessAccess = new EmployeeManagementServiceAccess();
                return businessAccess.DeleteEmployee(employeeId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}