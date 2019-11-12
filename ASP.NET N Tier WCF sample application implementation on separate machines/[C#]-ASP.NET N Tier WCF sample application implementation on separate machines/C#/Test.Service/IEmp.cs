using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Test.Model;

namespace Test.Services
{
    [ServiceContract]
    public interface IEmp
    {
        [OperationContract]
        List<EmpInfo> GetEmps();
    }
}
