

namespace EmployeeManagement.SharedLibraries
{
    /// <summary>
    /// This interface structure used for Employee Address information.
    /// </summary>
    public interface IAddress
    {
        string StreetName { get;  set; }

        string Country { get; set; }

        string City { get;  set; }

        string PostalCode { get; set; }

        string State { get; set; }
    }
}
