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
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Xml;

namespace ClaimsAuthorizationLibrary
{
    /// <summary>
    /// Simple ClaimsAuthorizationManager implementation that reads policy information from the .config file
    /// </summary>
    public class MyClaimsAuthorizationManager : ClaimsAuthorizationManager
    {
        static Dictionary<ResourceAction, Func<ClaimsPrincipal, bool>> _policies = new Dictionary<ResourceAction, Func<ClaimsPrincipal, bool>>();
        PolicyReader _policyReader = new PolicyReader();

        /// <summary>
        /// Creates a new instance of the MyClaimsAuthorizationManager
        /// </summary>        
        public MyClaimsAuthorizationManager()
        {
        }

        /// <summary>
        /// Overloads  the base class method to load the custom policies from the config file
        /// </summary>
        /// <param name="nodelist">XmlNodeList containing the policy information read from the config file</param>
        public override void LoadCustomConfiguration(XmlNodeList nodelist)
        {
            Expression<Func<ClaimsPrincipal, bool>> policyExpression;

            foreach (XmlNode node in nodelist)
            {
                //
                // Initialize the policy cache
                //
                XmlDictionaryReader rdr = XmlDictionaryReader.CreateDictionaryReader(new XmlTextReader(new StringReader(node.OuterXml)));
                rdr.MoveToContent();

                string resource = rdr.GetAttribute("resource");
                string action = rdr.GetAttribute("action");

                policyExpression = _policyReader.ReadPolicy(rdr);

                //
                // Compile the policy expression into a function
                //
                Func<ClaimsPrincipal, bool> policy = policyExpression.Compile();

                //
                // Insert the policy function into the policy cache
                //
                _policies[new ResourceAction(resource, action)] = policy;
            }
        }

        /// <summary>
        /// Checks if the principal specified in the authorization context is authorized to perform action specified in the authorization context 
        /// on the specified resoure
        /// </summary>
        /// <param name="pec">Authorization context</param>
        /// <returns>true if authorized, false otherwise</returns>
        public override bool CheckAccess(AuthorizationContext pec)
        {
            //
            // Evaluate the policy against the claims of the 
            // principal to determine access
            //
            bool access = false;
            try
            {
                ResourceAction ra = new ResourceAction(pec.Resource.First<Claim>().Value, pec.Action.First<Claim>().Value);

                access = _policies[ra](pec.Principal);
            }
            catch (Exception)
            {
                access = false;
            }

            return access;
        }
    }
}
