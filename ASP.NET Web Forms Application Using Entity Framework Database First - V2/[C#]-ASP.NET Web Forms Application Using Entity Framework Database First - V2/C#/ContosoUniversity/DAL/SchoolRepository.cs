using System;
using System.Collections.Generic;
using System.Linq;
using ContosoUniversity.DAL;
using System.Data.Objects;
using System.Data;

namespace ContosoUniversity.BLL
{
    public class SchoolRepository : IDisposable, ISchoolRepository
    {
        private SchoolEntities context = new SchoolEntities();

        public SchoolRepository()
        {
            context.Departments.MergeOption = MergeOption.NoTracking;
            context.InstructorNames.MergeOption = MergeOption.NoTracking;
            context.OfficeAssignments.MergeOption = MergeOption.NoTracking;
        }
        
        public IEnumerable<Department> GetDepartments()
        {
            return GetDepartments("");
        }

        public IEnumerable<Department> GetDepartments(string sortExpression)
        {
            if (String.IsNullOrWhiteSpace(sortExpression))
            {
                sortExpression = "Name";
            }
            return context.Departments.Include("Person").OrderBy("it." + sortExpression).ToList();
        }

        public IEnumerable<Department> GetDepartmentsByName(string sortExpression, string nameSearchString)
        {
            if (String.IsNullOrWhiteSpace(sortExpression))
            {
                sortExpression = "Name";
            } 
            if (String.IsNullOrWhiteSpace(nameSearchString)) 
            { 
                nameSearchString = ""; 
            }
            return context.Departments.Include("Person").Include("Courses").
               OrderBy("it." + sortExpression).Where(d => d.Name.Contains(nameSearchString)).ToList();
            
            //var departments = new ObjectQuery<Department>("SELECT VALUE d FROM Departments AS d", context).OrderBy("it." + sortExpression).Include("Person").Include("Courses").Where(d => d.Name.Contains(nameSearchString));
            //string commandText = ((ObjectQuery)departments).ToTraceString();
            //return departments.ToList(); 

            //var departments = new ObjectQuery<Department>("SELECT VALUE d FROM Departments AS d", context).OrderBy("it." + sortExpression).Where(d => d.Name.Contains(nameSearchString)).ToList();
            //foreach (Department d in departments)
            //{
            //    d.Courses.Load();
            //    d.PersonReference.Load();
            //}
            //return departments;
        }
        
        public IEnumerable<Department> GetDepartmentsByAdministrator(Int32 administrator)
        {
            //return new ObjectQuery<Department>("SELECT VALUE d FROM Departments as d", context, MergeOption.NoTracking).Include("Person").Where(d => d.Administrator == administrator).ToList();
            return context.CompiledDepartmentsByAdministratorQuery(administrator); 
        }
        
        public void InsertDepartment(Department department)
        {
            try
            {
                department.DepartmentID = GenerateDepartmentID();
                context.Departments.AddObject(department);
                context.SaveChanges();
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
                context.Departments.Attach(department);
                context.Departments.DeleteObject(department);
                SaveChanges();
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
            try
            {
                context.Departments.Attach(origDepartment);
                context.ApplyCurrentValues("Departments", department);
                SaveChanges();
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
            //return context.InstructorNames.OrderBy("it.FullName").ToList();
            return context.CompiledInstructorNamesQuery(); 
        }

        private Int32 GenerateDepartmentID()
        {
            Int32 maxDepartmentID = 0;
            var department = (from d in GetDepartments()
                              orderby d.DepartmentID descending
                              select d).FirstOrDefault();
            if (department != null)
            {
                maxDepartmentID = department.DepartmentID + 1;
            }
            return maxDepartmentID;
        }

        public IEnumerable<OfficeAssignment> GetOfficeAssignments(string sortExpression)
        {
            return new ObjectQuery<OfficeAssignment>("SELECT VALUE o FROM OfficeAssignments AS o", context).Include("Person").OrderBy("it." + sortExpression).ToList();
        }

        public void InsertOfficeAssignment(OfficeAssignment officeAssignment)
        {
            context.OfficeAssignments.AddObject(officeAssignment);
            context.SaveChanges();
        }

        public void DeleteOfficeAssignment(OfficeAssignment officeAssignment)
        {
            context.OfficeAssignments.Attach(officeAssignment);
            context.OfficeAssignments.DeleteObject(officeAssignment);
            context.SaveChanges();
        }

        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment, OfficeAssignment origOfficeAssignment)
        {
            context.OfficeAssignments.Attach(origOfficeAssignment);
            context.ApplyCurrentValues("OfficeAssignments", officeAssignment);
            SaveChanges();
        }
        
        public void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (OptimisticConcurrencyException ocex)
            {
                context.Refresh(RefreshMode.StoreWins, ocex.StateEntries[0].Entity);
                throw ocex;
            }
        }

        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    context.Dispose();
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