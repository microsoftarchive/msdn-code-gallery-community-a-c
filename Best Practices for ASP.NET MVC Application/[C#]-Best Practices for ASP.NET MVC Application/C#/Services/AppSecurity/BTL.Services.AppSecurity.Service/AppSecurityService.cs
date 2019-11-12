#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using BTL.ContractMessages.UserManagement;
using BTL.Infrastructure;
using BTL.Infrastructure.Extensions;
using BTL.Services.AppSecurity.Contract;
using BTL.Services.AppSecurity.Service.Contexts.Roles;

#endregion

namespace BTL.Services.AppSecurity.Service
{
#if DEBUG
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.Single)]
#else             
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]
#endif
    public class AppSecurityService : IAppSecurityService
    {
        private readonly IAppSecurityManager _appSecurityManager;

        public AppSecurityService()
            : this(ObjectFactory.GetType<IAppSecurityManager>())
        {
        }

        public AppSecurityService(IAppSecurityManager appSecurityManager)
        {
            _appSecurityManager = appSecurityManager;
        }

        public string TestMethod()
        {
            return _appSecurityManager.TestMethod();
        }

        public bool ValidateUser(string token)
        {
            //TODO: Validate user
            return true;
        }

        public IEnumerable<UserInfo> GetAllUsers()
        {
            var users = _appSecurityManager.GetAllUsers();

            return users.MapTo<UserInfo>();
        }

        public UserInfo GetUserByUserName(string userName)
        {
            return new UserInfo
            {
                UserName = userName,
                Password = "123",
                CreatedAt = DateTime.Now,
                Theme = "Default"
            };

            //return _appSecurityManager.GetAllUsers().FirstOrDefault(
            //    x => x.UserName.Equals(userName, StringComparison.CurrentCulture)).MapTo<UserInfo>();
        }
    }
}