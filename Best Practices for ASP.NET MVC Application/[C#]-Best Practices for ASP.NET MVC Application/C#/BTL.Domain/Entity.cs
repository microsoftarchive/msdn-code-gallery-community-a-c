#region

using System;

#endregion

namespace BTL.Domain
{
    public abstract class Entity
    {
        public virtual Guid Id { get; set; }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == typeof (Entity) && Equals((Entity) obj);
        }

        public bool Equals(Entity other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            return ReferenceEquals(this, other) || other.Id.Equals(Id);
        }
    }
}