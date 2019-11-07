//----------------------------------------------------------------------------------------------
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//----------------------------------------------------------------------------------------------

using System;
using System.IdentityModel;
using System.IdentityModel.Configuration;
using System.IdentityModel.Protocols.WSTrust;
using System.Security.Claims;

namespace LocalSTS
{
    /// <summary>
    /// Defines the custom STS implementation for LocalSTS.
    /// </summary>
    internal class CustomSecurityTokenService : SecurityTokenService
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="configuration"></param>
        public CustomSecurityTokenService(SecurityTokenServiceConfiguration configuration)
            : base(configuration)
        {
        }

        /// <summary>
        /// Gets the scope.
        /// </summary>
        /// <param name="principal"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        protected override Scope GetScope(ClaimsPrincipal principal, RequestSecurityToken request)
        {
            Scope scope = new Scope(request.AppliesTo.Uri.AbsoluteUri, SecurityTokenServiceConfiguration.SigningCredentials);

            /* ********** WARNING **********
             * Do not use this code as is.
             * The following lines of code disable encryption of tokens and symmetric keys 
             * to ease running of these samples by lessening the use of certificates.
             * This should not be done in production code. 
             * 
             * Disabling token encryption so that WS-Fed RPs do not need to worry about service certificate.
             * Token encryption should NOT be disabled in production code. Doing so exposes the contents of the token
             * to clients and may be intercepted by man in the middle attacks observing the wire. This has the impact
             * of potential exposure of PII.
             * 
             * Symmetric key encryption should not be disabled in production code as it prevents a mitigation of 
             * forwarding attacks in act as delegation scenarios.
             * ***************************** */
            scope.TokenEncryptionRequired = false;
            scope.SymmetricKeyEncryptionRequired = false;

            // Set the ReplyTo address for the WS-Federation passive protocol (wreply). This is the address to which responses will be directed. 
            if (request.ReplyTo != null)
            {
                // A valid ReplyTo address was provided. We use it to send the response.
                scope.ReplyToAddress = request.ReplyTo.ToString();
            }
            else
            {
                // If the ReplyTo address is not provided we set this to the Default.aspx page on the Relying Party. 
                // Note that this is not used in the WS-Trust active case.
                scope.ReplyToAddress = scope.AppliesToAddress;
            }

            return scope;
        }

        protected override ClaimsIdentity GetOutputClaimsIdentity(ClaimsPrincipal principal, RequestSecurityToken request, Scope scope)
        {
            ClaimsIdentity outputIdentity = new ClaimsIdentity();

            if (null == principal)
            {
                throw new InvalidRequestException("The caller's principal is null.");
            }

            // Creates a new ClaimsIdentity with the authenticated user.
            outputIdentity.AddClaim(new Claim(ClaimTypes.Name, principal.Identity.Name, ClaimValueTypes.String));

            // Adds claims as necessary.
            if (principal.Identity.Name.Equals("mary@treyresearch.com", StringComparison.OrdinalIgnoreCase))
            {
                outputIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin", ClaimValueTypes.String));
            }
            else if (principal.Identity.Name.Equals("adam@treyresearch.com", StringComparison.OrdinalIgnoreCase))
            {
                outputIdentity.AddClaim(new Claim(ClaimTypes.Role, "Sales", ClaimValueTypes.String));
            }

            return outputIdentity;
        }
    }
}
