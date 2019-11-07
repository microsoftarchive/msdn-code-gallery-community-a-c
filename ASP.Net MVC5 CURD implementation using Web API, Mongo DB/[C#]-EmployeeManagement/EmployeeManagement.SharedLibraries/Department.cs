

namespace EmployeeManagement.SharedLibraries
{
    /// <summary>
    /// This class structure used for hold Department details.
    /// </summary>
    public class Department : IDepartment
    {
        public int DepartmentID { get; set; }

        public string DepartmentName { get; set; }
    }
}
