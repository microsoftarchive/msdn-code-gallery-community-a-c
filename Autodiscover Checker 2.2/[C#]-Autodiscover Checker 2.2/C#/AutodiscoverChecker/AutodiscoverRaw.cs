using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

using AppHelpers;
 
namespace AutodiscoverChecker
{
    /// <summary>
    /// Proxy class to Exchange Autodiscover service
    /// </summary>
    /// 
     

    public class AutodiscoverRaw
    {

        private InMemoryListener _IML = null;
        private bool _TraceCertificateInformation = false;
        private bool _AllowHttpRedirect = false;

        // Guid for SCP URL keyword
        private const string ScpUrlGuidString = @"77378F46-2C66-4aa9-A6A6-3E7A48B19596";

        // Guid for SCP pointer keyword
        private const string ScpPtrGuidString = @"67661d7F-8FC4-4fa7-BFAC-E1D7794C1F68";

        // Autodiscover path
        private const string AutodiscoverPath = @"/autodiscover/autodiscover.xml";

        // Enable verbose Console Tracing for debug build
#if DEBUG
        private const bool TraceToConsole = true;
#else
        private const bool TraceToConsole = false;
#endif
         

        private string  TraceLogRequestAndResponseStream(ref System.Net.HttpWebRequest oRequest, ref System.Net.WebResponse oResponse)
        {
            String sRequestText = string.Empty;
            String sResponseText = string.Empty;
            WebHeaderCollection oWebHeaderCollection = null;
            string sResponseXml = string.Empty;

            // -- Get the request:

            // Request
 
            sRequestText += "      + Request Headers\r\n";
 
            // Get the headers associated with the response.
            oWebHeaderCollection = oRequest.Headers;

            for (int i = 0; i < oWebHeaderCollection.Count; i++)
            {
                String header = oWebHeaderCollection.GetKey(i);
                String[] values = oWebHeaderCollection.GetValues(header);
                if (values.Length > 0)
                {

                    sRequestText += String.Format("        {0}: ", header);

                    for (int j = 0; j < values.Length; j++)
                        sRequestText += String.Format("{0}\r\n", values[j]);
                    //sResponseText += "\r\n";
                }
                else
                    sRequestText += String.Format("        {0}: \r\n", header);
            }
            sRequestText += "      - Request Headers\r\n";

            sRequestText += "      + Request Body\r\n";
            try
            {

                Stream oRequestStream = (Stream)oRequest.GetRequestStream();
                StreamReader srRequest =  new StreamReader(oRequestStream);
                sRequestText += srRequest.ReadToEnd();
                
            }
            catch (Exception exRequest)
            {
                sResponseText += "\r\n";
                sResponseText += "!! Error getting the Request stream for loging.\r\n";
                sResponseText += "  Message: " + exRequest.Message + "\r\n";
                sResponseText += "  InnerException: " + exRequest.InnerException + "\r\n";
                sResponseText += "\r\n";
                sResponseText += "  StackTrace: " + exRequest.StackTrace + "\r\n";
                sResponseText += "\r\n";
            }
            sRequestText += "      - Request Body\r\n";

            sRequestText += "    - Request Info\r\n";
            ConsoleTrace(sRequestText);

 
            // ----------------------------------------------------------

            // -- Now get the response:
            sResponseText += "    + Response Info\r\n";

            if (oResponse != null)
            {
                sResponseText += "      + Response Headers\r\n";
                oWebHeaderCollection = oResponse.Headers;
                for (int i = 0; i < oWebHeaderCollection.Count; i++)
                {
                    String header = oWebHeaderCollection.GetKey(i);
                    String[] values = oWebHeaderCollection.GetValues(header);
                    if (values.Length > 0)
                    {

                        sResponseText += String.Format("       {0}: ", header);
                        for (int j = 0; j < values.Length; j++)
                            sResponseText += String.Format("{0}\r\n", values[j]);
                        //sResponseText += "\r\n";
                    }
                    else
                        sResponseText += String.Format("       {0}: \r\n", header);
                }
                sResponseText += "      - Response Headers\r\n";

                sResponseText += "     + Response Body\r\n";
                Stream oResponseStream = (Stream)oResponse.GetResponseStream();
                StreamReader srResponse = new StreamReader(oResponseStream);
                sResponseText += "Response Body:\r\n";
                sResponseXml = srResponse.ReadToEnd();
                sResponseText += sResponseXml;
                sResponseText += "\r\n";
                sResponseText += "     - Response Body\r\n";

                HttpWebResponse o = (HttpWebResponse)oResponse;
                int iResponseStatusCodeNumber = (int)o.StatusCode;
                sResponseText += "     * Response Code: " + iResponseStatusCodeNumber.ToString() + "\r\n";
                sResponseText += "    *  StatusDescription Code: " + o.StatusDescription + "\r\n";

 
                o = null;

            }
            else
            {
                sResponseText += "     ! Response Body is null\r\n";
            }


            sResponseText += "    - Response Info";

            ConsoleTrace(sResponseText);

            return sResponseXml;
        }

        private bool CheckForEwsUrl(string EwsXml, ref string EwsUrl)
        {
            bool bRet = false;
            EwsUrl = null; 
            System.Xml.XmlDocument oXmlDocument = new XmlDocument();
            try
            {
                oXmlDocument.LoadXml(EwsXml);
                string sEwsUrl = GetXmlDocumentElement(oXmlDocument, "EwsUrl");
                if (sEwsUrl != null)
                {
                    EwsUrl = sEwsUrl;
                    bRet = true;
                }
            }
            catch
            {
                bRet = false;
            }
            return bRet;
        }


        /// <summary>
        /// Autodiscover the configurations for a specific e-mail address.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <param name="nc">Network credentials, if null, then current credentials are used</param>
        /// <param name="maxHops">Maximum number of Active Directory and e-mail address redirections</param>
        /// <param name="allowSelfSignedCerts">Allow self-signed certificates flag</param>
        /// <returns>Autodiscover response</returns>
        /// 
        public AutodiscoverResponseXml TryDiscoverSoap(
            ref InMemoryListener oIML,
            string emailAddress,
            System.Net.NetworkCredential oNetworkCredential,
            ref int maxHops,
            bool allowSelfSignedCerts,
            bool bTraceCertificateInformation
            )
        {
            _IML = oIML;
            _TraceCertificateInformation = bTraceCertificateInformation;
            AutodiscoverResponseXml oAutodiscoverResponseXml = null;

            ConsoleTraceMarkTime("+ SOAP Autodiscover");

            // Verify parameters.
            if (VerifyParameters(emailAddress) == false)
            {
                return oAutodiscoverResponseXml;
                //return string.Empty;
            }

            string[] emailAddressParts = emailAddress.Split('@');
            string domainName = emailAddressParts[1]; // Get the domain from the e-mail address.

            System.Collections.Generic.List<string> urls = new List<string>();
            urls.Add("https://" + domainName + AutodiscoverPath);
            urls.Add("https://autodiscover." + domainName + AutodiscoverPath);
            urls.Add("https://autodiscover-s.outlook.com/autodiscover/autodiscover.xml");
            ConsoleTrace("  + URLs to try");
            foreach (string s in urls)
            {
                ConsoleTrace("    " + s);
            }
            ConsoleTrace("  - URLs to try");
            string EwsUrl = string.Empty;
            foreach (string url in urls)
            {
                ConsoleTraceMarkTime("    + Checking URL: " + url);

                //EwsUrl = DiscoverSoap(
                //    ref oIML,
                //    emailAddress,
                //    oNetworkCredential,
                //    ref maxHops,
                //    allowSelfSignedCerts,
                //    url);


                oAutodiscoverResponseXml = DiscoverSoap(
                    ref oIML,
                    emailAddress,
                    oNetworkCredential,
                    ref maxHops,
                    allowSelfSignedCerts,
                    url);

                 //If a valid Outlook response is returned, stop the search.
                if (IsOutlookDataReturned(oAutodiscoverResponseXml))
                {
                    ConsoleTraceMarkTime("      * Outlook Address was found.");
                    ConsoleTraceMarkTime("    - Checking URL: " + url);
                    return oAutodiscoverResponseXml;
                }
                //else
                //{
                //    // Clear the list of URLs to try two default URLs.
                //    urls.Clear();
                //}

                ConsoleTraceMarkTime("    - Checking URL: " + url);

                //if (EwsUrl != string.Empty)
                //    break;
            }

            _IML = null;

            ConsoleTraceMarkTime("- SOAP Autodiscover");

            return oAutodiscoverResponseXml;
           // return EwsUrl;
 
        }

        /// <summary>
        /// Autodiscover the configurations for a specific e-mail address.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <param name="nc">Network credentials, if null, then current credentials are used</param>
        /// <param name="maxHops">Maximum number of Active Directory and e-mail address redirections</param>
        /// <param name="allowSelfSignedCerts">Allow self-signed certificates flag</param>
        /// <returns>Autodiscover response</returns>
        /// 
        public AutodiscoverResponseXml DiscoverSoap(
            ref InMemoryListener oIML,
            string emailAddress,
            System.Net.NetworkCredential oNetworkCredential,
            ref int maxHops,
            bool allowSelfSignedCerts,
            String sCasUrl
            )
        {

            string EwsResponseXML = string.Empty;
            string EwsUrl = string.Empty;
            bool bFoundEwsUrl = false;

            AutodiscoverResponseXml oAutodiscoverResponseXml = null;

            CheckAndDecrementHops(ref maxHops);


            ConsoleTrace("      + Starting SOAP Discovery");

       
            String sDiscXml = 
                "<Autodiscover xmlns=\"http://schemas.microsoft.com/exchange/autodiscover/outlook/requestschema/2006\">" +
                "<Request>" +
                "<EMailAddress>" + emailAddress + "</EMailAddress>" +
                "<AcceptableResponseSchema>http://schemas.microsoft.com/exchange/autodiscover/outlook/responseschema/2006a</AcceptableResponseSchema>" +
                "</Request>" +
                "</Autodiscover>";

            System.Net.HttpWebRequest oRequest = null;
            System.Net.WebResponse oResponse = null;
            //HttpWebResponse o = null;

            //int iResponseStatusCodeNumber = 0;
            bool bError = false;

           
            oRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sCasUrl);

            //NetworkCredential ncCred = oNetworkCredential;
            byte[] bytes = Encoding.UTF8.GetBytes(sDiscXml);
            oRequest.ContentLength = bytes.Length;
            oRequest.ContentType = "text/xml";
            oRequest.Headers.Add("Translate", "F");
            oRequest.Method = "POST";
            oRequest.Credentials = oNetworkCredential;

            oRequest.MaximumAutomaticRedirections = maxHops;
            oRequest.AllowAutoRedirect = false;
            Stream oRequestStream = null;

            try
            {
                oRequestStream = oRequest.GetRequestStream();
                oRequestStream.Write(bytes, 0, bytes.Length);
                oRequestStream.Flush();
                oRequestStream.Close();
                oRequestStream = null;
            }
            catch (Exception exRequest)
            {
                bError = true;
                ConsoleTrace("");
                ConsoleTrace("!! Error building the request for: " + sCasUrl);
                ConsoleTrace("  Message: " + exRequest.Message);
                ConsoleTrace("  InnerException: " + exRequest.InnerException);
                ConsoleTrace("");
                ConsoleTrace("  StackTrace: " + exRequest.StackTrace);
                ConsoleTrace("");
                //ConsoleTrace("  This is the request XML: \r\n" + sDiscXml);
                //TraceLogRequestAndResponseStream(ref oRequest, ref oResponse);
                
            }

            if (bError == false)
            {
                ConsoleTrace("        + Initial POST using URL: " + sCasUrl);
                try
                {
                    oResponse = oRequest.GetResponse();
                    ConsoleTrace("          * Sucessful POST on URL: " + sCasUrl);
                    ConsoleTrace("          + DeserializeResponse");
                    oAutodiscoverResponseXml = DeserializeResponse(oResponse.GetResponseStream());
                    ConsoleTrace("          - DeserializeResponse");
                    //EwsResponseXML = TraceLogRequestAndResponseStream(ref oRequest, ref oResponse);
                    //if (CheckForEwsUrl(EwsResponseXML, ref EwsUrl))
                    //{
                    //    ConsoleTrace("  * Found URL: " + EwsUrl);
                    //    bFoundEwsUrl = true;
                    //}
                     
                    ConsoleTrace("        - Initial POST using URL: " + sCasUrl);

                }
                catch (Exception ex)
                {
                    bError = true;
                    ConsoleTrace("");
                    ConsoleTrace("!! Error doing POST on URL: " + sCasUrl);
                    ConsoleTrace("  Message: " + ex.Message);
                    ConsoleTrace("  InnerException: " + ex.InnerException);
                    ConsoleTrace("");
                    ConsoleTrace("  StackTrace: " + ex.StackTrace);
                    ConsoleTrace("");
                    //TraceLogRequestAndResponseStream(ref oRequest, ref oResponse);
                    ConsoleTrace("        - Initial POST using URL: " + sCasUrl);
               
                }
                 

                if (IsOutlookDataReturned(oAutodiscoverResponseXml))
                {
                    ConsoleTrace("        * The last response contained Autodiscover information.");
                    ConsoleTrace("      - Starting SOAP Discovery");
                    return oAutodiscoverResponseXml;
                }
            }

 
 
            if (bError == false && bFoundEwsUrl == false)
            {

                String sRedirect = oResponse.Headers.Get("Location");
                if (sRedirect != null)
                {
                    ConsoleTrace("          * Redirection location found in prior response: " + sRedirect);

                    oRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sRedirect);
                    oRequest.ContentLength = bytes.Length;
                    oRequest.ContentType = "text/xml";
                    oRequest.Headers.Add("Translate", "F");
                    oRequest.Method = "POST";
                    oRequest.Credentials = oNetworkCredential;
                    oRequestStream = oRequest.GetRequestStream();

                    oRequestStream.Write(bytes, 0, bytes.Length);
                    oRequestStream.Flush();
                    oRequestStream.Close();
                    oRequestStream = null;

                    ConsoleTrace("          + POST using Redirect: " + sRedirect);

                    try
                    {
                        oResponse = oRequest.GetResponse();
                        ConsoleTrace("          * Sucessful POST on URL: " + sCasUrl);
                        ConsoleTrace("          + DeserializeResponse");
                        oAutodiscoverResponseXml = DeserializeResponse(oResponse.GetResponseStream());
                        ConsoleTrace("          - DeserializeResponse");
                        ConsoleTrace("        - POST using Redirect: " + sRedirect);
                        //EwsResponseXML = TraceLogRequestAndResponseStream(ref oRequest, ref oResponse);
                        //if (CheckForEwsUrl(EwsResponseXML, ref EwsUrl))
                        //{
                        //    ConsoleTrace("  * Found URL: " + EwsUrl);
                        //    bFoundEwsUrl = true;
                        //}
                    }
                    catch (Exception ex)
                    {
                        bError = true;
                        ConsoleTrace("");
                        ConsoleTrace("!! Error doing POST on URL: " + sCasUrl);
                        ConsoleTrace("  Message: " + ex.Message);
                        ConsoleTrace("  InnerException: " + ex.InnerException);
                        ConsoleTrace("");
                        ConsoleTrace("  StackTrace: " + ex.StackTrace);
                        ConsoleTrace("");
                        ConsoleTrace("        - POST using Redirect: " + sRedirect);
                        //TraceLogRequestAndResponseStream(ref oRequest, ref oResponse);
                    }

                     

                    if (IsOutlookDataReturned(oAutodiscoverResponseXml))
                    {
                        ConsoleTrace("        * The last response contained Autodiscover information.");
                    
                        ConsoleTrace("      - Starting SOAP Discovery");
                        return oAutodiscoverResponseXml;
                    }

//                    oRequestStream.Close();

                    // start - Testing third level 
                    if (bError == false && bFoundEwsUrl == false)   
                    {
                        String sRedirect2 = oResponse.Headers.Get("Location");
                        if (sRedirect2 != null)
                        {
                            ConsoleTrace("        * Redirection location found in prior response: " + sRedirect2);

                            oRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(sRedirect2);
                            oRequest.ContentLength = bytes.Length;
                            oRequest.ContentType = "text/xml";
                            oRequest.Headers.Add("Translate", "F");
                            oRequest.Method = "POST";
                            oRequest.Credentials = oNetworkCredential;
                            oRequestStream = oRequest.GetRequestStream();

                            oRequestStream.Write(bytes, 0, bytes.Length);
                            oRequestStream.Flush();
                            oRequestStream.Close();
                            oRequestStream = null;


                            ConsoleTraceMarkTime("        + POST using secondary Redirect: " + sRedirect2);

                            try
                            {
                                oResponse = oRequest.GetResponse();
                                ConsoleTrace("          * Sucessful POST on URL: " + sCasUrl);
                                ConsoleTrace("          + DeserializeResponse");
                                oAutodiscoverResponseXml = DeserializeResponse(oResponse.GetResponseStream());
                                ConsoleTrace("          - DeserializeResponse");
                                ConsoleTrace("        - POST using secondary Redirect: " + sRedirect2);
                                //EwsResponseXML= TraceLogRequestAndResponseStream(ref oRequest, ref oResponse);
                                //if (CheckForEwsUrl(EwsResponseXML, ref EwsUrl))
                                //{
                                //    ConsoleTrace("  * Found URL: " + EwsUrl);
                                //    bFoundEwsUrl = true;
                                //}
                            }
                            catch (Exception ex)
                            {
                                bError = true;
                                ConsoleTrace("");
                                ConsoleTrace("!! Error doing POST on URL: " + sCasUrl);
                                ConsoleTrace("  Message: " + ex.Message);
                                ConsoleTrace("  InnerException: " + ex.InnerException);
                                ConsoleTrace("");
                                ConsoleTrace("  StackTrace: " + ex.StackTrace);
                                ConsoleTrace("");

                                ConsoleTrace("  - POST using secondary Redirect: " + sRedirect2);
                                // TraceLogRequestAndResponseStream(ref oRequest, ref oResponse);
                                 
                            }

                            oRequestStream.Close();

 
                             
                            if (IsOutlookDataReturned(oAutodiscoverResponseXml))
                            {
                                ConsoleTrace("        * The last response contained Autodiscover information.");
                                ConsoleTrace("      - Starting SOAP Discovery");
                                return oAutodiscoverResponseXml;
                            }

                        }
                    }

                    // end - testing third level

                }
            }
 
            if (bError == false)
            {
 
  
            }
            ConsoleTrace("      - Starting SOAP Discovery");
            //return EwsUrl;
            return oAutodiscoverResponseXml;
        }

        /// <summary>
        /// Autodiscover the configurations for a specific e-mail address.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <param name="nc">Network credentials, if null, then current credentials are used</param>
        /// <param name="maxHops">Maximum number of Active Directory and e-mail address redirections</param>
        /// <param name="allowSelfSignedCerts">Allow self-signed certificates flag</param>
        /// <returns>Autodiscover response</returns>
        /// 
        public AutodiscoverResponseXml DiscoverScp(
            ref InMemoryListener oIML,
            string emailAddress,
            System.Net.NetworkCredential nc,
            ref int maxHops,
            bool allowSelfSignedCerts,
            bool bTraceCertificateInformation
            
            ) 
      
        {
            _IML = oIML;
            _TraceCertificateInformation = bTraceCertificateInformation; 
             
            AutodiscoverResponseXml autodiscoverResponse = null;

            CheckAndDecrementHops(ref maxHops);
            //ConsoleTrace("=============================================================================================");
            ConsoleTrace("+ SCP Autodiscover for \"" + emailAddress + "\".");

            if (VerifyParameters(emailAddress) == false)
            {
                return autodiscoverResponse;
            }
            string[] emailAddressParts = emailAddress.Split('@');
            string domainName = emailAddressParts[1]; // Get the domain from the e-mail address.
 
            // Get either a list of SCP URLs or a list with 0 entries.
            ConsoleTraceMarkTime("  + Getting SCP List(GetScpUrlList)");
            System.Collections.Generic.List<string> urls = GetScpUrlList(domainName, null, ref maxHops);
            ConsoleTraceMarkTime("  - Getting SCP List (GetScpUrlList)");

 
            // Try SCP URLs retrieved from Active Directory to make Autodiscover requests.
            if (urls.Count > 0)
            {
                ConsoleTrace("");
                ConsoleTrace("  + URLs Found"); 
                foreach (string sUrl in urls)
                {
                    ConsoleTrace("    " + sUrl);
                }
                ConsoleTrace("  - URLs Found");
 
                ConsoleTrace("");
      
                ConsoleTrace("  + Get the Autodiscover information using URLs.");

                // Get the Autodiscover response with client configuration information.
                autodiscoverResponse = DiscoverTryUrls_SCP(
                   emailAddress,
                   nc,
                   urls,
                   true,
                   allowSelfSignedCerts,
                   ref maxHops,
                   bTraceCertificateInformation);

                // If a valid Outlook response is returned, stop the search.
                if (IsOutlookDataReturned(autodiscoverResponse))
                {
                     
                    //ConsoleTraceMarkTime("Outlook Addres was found.");
                    ConsoleTrace("    * Autodiscover information was found.");
                    ConsoleTrace("  - Get the Autodiscover information using URLs.");
                    ConsoleTrace("- SCP Autodiscover for \"" + emailAddress + "\".");
                    return autodiscoverResponse;
                }
                else
                {
                    // Clear the list of URLs to try two default URLs.
                    urls.Clear();
                }

                ConsoleTrace("  - Get the Autodiscover information using URLs.");
            }
            else
            {
                ConsoleTrace("  ! No URLs found");
            }

            ConsoleTrace("- SCP Autodiscover for \"" + emailAddress + "\".");

            return autodiscoverResponse;
        }
 

        /// <summary>
        /// Autodiscover the configurations for a specific e-mail address.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <param name="nc">Network credentials, if null, then current credentials are used</param>
        /// <param name="maxHops">Maximum number of Active Directory and e-mail address redirections</param>
        /// <param name="allowSelfSignedCerts">Allow self-signed certificates flag</param>
        /// <returns>Autodiscover response</returns>
        /// 
        public AutodiscoverResponseXml DiscoverPox(
            ref InMemoryListener oIML,
            string emailAddress,
            System.Net.NetworkCredential nc,
            ref int maxHops,
            bool allowSelfSignedCerts,
            bool bTraceCertificateInformation
            )
        {
            //http://msdn.microsoft.com/en-us/library/ee332364(EXCHG.140).aspx
            // http://blogs.msdn.com/b/exchangedev/archive/2011/07/08/autodiscover-for-exchange-activesync-developers.aspx


            _IML = oIML;
            _TraceCertificateInformation = bTraceCertificateInformation;

            AutodiscoverResponseXml autodiscoverResponse = null;     

            CheckAndDecrementHops(ref maxHops);

            //if (VerifyParameters(emailAddress) == false)
            //{
            //    return autodiscoverResponse;
            //}
            string[] emailAddressParts = emailAddress.Split('@');

 
            // Get the domain from the e-mail address.
            string domainName = emailAddressParts[1];
            System.Collections.Generic.List<string> urls = new List<string>();

            ConsoleTrace("+ Doing POX Autodiscover for \"" + emailAddress + "\".");

            if (VerifyParameters(emailAddress) == false)
            {
                return autodiscoverResponse;
            }

            // http://msdn.microsoft.com/en-us/library/ee332364(EXCHG.140).aspx
 
            // private const string AutodiscoverPath = @"/autodiscover/autodiscover.xml";
            // Add two SSL URLs built from the domain part of SMTP address.
            urls.Add("https://" + domainName + AutodiscoverPath);
            urls.Add("https://autodiscover." + domainName + AutodiscoverPath);
            // TODO: try this? urls.Add("http://autodiscover." + domainName + AutodiscoverPath); // http://support.microsoft.com/?kbid=940881
            urls.Add("https://autodiscover-s.outlook.com/autodiscover/autodiscover.xml");

            ConsoleTrace("  + URLs to try");
            foreach (string s in urls)
            {
                ConsoleTrace("    " + s);
            }
            ConsoleTrace("  - URLs to try");


            ConsoleTrace("  + Processing list of URLs"); 
            // Try  URLs.
            autodiscoverResponse = DiscoverTryUrls_POX(
               emailAddress,
               nc,
               urls,
               false,
               allowSelfSignedCerts,
               ref maxHops,
               bTraceCertificateInformation);
            ConsoleTrace("  - Processing list of URLs"); 
            
            // If no response is returned yet
            if (!IsOutlookDataReturned(autodiscoverResponse))
            {
                //ConsoleTrace("Outlook data not found .");
                ConsoleTrace("* Autodiscover information has not been found yet.");

                 
                // Try non-SSL URL to get SSL redirect URL.
                string redirectUrl = GetRedirectUrl(domainName);
                 

                // If returned redirectUrl is not null it is a valid redirect SSL URL.
                // Then attempt to request Autodiscover data.
                if (!string.IsNullOrEmpty(redirectUrl))
                {
                    
                    ConsoleTrace("  * Redirect found!!!");
                    ConsoleTraceMarkTime("  * Will do POX Autodiscover for \"" + emailAddress + "\" using redirect domain \"" + redirectUrl + "\".");
                     
                    urls.Clear();
                    urls.Add(redirectUrl);

                    ConsoleTrace("  + Trying redirect of: " + redirectUrl);
                    //ConsoleTraceMarkTime("Start - Getting External Autodiscover List(DiscoverTryUrls) using redirect: " + redirectUrl);
                    autodiscoverResponse = DiscoverTryUrls_POX(
                       emailAddress,
                       nc,
                       urls,
                       false,
                       allowSelfSignedCerts,
                       ref maxHops,
                       bTraceCertificateInformation);
                    //ConsoleTraceMarkTime("End - Getting External Autodiscover List(DiscoverTryUrls) using redirect: " + redirectUrl);
                    ConsoleTrace("  + Trying redirect of: " + redirectUrl);
                    if (IsOutlookDataReturned(autodiscoverResponse))
                    {
                        //ConsoleTraceMarkTime("Outlook Addres was found.");
                        ConsoleTrace("  * The last response contained Autodiscover information.");
                    }

                    //ConsoleTraceMarkTime("+ Doing POX Autodiscover for \"" + emailAddress + "\" using redirect domain \"" + redirectUrl + "\".");
                }
    
                 
            }

            ConsoleTrace("- Doing POX Autodiscover for \"" + emailAddress + "\".");

            return autodiscoverResponse;
        }

        /// <summary>
        /// Verifieds an e-mail address.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <returns>bool - true if success, false if failure</returns>
        /// 
        private bool VerifyParameters(string emailAddress)
        {
            bool bRet = true;
            if (emailAddress == null)
            {
                bRet = false;
                 ConsoleTrace("  * E-mail address should not be null");
                //throw new System.ArgumentNullException("E-mail address should not be null");
            }
            else
            {
                bRet = true;
                ConsoleTrace("  * Verified Email Address is not null.");
            }

            string[] emailAddressParts = emailAddress.Split('@');

            if ((emailAddressParts.Length < 2) || (string.IsNullOrEmpty(emailAddressParts[1])))
            {
                bRet = false;
                ConsoleTrace("  !! Invalid format for e-mail address: domain is not specified");
                //throw new System.ArgumentException("Invalid format for e-mail address: domain is not specified");
            }
            else
            {
                bRet = true;
                ConsoleTrace("  * Checked Email Address format");
            }
            return bRet;
        }


        /// <summary>
        /// Search Active Directory for any related SCP URLs for a given domain name.
        /// </summary>
        /// <param name="domainName">Domain name to search for SCP information</param>
        /// <param name="ldapPath">LDAP path to start the search</param>
        /// <param name="maxHops">The number of remaining allowed hops</param>

        private  System.Collections.Generic.List<string> GetScpUrlList(
           string domainName,
           string ldapPath,
           ref int maxHops 
           )
        {
            CheckAndDecrementHops(ref maxHops);

 
          
            ConsoleTraceMarkTime("    + GetScpUrlList - Getting list of URLs using SCP lookup for domainName='" + domainName + "', root path='" + ldapPath + "'");
          
            string scpUrl = null;
            string fallBackLdapPath = null;
            string rootDsePath = null;
            string configPath = null;

            // The container for SCP pointers and URLs objects from Active Directory
            System.DirectoryServices.SearchResultCollection scpDirEntries;

            // The list of SCP URLs.
            System.Collections.Generic.List<string> scpUrlList =
               new System.Collections.Generic.List<string>();

            try
            {
                // Get the LDAP root path.
                 
                rootDsePath = (ldapPath == null) ? "LDAP://RootDSE" : ldapPath + "/RootDSE";
                ConsoleTrace("    * Using Root DSE Path:" + rootDsePath);

                // Get the root directory entry.
                
                System.DirectoryServices.DirectoryEntry rootDseEntry =
                   new System.DirectoryServices.DirectoryEntry(rootDsePath);
                //ConsoleTraceMarkTime("Root directory entry:" + rootDseEntry.);

                // Get the configuration path.
                //ConsoleTraceMarkTime("Start -  Get the configuration path.");
                configPath = rootDseEntry.Properties["configurationNamingContext"].Value as string;
                ConsoleTrace("    * Config path for 'configurationNamingContext':" + configPath);
                //ConsoleTraceMarkTime("End -  Get the configuration path.");

                // Get the configuration entry path.
                System.DirectoryServices.DirectoryEntry configEntry =
                   new System.DirectoryServices.DirectoryEntry("LDAP://" + configPath);

                // Use the configuration entry path to create a query.
                System.DirectoryServices.DirectorySearcher configSearcher =
                   new System.DirectoryServices.DirectorySearcher(configEntry);

                // Filter for Autodiscover SCP URLs and SCP pointers.
                configSearcher.Filter =
                   "(&(objectClass=serviceConnectionPoint)" +
                   "(|(keywords=" + ScpPtrGuidString + ")(keywords=" + ScpUrlGuidString + ")))";
                ConsoleTrace("    Search Filter:" + configSearcher.Filter);

                // Identify properties to retrieve using the the query.
                configSearcher.PropertiesToLoad.Add("keywords");
                configSearcher.PropertiesToLoad.Add("serviceBindingInformation");

                ConsoleTrace( "    * Searching for SCP entries in " + configEntry.Path);

                // Query Active Directory for SCP entries.
 
                ConsoleTraceMarkTime("    + Query Active Directory for SCP entries.");
                scpDirEntries = configSearcher.FindAll();
                ConsoleTraceMarkTime("    - Query Active Directory for SCP entries.");
 
            }
            catch (System.Exception e)
            {
                ConsoleTrace("");
                ConsoleTrace("!! LDAP Query Active Directory for SCP entries failed");
                ConsoleTrace("    Message: " + e.Message);
                ConsoleTrace("    Message: " + e.InnerException);
                ConsoleTrace("");
                ConsoleTrace("    StackTrace: " + e.StackTrace);
                ConsoleTrace("");

                // Return the list with 0 entries.
                return scpUrlList;
            }


            // Identify the domain to match.
            string domainMatch = "Domain=" + domainName;

            // Contains a pointer to the LDAP path of a SCP object.
            string scpPtrLdapPath;

 
            ConsoleTrace ( "    + Scanning for SCP pointers [domain match]: " + domainMatch);
 
 
            foreach (System.DirectoryServices.SearchResult scpDirEntry in scpDirEntries)
            {
                System.DirectoryServices.ResultPropertyValueCollection entryKeywords = scpDirEntry.Properties["keywords"];

                // Identify SCP pointers.
                if (CollectionHelpers.CollectionContains(entryKeywords, ScpPtrGuidString))
                {
                    // Get the LDAP path to SCP pointer.
                    scpPtrLdapPath = scpDirEntry.Properties["serviceBindingInformation"][0] as string;

                    // If the SCP pointer matches the user's domain, then restart search from that point.
                    if (CollectionHelpers.CollectionContains(entryKeywords, domainMatch))
                    {
                        // Stop the current search, start another from a new location.
                        ConsoleTraceMarkTime("      * SCP pointer Found");
                        ConsoleTrace( "      * SCP pointer for " + domainMatch + " is found in '" + scpDirEntry.Path +  "'\n" +
                                      "      * Restarting seach in '" + scpPtrLdapPath + "'");
                        ConsoleTrace("");
 
                        System.Collections.Generic.List<string> oList = null;
                        ConsoleTraceMarkTime("      + Getting list from: " + scpPtrLdapPath);
                        oList = GetScpUrlList( domainName, scpPtrLdapPath, ref maxHops);
                        ConsoleTraceMarkTime("      - Getting list from" + scpPtrLdapPath);
                        ConsoleTrace("    - Scanning for SCP pointers [domain match]: " + domainMatch);
                        return oList;
                         
                    }
                    else
                    {
                        // Save the first SCP pointer ldapPath for a later call if a SCP URL is not found.
                        // Directory entries with a SCP pointer should have only one keyword=ScpPtrGuidString.
                        if ((entryKeywords.Count == 1) && string.IsNullOrEmpty(fallBackLdapPath))
                        {
                            fallBackLdapPath = scpPtrLdapPath;
                            ConsoleTrace( "      * Fallback SCP pointer='" + fallBackLdapPath + "'for " + domainMatch + " is found in '" +
                                      scpDirEntry.Path + "' and saved");
                            ConsoleTrace("");
                        }
                    }
                }
            }
            ConsoleTrace("    - Scanning for SCP pointers [domain match]: " + domainMatch);

            ConsoleTrace( "    * No SCP pointers found for " + domainMatch + " in configPath='" + configPath + "'");

             
            // Get the computer's current site.
            string computerSiteName = null;
            try
            {
                computerSiteName = GetSiteName();
                ConsoleTrace("    * Computer Site name  = " + computerSiteName);
            }
            catch (System.Exception e)
            {
                ConsoleTrace("    ! Unable to get computer Site Name" + e.ToString());  // Info
            }

            

            if (!string.IsNullOrEmpty(computerSiteName))
            {
                // Search for SCP entries.
                string sitePrefix = "Site=";
                string siteMatch = sitePrefix + computerSiteName;
                System.Collections.Generic.List<string> scpListNoSiteMatch =
                   new System.Collections.Generic.List<string>();


                ConsoleTrace("    + Scanning for SCP urls for the current computer [site match] " + siteMatch);


                foreach (System.DirectoryServices.SearchResult scpDirEntry in scpDirEntries)
                {
                    System.DirectoryServices.ResultPropertyValueCollection entryKeywords = scpDirEntry.Properties["keywords"];

                    // Identify SCP URLs.
                    if (CollectionHelpers.CollectionContains(entryKeywords, ScpUrlGuidString))
                    {
                        // Get the SCP URL.
                        scpUrl = scpDirEntry.Properties["serviceBindingInformation"][0] as string;

                        // If the SCP URL matches the exact ComputerSiteName.
                        if (CollectionHelpers.CollectionContains(entryKeywords, siteMatch))
                        {
                            // Priority 1 SCP URL. Add SCP URL to the list if it's not already there.
                            if (!CollectionHelpers.CollectionContains(scpUrlList, scpUrl))
                            {
                                ConsoleTrace("      Adding (Priority 1) '" + scpUrl + "' for the " + siteMatch +
                                          " from '" + scpDirEntry.Path + "' to the top of the list (exact match)");
                                ConsoleTrace("");
                                scpUrlList.Add(scpUrl);
                            }
                        }

                        // No match between the SCP URL and the ComputerSiteName
                        else
                        {
                            bool hasSiteKeyword = false;

                            // Check if SCP URL entry has any keyword starting with "Site=" 
                            foreach (string keyword in entryKeywords)
                            {
                                hasSiteKeyword |= keyword.StartsWith(sitePrefix, System.StringComparison.InvariantCultureIgnoreCase);
                            }

                            // Add SCP URL to the scpListNoSiteMatch list if it's not already there.
                            if (!CollectionHelpers.CollectionContains(scpListNoSiteMatch, scpUrl))
                            {
                                // Priority 2 SCP URL. SCP entry doesn't have any "Site=<otherSite>" keywords, insert at the top of list.
                                if (!hasSiteKeyword)
                                {
                                    ConsoleTrace("      Adding (Priority 2) '" + scpUrl +
                                              "' from '" + scpDirEntry.Path + "' into the middle of the list (wildcard)");
                                    ConsoleTrace("");
                                    scpListNoSiteMatch.Insert(0, scpUrl);
                                }
                                // Priority 3 SCP URL. SCP entry has at least one "Site=<otherSite>" keyword, add to the end of list.
                                else
                                {
                                    ConsoleTrace("      Adding (Priority 3) '" + scpUrl +
                                              "' from '" + scpDirEntry.Path + "' to the end of the list (site mismatch)");
                                    ConsoleTrace("");
                                    scpListNoSiteMatch.Add(scpUrl);
                                }
                            }
                        }
                    }

                }
                 
                 
                // Append SCP URLs to the list. List contains:
                // Priority 1 URLs -- URLs with an exact match, "Site=<machineSite>"
                // Priority 2 URLs -- URLs without a match, no any "Site=<anySite>" in the entry
                // Priority 3 URLs -- URLs without a match, "Site=<nonMachineSite>"
                if (scpListNoSiteMatch.Count > 0)
                {
                    ConsoleTrace("      + Adding URL to final list");
                    foreach (string url in scpListNoSiteMatch)
                    {
                        if (!CollectionHelpers.CollectionContains(scpUrlList, url))
                        {
                            scpUrlList.Add(url);
                            ConsoleTrace("        " + url);
                        }
                    }
                    ConsoleTrace("      - Adding URL to final list");
                }

                ConsoleTrace("    - Scanning for SCP urls for the current computer [site match] " + siteMatch);
                
            }
 

            // If no entries found, try fallBackLdapPath if it's non-empty.
            if (scpUrlList.Count == 0)
            {
                if (!string.IsNullOrEmpty(fallBackLdapPath))
                {
                    //ConsoleTrace("--------------------------------------------------------------------------------------------------------------------------------------------");
                    //ConsoleTraceMarkTime("+ Restarting search for domain:" + domainName + " in SCP fallback pointer:" + fallBackLdapPath);
                    //ConsoleTrace("--------------------------------------------------------------------------------------------------------------------------------------------");
                    System.Collections.Generic.List<string> oList = null;
                    ConsoleTraceMarkTime("    + Restarting search for domain:" + domainName + " in SCP fallback pointer:" + fallBackLdapPath);
                    oList = GetScpUrlList(domainName, fallBackLdapPath, ref maxHops);
                    ConsoleTraceMarkTime("    - Restarting search for domain:" + domainName + " in SCP fallback pointer:" + fallBackLdapPath);
                    return oList;

                }
            }
 
            ConsoleTraceMarkTime("    - GetScpUrlList - Getting list of URLs using SCP lookup for domainName='" + domainName + "', root path='" + ldapPath + "'");
 


            // Return the list with 0 or more SCP URLs.
            return scpUrlList;

 
        }

        /// <summary>
        /// Autodiscover e-mail address against a list of URLs.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <param name="nc">Network credentials</param>
        /// <param name="urls">List of URLs to try</param>
        /// <param name="authoritative">URLs are from Active Directory</param>
        /// <param name="allowSelfSignedCerts">Allow self signed certs flag</param>
        /// <param name="maxHops">The number of remaining Active Directory or e-mail address redirections</param>
        /// <returns></returns>

        private  AutodiscoverResponseXml DiscoverTryUrls_SCP(
           string emailAddress,
           System.Net.NetworkCredential nc,
           System.Collections.Generic.List<string> urls,
           bool authoritative,
           bool allowSelfSignedCerts, 
           ref int maxHops,
           bool bTraceDetailedCertificateInformation
            )
        {
            AutodiscoverResponseXml responseXml = null;

 
            ConsoleTrace("    + Autodiscover e-mail address against a list of URLs.");
 
            foreach (string url in urls)
            {
                ConsoleTraceMarkTime("      + Checking URL: " + url + "");

                // Try each URL - send request to Autodiscover and parse the response.
                responseXml = DiscoverTryUrl(emailAddress, nc, url, authoritative, allowSelfSignedCerts);

                // Check if the response contains data.
                if ((IsOutlookDataReturned(responseXml) && (responseXml.OutlookData.Account != null)))
                {
                    // Check if the response contains a redirect.
                    if (responseXml.OutlookData.Account.Action == "redirectAddr")
                    {
                        // Retry Autodiscover with new redirect e-mail address.
                        string redirectEmailAddress = responseXml.OutlookData.Account.RedirectAddr;
                        ConsoleTrace("        * Redirect EmailAddress='" + redirectEmailAddress + "' is returned, restarting the search");
                        responseXml = DiscoverScp(ref _IML, redirectEmailAddress, nc, ref maxHops, allowSelfSignedCerts, bTraceDetailedCertificateInformation);
   
                    }

                    // Outlook account data is returned by the Autodiscover service - stop the search.
                    ConsoleTrace("        * Discovery information returned by the Autodiscover service.");
 
                    break;
                }

                // Check for error response.
                else
                {
                    if (IsErrorResponseReturned(responseXml))
                    {
                        ConsoleTrace("        !! Error: '" + responseXml.ErrorResponse.Error.ErrorCode +
                           "', Message='" + responseXml.ErrorResponse.Error.Message + "' is returned by Audiscover service");
                    }
                }

                ConsoleTraceMarkTime("      - Checking URL: " + url);
            }


            ConsoleTrace("    - Autodiscover e-mail address against a list of URLs.");
 
            return responseXml;  // Return the successful response.
        }


        /// <summary>
        /// Autodiscover e-mail address against a list of URLs.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <param name="nc">Network credentials</param>
        /// <param name="urls">List of URLs to try</param>
        /// <param name="authoritative">URLs are from Active Directory</param>
        /// <param name="allowSelfSignedCerts">Allow self signed certs flag</param>
        /// <param name="maxHops">The number of remaining Active Directory or e-mail address redirections</param>
        /// <returns></returns>

        private AutodiscoverResponseXml DiscoverTryUrls_POX(
           string emailAddress,
           System.Net.NetworkCredential nc,
           System.Collections.Generic.List<string> urls,
           bool authoritative,
           bool allowSelfSignedCerts,
           ref int maxHops,
           bool bTraceDetailedCertificateInformation
            )
        {
            AutodiscoverResponseXml oAutodiscoverResponseXml = null;

 
            ConsoleTrace("    + Autodiscover e-mail address against a list of URLs.");
 


            foreach (string url in urls)
            {
                ConsoleTraceMarkTime("      + Checking URL: " + url );

                // Try each URL - send request to Autodiscover and parse the response.
                oAutodiscoverResponseXml = DiscoverTryUrl(emailAddress, nc, url, authoritative, allowSelfSignedCerts);

                // Check if the response contains data.
                if ((IsOutlookDataReturned(oAutodiscoverResponseXml) && (oAutodiscoverResponseXml.OutlookData.Account != null)))
                {
                    // Check if the response contains a redirect.
                    if (oAutodiscoverResponseXml.OutlookData.Account.Action == "redirectAddr")
                    {
                        // Retry Autodiscover with new redirect e-mail address.
                        string redirectEmailAddress = oAutodiscoverResponseXml.OutlookData.Account.RedirectAddr;
                        ConsoleTrace("        * Redirect EmailAddress='" + redirectEmailAddress + "' is returned, restarting the search");
                        //responseXml = DiscoverScp(ref _IML, redirectEmailAddress, nc, ref maxHops, allowSelfSignedCerts, bTraceDetailedCertificateInformation);
                        oAutodiscoverResponseXml = DiscoverPox(ref _IML, redirectEmailAddress, nc, ref maxHops, allowSelfSignedCerts, bTraceDetailedCertificateInformation);

                    }

                    // Outlook account data is returned by the Autodiscover service - stop the search.
                    ConsoleTrace("        * Discovery information returned by the Autodiscover service.");
 
                    break;
                }

                // Check for error response.
                else
                {
                    if (IsErrorResponseReturned(oAutodiscoverResponseXml))
                    {
                        ConsoleTrace("!! Error: '" + oAutodiscoverResponseXml.ErrorResponse.Error.ErrorCode +
                           "', Message='" + oAutodiscoverResponseXml.ErrorResponse.Error.Message + "' is returned by Audiscover service");
                    }
                }

                ConsoleTraceMarkTime("      - Checking URL: " + url   );
            }

 
            ConsoleTrace("    - Autodiscover e-mail address against a list of URLs.");
 

            // Return the successful response.
            return oAutodiscoverResponseXml;
        }

        /// <summary>
        /// Contact Autodiscover service at the given URL with the given e-mail address.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <param name="nc">Network credentials</param>
        /// <param name="url">A single URL to try</param>
        /// <param name="authoritative">URL is from Active Directory</param>
        /// <param name="allowSelfSignedCerts">Allow self-signed certificates</param>
        /// <returns></returns>

        private  AutodiscoverResponseXml DiscoverTryUrl(
           string emailAddress,
           System.Net.NetworkCredential nc,
           string url,
           bool authoritative,
           bool allowSelfSignedCerts)
        {
            AutodiscoverResponseXml oAutodiscoverResponseXml = null;
            System.Net.HttpWebRequest oRequest = null;
            System.Net.HttpWebResponse oResponse = null;
            System.IO.Stream webRequestStream = null;
            bool bError = false;
            StreamReader oStreamReader = null;
            HttpWebResponse oHttpWebResponse = null;

            ConsoleTraceMarkTime("        + DiscoverTryUrl- Trying POST for  '" + emailAddress + "' at '" + url + "'");
 
             
            try
            {
                // Custom handling of certificates.
                if (allowSelfSignedCerts)
                {
                    System.Net.ServicePointManager.ServerCertificateValidationCallback += CertificateValidationCallBack;      
                }

 
                oRequest = (HttpWebRequest) System.Net.HttpWebRequest.Create(url);
                if (nc == null)
                {
                    oRequest.UseDefaultCredentials = true;
                    oRequest.Credentials  = CredentialCache.DefaultCredentials;
                }
                else
                {
                    oRequest.Credentials = nc;
                }


                // Create Autodiscover request body to POST to Autodiscover service.
                oRequest.Method = "POST";
                oRequest.ContentType = "text/xml";
 

                if (_AllowHttpRedirect)
                    oRequest.AllowAutoRedirect = true;
                //webRequest.MaximumAutomaticRedirections

                ConsoleTrace("          + Serializing Request stream");


                // Build Request Stream
                if (bError == false)
                {
                     
                    try
                    {
 
                        webRequestStream = (System.IO.Stream)oRequest.GetRequestStream();
                        SerializeRequest(emailAddress, webRequestStream);
                         
                        //StreamReader sr = new StreamReader(webRequestStream);
                        //string sRequest = sr.ReadToEnd();
                        webRequestStream.Close();
                         
  
                    }
                    catch (Exception exCreatePostRequest)
                    {
                        bError = true;
                        ConsoleTrace("!! Exception:");
                        ConsoleTrace("    Message: " + exCreatePostRequest.Message);
                        ConsoleTrace("    InnerException: " + exCreatePostRequest.InnerException);
                        ConsoleTrace("");
                        ConsoleTrace("    StackTrace: " + exCreatePostRequest.StackTrace);
                        ConsoleTrace("");
                       // ConsoleTrace("      StackTrace: " + exCreatePostRequest.StackTrace);
                        //ConsoleTrace("");

                        //ConsoleTrace("!! Base Exception:");
                        //ConsoleTrace("  Message: " + exCreatePostRequest.Message);
                        //ConsoleTrace("  InnerException: " + exCreatePostRequest.InnerException);
                        //ConsoleTrace("      StackTrace: " + exCreatePostRequest.StackTrace);
                      

                    }
                     
 
                }
                ConsoleTrace("          - Serializing Request stream");
 
              
                // Now do the POST
                if (bError == false)
                {
                    ConsoleTraceMarkTime("          + Doing POST and getting response.");

                    try
                    {
                        ConsoleTraceMarkTime("            + Posting.");
                        oResponse = (HttpWebResponse)oRequest.GetResponse(); // POST!!!
                        ConsoleTraceMarkTime("            - Posting.");

                        ConsoleTrace("            + Processing response data.");

                        oHttpWebResponse = (HttpWebResponse)oResponse;
                        int iResponseStatusCodeNumber = (int)oHttpWebResponse.StatusCode;
                        ConsoleTrace("              * Response Code: " + iResponseStatusCodeNumber.ToString());
                        ConsoleTrace("              * StatusDescription Code: " + oHttpWebResponse.StatusDescription);

                        //System.IO.MemoryStream ms = new MemoryStream();
                        //StreamReader sr = new StreamReader();
                        //Stream s = oHttpWebResponse.GetResponseStream();
                        //ResponseXml = sr.ReadToEnd(s);
                        ////System.IO.BinaryWriter bw= new BinaryWriter(s);
                        ////System.IO.BinaryReader br = new BinaryReader(s);
                        ////System.IO.BufferedStream bs = new BufferedStream(s);
                        //bs.
                        //byte[] ResponseBuffer = new byte[1024];
                        //while (true)
                        //{
                        //    if ((sr.Read(ResponseBuffer, 0, ResponseBuffer.Length) <= 0))
                        //    {

                        //    }
                        //}

                    }
                    catch (System.Net.WebException ex)
                    {
                        bError = true;

                        ConsoleTraceMarkTime("!! WebException Exception:");
                        ConsoleTrace("    Status: " + ex.Status.ToString());
                        ConsoleTrace("    Message: " + ex.Message);
                        ConsoleTrace("    InnerException: " + ex.InnerException);
                        ConsoleTrace("    Response: " + ex.Response);
                        ConsoleTrace("");
                        ConsoleTrace("    StackTrace: " + ex.StackTrace);
                        ConsoleTrace("");

                    }
                    catch (Exception ex2)
                    {
                        bError = true;
                        ConsoleTrace("");
                        ConsoleTraceMarkTime("!! Exception:");
                        ConsoleTrace("  Error - Message: " + ex2.Message);
                        ConsoleTrace("  Error - InnerException: " + ex2.InnerException);
                        ConsoleTrace("");
                        ConsoleTrace("  Error - StackTrace: " + ex2.StackTrace);
                        ConsoleTrace("");
                    }
                }

                // Now extract the response from the earlier POST
                if (bError == false)
                {
                    try
                    {
                        ConsoleTraceMarkTime("              * POST succeeded.");

                        ConsoleTraceMarkTime("              + Deserializing the response");
                        oAutodiscoverResponseXml = DeserializeResponse(oHttpWebResponse.GetResponseStream());
                        //    oAutodiscoverResponseXml = DeserializeResponse(oStreamReader.BaseStream);
                        //responseXml = DeserializeResponse(oResponse.GetResponseStream());
                        ConsoleTraceMarkTime("              - Deserializing the response");

                        // TODO: + Get the response stream of GetResponseStream() read into a stream then 
                        // have DeserializeResponse() and the code below use it.
                        ConsoleTrace("              + Extracting response payload as XML.");
                        System.IO.MemoryStream oMemoryStream = new System.IO.MemoryStream();
                        oStreamReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                        string ResponseXml = oStreamReader.ReadToEnd();
                        oStreamReader = null;
                        ConsoleTrace("              - Extracting response payload as XML.");
                        //ConsoleTrace("");
                        ConsoleTrace("              + Response XML");
                        ConsoleTrace(ResponseXml.TrimEnd());
                        ConsoleTrace("              - Response XML");
                      
                        //ConsoleTrace("- Extracting response payload as XML.");
                        // TODO: - Get the response stream of GetResponseStream() read into a stream then 

                        ConsoleTrace("            - Processing response data.");
 
                        oHttpWebResponse = null;
                        //ConsoleTrace("- Extracting payload as text.");
 
                        //sAction = GetXmlDocumentElement(oXmlDocument, "Action");
                        //sRedirectAddr = GetXmlDocumentElement(oXmlDocument, "RedirectAddr");
                        // end xxxx

                         
                    }
                    catch (System.Net.WebException ex)
                    {
                        bError = true;
                        ConsoleTrace("");
                        ConsoleTraceMarkTime("!! WebException Exception:");
                        ConsoleTrace("    Status: " + ex.Status.ToString());
                        ConsoleTrace("    Message: " + ex.Message);
                        ConsoleTrace("");
                        ConsoleTrace("    InnerException: " + ex.InnerException);
                        ConsoleTrace("    StackTrace: " + ex.StackTrace);
                        ConsoleTrace("");
                        //ConsoleTrace("    Response: " + ex.Response);
                        //ConsoleTrace("");
 
 
                    }
                    catch (Exception ex2)
                    {
                        bError = true;
                        ConsoleTrace("!! Exception:");
                        ConsoleTrace("  Message: " + ex2.Message);
                        ConsoleTrace("  InnerException: " + ex2.InnerException);
                        ConsoleTrace("");
                        ConsoleTrace("  StackTrace: " + ex2.StackTrace);
                        ConsoleTrace("");

                    }

 
                    //ConsoleTrace("+Post Data: ");
                    //ConsoleTrace("Request.MaximumAutomaticRedirections: " + oRequest.MaximumAutomaticRedirections.ToString());

                    if (oRequest.Referer != null)
                        ConsoleTrace("            * Request.Referer: " + oRequest.Referer.ToString());
                    if (oRequest.Referer != null)
                    {
                        ConsoleTrace("            * Response.StatusDescription: " + oResponse.StatusDescription);
                        ConsoleTrace("            * Response.StatusCode: " + oResponse.StatusCode.ToString());
                        ConsoleTrace("            * Response.ResponseUri: " + oResponse.ResponseUri.ToString());
                    }
                    else
                        ConsoleTrace("            * Response was null");

                    ConsoleTraceMarkTime("          - Doing POST and getting response."); 
                }

            }
            catch (System.Net.WebException ex)
            {
                ConsoleTrace("!! WebException Exception:");
 
                ConsoleTrace("    Message: " + ex.Message);
                ConsoleTrace("    InnerException: " + ex.InnerException);
                ConsoleTrace(" ");
                ConsoleTrace("    StackTrace: " + ex.StackTrace);
                ConsoleTrace(" ");
                ConsoleTrace("    Status: " + ex.Status.ToString());
                ConsoleTrace("    Response: " + ex.Response);
                ConsoleTrace(" ");
            }
            catch (Exception e)
            {

                ConsoleTrace("");
                ConsoleTrace("!! Exception");
                ConsoleTrace("    Message: " + e.Message);
                ConsoleTrace("    InnerException: " + e.InnerException);
                ConsoleTrace("");
                ConsoleTrace("    StackTrace: " + e.StackTrace);
                ConsoleTrace("");
            }
            finally
            {
                if (allowSelfSignedCerts)
                {
                    // Remove the callback.
                    System.Net.ServicePointManager.ServerCertificateValidationCallback -= CertificateValidationCallBack;
                }
            }



            ConsoleTraceMarkTime("        - DiscoverTryUrl- Trying POST for  '" + emailAddress + "' at '" + url + "'");
 
 
 
            return oAutodiscoverResponseXml;
        }

        /// <summary>
        /// Get redirection to SSL Autodiscover URL from non-SSL URL.
        /// </summary>
        /// <param name="emailAddress">SMTP address</param>
        /// <param name="nc">Network credentials</param>
        /// <param name="url">A single URL to try</param>
        /// <param name="authoritative">URL is from Active Directory</param>
        /// <returns>Valid redirect SSL URL or null</returns>

        private   string GetRedirectUrl(string domainName)
        {
            string url = "http://autodiscover." + domainName + AutodiscoverPath;
 
            ConsoleTraceMarkTime("  + GetRedirectUrl - Trying Anonymous GET to obtain redirection to SSL Autodiscover URL from non-SSL URL. ");
            ConsoleTrace("    *  Url: " + url);

            System.Net.HttpWebRequest oRequest = null;
            System.Net.HttpWebResponse oResponse = null;

            try
            {
                // Create the HTTP Web request.
                oRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);

                oRequest.Method = "GET";
                oRequest.AuthenticationLevel = System.Net.Security.AuthenticationLevel.None;
                oRequest.ImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.Anonymous;
                oRequest.AllowAutoRedirect = false;
                //httpRequest.AllowAutoRedirect = true;
                oRequest.PreAuthenticate = false;

                // Send the request and get the response.
                ConsoleTraceMarkTime("    + Doing GET");
                oResponse = (System.Net.HttpWebResponse)oRequest.GetResponse();
                ConsoleTraceMarkTime("    - Doing GET");

                 

                HttpWebResponse oHttpWebResponse = (HttpWebResponse)oResponse;
                int iResponseStatusCodeNumber = (int)oHttpWebResponse.StatusCode;
                ConsoleTrace("    Response Code: " + iResponseStatusCodeNumber.ToString());
                ConsoleTrace("    StatusDescription Code: " + oHttpWebResponse.StatusDescription);
                 

                // begin xxx 6/11/2013 testing - seeing whats in the response...
                ConsoleTrace("    + Extracting payload.");

                StreamReader oStreamReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                string ResponseXml = oStreamReader.ReadToEnd();

                ConsoleTrace("      + Response XML");
                ConsoleTrace(ResponseXml.TrimEnd());
                ConsoleTrace("      - Response XML");

                //System.Xml.XmlDocument oXmlDocument = new XmlDocument();
                //oXmlDocument.LoadXml(ResponseXml);
                ConsoleTrace("    - Extracting payload.");

                //sAction = GetXmlDocumentElement(oXmlDocument, "Action");
                //sRedirectAddr = GetXmlDocumentElement(oXmlDocument, "RedirectAddr");
                // end xxxx

                 
                oHttpWebResponse = null;

                // http://msdn.microsoft.com/en-us/library/system.net.httpstatuscode.aspx 
                // Check if 301 (moved) or 302 (redirect) codes are returned.
                if ((oResponse.StatusCode == System.Net.HttpStatusCode.Moved) ||
                   (oResponse.StatusCode == System.Net.HttpStatusCode.Redirect))
                {
                    if (oResponse.StatusCode == HttpStatusCode.Redirect)
                        ConsoleTrace("    * 302 (Redirect) encountered");
                    if (oResponse.StatusCode == HttpStatusCode.Moved)
                        ConsoleTrace("    * 301 (Moved) encountered");

                    // Get the redirect URL and verify that it's valid.
                    string redirectUrl = oResponse.Headers["Location"];
                    bool isValidRedirectUrl = false;

                    if (!string.IsNullOrEmpty(redirectUrl))
                    {
                        ConsoleTrace("    * Redirect URL Found: " + redirectUrl);

                        System.UriBuilder urib = new System.UriBuilder(redirectUrl);

                        // Check if URI is SSL and that the path matches.
                        isValidRedirectUrl =
                           (string.Compare(urib.Scheme, "https", true) == 0) &&
                           (string.Compare(urib.Path, AutodiscoverPath, true) == 0);
                    }

                    // Return the redirect URL.
                    if (isValidRedirectUrl)
                    {
                        ConsoleTrace("    Redirection URL is valid: " + redirectUrl  );
                        return redirectUrl;
                    }
                    else
                    {
                        ConsoleTrace("    !! Redirection URL is not valid" + redirectUrl);
                    }
                }

                // The default non-SSL end point has not been setup to redirect.
                else
                {
                    ConsoleTrace("    ! Warning: '" + url + "' is not configured for redirection");
                }
                //TraceLogResponseStream(ref oRequest, ref oResponse);
            }

            catch (System.Net.WebException e)
            {
                ConsoleTrace("");
                ConsoleTrace("!! Exception");
                ConsoleTrace("    Message: " + e.Message);
                ConsoleTrace("    InnerException: " + e.InnerException);
                ConsoleTrace("");
                ConsoleTrace("    StackTrace: " + e.StackTrace);
                ConsoleTrace("");
                //TraceLogResponseStream(ref oRequest, ref oResponse);
            }

            ConsoleTraceMarkTime("  - GetRedirectUrl - Trying Anonymous GET to obtain redirection to SSL Autodiscover URL from non-SSL URL. ");

 
 
            return null;
        }

        private string GetXmlDocumentElement(XmlDocument oXmlDocument, string ElementName)
        {

            XmlNodeList oXmlNodeList = oXmlDocument.GetElementsByTagName(ElementName);

            if (oXmlNodeList.Count > 0)
            {
                XmlNode oEwsUrl = oXmlNodeList.Item(0);
                return oEwsUrl.InnerText;
            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Callback to handle SSL certificate.
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="certificate">Certificate</param>
        /// <param name="chain">Chain</param>
        /// <param name="sslPolicyErrors">SSL policy errors</param>
        /// <returns>true if certificate is OK</returns>
        private   bool CertificateValidationCallBack(
              object sender,
              System.Security.Cryptography.X509Certificates.X509Certificate certificate,
              System.Security.Cryptography.X509Certificates.X509Chain chain,
              System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {

            if (_TraceCertificateInformation == true)
            {
                ConsoleTraceMarkTime("+ Validate Certificate");
            }

            // If no errors - exit.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {

                if (_TraceCertificateInformation == true)
                {
                    ConsoleTrace("  + Valid Certificate [No policy errors] ");
                    ConsoleTrace("    Issuer:               " + certificate.Issuer);
                    ConsoleTrace("    Subject:              " + certificate.Subject);
                    ConsoleTrace("    EffectiveDateString:  " + certificate.GetEffectiveDateString());
                    ConsoleTrace("    ExpirationDate:       " + certificate.GetExpirationDateString());
                    ConsoleTrace("    Format:               " + certificate.GetFormat());
                    ConsoleTrace("    SerialNumber:         " + certificate.GetSerialNumberString());
                    ConsoleTrace("    RawCertData:          " + certificate.GetRawCertDataString());
                    ConsoleTrace("    PublicKey:            " + certificate.GetPublicKeyString());
                    ConsoleTrace("  - Valid Certificate [No policy errors] ");
                }
                else
                {
                    ConsoleTrace("              * Certificate validated [No policy errors]");
                     
                }
                if (_TraceCertificateInformation == true)
                    ConsoleTraceMarkTime("- Validate Certificate");
                return true;
            }

            // If RemoteCertificateChainErrors, walk the chain to handle errors.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Untrusted root for self-signed certificate is OK.

                            if (_TraceCertificateInformation == true)
                            {
                                ConsoleTrace("  + Validate Certificate [Self-signed certificates with an untrusted root - Considering as valid]");
                                ConsoleTrace("    Status Information:   " + status.StatusInformation);
                                ConsoleTrace("    Issuer:               " + certificate.Issuer);
                                ConsoleTrace("    Subject:              " + certificate.Subject);
                                ConsoleTrace("    EffectiveDateString:  " + certificate.GetEffectiveDateString());
                                ConsoleTrace("    ExpirationDate:       " + certificate.GetExpirationDateString());
                                ConsoleTrace("    Format:               " + certificate.GetFormat());
                                ConsoleTrace("    SerialNumber:         " + certificate.GetSerialNumberString());
                                ConsoleTrace("    RawCertData:          " + certificate.GetRawCertDataString());
                                ConsoleTrace("    PublicKey:            " + certificate.GetPublicKeyString());
                                ConsoleTrace("  - Validate Certificate [Self-signed certificates with an untrusted root - Considering as valid]");
                            }
                            else
                            {
                                ConsoleTrace("              * Certificate validated [Self-signed certificates with an untrusted root - Considering as valid]");
                            }
                            if (_TraceCertificateInformation == true)
                                ConsoleTraceMarkTime("- Validate Certificate");
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                if (_TraceCertificateInformation == true)
                                {
                                    ConsoleTrace("  + Validate Certificate [Certificate Errors - Considering as invalid]");
                                    ConsoleTrace("    Status Information:   " + status.StatusInformation);
                                    ConsoleTrace("    Issuer:               " + certificate.Issuer);
                                    ConsoleTrace("    Subject:              " + certificate.Subject);
                                    ConsoleTrace("    EffectiveDateString:  " + certificate.GetEffectiveDateString());
                                    ConsoleTrace("    ExpirationDate:       " + certificate.GetExpirationDateString());
                                    ConsoleTrace("    Format:               " + certificate.GetFormat());
                                    ConsoleTrace("    SerialNumber:         " + certificate.GetSerialNumberString());
                                    ConsoleTrace("    RawCertData:          " + certificate.GetRawCertDataString());
                                    ConsoleTrace("    PublicKey:            " + certificate.GetPublicKeyString());
                                    ConsoleTrace("");
                                    ConsoleTrace("    !! Chain Error status='" + status.Status.ToString() + "', statusInformation='" + status.StatusInformation + "'");
                                    ConsoleTrace("");
                                    // Fail on any other certificate error.
                                    ConsoleTrace("  - Validate Certificate [Certificate Errors - Considering as invalid]");
                                }
                                else
                                {
                                    ConsoleTrace("              * Certificate validated [No policy errors]");
                                }
                                if (_TraceCertificateInformation == true)
                                    ConsoleTraceMarkTime("- Validate Certificate");
                                return false;
                            }
                        }
                    }
                }
                if (_TraceCertificateInformation == true)
                {
                    ConsoleTraceMarkTime("- Validate Certificate");
                }
                // No errors except untrusted root for self-signed certificates.
                return true;
            }
            else
            {
                if (_TraceCertificateInformation == true)
                {
                    ConsoleTraceMarkTime("- Validate Certificate");
                }
                return false;
            }
        }

        ///// <summary>
        ///// Case insensitive check if the collection contains the string.
        ///// </summary>
        ///// <param name="collection">The collection of objects, only strings are checked</param>
        ///// <param name="match">String to match</param>
        ///// <returns>true, if match contains in the collection</returns>
        //private   bool CollectionContains(System.Collections.ICollection oCollection, string matchingstring)
        //{
        //    foreach (object obj in oCollection)
        //    {
        //        string str = obj as string;
        //        if (str != null)
        //        {
        //            if (string.Compare(str, matchingstring, true) == 0)
        //            {
        //                return true;
        //            }
        //        }
        //    }
        //    return false;
        //}

        /// <summary>
        /// Check maxHops, if less than one - throw exception, otherwise - decrement the counter.
        /// </summary>
        /// <param name="maxHops">Hops counter</param>
        private   void CheckAndDecrementHops(ref int maxHops)
        {
            if (maxHops <= 0)
            {
                ConsoleTrace("!! The number of hops exceeded the limit");
                throw new System.ArgumentOutOfRangeException("maxHops", "The number of hops exceeded the limit");
            }
            maxHops = maxHops - 1;
        }

        /// <summary>
        /// Check if AutodiscoverResponse contains Outlook data.
        /// </summary>
        /// <param name="autodiscoverResponse">Autodiscover response to verify</param>
        /// <returns>true if OutlookDate is presented</returns>

        private   bool IsOutlookDataReturned(AutodiscoverResponseXml autodiscoverResponse)
        {
            return ((autodiscoverResponse != null) &&
                  (autodiscoverResponse.OutlookData != null));
        }

        /// <summary>
        /// Check if AutodiscoverResponse contains Error data.
        /// </summary>
        /// <param name="autodiscoverResponse">Autodiscover response to verify</param>
        /// <returns>true if ErrorResponse is presented</returns>

        private  bool IsErrorResponseReturned(AutodiscoverResponseXml autodiscoverResponse)
        {
            return ((autodiscoverResponse != null) &&
                  (autodiscoverResponse.ErrorResponse != null));
        }

        /// <summary>
        /// Console Tracing function.
        /// </summary>
        /// <param name="message">Message to output to Console</param>
        private  void ConsoleTrace( string message)
        {
            _IML.WriteLine(message);
            //if (TraceToConsole)
            //    System.Console.WriteLine(message);
        }

        private  void ConsoleTraceMarkTime()
        {
            _IML.WriteLine("[" + DateTime.Now.ToString() + "]\n");
            //if (TraceToConsole)
            //    System.Console.WriteLine(message);
        }

        private void ConsoleTraceMarkTime(string message)
        {
            _IML.WriteLine(message + "  [" + DateTime.Now.ToString() + "]" +"\n");
            //if (TraceToConsole)
            //    System.Console.WriteLine(message);
        }
       

        /// <summary>
        /// Generate an AutoDiscover XML Request.
        /// </summary>
        /// <param name="emailAddress">E-mail address to Autodiscover</param>
        /// <param name="requestStream">Output stream for serialized Autodiscover request</param>
        private  void  SerializeRequest(string emailAddress, System.IO.Stream requestStream)
        {
            AutodiscoverRequestXml requestXml =
               AutodiscoverRequestXml.NewRequest(emailAddress);

            System.Xml.Serialization.XmlSerializer xmlSerializer =
               new System.Xml.Serialization.XmlSerializer(typeof(AutodiscoverRequestXml));

            xmlSerializer.Serialize(requestStream, requestXml);

        }

        /// <summary>
        /// Parse an AutoDiscover XML Response.
        /// </summary>
        /// <param name="responseStream">Stream to deserialize</param>
        /// <returns>Deserialized AutodiscoverResponse class instance</returns>

        private  AutodiscoverResponseXml DeserializeResponse(System.IO.Stream responseStream)
        {
            System.Xml.Serialization.XmlSerializer xmlDeserializer =
               new System.Xml.Serialization.XmlSerializer(typeof(AutodiscoverResponseXml));

            return xmlDeserializer.Deserialize(responseStream) as AutodiscoverResponseXml;
        }

        #region Autodiscover Request Xml

        const string OutlookRequestNamespace = "http://schemas.microsoft.com/exchange/autodiscover/outlook/requestschema/2006";
        const string OutlookResponseNamespace = "http://schemas.microsoft.com/exchange/autodiscover/outlook/responseschema/2006a";
        const string AutodiscoverResponseNamespace = "http://schemas.microsoft.com/exchange/autodiscover/responseschema/2006";

        /*   Autodiscover POX Request Xml sample
		  
          <Autodiscover xmlns="http://schemas.microsoft.com/exchange/autodiscover/outlook/requestschema/2006">
            <Request>
              <EMailAddress>user@contoso.com</EMailAddress>
              <AcceptableResponseSchema>http://schemas.microsoft.com/exchange/autodiscover/outlook/responseschema/2006a</AcceptableResponseSchema>
            </Request>
          </Autodiscover>

         */

        /// <summary></summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "Autodiscover", Namespace = OutlookRequestNamespace)]
        public class AutodiscoverRequestXml
        {
            /// <summary></summary>
            [System.Xml.Serialization.XmlElement(IsNullable = false)]
            public RequestXml Request = null;

            /// <summary>Creates Autodiscover XML request</summary>
            public static AutodiscoverRequestXml NewRequest(string address)
            {
                RequestXml request = new RequestXml();
                request.EMailAddress = address;
                request.AcceptableResponseSchema = OutlookResponseNamespace;

                AutodiscoverRequestXml outlookRequest = new AutodiscoverRequestXml();
                outlookRequest.Request = request;

                return outlookRequest;
            }
        }

        /// <summary>Request container</summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "Request", Namespace = OutlookRequestNamespace)]
        public class RequestXml
        {
            /// <summary>User SMTP address</summary>
            public string EMailAddress = null;

            /// <summary>The response schema, acceptable for a client</summary>
            public string AcceptableResponseSchema = null;
        }

        #endregion

        #region Autodiscover Response Xml

        /* Autodiscover sample response

		<Autodiscover xmlns="http://schemas.microsoft.com/exchange/autodiscover/responseschema/2006">
			<Response xmlns="http://schemas.microsoft.com/exchange/autodiscover/outlook/responseschema/2006a">
				<User>
					<DisplayName>First Last</DisplayName>
					<LegacyDN>/o=contoso/ou=First Administrative Group/cn=Recipients/cn=iuser885646</LegacyDN>
					<DeploymentId>644560b8-a1ce-429c-8ace-23395843f701</DeploymentId>
				</User>
				<Account>
					<AccountType>email</AccountType>
					<Action>settings</Action>
					<Protocol>
						<Type>EXCH</Type>
						<Server>MBX-SERVER.mail.internal.contoso.com</Server>
						<ServerDN>/o=contoso/ou=Exchange Administrative Group (FYDIBOHF23SPDLT)/cn=Configuration/cn=Servers/cn=MBX-SERVER</ServerDN>
						<ServerVersion>72008287</ServerVersion>
						<MdbDN>/o=contoso/ou=Exchange Administrative Group (FYDIBOHF23SPDLT)/cn=Configuration/cn=Servers/cn=MBX-SERVER/cn=Microsoft Private MDB</MdbDN>
						<ASUrl>https://mail.contoso.com/ews/exchange.asmx</ASUrl>
						<OOFUrl>https://mail.contoso.com/ews/exchange.asmx</OOFUrl>
						<UMUrl>https://mail.contoso.com/unifiedmessaging/service.asmx</UMUrl>
						<OABUrl>https://mail.contoso.com/OAB/d29844a9-724e-468c-8820-0f7b345b767b/</OABUrl>
					</Protocol>
					<Protocol>
						<Type>EXPR</Type>
						<Server>Exchange.contoso.com</Server>
						<ASUrl>https://mail.contoso.com/ews/exchange.asmx</ASUrl>
						<OOFUrl>https://mail.contoso.com/ews/exchange.asmx</OOFUrl>
						<UMUrl>https://mail.contoso.com/unifiedmessaging/service.asmx</UMUrl>
						<OABUrl>https://mail.contoso.com/OAB/d29844a9-724e-468c-8820-0f7b345b767b/</OABUrl>
					</Protocol>
					<Protocol>
						<Type>WEB</Type>
						<Internal>
							<OWAUrl AuthenticationMethod="Ntlm, WindowsIntegrated">https://cas-01-server.mail.internal.contoso.com/owa</OWAUrl>
							<OWAUrl AuthenticationMethod="Ntlm, WindowsIntegrated">https://cas-02-server.mail.internal.contoso.com/owa</OWAUrl>
							<OWAUrl AuthenticationMethod="Basic">https://cas-04-server.mail.internal.contoso.com/owa</OWAUrl>
							<OWAUrl AuthenticationMethod="Ntlm, WindowsIntegrated">https://cas-05-server.mail.internal.contoso.com/owa</OWAUrl>
						</Internal>
					</Protocol>
				</Account>
			</Response>
		</Autodiscover>
		*/

        /// <summary>Autodiscover response container</summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "Autodiscover", Namespace = AutodiscoverResponseNamespace)]
        public class AutodiscoverResponseXml
        {
            /// <summary>Outlook data container</summary>
            [System.Xml.Serialization.XmlElement(IsNullable = false, ElementName = "Response", Namespace = OutlookResponseNamespace)]
            public OutlookDataXml OutlookData = null;

            /// <summary>Error response</summary>
            [System.Xml.Serialization.XmlElement(IsNullable = false, ElementName = "Response", Namespace = AutodiscoverResponseNamespace)]
            public ErrorResponseXml ErrorResponse = null;
        }

        /// <summary>Outlook data response container</summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "Response", Namespace = OutlookResponseNamespace)]
        public class OutlookDataXml
        {
            /// <summary>User data container</summary>
            public UserXml User = null;
            /// <summary>Account data container</summary>
            public AccountXml Account = null;
        }

        /// <summary>User container</summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "User", Namespace = OutlookResponseNamespace)]
        public class UserXml
        {
            /// <summary>User display name</summary>
            public string DisplayName = null;
            /// <summary>Exchange LegacyDN address</summary>
            public string LegacyDN = null;
            /// <summary>Deployment Id</summary>
            public string DeploymentId = null;
        }

        /// <summary>Account container</summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "Account", Namespace = OutlookResponseNamespace)]
        public class AccountXml
        {
            /// <summary></summary>
            public string AccountType = null;
            /// <summary></summary>
            public string Action = null;
            /// <summary></summary>
            public string RedirectAddr = null;
            /// <summary></summary>
            [System.Xml.Serialization.XmlElement]
            public ProtocolXml[] Protocol = null;
            /// <summary></summary>
            public string SSL = null;
            /// <summary></summary>
            public string AuthPackage = null;
        }

        /// <summary>Protocol container</summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "Protocol", Namespace = OutlookResponseNamespace)]
        public class ProtocolXml
        {
            /// <summary></summary>
            public string Type = null;
            /// <summary></summary>
            public string Server = null;
            /// <summary></summary>
            public string ServerDN = null;
            /// <summary></summary>
            public string ServerVersion = null;
            /// <summary></summary>
            public string MdbDN = null;
            /// <summary></summary>
            public string ASUrl = null;
            /// <summary></summary>
            public string OOFUrl = null;
            /// <summary></summary>
            public string OABUrl = null;
            /// <summary></summary>
            public string UMUrl = null;
            /// <summary></summary>
            public int Port = 0;
            /// <summary></summary>
            public int DirectoryPort = 0;
            /// <summary></summary>
            public int ReferralPort = 0;
            /// <summary></summary>
            public string FBPublish = null;
            /// <summary></summary>
            public string SSL = null;
            /// <summary></summary>
            public string TTL = null;
            /// <summary></summary>
            public string AuthPackage = null;
            /// <summary></summary>
            public string CertPrincipalName = null;
            ///// <summary></summary>
            //public string GroupingInformation = null;
            /// <summary></summary>
            [System.Xml.Serialization.XmlAnyElement]
            public object[] OtherXml = null;
        }

        /// <summary></summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "Response", Namespace = AutodiscoverResponseNamespace)]
        public class ErrorResponseXml
        {
            /// <summary></summary>
            public ErrorXml Error = null;
        }

        /// <summary>Error container</summary>
        [System.Xml.Serialization.XmlRoot(ElementName = "Error", Namespace = AutodiscoverResponseNamespace)]
        public class ErrorXml
        {
            /// <summary></summary>
            [System.Xml.Serialization.XmlAttribute]
            public string Time = null;
            /// <summary></summary>
            [System.Xml.Serialization.XmlAttribute]
            public string Id = null;
            /// <summary></summary>
            public string ErrorCode = null;
            /// <summary></summary>
            public string Message = null;
            /// <summary></summary>
            public string DebugData = null;
        }
        #endregion

        /// <summary>
        /// Returns local computer's site name.
        /// </summary>
        /// <returns>Name of the local site.</returns>

        private static string GetSiteName()
        {
            System.DirectoryServices.ActiveDirectory.ActiveDirectorySite site =
               System.DirectoryServices.ActiveDirectory.ActiveDirectorySite.GetComputerSite();
            return site.Name;
        }

    }
}

