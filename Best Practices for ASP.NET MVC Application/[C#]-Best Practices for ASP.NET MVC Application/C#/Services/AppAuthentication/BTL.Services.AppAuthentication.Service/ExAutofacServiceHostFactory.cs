#region

using Autofac;
using BTL.Infrastructure.Autofac;

#endregion

namespace BTL.Services.AppAuthentication.Service
{
    public class AppAuthenticationServiceHostFactory : ExAutofacServiceHostFactory
    {
        public AppAuthenticationServiceHostFactory() 
            : base(builder =>
                {
                    builder.RegisterModule(new AppAuthenticationModule());

                    AutoMapperConfiguration.Configure();                                                  
                })
        {
        }
    }
}