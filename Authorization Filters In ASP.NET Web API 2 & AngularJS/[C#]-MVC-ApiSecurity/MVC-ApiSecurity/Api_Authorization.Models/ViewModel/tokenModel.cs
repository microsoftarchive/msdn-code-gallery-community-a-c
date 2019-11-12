using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Authorization.Models.ViewModel
{
    public class tokenModel
    {
        public string clientToken { get; set; }
        public string userid { get; set; }
        public string methodtype { get; set; }
        public string ip { get; set; }
    }
}
