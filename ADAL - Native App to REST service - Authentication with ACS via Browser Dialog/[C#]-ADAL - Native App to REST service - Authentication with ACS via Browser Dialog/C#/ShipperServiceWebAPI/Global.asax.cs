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
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Configuration;
using System.IdentityModel.Metadata;
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Xml;
using ShipperService.App_Start;

namespace ShipperService
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);

            BundleConfig.RegisterBundles(BundleTable.Bundles);
            Configure(GlobalConfiguration.Configuration);
        }

        static void Configure(HttpConfiguration config)
        {
            config.MessageHandlers.Add(new TokenValidationHandler());
        }
    }

    internal class TokenValidationHandler : DelegatingHandler
    {
        static string _issuer = null;
        static DateTime _stsMetadataRetrievalTime = DateTime.MinValue;
        static List<X509SecurityToken> _signingTokens = null;

        // This function retrieves ACS token (in format of OAuth 2.0 Bearer Token type) from 
        // the Authorization header in the incoming HTTP request from the ShipperClient.
        static bool TryRetrieveToken(HttpRequestMessage request, out string token)
        {
            token = null;
            IEnumerable<string> authzHeaders;

            if ((!request.Headers.TryGetValues("Authorization", out authzHeaders) || authzHeaders.Count() > 1))
            {
                // Fail if no Authorization header or more than one Authorization headers 
                // are found in the HTTP request 
                return false;
            }

            // Remove the bearer token scheme prefix and return the rest as ACS token 
            var bearerToken = authzHeaders.ElementAt(0);
            token = bearerToken.StartsWith("Bearer ") ? bearerToken.Substring(7) : bearerToken;
            return true;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                                                               CancellationToken cancellationToken)
        {
            string issuer;
            string token;
            string metadataAddress = ConfigurationManager.AppSettings["Tenant"] +
                                     @"FederationMetadata\2007-06\FederationMetadata.xml";

            List<X509SecurityToken> signingTokens;           

            if (!TryRetrieveToken(request, out token))
            {
                return
                    Task<HttpResponseMessage>.Factory.StartNew(
                        () => new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }

            try
            {
                GetTenantInformation(metadataAddress, out issuer, out signingTokens);
            }
            catch (Exception)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError));
            }

            try
            {
                // Use JwtSecurityTokenHandler to validate the JWT token
                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler()
                    {
                        // turning off certificate validation for demo purposes. Please note that this shouldn't be done in production code.
                        CertificateValidator = X509CertificateValidator.None
                    };

                // Set the expected properties of the JWT token in the TokenValidationParameters
                TokenValidationParameters validationParameters = new TokenValidationParameters()
                    {
                        AllowedAudience = ConfigurationManager.AppSettings["AllowedAudience"],
                        ValidIssuer = issuer,
                        SigningTokens = signingTokens
                    };

                Thread.CurrentPrincipal = tokenHandler.ValidateToken(token, validationParameters);

                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = Thread.CurrentPrincipal;
                }

                return base.SendAsync(request, cancellationToken);
            }
            catch (SecurityTokenValidationException)
            {
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            catch (Exception)
            {
                return Task.FromResult((new HttpResponseMessage(HttpStatusCode.InternalServerError)));
            }
        }

        /// <summary>
        /// Parses the federation metadata document and gets issuer Name and Signing Certificates
        /// </summary>
        /// <param name="metadataAddress">URL of the Federation Metadata document</param>
        /// <param name="issuer">Issuer Name</param>
        /// <param name="signingTokens">Signing Certificates in the form of X509SecurityToken</param>
        static void GetTenantInformation(string metadataAddress, out string issuer,
                                                 out List<X509SecurityToken> signingTokens)
        {
            signingTokens = new List<X509SecurityToken>();

            // The issuer and signingTokens are cached for 24 hours. They are updated if any of the conditions in the if condition is true.            
            if (DateTime.UtcNow.Subtract(_stsMetadataRetrievalTime).TotalHours > 24
                || string.IsNullOrEmpty(_issuer)
                || _signingTokens == null)
            {
                MetadataSerializer serializer = new MetadataSerializer()
                    {
                        // turning off certificate validation for demo. Don't use this in production code.
                        CertificateValidationMode = X509CertificateValidationMode.None
                    };
                MetadataBase metadata = serializer.ReadMetadata(XmlReader.Create(metadataAddress));

                EntityDescriptor entityDescriptor = (EntityDescriptor)metadata;

                // get the issuer name.
                if (!string.IsNullOrWhiteSpace(entityDescriptor.EntityId.Id))
                {
                    _issuer = entityDescriptor.EntityId.Id;
                }

                // get the signing certs.
                _signingTokens = ReadSigningCertsFromMetadata(entityDescriptor);

                _stsMetadataRetrievalTime = DateTime.UtcNow;
            }

            issuer = _issuer;
            signingTokens = _signingTokens;
        }

        static List<X509SecurityToken> ReadSigningCertsFromMetadata(EntityDescriptor entityDescriptor)
        {
            List<X509SecurityToken> stsSigningTokens = new List<X509SecurityToken>();

            SecurityTokenServiceDescriptor stsd = entityDescriptor.RoleDescriptors.OfType<SecurityTokenServiceDescriptor>().First();

            if (stsd != null)
            {
                // read non-null X509Data keyInfo elements meant for Signing
                IEnumerable<X509RawDataKeyIdentifierClause> x509DataClauses = stsd.Keys.Where(key => key.KeyInfo != null && (key.Use == KeyType.Signing || key.Use == KeyType.Unspecified)).
                                                            Select(key => key.KeyInfo.OfType<X509RawDataKeyIdentifierClause>().First());

                stsSigningTokens.AddRange(x509DataClauses.Select(token => new X509SecurityToken(new X509Certificate2(token.GetX509RawData()))));
            }
            else
            {
                throw new InvalidOperationException("There is no RoleDescriptor of type SecurityTokenServiceType in the metadata");
            }

            return stsSigningTokens;
        }
    }
}