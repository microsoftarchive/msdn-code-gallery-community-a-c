// Copyright © Microsoft Corporation.  All Rights Reserved.
// This code released under the terms of the 
// Microsoft Public License (MS-PL, http://opensource.org/licenses/ms-pl.html.)
// Author: Girish Raja - http://blogs.msdn.com/girishr

using System;
using System.IO;
using System.Net;
using Microsoft.Crm.Sdk.Samples;
using System.Xml;

namespace CRMOnlineSOAPRequests
{
    class Program
    {
        // USE AT YOUR OWN RISK. 
        // PLEASE BE AWARE THAT ANY INFORMATION YOU MAY FIND HERE MAY BE INACCURATE, MISLEADING, DANGEROUS, ADDICTIVE, UNETHICAL OR ILLEGAL (as-is from Wikipedia!)

        // This example retrives data from CRM Online using pure SOAP calls only and no additional assemblies to illustrate the underlying SOAP interactions.
        // It is useful if you're planning to interact with CRM Online web services from a non-.NET environment.
        // The soap messages were based on Fiddler (http://www.fiddler2.com/) traffic capture of sample code from the CRM 2011 SDK (http://msdn.microsoft.com/en-us/library/gg309408.aspx).

        // This may look like a lot of code because it's completely done using raw SOAP calls and no C# wrappers or proxies. 
        // For optimal source code, please use the .NET assemblies that ship with CRM SDK or a wrapper around these methods in the programming language of your choice.

