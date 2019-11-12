#region

using System;
using System.Collections.Generic;
using BTL.DataAccess;
using BTL.Domain.Core.UserManagement;
using BTL.Infrastructure;
using BTL.Services.AppSecurity.Service.Contexts.Roles;

#endregion

namespace BTL.Services.AppSecurity.Service.Contexts
{
    public class AppSecurityManager : IAppSecurityManager
    {
        private readonly IRepository<User> _userRepository;

        public AppSecurityManager() : this(ObjectFactory.GetType<IRepository<User>>())
        {
        }

        public AppSecurityManager(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        #region IAppSecurityManager Members

        public string TestMethod()
        {
            return "test method";
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.All();
        }

        #endregion
    }
}