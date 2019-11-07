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

using SimpleWebToken;
using System.IdentityModel.Configuration;
using System.Web;

namespace PassiveSTS
{
    /// <summary>
    /// Extends the Microsoft.IdentityModel.Services.SecurityTokenServiceConfiguration class to 
    /// be consumed by the CustomSecurityTokenService.
    /// </summary>
    public class CustomSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        static readonly object syncRoot = new object();
        static string CustomSecurityTokenServiceConfigurationKey = "CustomSecurityTokenServiceConfigurationKey";
        static string Base64SymmetricKey = "wAVkldQiFypTQ+kdNdGWCYCHRcee8XmXxOvgmak8vSY=";

        public static CustomSecurityTokenServiceConfiguration Current
        {
            get
            {
                HttpApplicationState httpAppState = HttpContext.Current.Application;

                CustomSecurityTokenServiceConfiguration myConfiguration = httpAppState.Get( CustomSecurityTokenServiceConfigurationKey ) as CustomSecurityTokenServiceConfiguration;

                if ( myConfiguration != null )
                {
                    return myConfiguration;
                }

                lock ( syncRoot )
                {
                    myConfiguration = httpAppState.Get( CustomSecurityTokenServiceConfigurationKey ) as CustomSecurityTokenServiceConfiguration;

                    if ( myConfiguration == null )
                    {
                        myConfiguration = new CustomSecurityTokenServiceConfiguration();
                        httpAppState.Add( CustomSecurityTokenServiceConfigurationKey, myConfiguration );
                    }

                    return myConfiguration;
                }
            }
        }

        public CustomSecurityTokenServiceConfiguration()
            : base( "PassiveSTS" )
        {
            this.SecurityTokenService = typeof( PassiveSTS.CustomSecurityTokenService );
            SimpleWebTokenHandler tokenHandler = new SimpleWebTokenHandler();
            this.SecurityTokenHandlers.Add(tokenHandler);
            
            CustomIssuerTokenResolver  customTokenResolver =  new SimpleWebToken.CustomIssuerTokenResolver();
            customTokenResolver.AddAudienceKeyPair("http://localhost:19851/", Base64SymmetricKey);
            this.IssuerTokenResolver = customTokenResolver;

            this.DefaultTokenType = SimpleWebTokenHandler.SimpleWebTokenTypeUri;
        }
    }
}