        static void Main(string[] args)
        {

            string Username = "mywlid@hotmail.com";
            string Password = "yesthisismypassword";
            string CRMUrl = "https://yourcrmorganization.api.crm.dynamics.com/XRMServices/2011/Organization.svc";

            // Change this to an account record guid from your CRM Online system to test Step #2 
            // This can usually be found by opening an account record in the browser and looking at the URL's query string 
            // Tip: David Cabaniuk has written a nice & simple post that shows you how to find a sample account ID: http://www.crmcodex.com/2012/01/tip-get-record-id-quickly-and-easily/
            string accountId = "05C92E5C-1B29-E011-8691-1CC1DEF177C2";
            
            #region Step 0: Get URN address and STS Enpoint dynamically from WSDL

            string WSDL = GetMethod(CRMUrl + "?wsdl");
            string WSDLImportURL = GetValueFromXML(WSDL, @"//*[local-name()='import' and namespace-uri()='http://schemas.xmlsoap.org/wsdl/']/@location");
            string WSDKImport = GetMethod(WSDLImportURL);
            string URNAddress = GetValueFromXML(WSDKImport, @"//*[local-name()='AuthenticationPolicy' and namespace-uri()='http://schemas.microsoft.com/xrm/2011/Contracts/Services']/*[local-name()='SecureTokenService' and namespace-uri()='http://schemas.microsoft.com/xrm/2011/Contracts/Services']//*[local-name()='AppliesTo' and namespace-uri()='http://schemas.microsoft.com/xrm/2011/Contracts/Services']/text()");
            string STSEnpoint = GetValueFromXML(WSDKImport, @"//*[local-name()='Issuer' and namespace-uri()='http://docs.oasis-open.org/ws-sx/ws-securitypolicy/200702']/*[local-name()='Address' and namespace-uri()='http://www.w3.org/2005/08/addressing']/text()");

            #endregion

            #region Step 1: Determine which authentication method (LiveID or OCP) and authenticate to get tokens and key.
            string keyIdentifier = null;
            string securityToken0 = null;
            string securityToken1 = null;
            if ((STSEnpoint != null) && (STSEnpoint.StartsWith("https://login.live.com")))
            {
                #region WLID Authenciation
                #region Step A: Get Windows Live Device Credentials

                // Please note that this step uses a modified version of DeviceIdManager class from the one that ships with the SDK. 
                // The modifications have been made to remove any writes to local disk which unfortunately removes the caching of device id as well. 

                // Generates random credentials (Username, Password & Application ID) for the device 
                // Sends the credentials to WLID and gets a PUID back
                DeviceIdManager.DeviceCredentials deviceCredentials = DeviceIdManager.RegisterDevice();

                #endregion

                #region Step B: Register Device Credentials and get binaryDAToken
                string deviceCredentialsSoapTemplate = @"<s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope""
                xmlns:a=""http://www.w3.org/2005/08/addressing""
                xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">

                    <s:Header>
                    <a:Action s:mustUnderstand=""1"">
                    http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</a:Action>
                    <a:MessageID>
                    urn:uuid:{4:MessageID}</a:MessageID>
                    <a:ReplyTo>
                        <a:Address>
                        http://www.w3.org/2005/08/addressing/anonymous</a:Address>
                    </a:ReplyTo>
                    <VsDebuggerCausalityData xmlns=""http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink"">
                    uIDPoy9Ez+P/wJdOhoN2XNauvYcAAAAAK0Y6fOjvMEqbgs9ivCmFPaZlxcAnCJ1GiX+Rpi09nSYACQAA</VsDebuggerCausalityData>
                    <a:To s:mustUnderstand=""1"">
                    {4:STSEndpoint}</a:To>
                    <o:Security s:mustUnderstand=""1""
                    xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                        <u:Timestamp u:Id=""_0"">
                        <u:Created>{0:timeCreated}Z</u:Created>
                        <u:Expires>{1:timeExpires}Z</u:Expires>
                        </u:Timestamp>
                        <o:UsernameToken u:Id=""devicesoftware"">
                        <o:Username>{2:deviceUserName}</o:Username>
                        <o:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{3:devicePassword}</o:Password>
                        </o:UsernameToken>
                    </o:Security>
                    </s:Header>
                    <s:Body>
                    <t:RequestSecurityToken xmlns:t=""http://schemas.xmlsoap.org/ws/2005/02/trust"">
                        <wsp:AppliesTo xmlns:wsp=""http://schemas.xmlsoap.org/ws/2004/09/policy"">
                        <a:EndpointReference>
                            <a:Address>http://passport.net/tb</a:Address>
                        </a:EndpointReference>
                        </wsp:AppliesTo>
                        <t:RequestType>
                        http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</t:RequestType>
                    </t:RequestSecurityToken>
                    </s:Body>
                </s:Envelope>
                ";

                DateTime binaryDARequestCreatedTime = DateTime.Now.ToUniversalTime();
                string binaryDATokenXML = GetSOAPResponse(STSEnpoint, string.Format(deviceCredentialsSoapTemplate
                    , binaryDARequestCreatedTime.ToString("s") + "." + binaryDARequestCreatedTime.Millisecond
                    , binaryDARequestCreatedTime.AddMinutes(5.0).ToString("s") + "." + binaryDARequestCreatedTime.Millisecond
                    , "11" + deviceCredentials.DeviceName, deviceCredentials.Password, Guid.NewGuid().ToString(), STSEnpoint));
                string binaryDAToken = GetValueFromXML(binaryDATokenXML, @"//*[local-name()='CipherValue']/text()");

                #endregion

                #region Step C: Get Security Token by sending WLID username, password and device binaryDAToken

                string securityTokenSoapTemplate = @"
                <s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope""
                xmlns:a=""http://www.w3.org/2005/08/addressing""
                xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
                  <s:Header>
                    <a:Action s:mustUnderstand=""1"">
                    http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue</a:Action>
                    <a:MessageID>
                    urn:uuid:{5:MessageID}</a:MessageID>
                    <a:ReplyTo>
                      <a:Address>
                      http://www.w3.org/2005/08/addressing/anonymous</a:Address>
                    </a:ReplyTo>
                    <VsDebuggerCausalityData xmlns=""http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink"">
                    uIDPozBEz+P/wJdOhoN2XNauvYcAAAAAK0Y6fOjvMEqbgs9ivCmFPaZlxcAnCJ1GiX+Rpi09nSYACQAA</VsDebuggerCausalityData>
                    <a:To s:mustUnderstand=""1"">
                    {7:STSEndpoint}</a:To>
                    <o:Security s:mustUnderstand=""1""
                    xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                      <u:Timestamp u:Id=""_0"">
                        <u:Created>{0:timeCreated}Z</u:Created>
                        <u:Expires>{1:timeExpires}Z</u:Expires>
                      </u:Timestamp>
                      <o:UsernameToken u:Id=""user"">
                        <o:Username>{2:UserName}</o:Username>
                        <o:Password Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">
                        {3:Password}</o:Password>
                      </o:UsernameToken>
                      <wsse:BinarySecurityToken ValueType=""urn:liveid:device""
                      xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                        <EncryptedData Id=""BinaryDAToken0""
                        Type=""http://www.w3.org/2001/04/xmlenc#Element""
                        xmlns=""http://www.w3.org/2001/04/xmlenc#"">
                          <EncryptionMethod Algorithm=""http://www.w3.org/2001/04/xmlenc#tripledes-cbc"">
                          </EncryptionMethod>
                          <ds:KeyInfo xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"">
                            <ds:KeyName>http://Passport.NET/STS</ds:KeyName>
                          </ds:KeyInfo>
                          <CipherData>
                            <CipherValue>
                                {4:BinaryDAToken}
                            </CipherValue>
                          </CipherData>
                        </EncryptedData>
                      </wsse:BinarySecurityToken>
                    </o:Security>
                  </s:Header>
                  <s:Body>
                    <t:RequestSecurityToken xmlns:t=""http://schemas.xmlsoap.org/ws/2005/02/trust"">
                      <wsp:AppliesTo xmlns:wsp=""http://schemas.xmlsoap.org/ws/2004/09/policy"">
                        <a:EndpointReference>
                          <a:Address>{6:URNAddress}</a:Address>
                        </a:EndpointReference>
                      </wsp:AppliesTo>
                      <wsp:PolicyReference URI=""MBI_FED_SSL""
                      xmlns:wsp=""http://schemas.xmlsoap.org/ws/2004/09/policy"" />
                      <t:RequestType>
                      http://schemas.xmlsoap.org/ws/2005/02/trust/Issue</t:RequestType>
                    </t:RequestSecurityToken>
                  </s:Body>
                </s:Envelope>
                ";
                DateTime securityTokenRequestCreatedTime = DateTime.Now.ToUniversalTime();
                string securityTokenXML = GetSOAPResponse(STSEnpoint, string.Format(securityTokenSoapTemplate
                    , securityTokenRequestCreatedTime.ToString("s") + "." + securityTokenRequestCreatedTime.Millisecond
                    , securityTokenRequestCreatedTime.AddMinutes(5.0).ToString("s") + "." + securityTokenRequestCreatedTime.Millisecond
                    , Username, Password, binaryDAToken
                    , Guid.NewGuid().ToString(), URNAddress, STSEnpoint));
                securityToken0 = GetValueFromXML(securityTokenXML, @"//*[local-name()='CipherValue']/text()");
                securityToken1 = GetValueFromXML(securityTokenXML, @"//*[local-name()='CipherValue']/text()", 1);
                keyIdentifier = GetValueFromXML(securityTokenXML, @"//*[local-name()='KeyIdentifier']/text()");

                #endregion
                #endregion
            }
            else
            {
                #region OCP Authentication
                #region Step A: Get Security Token by sending OCP username, password

                string securityTokenSoapTemplate = @"
                <s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope""
	                xmlns:a=""http://www.w3.org/2005/08/addressing""
	                xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
	                <s:Header>
		                <a:Action s:mustUnderstand=""1"">http://schemas.xmlsoap.org/ws/2005/02/trust/RST/Issue
		                </a:Action>
		                <a:MessageID>urn:uuid:{4:MessageID}
		                </a:MessageID>
		                <a:ReplyTo>
			                <a:Address>http://www.w3.org/2005/08/addressing/anonymous</a:Address>
		                </a:ReplyTo>
		                <VsDebuggerCausalityData
			                xmlns=""http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink"">uIDPo4TBVw9fIMZFmc7ZFxBXIcYAAAAAbd1LF/fnfUOzaja8sGev0GKsBdINtR5Jt13WPsZ9dPgACQAA
		                </VsDebuggerCausalityData>
		                <a:To s:mustUnderstand=""1"">{6:STSEndpoint}
		                </a:To>
		                <o:Security s:mustUnderstand=""1""
			                xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
			                <u:Timestamp u:Id=""_0"">
				                <u:Created>{0:timeCreated}Z</u:Created>
				                <u:Expires>{1:timeExpires}Z</u:Expires>
			                </u:Timestamp>
			                <o:UsernameToken u:Id=""uuid-14bed392-2320-44ae-859d-fa4ec83df57a-1"">
				                <o:Username>{2:UserName}</o:Username>
				                <o:Password
					                Type=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText"">{3:Password}</o:Password>
			                </o:UsernameToken>
		                </o:Security>
	                </s:Header>
	                <s:Body>
		                <t:RequestSecurityToken xmlns:t=""http://schemas.xmlsoap.org/ws/2005/02/trust"">
			                <wsp:AppliesTo xmlns:wsp=""http://schemas.xmlsoap.org/ws/2004/09/policy"">
				                <a:EndpointReference>
					                <a:Address>{5:URNAddress}</a:Address>
				                </a:EndpointReference>
			                </wsp:AppliesTo>
			                <t:RequestType>http://schemas.xmlsoap.org/ws/2005/02/trust/Issue
			                </t:RequestType>
		                </t:RequestSecurityToken>
	                </s:Body>
                </s:Envelope>
                ";

                DateTime securityTokenRequestCreatedTime = DateTime.Now.ToUniversalTime();
                string securityTokenXML = GetSOAPResponse(STSEnpoint, string.Format(securityTokenSoapTemplate
                    , securityTokenRequestCreatedTime.ToString("s") + "." + securityTokenRequestCreatedTime.Millisecond
                    , securityTokenRequestCreatedTime.AddMinutes(5.0).ToString("s") + "." + securityTokenRequestCreatedTime.Millisecond
                    , Username, Password
                    , Guid.NewGuid().ToString(), URNAddress, STSEnpoint));
                securityToken0 = GetValueFromXML(securityTokenXML, @"//*[local-name()='CipherValue']/text()");
                securityToken1 = GetValueFromXML(securityTokenXML, @"//*[local-name()='CipherValue']/text()", 1);
                keyIdentifier = GetValueFromXML(securityTokenXML, @"//*[local-name()='KeyIdentifier']/text()");

                #endregion
                #endregion
            }
            #endregion

            #region Step 2: Get / Set CRM Data by sending FetchXML Query
            string crmSoapRequestHeader = @"
                <s:Envelope xmlns:s=""http://www.w3.org/2003/05/soap-envelope""
                xmlns:a=""http://www.w3.org/2005/08/addressing""
                xmlns:u=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd"">
                  <s:Header>
                    <a:Action s:mustUnderstand=""1"">
                    http://schemas.microsoft.com/xrm/2011/Contracts/Services/IOrganizationService/{7:Action}</a:Action>
                    <a:MessageID>
                    urn:uuid:{6:MessageID}</a:MessageID>
                    <a:ReplyTo>
                      <a:Address>
                      http://www.w3.org/2005/08/addressing/anonymous</a:Address>
                    </a:ReplyTo>
                    <VsDebuggerCausalityData xmlns=""http://schemas.microsoft.com/vstudio/diagnostics/servicemodelsink"">
                    uIDPozJEz+P/wJdOhoN2XNauvYcAAAAAK0Y6fOjvMEqbgs9ivCmFPaZlxcAnCJ1GiX+Rpi09nSYACQAA</VsDebuggerCausalityData>
                    <a:To s:mustUnderstand=""1"">
                    {2:CRMURL}</a:To>
                    <o:Security s:mustUnderstand=""1""
                    xmlns:o=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">
                      <u:Timestamp u:Id=""_0"">
                        <u:Created>{0:timeCreated}Z</u:Created>
                        <u:Expires>{1:timeExpires}Z</u:Expires>
                      </u:Timestamp>
                      <EncryptedData Id=""Assertion0""
                      Type=""http://www.w3.org/2001/04/xmlenc#Element""
                      xmlns=""http://www.w3.org/2001/04/xmlenc#"">
                        <EncryptionMethod Algorithm=""http://www.w3.org/2001/04/xmlenc#tripledes-cbc"">
                        </EncryptionMethod>
                        <ds:KeyInfo xmlns:ds=""http://www.w3.org/2000/09/xmldsig#"">
                          <EncryptedKey>
                            <EncryptionMethod Algorithm=""http://www.w3.org/2001/04/xmlenc#rsa-oaep-mgf1p"">
                            </EncryptionMethod>
                            <ds:KeyInfo Id=""keyinfo"">
                              <wsse:SecurityTokenReference xmlns:wsse=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd"">

                                <wsse:KeyIdentifier EncodingType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary""
                                ValueType=""http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-x509-token-profile-1.0#X509SubjectKeyIdentifier"">
                                {3:KeyIdentifier}</wsse:KeyIdentifier>
                              </wsse:SecurityTokenReference>
                            </ds:KeyInfo>
                            <CipherData>
                              <CipherValue>
                              {4:SecurityToken0}</CipherValue>
                            </CipherData>
                          </EncryptedKey>
                        </ds:KeyInfo>
                        <CipherData>
                          <CipherValue>
                          {5:SecurityToken1}</CipherValue>
                        </CipherData>
                      </EncryptedData>
                    </o:Security>
                  </s:Header>
                  ";
                  string retrieveRequestBodyTemplate= @"<s:Body>
                    <Retrieve xmlns=""http://schemas.microsoft.com/xrm/2011/Contracts/Services"">
                      <entityName>account</entityName>
                      <id>{8:AccountID}</id>
                      <columnSet xmlns:b=""http://schemas.microsoft.com/xrm/2011/Contracts""
                      xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
                        <b:AllColumns>false</b:AllColumns>
                        <b:Columns xmlns:c=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
                          <c:string>name</c:string>
                          <c:string>address1_postalcode</c:string>
                          <c:string>lastusedincampaign</c:string>
                        </b:Columns>
                      </columnSet>
                    </Retrieve>
                  </s:Body>
                </s:Envelope>
                ";

            string retrieveRequestSoapTemplate = crmSoapRequestHeader + retrieveRequestBodyTemplate;
            DateTime retrieveRequestCreatedTime = DateTime.Now.ToUniversalTime();
            string retrieveResponseXML = GetSOAPResponse(CRMUrl, string.Format(retrieveRequestSoapTemplate
                , retrieveRequestCreatedTime.ToString("s") + "." + retrieveRequestCreatedTime.Millisecond
                , retrieveRequestCreatedTime.AddMinutes(5.0).ToString("s") + "." + retrieveRequestCreatedTime.Millisecond
                , CRMUrl
                , keyIdentifier
                , securityToken0
                , securityToken1
                , Guid.NewGuid().ToString()
                , "Retrieve"
                , accountId
                ));
            string[,] namespaces = {
                                       {"b","http://schemas.microsoft.com/xrm/2011/Contracts"},
                                       {"c","http://schemas.datacontract.org/2004/07/System.Collections.Generic"}
                                   };
            string accountName = GetValueFromXML(retrieveResponseXML, @"//b:KeyValuePairOfstringanyType[c:key='name']/c:value/text()", 0, namespaces);
            string zipcode = GetValueFromXML(retrieveResponseXML, @"//b:KeyValuePairOfstringanyType[c:key='address1_postalcode']/c:value/text()", 0, namespaces);
            Console.WriteLine(accountName);
            Console.WriteLine(zipcode);

            #endregion

            #region Step 3: Retrieve Multiple records by sending FetchXML Query
            string retrieveMultipleRequestBodyTemplate = @"
              <s:Body>
                <RetrieveMultiple xmlns=""http://schemas.microsoft.com/xrm/2011/Contracts/Services"">
                  <query i:type=""b:QueryExpression""
                  xmlns:b=""http://schemas.microsoft.com/xrm/2011/Contracts""
                  xmlns:i=""http://www.w3.org/2001/XMLSchema-instance"">
                    <b:ColumnSet>
                      <b:AllColumns>false</b:AllColumns>
                      <b:Columns xmlns:c=""http://schemas.microsoft.com/2003/10/Serialization/Arrays"">
                        <c:string>accountid</c:string>
                        <c:string>name</c:string>
                      </b:Columns>
                    </b:ColumnSet>
                    <b:Criteria>
                      <b:Conditions />
                      <b:FilterOperator>And</b:FilterOperator>
                      <b:Filters />
                    </b:Criteria>
                    <b:Distinct>false</b:Distinct>
                    <b:EntityName>account</b:EntityName>
                    <b:LinkEntities />
                    <b:Orders />
                    <b:PageInfo>
                      <b:Count>0</b:Count>
                      <b:PageNumber>0</b:PageNumber>
                      <b:PagingCookie i:nil=""true"" />
                      <b:ReturnTotalRecordCount>
                      false</b:ReturnTotalRecordCount>
                    </b:PageInfo>
                  </query>
                </RetrieveMultiple>
              </s:Body>
            </s:Envelope>
            ";
            string retrieveMultipleRequestSoapTemplate = crmSoapRequestHeader + retrieveMultipleRequestBodyTemplate;
            DateTime retrieveMultipleRequestCreatedTime = DateTime.Now.ToUniversalTime();
            string retrieveMultipleResponseXML = GetSOAPResponse(CRMUrl, string.Format(retrieveMultipleRequestSoapTemplate
                , retrieveMultipleRequestCreatedTime.ToString("s") + "." + retrieveMultipleRequestCreatedTime.Millisecond
                , retrieveMultipleRequestCreatedTime.AddMinutes(5.0).ToString("s") + "." + retrieveMultipleRequestCreatedTime.Millisecond
                , CRMUrl
                , keyIdentifier
                , securityToken0
                , securityToken1
                , Guid.NewGuid().ToString()
                , "RetrieveMultiple"
                ));

            //Temp XML Code
            string xPathQuery = "//b:Entity/b:Attributes";
            XmlDocument document = new XmlDocument();
            XmlNodeList nodes;
            document.LoadXml(retrieveMultipleResponseXML);

            XmlNamespaceManager nsManager = new XmlNamespaceManager(document.NameTable);
            for (int i = 0; i < namespaces.Length / namespaces.Rank; i++)
            {
                nsManager.AddNamespace(namespaces[i, 0], namespaces[i, 1]);
            }
            nodes = document.SelectNodes(xPathQuery, nsManager);
            foreach (XmlNode node in nodes)
            {
                Console.WriteLine("Account ID:  " + node.SelectSingleNode(".//b:KeyValuePairOfstringanyType[c:key='accountid']/c:value/text()", nsManager).Value);
                Console.WriteLine("Account Name:" + node.SelectSingleNode(".//b:KeyValuePairOfstringanyType[c:key='name']/c:value/text()", nsManager).Value);
            }
            #endregion

            Console.Read();
        }

