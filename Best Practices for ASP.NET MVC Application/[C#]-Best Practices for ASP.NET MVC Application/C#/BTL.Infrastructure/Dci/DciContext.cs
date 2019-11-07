#region

using System;
using System.Linq.Expressions;

#endregion

namespace BTL.Infrastructure.Dci
{
    public abstract class DciContext<T, TParam> : IDciContext<T, TParam> where TParam : IDciParameter
    {
        protected T Result;

        #region IDciContext<T,TParam> Members

        public abstract void Execute(Expression<Func<TParam>> expr);

        public T ReturnResult
        {
            get { return Result; }
        }

        #endregion
    }
}