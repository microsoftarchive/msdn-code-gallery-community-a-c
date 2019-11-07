using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementProgram
{
    class subject
    {
        //for code reusability and rather than hardcoding the subjects, it is better to create a class for subjects taught
        private string cName;   // course name

        public void setCName(string n) { cName = n; }
        public string getCName() { return cName; }
    }
}
