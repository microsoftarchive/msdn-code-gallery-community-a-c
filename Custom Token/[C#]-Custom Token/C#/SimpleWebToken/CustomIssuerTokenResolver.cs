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

using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.IO;
using System.Text;
using System.Xml;

namespace SimpleWebToken
{
    public class CustomIssuerTokenResolver : IssuerTokenResolver
    {
        private Dictionary<string, string> _keys;

        public CustomIssuerTokenResolver()
        {
            _keys = new Dictionary<string, string>();            
        }

        public void AddAudienceKeyPair(string audience, string symmetricKey)
        {
            _keys.Add(audience, symmetricKey);
        }

        public override void LoadCustomConfiguration(System.Xml.XmlNodeList nodelist)
        {
            foreach (XmlNode node in nodelist)
            {
                XmlDictionaryReader rdr = XmlDictionaryReader.CreateDictionaryReader(new XmlTextReader(new StringReader(node.OuterXml)));
                rdr.MoveToContent();

                string symmetricKey = rdr.GetAttribute("symmetricKey");
                string audience = rdr.GetAttribute("audience");
                
                this.AddAudienceKeyPair(audience, symmetricKey);
            }
        }

        protected override bool TryResolveSecurityKeyCore(SecurityKeyIdentifierClause keyIdentifierClause, out SecurityKey key)
        {
            key = null;
            SimpleWebTokenKeyIdentifierClause keyClause = keyIdentifierClause as SimpleWebTokenKeyIdentifierClause;
            if (keyClause != null)
            {
                string base64Key = null;
                _keys.TryGetValue(keyClause.Audience, out base64Key);
                if (!string.IsNullOrEmpty(base64Key))
                {
                    key = new InMemorySymmetricSecurityKey(Encoding.UTF8.GetBytes(base64Key));
                    return true;
                }
            }

            return false;
        }

    }
}
