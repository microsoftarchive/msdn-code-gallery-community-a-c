#region

using System;
using System.Runtime.Serialization;

#endregion

namespace BTL.ContractMessages.UserManagement
{
    [DataContract]
    public class UserInfo
    {
        [DataMember]
        public virtual string UserName { get; set; }

        [DataMember]
        public virtual string Password { get; set; }

        [DataMember]
        public virtual string Theme { get; set; }

        [DataMember]
        public virtual DateTime CreatedAt { get; set; }

        [DataMember]
        public virtual DateTime? UpdatedAt { get; set; }
    }
}