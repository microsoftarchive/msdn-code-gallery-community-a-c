#region

using System;
using System.Diagnostics.Contracts;

#endregion

namespace BTL.Infrastructure
{
    public static class Guard
    {
        public static void Assert(bool isTrue, string argumentName)
        {
#if DEBUG
            Contract.Assert(!isTrue, argumentName);
#endif
            if (isTrue)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void MakeSureAllInstancesIsNullNot(params object[] obj)
        {
            foreach (var o in obj)
            {
                Assert(o == null, string.Format("{0} is null", o.GetType().FullName));
            }
        }
    }
}