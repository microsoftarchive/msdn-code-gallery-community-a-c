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
using System.IdentityModel.Configuration;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;

namespace LocalSTS
{
    /// <summary>
    /// A custom SecurityTokenServiceConfiguration implementation.
    /// </summary>
    public class CustomSecurityTokenServiceConfiguration : SecurityTokenServiceConfiguration
    {
        internal static X509Certificate2 Certificate = new X509Certificate2(AppDomain.CurrentDomain.BaseDirectory + @"LocalSTS\ls\LocalSTS.pfx", "LocalSTS", X509KeyStorageFlags.PersistKeySet);
        /// <summary>
        /// CustomSecurityTokenServiceConfiguration constructor.
        /// </summary>
        public CustomSecurityTokenServiceConfiguration()
        {
            this.SecurityTokenService = typeof(CustomSecurityTokenService);
            this.TokenIssuerName = "LocalSTS";
            this.SigningCredentials = new X509SigningCredentials(CustomSecurityTokenServiceConfiguration.Certificate);
            this.ServiceCertificate = CustomSecurityTokenServiceConfiguration.Certificate;
        }
    }
}
