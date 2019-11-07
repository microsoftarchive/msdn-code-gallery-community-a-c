#region

using System;
using System.Collections.Generic;
using System.Linq;
using BTL.Application.Web.Infrastructure.Security.Authentications.Contexts;
using BTL.Infrastructure.Configuration;
using BTL.Infrastructure.Dci;
using BTL.Infrastructure.Extensions;

#endregion

namespace BTL.Application.Web
{
    public class AuthenticationTypeFactory
    {
        public AuthenticationTypeFactory()
        {
            Initialize();
        }

        /// <summary>
        ///   Tuple contains name, value, authRequestType, processType, returnResult, inputParameter
        /// </summary>
        private ISet<Tuple<string, string, string, string, string, string>> AuthenticationContexts { get; set; }

        private void Initialize()
        {
            var pluginConfiguration =
                new SectionConfiguration().GetInstance<AuthenticationTypeConfiguration>(
                    "BTL.Applications/AuthRequestTypeSettings");
            AuthenticationContexts = pluginConfiguration.SectionCollection;
        }

        /// <summary>
        ///   http://msdn.microsoft.com/en-us/library/b8ytshk6.aspx
        /// </summary>
        /// <typeparam name = "TReturnResult"></typeparam>
        /// <typeparam name = "TInputParam"></typeparam>
        /// <param name = "authType"></param>
        /// <param name = "processType"></param>
        /// <returns></returns>
        public IDciContext<TReturnResult, TInputParam> GetAuthenticationContext<TReturnResult, TInputParam>(
            AuthRequestType authType, ProcessType processType) where TInputParam : IDciParameter
        {
            var context = AuthenticationContexts.FirstOrDefault(x =>
                                                                x.Item3.Equals(authType.ToString(),
                                                                               StringComparison.CurrentCulture) &&
                                                                x.Item4.Equals(processType.ToString(),
                                                                               StringComparison.CurrentCulture));

            //Type[] typeArgs = { Type.GetType(context.Item4), Type.GetType(context.Item5) };

            var fileType = Type.GetType(context.Item2);

            //var constructed = fileType.MakeGenericType(typeArgs);

            if (fileType == null)
                throw new Exception("Cannot resolve type for " + context.Item3);

            //if (!typeof(IDciContext<TReturnResult, TInputParam>).IsAssignableFrom(constructed))
            //    throw new Exception(string.Format("{0} must be inherit from IDciContext<TReturnResult, TInputParam>", context.Item3));

            return (IDciContext<TReturnResult, TInputParam>) Activator.CreateInstance(fileType);
        }
    }
}