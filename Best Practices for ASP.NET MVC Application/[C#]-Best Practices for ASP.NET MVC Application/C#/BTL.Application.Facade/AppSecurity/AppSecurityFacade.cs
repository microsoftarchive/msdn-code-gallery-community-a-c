#region

using System;
using System.Collections.Generic;
using BTL.ContractMessages.UserManagement;
using BTL.Infrastructure.Wcf;
using BTL.Services.AppSecurity.Contract;

#endregion

namespace BTL.Application.Facade.AppSecurity
{
    public class AppSecurityFacade : ServiceFacadeBase<IAppSecurityService>, IAppSecurityFacade
    {
        protected override string ServiceName
        {
            get { return "AppSecurityService"; }
        }

        #region IAppSecurityFacade Members

        public string TestMethod()
        {
            return Service.TestMethod();
        }

        public bool ValidateUser(string token)
        {
            return Service.ValidateUser(token);
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            return Service.GetAllUsers();
        }

        public UserInfo GetUserByUserName(string userName)
        {
            return Service.GetUserByUserName(userName);
        }

        #endregion
    }
}