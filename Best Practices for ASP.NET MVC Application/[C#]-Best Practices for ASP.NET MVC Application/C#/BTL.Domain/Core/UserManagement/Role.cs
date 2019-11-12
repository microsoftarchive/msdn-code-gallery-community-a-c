#region

using System;
using System.Collections.Generic;

#endregion

namespace BTL.Domain.Core.UserManagement
{
    public class Role : Entity, IAggregateRoot
    {
        private IList<User> _users;

        public virtual string Name { get; set; }

        public virtual IList<User> Users
        {
            get { return _users ?? (_users = new List<User>()); }
        }

        #region IAggregateRoot Members

        public virtual DateTime CreatedAt { get; set; }

        public virtual DateTime? UpdatedAt { get; set; }

        #endregion
    }
}