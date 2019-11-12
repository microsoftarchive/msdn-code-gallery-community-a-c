using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace WebApiPagingAngularClient.Utility
{
    internal static class QueryHelper
    {
        public static bool PropertyExists<T>(string propertyName)
        {
            return typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) != null;
        }

        public static Expression<Func<T, string>> GetPropertyExpression<T>(string propertyName)
        {
            if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
            {
                return null;
            }

            var paramterExpression = Expression.Parameter(typeof(T));

            return (Expression<Func<T, string>>)Expression.Lambda(Expression.PropertyOrField(paramterExpression, propertyName), paramterExpression);
        }

        public static Expression<Func<T, int>> GetPropertyExpressionInt<T>(string propertyName)
        {
            if (typeof(T).GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance) == null)
            {
                return null;
            }

            var paramterExpression = Expression.Parameter(typeof(T));

            return (Expression<Func<T, int>>)Expression.Lambda(Expression.PropertyOrField(paramterExpression, propertyName), paramterExpression);
        }
    }
}