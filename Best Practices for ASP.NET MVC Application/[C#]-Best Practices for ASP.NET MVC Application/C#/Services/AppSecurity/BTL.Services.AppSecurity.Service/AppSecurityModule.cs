#region

using Autofac;
using BTL.Services.AppSecurity.Contract;
using BTL.Services.AppSecurity.Service.Contexts;
using BTL.Services.AppSecurity.Service.Contexts.Roles;

#endregion

namespace BTL.Services.AppSecurity.Service
{
    public class AppSecurityModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<AppSecurityService>().SingleInstance();
            //builder.RegisterType<AppSecurityManager>().As<IAppSecurityManager>();
            builder.RegisterType<AppSecurityManagerStub>().As<IAppSecurityManager>();
        }
    }
}