#region

using System;
using System.Collections.Generic;
using BTL.Domain.Core.UserManagement;
using BTL.Services.AppSecurity.Service.Contexts.Roles;

#endregion

namespace BTL.Services.AppSecurity.Service.Contexts
{
    public class AppSecurityManagerStub : IAppSecurityManager
    {
        #region IAppSecurityManager Members

        public string TestMethod()
        {
            return "test method";
        }

        public IEnumerable<User> GetAllUsers()
        {
            return new List<User>
                       {
                           new User
                               {
                                   Id = new Guid("A1522495-F368-4371-8B40-A937C15A57B9"),
                                   UserName = "Thang Chung",
                                   Password = "123456",
                                   Theme = "Default",
                                   CreatedAt = DateTime.Now
                               }
                       };
        }

        #endregion
    }
}