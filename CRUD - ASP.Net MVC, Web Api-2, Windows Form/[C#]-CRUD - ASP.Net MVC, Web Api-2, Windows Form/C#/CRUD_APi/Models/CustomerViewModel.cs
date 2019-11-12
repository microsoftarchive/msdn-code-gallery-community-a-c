using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_APi.Models
{
    public class CustomerViewModel
    {
        public long CustID { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string CustAddress { get; set; }
        public string CustContact { get; set; }
    }
}