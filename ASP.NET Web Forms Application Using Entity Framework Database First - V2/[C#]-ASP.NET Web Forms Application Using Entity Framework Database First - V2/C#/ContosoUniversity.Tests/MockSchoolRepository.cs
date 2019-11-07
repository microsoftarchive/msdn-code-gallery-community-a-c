using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ContosoUniversity.DAL;
using ContosoUniversity.BLL;

namespace ContosoUniversity.Tests
{
    class MockSchoolRepository : ISchoolRepository, IDisposable
    {
        List<Department> departments = new List<Department>();
        List<InstructorName> instructors = new List<InstructorName>();

        List<OfficeAssignment> officeAssignments = new List<OfficeAssignment>();

        public IEnumerable<OfficeAssignment> GetOfficeAssignments(string sortExpression)
        {
            return officeAssignments;
        }

        public void InsertOfficeAssignment(OfficeAssignment officeAssignment)
        {
            officeAssignments.Add(officeAssignment);
        }

        public void DeleteOfficeAssignment(OfficeAssignment officeAssignment)
        {
            officeAssignments.Remove(officeAssignment);
        }

        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment, OfficeAssignment origOfficeAssignment)
        {
            officeAssignments.Remove(origOfficeAssignment);
            officeAssignments.Add(officeAssignment);
        }
        
        public IEnumerable<Department> GetDepartments()
        {
            return departments;
        }

        public IEnumerable<Department> GetDepartments(string sortExpression)
        {
            return departments;
        }

        public IEnumerable<Department> GetDepartmentsByName(string sortExpression, string nameSearchString)
        {
            return departments;
        }
        
        public void InsertDepartment(Department department)
        {
            departments.Add(department);
        }

        public void DeleteDepartment(Department department)
        {
            departments.Remove(department);
        }

        public void UpdateDepartment(Department department, Department origDepartment)
        {
            departments.Remove(origDepartment);
            departments.Add(department);
        }

        public IEnumerable<InstructorName> GetInstructorNames()
        {
            return instructors;
        }

        public IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator)
        {
            return (from d in departments
                    where d.Administrator == administrator
                    select d);
        }

        public void Dispose()
        {

        }
    }
}