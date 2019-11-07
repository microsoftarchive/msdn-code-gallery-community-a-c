#region

using Autofac;
using BTL.DataAccess;
using BTL.Infrastructure.Autofac;
using BTL.Infrastructure.Configuration;
using BTL.Infrastructure.Extensions;

#endregion

namespace BTL.Services.AppSecurity.Service
{
    public class AppSecurityServiceHostFactory : ExAutofacServiceHostFactory
    {
        private static readonly IExConfigurationManager ConfigurationManager = new ExConfigurationManager();

        public AppSecurityServiceHostFactory()
            : base(builder =>
                       {
                           builder.RegisterModule(new AppSecurityModule());
                           builder.RegisterModule(new DataAccessModule());

                           new SchemaSynchronizer(
                               () => ConfigurationManager.GetAppConfigBy("IsCreatedNewDb").ConvertToBool())
                               .Execute();

                           AutoMapperConfiguration.Configure();
                       })
        {
        }
    }
}