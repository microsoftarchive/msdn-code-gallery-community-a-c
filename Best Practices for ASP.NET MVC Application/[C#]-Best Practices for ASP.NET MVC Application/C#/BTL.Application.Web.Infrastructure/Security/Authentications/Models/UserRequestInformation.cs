#region

using System.Web.Mvc;
using BTL.ContractMessages.UserManagement;
using BTL.Infrastructure.Configuration;

#endregion

namespace BTL.Application.Web.Infrastructure.Security.Authentications.Models
{
    public abstract class UserRequestInformation : SocialUserInformation
    {
        protected readonly IExConfigurationManager ConfigurationManager;

        protected UserRequestInformation()
            : this(DependencyResolver.Current.GetService<IExConfigurationManager>())
        {
        }

        protected UserRequestInformation(IExConfigurationManager configurationManager)
        {
            ConfigurationManager = configurationManager;
        }
    }
}