

namespace EmployeeManagement.SharedLibraries
{
    /// <summary>
    /// This class structure for handle Address information.
    /// </summary>
    public class Address : IAddress
    {
        public string StreetName { get; set; }

        public string Country { get; set; }

        public string City { get; set; }

        public string PostalCode { get; set; }

        public string State { get; set; }
    }
}
