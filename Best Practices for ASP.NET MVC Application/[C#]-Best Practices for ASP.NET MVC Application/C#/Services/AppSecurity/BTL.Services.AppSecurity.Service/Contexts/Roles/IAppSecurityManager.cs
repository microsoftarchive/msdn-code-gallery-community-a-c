#region

using System.Collections.Generic;
using BTL.Domain.Core.UserManagement;

#endregion

namespace BTL.Services.AppSecurity.Service.Contexts.Roles
{
    public interface IAppSecurityManager
    {
        string TestMethod();

        IEnumerable<User> GetAllUsers();
    }
}