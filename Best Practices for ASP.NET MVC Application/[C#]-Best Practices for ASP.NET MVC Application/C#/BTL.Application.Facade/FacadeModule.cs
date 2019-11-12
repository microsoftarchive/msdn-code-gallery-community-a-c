#region

using System.ServiceModel;
using Autofac;
using Autofac.Integration.Mvc;
using BTL.Services.AppAuthentication.Contract;
using BTL.Services.AppSecurity.Contract;

#endregion

namespace BTL.Application.Facade
{
    public class FacadeModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            // http://stackoverflow.com/questions/5726220/wcf-contract-mismatch-error-using-autofac-to-register-endpoint-via-channelfactor
            builder.Register(c => new ChannelFactory<IAppSecurityService>("AppSecurityService")).SingleInstance().CacheInSession();
            builder.Register(c => c.Resolve<ChannelFactory<IAppSecurityService>>().CreateChannel()).InstancePerHttpRequest().CacheInSession();

            builder.Register(c => new ChannelFactory<IAppAuthenticationService>("AppAuthenticationService")).SingleInstance();
            builder.Register(c => c.Resolve<ChannelFactory<IAppAuthenticationService>>().CreateChannel()).InstancePerHttpRequest();
        }
    }
}