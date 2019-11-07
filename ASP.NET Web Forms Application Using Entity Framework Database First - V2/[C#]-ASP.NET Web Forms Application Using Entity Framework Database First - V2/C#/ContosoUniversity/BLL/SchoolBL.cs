using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ContosoUniversity.DAL;

namespace ContosoUniversity.BLL
{
    public class SchoolBL : IDisposable
    {
        private ISchoolRepository schoolRepository;

        public SchoolBL()
        {
            this.schoolRepository = new SchoolRepository();
        }

        public SchoolBL(ISchoolRepository schoolRepository)
        {
            this.schoolRepository = schoolRepository;
        }

        public IEnumerable<Department> GetDepartments()
        {
            return schoolRepository.GetDepartments();
        }

        public IEnumerable<Department> GetDepartments(string sortExpression)
        {
            return schoolRepository.GetDepartments(sortExpression);
        }

        public IEnumerable<Department> GetDepartmentsByName(string sortExpression, string nameSearchString)
        {
            return schoolRepository.GetDepartmentsByName(sortExpression, nameSearchString);
        }
        
        public void InsertDepartment(Department department)
        {
            ValidateOneAdministratorAssignmentPerInstructor(department);
            try
            {
                schoolRepository.InsertDepartment(department);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void DeleteDepartment(Department department)
        {
            try
            {
                schoolRepository.DeleteDepartment(department);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void UpdateDepartment(Department department, Department origDepartment)
        {
            ValidateOneAdministratorAssignmentPerInstructor(department);
            try
            {
                schoolRepository.UpdateDepartment(department, origDepartment);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }

        }

        public IEnumerable<InstructorName> GetInstructorNames()
        {
            return schoolRepository.GetInstructorNames();
        }

        public IEnumerable<OfficeAssignment> GetOfficeAssignments(string sortExpression)
        {
            if (string.IsNullOrEmpty(sortExpression)) sortExpression = "Person.LastName";
            return schoolRepository.GetOfficeAssignments(sortExpression);
        }

        public void InsertOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                schoolRepository.InsertOfficeAssignment(officeAssignment);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void DeleteOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                schoolRepository.DeleteOfficeAssignment(officeAssignment);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }

        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment, OfficeAssignment origOfficeAssignment)
        {
            try
            {
                schoolRepository.UpdateOfficeAssignment(officeAssignment, origOfficeAssignment);
            }
            catch (Exception ex)
            {
                //Include catch blocks for specific exceptions first, 
                //and handle or log the error as appropriate in each. 
                //Include a generic catch block like this one last. 
                throw ex;
            }
        }
        
        private void ValidateOneAdministratorAssignmentPerInstructor(Department department)
        {
            if (department.Administrator != null)
            {
                var duplicateDepartment = schoolRepository.GetDepartmentsByAdministrator(department.Administrator.GetValueOrDefault()).FirstOrDefault();
                if (duplicateDepartment != null && duplicateDepartment.DepartmentID != department.DepartmentID)
                {
                    throw new DuplicateAdministratorException(String.Format(
                        "Instructor {0} {1} is already administrator of the {2} department.",
                        duplicateDepartment.Person.FirstMidName,
                        duplicateDepartment.Person.LastName,
                        duplicateDepartment.Name));
                }
            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    schoolRepository.Dispose();
                }
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}