#region

using System.ServiceModel;

#endregion

namespace BTL.Services.AppAuthentication.Contract
{
    [ServiceContract(Namespace = "http://www.btlvn.com/AppAuthenticationService")]
    public interface IAppAuthenticationService
    {
        [OperationContract(Name = "TestMethod")]
        void TestMethod();
    }
}