using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.ActiveDirectory.GraphClient;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace Office365Licensing
{
    class AuthenticationHelper
    {
        //public static string TokenForUser;

        /// <summary>
        /// Async task to acquire token for Application.
        /// </summary>
        /// <returns>Async Token for application.</returns>
        public static async Task<string> AcquireTokenAsyncForApplication(string clientID, string clientSecret, string tenantName)
        {
            return GetTokenForApplication(clientID,clientSecret,tenantName);
        }

        /// <summary>
        /// Get Token for Application.
        /// </summary>
        /// <returns>Token for application.</returns>
        public static string GetTokenForApplication(string clientID, string clientSecret, string tenantName)
        {
            AuthenticationContext authenticationContext = new AuthenticationContext(Constants.AuthString + tenantName, false);
            // Config for OAuth client credentials 
            ClientCredential clientCred = new ClientCredential(clientID, clientSecret);
            AuthenticationResult authenticationResult = authenticationContext.AcquireToken(Constants.ResourceUrl,
                clientCred);
            string token = authenticationResult.AccessToken;
            return token;
        }

        /// <summary>
        /// Get Active Directory Client for Application.
        /// </summary>
        /// <returns>ActiveDirectoryClient for Application.</returns>
        public static ActiveDirectoryClient GetActiveDirectoryClientAsApplication(string tenantID, string clientID, string clientSecret, string tenantName)
        {
            Uri servicePointUri = new Uri(Constants.ResourceUrl);
            Uri serviceRoot = new Uri(servicePointUri, tenantID);
            ActiveDirectoryClient activeDirectoryClient = new ActiveDirectoryClient(serviceRoot,
                async () => await AcquireTokenAsyncForApplication(clientID,clientSecret,tenantName));
            return activeDirectoryClient;
        }

        
    }
}
