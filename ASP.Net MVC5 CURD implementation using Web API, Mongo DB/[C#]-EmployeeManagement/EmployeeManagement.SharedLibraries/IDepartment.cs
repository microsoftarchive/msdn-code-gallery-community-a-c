

namespace EmployeeManagement.SharedLibraries
{
    /// <summary>
    /// This interface structure used for handle Employee department details.
    /// </summary>
    public interface IDepartment
    {
        int DepartmentID { get; set; }

        string DepartmentName { get; set; }
    }
}
