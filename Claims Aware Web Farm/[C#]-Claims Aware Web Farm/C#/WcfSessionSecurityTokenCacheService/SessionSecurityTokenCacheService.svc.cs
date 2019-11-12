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
using System.IdentityModel.Configuration;
using System.IdentityModel.Tokens;
using System.ServiceModel;
using System.Xml;

namespace WcfSessionSecurityTokenCacheService
{
    /// <summary>
    /// This WCF service exposes a SessionSecurityTokenCache interface that can be accessed by multple relying parties.  
    /// The WIF default, in-memory MruSessionSecurityTokenCache is used as the internal cache.
    /// Alternatively, this can be implemented as a durable cache backed by a database which would withstand recycles.
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class SessionSecurityTokenCacheService : ISessionSecurityTokenCacheService
    {
        SessionSecurityTokenCache internalCache;

        public SessionSecurityTokenCacheService()
        {
            internalCache = new IdentityModelCaches().SessionSecurityTokenCache;
        }

        public void AddOrUpdate(string endpointId, string contextId, string keyGeneration, SessionSecurityToken value, DateTime expiryTime)
        {
            internalCache.AddOrUpdate(
                new SessionSecurityTokenCacheKey(endpointId, GetContextId(contextId), GetKeyGeneration(keyGeneration)),
                value,
                expiryTime);
        }

        public IEnumerable<SessionSecurityToken> GetAll(string endpointId, string contextId)
        {
            // Delegates to the default, in-memory MruSessionSecurityTokenCache employed by WIF
            return internalCache.GetAll(endpointId, GetContextId(contextId));
        }

        public SessionSecurityToken Get(string endpointId, string contextId, string keyGeneration)
        {
            SessionSecurityToken token = internalCache.Get(new SessionSecurityTokenCacheKey(endpointId, GetContextId(contextId), GetKeyGeneration(keyGeneration)));
            return token;
        }

        public void RemoveAll(string endpointId, string contextId)
        {
            internalCache.RemoveAll(endpointId, GetContextId(contextId));
        }

        public void RemoveAll(string endpointId)
        {
            internalCache.RemoveAll(endpointId);
        }

        public void Remove(string endpointId, string contextId, string keyGeneration)
        {
            internalCache.Remove(new SessionSecurityTokenCacheKey(endpointId, GetContextId(contextId), GetKeyGeneration(keyGeneration)));
        }

        private static UniqueId GetContextId(string contextIdString)
        {
            return contextIdString == null ? null : new UniqueId(contextIdString);
        }

        private static UniqueId GetKeyGeneration(string keyGenerationString)
        {
            return keyGenerationString == null ? null : new UniqueId(keyGenerationString);
        }
    }
}
