#region

using System;

#endregion

namespace BTL.Domain
{
    public interface IEntity
    {
        Guid Id { get; set; }
    }
}