        public static string GetMethod(string url)
        {

            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";

            request.Timeout = 180000;

            string soapXMLResponse = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
                    soapXMLResponse = reader.ReadToEnd();
                response.Close();
            }

            return soapXMLResponse;
        }

        public static string GetSOAPResponse(string url, string soapEnvelope)
        {

            WebRequest request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/soap+xml; charset=UTF-8";

            request.Timeout = 180000;
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(soapEnvelope);
            using (Stream str = request.GetRequestStream())
            {
                str.Write(bytes, 0, bytes.Length);
                str.Close();
            }

            string soapXMLResponse = string.Empty;
            using (WebResponse response = request.GetResponse())
            {
                using (System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream()))
                    soapXMLResponse = reader.ReadToEnd();
                response.Close();
            }

            return soapXMLResponse;
        }

        public static string GetValueFromXML(string inputXML, string xPathQuery)
        {
            return GetValueFromXML(inputXML, xPathQuery, 0);
        }
        public static string GetValueFromXML(string inputXML, string xPathQuery, int index)
        {
            return GetValueFromXML(inputXML, xPathQuery, index, null);
        }
        public static string GetValueFromXML(string inputXML, string xPathQuery, int index, string[,] namespaces)
        {
            XmlDocument document = new XmlDocument();
            XmlNodeList nodes;
            document.LoadXml(inputXML);

            if (namespaces != null)
            {
                XmlNamespaceManager nsManager = new XmlNamespaceManager(document.NameTable);
                for (int i = 0; i < namespaces.Length/namespaces.Rank; i++)
                {
                    nsManager.AddNamespace(namespaces[i, 0], namespaces[i, 1]);
                }
                nodes = document.SelectNodes(xPathQuery, nsManager);
            }
            else
                nodes = document.SelectNodes(xPathQuery);

            if (nodes != null && nodes.Count > 0 && nodes[index] != null)
                return nodes[index].Value;
            else
                return string.Empty;
        }
    }
}
