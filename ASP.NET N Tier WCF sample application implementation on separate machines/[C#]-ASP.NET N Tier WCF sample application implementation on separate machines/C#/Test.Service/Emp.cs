using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Test.Model;

namespace Test.Services
{
    public class Emp : IEmp
    {
        public List<EmpInfo> GetEmps()
        {
            return BLL.Emp.GetEmps();
        }
    }
}
