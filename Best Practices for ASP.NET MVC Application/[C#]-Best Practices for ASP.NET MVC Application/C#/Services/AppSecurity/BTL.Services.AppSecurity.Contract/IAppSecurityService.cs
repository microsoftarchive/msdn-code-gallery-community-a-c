#region

using System.Collections.Generic;
using System.ServiceModel;
using BTL.ContractMessages.UserManagement;

#endregion

namespace BTL.Services.AppSecurity.Contract
{
    [ServiceContract(Namespace = "http://www.btlvn.com/AppSecurityService")]
    public interface IAppSecurityService
    {
        [OperationContract(Name = "TestMethod")]
        string TestMethod();

        [OperationContract(Name = "ValidateUser")]
        bool ValidateUser(string token);

        [OperationContract(Name = "GetAllUsers")]
        IEnumerable<UserInfo> GetAllUsers();

        [OperationContract(Name = "GetUserBy")]
        UserInfo GetUserByUserName(string userName);
    }
}