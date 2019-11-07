#region

using System;
using System.Security.Principal;
using BTL.Infrastructure;

#endregion

namespace BTL.ContractMessages.UserManagement
{
    public class UserPrincipal : IPrincipal
    {
        private readonly IIdentity _identity;
        private readonly UserInfo _user;

        public UserPrincipal(IIdentity identity, UserInfo user)
        {
            _identity = identity;
            _user = user;
        }

        public UserInfo User
        {
            get { return _user; }
        }

        public ISetting Setting { get; set; }

        #region IPrincipal Members

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public IIdentity Identity
        {
            get { return _identity; }
        }

        #endregion
    }
}