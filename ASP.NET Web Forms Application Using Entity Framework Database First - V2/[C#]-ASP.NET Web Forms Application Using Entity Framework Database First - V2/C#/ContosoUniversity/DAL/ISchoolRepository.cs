using System;
using System.Collections.Generic;

namespace ContosoUniversity.DAL
{
    public interface ISchoolRepository : IDisposable
    {
        IEnumerable<Department> GetDepartments();
        IEnumerable<Department> GetDepartments(string sortExpression);
        IEnumerable<Department> GetDepartmentsByName(string sortExpression, string nameSearchString);
        IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator);
        void InsertDepartment(Department department);
        void DeleteDepartment(Department department);
        void UpdateDepartment(Department department, Department origDepartment);
        IEnumerable<InstructorName> GetInstructorNames();
        IEnumerable<OfficeAssignment> GetOfficeAssignments(string sortExpression);
        void InsertOfficeAssignment(OfficeAssignment OfficeAssignment);
        void DeleteOfficeAssignment(OfficeAssignment OfficeAssignment);
        void UpdateOfficeAssignment(OfficeAssignment OfficeAssignment, OfficeAssignment origOfficeAssignment);
    }
}