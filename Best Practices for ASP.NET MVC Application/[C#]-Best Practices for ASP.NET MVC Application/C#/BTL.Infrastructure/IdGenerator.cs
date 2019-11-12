#region

using System;

#endregion

namespace BTL.Infrastructure
{
    public class IdGenerator
    {
        public static object Generating<TType>(dynamic seek)
        {
            if (typeof (TType) is Guid)
                return Guid.NewGuid();

            if (typeof (TType) is int)
                return seek + 1;

            return null;
        }
    }
}