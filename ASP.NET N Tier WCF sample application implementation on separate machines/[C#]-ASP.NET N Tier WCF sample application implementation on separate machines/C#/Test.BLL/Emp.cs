using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Model;
using Test.IDAL;
using Test.Factory;

namespace Test.BLL
{
    public class Emp
    {
        private static readonly IEmp dal = DataAccess.CreateInstance<IEmp>("Emp");

        public static List<EmpInfo> GetEmps()
        {
            return dal.GetEmps();
        }
    }
}
