#region

using System.Collections.Generic;
using BTL.ContractMessages.UserManagement;

#endregion

namespace BTL.Application.Facade.AppSecurity
{
    public interface IAppSecurityFacade
    {
        string TestMethod();

        bool ValidateUser(string token);

        IEnumerable<UserInfo> GetAllUsers();

        UserInfo GetUserByUserName(string userName);
    }
}