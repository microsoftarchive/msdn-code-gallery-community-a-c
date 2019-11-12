using System.ServiceModel;

namespace ClaimsAwareWebService
{
    [ServiceContract]
    public interface IClaimsAwareWebService
    {
        [OperationContract]
        string ComputeResponse(string input);
    }
}

