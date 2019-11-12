#region

using System;
using System.Collections.Generic;

#endregion

namespace BTL.Domain.Core.UserManagement
{
    public class User : Entity, IAggregateRoot
    {
        private IList<Role> _roles;

        public virtual string UserName { get; set; }

        public virtual string Password { get; set; }

        public virtual string Theme { get; set; }

        public virtual IList<Role> Roles
        {
            get { return _roles ?? (_roles = new List<Role>()); }
        }

        #region IAggregateRoot Members

        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime? UpdatedAt { get; set; }

        #endregion

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}-{3}-{4}", UserName, Password, Theme, CreatedAt, UpdatedAt);
        }
    }
}