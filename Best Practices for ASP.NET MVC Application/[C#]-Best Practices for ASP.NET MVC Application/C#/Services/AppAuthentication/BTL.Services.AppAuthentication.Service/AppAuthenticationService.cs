#region

using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using BTL.Services.AppAuthentication.Contract;

#endregion

namespace BTL.Services.AppAuthentication.Service
{
#if DEBUG
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, ConcurrencyMode = ConcurrencyMode.Multiple,
        InstanceContextMode = InstanceContextMode.PerSession)]
#else             
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.PerSession)]
#endif
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class AppAuthenticationService : IAppAuthenticationService
    {
        public void TestMethod()
        {
            throw new NotImplementedException();
        }
    }
}