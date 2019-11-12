using System.Security.Claims;
using System.ServiceModel;
using System.Text;

namespace ClaimsAwareWebService
{
    /* For illustrative purposes this sample application simply shows all the parameters of 
      * claims (i.e. claim types and claim values), which are issued by a security token 
      * service (STS), in its console window. In production code, security implications of echoing 
      * the properties of claims should be carefully considered. For example, 
      * some of the security considerations are: (i) accepting the only claim types that are 
      * expected by relying party applications; (ii) sanitizing the claim parameters before 
      * using them; and (iii) filtering out claims that contain sensitive personal information). 
      * DO NOT use this sample code ‘as is’ in production code.
     */
    public class ClaimsAwareWebService : IClaimsAwareWebService
    {
        public string ComputeResponse(string input)
        {
            // Get the caller's identity from ClaimsPrincipal.Current
                        
            ClaimsPrincipal claimsPrincipal = OperationContext.Current.ClaimsPrincipal;
           
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("Computed by ClaimsAwareWebService");
            builder.AppendLine("Input received from client:" + input);

            if (claimsPrincipal != null)
            {
     
                ClaimsIdentity identity = claimsPrincipal.Identity as ClaimsIdentity;
                builder.AppendLine("Client Name:" +  identity.Name);
                builder.AppendLine("IsAuthenticated:" + identity.IsAuthenticated);
                builder.AppendLine("The service received the following issued claims of the client:");

                foreach (Claim claim in claimsPrincipal.Claims)
                {
                    builder.AppendLine("ClaimType :" + claim.Type + "   ClaimValue:" + claim.Value);
                }
            }

            return builder.ToString();
        }
    }
}
