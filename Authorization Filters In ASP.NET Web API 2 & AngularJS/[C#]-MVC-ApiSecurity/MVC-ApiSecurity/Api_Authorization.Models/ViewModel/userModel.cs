using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api_Authorization.Models.ViewModel
{
    public class loginUserModel
    {
        public string LoginId { get; set; }
        public string Password { get; set; }
    }

    public class loggedUserModel
    {
        public int UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; }
        public string Role { get; set; }
        public bool Create { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
        public bool Read { get; set; }
        public string Ip { get; set; }

    }
}
