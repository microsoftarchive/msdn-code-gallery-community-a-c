#region

using System;
using System.Linq.Expressions;

#endregion

namespace BTL.Infrastructure.Dci
{
    public interface IDciContext<out T, TParam> where TParam : IDciParameter
    {
        T ReturnResult { get; }

        void Execute(Expression<Func<TParam>> expr);
    }
}