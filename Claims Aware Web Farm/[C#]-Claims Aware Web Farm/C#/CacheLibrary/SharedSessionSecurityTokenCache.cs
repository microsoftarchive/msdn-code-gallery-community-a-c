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
using System.Configuration;
using System.IdentityModel.Configuration;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.Xml;

namespace CacheLibrary
{
    /// <summary>
    /// This class acts as a proxy to the WcfSessionSecurityTokenCacheService.
    /// </summary>
    public class SharedSessionSecurityTokenCache : SessionSecurityTokenCache, ICustomIdentityConfiguration
    {
        private ISessionSecurityTokenCacheService WcfSessionSecurityTokenCacheServiceClient;

        internal SharedSessionSecurityTokenCache()
        {
        }

        /// <summary>
        /// Creates a client channel to call the service host.
        /// </summary>
        protected void Initialize(string cacheServiceAddress)
        {
            if (this.WcfSessionSecurityTokenCacheServiceClient != null)
            {
                return;
            }

            ChannelFactory<ISessionSecurityTokenCacheService> cf = new ChannelFactory<ISessionSecurityTokenCacheService>(
                new WS2007HttpBinding(SecurityMode.None),
                new EndpointAddress(cacheServiceAddress));
            this.WcfSessionSecurityTokenCacheServiceClient = cf.CreateChannel();
        }

        #region SessionSecurityTokenCache Members
        // Delegates the following operations to the centralized session security token cache service in the web farm.

        public override void AddOrUpdate(SessionSecurityTokenCacheKey key, SessionSecurityToken value, DateTime expiryTime)
        {
            this.WcfSessionSecurityTokenCacheServiceClient.AddOrUpdate(key.EndpointId, GetContextIdString(key), GetKeyGenerationString(key), value, expiryTime);
        }

        public override System.Collections.Generic.IEnumerable<SessionSecurityToken> GetAll(string endpointId, UniqueId contextId)
        {
            return this.WcfSessionSecurityTokenCacheServiceClient.GetAll(endpointId, GetContextIdString(contextId));
        }

        public override SessionSecurityToken Get(SessionSecurityTokenCacheKey key)
        {
            return this.WcfSessionSecurityTokenCacheServiceClient.Get(key.EndpointId, GetContextIdString(key), GetKeyGenerationString(key));
        }

        public override void RemoveAll(string endpointId, UniqueId contextId)
        {
            this.WcfSessionSecurityTokenCacheServiceClient.RemoveAll(endpointId, GetContextIdString(contextId));
        }

        public override void RemoveAll(string endpointId)
        {
            this.WcfSessionSecurityTokenCacheServiceClient.RemoveAll(endpointId);
        }

        public override void Remove(SessionSecurityTokenCacheKey key)
        {
            this.WcfSessionSecurityTokenCacheServiceClient.Remove(key.EndpointId, GetContextIdString(key), GetKeyGenerationString(key));
        }
        #endregion

        #region ICustomIdentityConfiguration Members
        public void LoadCustomConfiguration(XmlNodeList nodeList)
        {
            // Retrieve the endpoint address of the centralized session security token cache service running in the web farm
            if (nodeList.Count == 0)
            {
                throw new ConfigurationException("No child config element found under <sessionSecurityTokenCache>.");
            }

            XmlElement cacheServiceAddressElement = nodeList.Item(0) as XmlElement;
            if (cacheServiceAddressElement.LocalName != "cacheServiceAddress")
            {
                throw new ConfigurationException("First child config element under <sessionSecurityTokenCache> is expected to be <cacheServiceAddress>.");
            }

            string cacheServiceAddress = null;
            if (cacheServiceAddressElement.Attributes["url"] != null)
            {
                cacheServiceAddress = cacheServiceAddressElement.Attributes["url"].Value;
            }
            else
            {
                throw new ConfigurationException("<cacheServiceAddress> is expected to contain a 'url' attribute.");
            }

            // Initialize the proxy to the WebFarmSessionSecurityTokenCacheService
            this.Initialize(cacheServiceAddress);
        }
        #endregion

        private static string GetKeyGenerationString(SessionSecurityTokenCacheKey key)
        {
            return key.KeyGeneration == null ? null : key.KeyGeneration.ToString();
        }

        private static string GetContextIdString(SessionSecurityTokenCacheKey key)
        {
            return GetContextIdString(key.ContextId);
        }

        private static string GetContextIdString(UniqueId contextId)
        {
            return contextId == null ? null : contextId.ToString();
        }
    }
}
