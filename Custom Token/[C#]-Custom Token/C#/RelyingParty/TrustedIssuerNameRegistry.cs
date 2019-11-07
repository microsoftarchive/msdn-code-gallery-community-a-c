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
using System.IdentityModel.Tokens;

namespace RelyingParty
{
    public class TrustedIssuerNameRegistry : IssuerNameRegistry
    {
        /// <summary>
        ///  Returns the issuer Name from the security token.
        /// </summary>
        /// <param name="securityToken">The security token that contains the STS's certificates.</param>
        /// <returns>The name of the issuer who signed the security token.</returns>
        public override string GetIssuerName(SecurityToken securityToken)
        {
            SimpleWebToken.SimpleWebToken webToken = securityToken as SimpleWebToken.SimpleWebToken;
            if (webToken != null)
            {
                //Note: This piece of code is for illustrative purposes only. Validating certificates based on 
                //subject name is not a good practice.  This code should not be used as is in production.
                if (String.Compare(webToken.Issuer, "PassiveSTS") == 0)
                {
                    return webToken.Issuer;
                }
            }

            throw new SecurityTokenException("Untrusted issuer.");
        }
    }
}