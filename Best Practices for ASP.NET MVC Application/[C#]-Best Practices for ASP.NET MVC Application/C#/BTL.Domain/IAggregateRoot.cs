#region

using System;

#endregion

namespace BTL.Domain
{
    public interface IAggregateRoot : IEntity
    {
        DateTime CreatedAt { get; set; }

        DateTime? UpdatedAt { get; set; }
    }
}