using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Support;

namespace Wpf_CollectionView
{
    public  class Person : NotifyUIBase
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string LoginId { get; set; }
        public string JobTitle { get; set; }
        public string Gender { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime BirthDate { get; set; }
        public int OrganizationLevel { get; set; }
    }
}
