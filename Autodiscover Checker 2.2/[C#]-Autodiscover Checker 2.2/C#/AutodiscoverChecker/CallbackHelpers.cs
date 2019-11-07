using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;

using Microsoft.Exchange.WebServices.Autodiscover;
using Microsoft.Exchange.WebServices.Data;
using System.Security.Cryptography.X509Certificates;
 

// must be instanced...

namespace AppHelpers
{
     
 
    public class EwsCertificateCallbackHelper
    {
  
        private static bool CertificateValidationCallBack(
                 object sender,
                 System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                 System.Security.Cryptography.X509Certificates.X509Chain chain,
                 System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
                return true;
            }

            // If thre are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certifcates. These certificates are valid
                // for default Exchange server installations, so return true.
                return true;
            }
            else
            {
                // In all other cases, return false.
                return false;
            }
        }
    }

    class EwsCertificateLoggingCallbackHelper
    {
 
        //public int RedirectionCount = 0;
        //public int MaxRedirects = 5;

        //public string _RedirectionUrls = string.Empty;
        public string _Certificates = string.Empty;

        public bool CertificateValidationCallBack(
                 object sender,
                 System.Security.Cryptography.X509Certificates.X509Certificate certificate,
                 System.Security.Cryptography.X509Certificates.X509Chain chain,
                 System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            string sCerts = string.Empty;

            sCerts += "+ Validate Certificate \r\n"; 

            // If the certificate is a valid, signed certificate, return true.
            if (sslPolicyErrors == System.Net.Security.SslPolicyErrors.None)
            {
 
                sCerts += "  + Valid Certificate [No policy errors] \r\n";
                sCerts += "    Issuer:               " + certificate.Issuer + "\r\n";
                sCerts += "    Subject:              " + certificate.Subject + "\r\n";
                sCerts += "    EffectiveDateString:  " + certificate.GetEffectiveDateString() + "\r\n";
                sCerts += "    ExpirationDate:       " + certificate.GetExpirationDateString() + "\r\n";
                sCerts += "    Format:               " + certificate.GetFormat() + "\r\n";
                sCerts += "    SerialNumber:         " + certificate.GetSerialNumberString() + "\r\n";
                sCerts += "    RawCertData:          " + certificate.GetRawCertDataString() + "\r\n";
                sCerts += "    PublicKey:            " + certificate.GetPublicKeyString() + "\r\n";
                sCerts += "  - Valid Certificate [No policy errors] \r\n";
                sCerts += "- Validate Certificate \r\n"; 
                _Certificates += sCerts;
                return true;
            }

            // If thre are errors in the certificate chain, look at each error to determine the cause.
            if ((sslPolicyErrors & System.Net.Security.SslPolicyErrors.RemoteCertificateChainErrors) != 0)
            {
                sCerts += "  * [Remote Certificate Chain Errors Found]\r\n\r\n";
                if (chain != null && chain.ChainStatus != null)
                {
                    foreach (System.Security.Cryptography.X509Certificates.X509ChainStatus status in chain.ChainStatus)
                    {
                        if ((certificate.Subject == certificate.Issuer) &&
                           (status.Status == System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.UntrustedRoot))
                        {
                            
                            sCerts += "  + Validate Certificate [Self-signed certificates with an untrusted root - Considering as valid]\r\n";
                            sCerts += "    Status Information:   " + status.StatusInformation + "\r\n";
                            sCerts += "    Issuer:               " + certificate.Issuer + "\r\n";
                            sCerts += "    Subject:              " + certificate.Subject + "\r\n";
                            sCerts += "    EffectiveDateString:  " + certificate.GetEffectiveDateString() + "\r\n";
                            sCerts += "    ExpirationDate:       " + certificate.GetExpirationDateString() + "\r\n";
                            sCerts += "    Format:               " + certificate.GetFormat() + "\r\n";
                            sCerts += "    SerialNumber:         " + certificate.GetSerialNumberString() + "\r\n";
                            sCerts += "    RawCertData:          " + certificate.GetRawCertDataString() + "\r\n";
                            sCerts += "    PublicKey:            " + certificate.GetPublicKeyString() + "\r\n";
                            sCerts += "  - Validate Certificate [Self-signed certificates with an untrusted root - Considering as valid]\r\n";
                            //sCerts += "- Validate Certificate \r\n"; 
                            _Certificates += sCerts;
                            // Self-signed certificates with an untrusted root are valid. 
                            continue;
                        }
                        else
                        {
                            if (status.Status != System.Security.Cryptography.X509Certificates.X509ChainStatusFlags.NoError)
                            {
                     
                                sCerts += "  + Validate Certificate [Certificate Errors - Considering as invalid]\r\n" ;
                                sCerts += "    Status Information:   " + status.StatusInformation + "\r\n";
                                sCerts += "    Issuer:               " + certificate.Issuer + "\r\n";
                                sCerts += "    Subject:              " + certificate.Subject + "\r\n";
                                sCerts += "    EffectiveDateString:  " + certificate.GetEffectiveDateString() + "\r\n";
                                sCerts += "    ExpirationDate:       " + certificate.GetExpirationDateString() + "\r\n";
                                sCerts += "    Format:               " + certificate.GetFormat() + "\r\n";
                                sCerts += "    SerialNumber:         " + certificate.GetSerialNumberString() + "\r\n";
                                sCerts += "    RawCertData:          " + certificate.GetRawCertDataString() + "\r\n";
                                sCerts += "    PublicKey:            " + certificate.GetPublicKeyString() + "\r\n";
                                sCerts += "  - Validate Certificate \r\n"; 
                                _Certificates += sCerts;
                                // If there are any other errors in the certificate chain, the certificate is invalid,
                                // so the method returns false.
                                return false;
                            }
                        }
                    }
                }

                // When processing reaches this line, the only errors in the certificate chain are 
                // untrusted root errors for self-signed certifcates. These certificates are valid
                // for default Exchange server installations, so return true.
                _Certificates += "- Validate Certificate \r\n"; 
                return true;
            }
            else
            {
                // In all other cases, return false.
                _Certificates += "- Validate Certificate \r\n"; 
                return false;
            }
        }
    }

    class EwsRedirectLoggingCallbackHelper
    {
        //public delegate void AddressRedirectEventHandler(object sender, AddressRedirectEventArgs e);
        public NetworkCredential UseCredentials = null;
        public string AutodiscoveringAddress = string.Empty;
        
        public string _RedirectUrl = string.Empty;
        public string _RedirectEmailAddress = string.Empty;
        public bool _AddressRedirection = false;
        public bool _DoAddressRedirectWorkAround = false;
        private int RedirectionCount = 0;
        private int MaxRedirects = 5;

        public string _RedirectionUrls = string.Empty;
        public string _Certificates = string.Empty;

        public void ResetRedirects()
        {
            RedirectionCount = 0;
            _RedirectUrl = string.Empty;
            _RedirectEmailAddress = string.Empty;
            _AddressRedirection = false;
            _DoAddressRedirectWorkAround = false;
        }

 
        // http://msdn.microsoft.com/en-us/library/gg194011(v=exchg.140).aspx
        public bool RedirectionUrlValidationCallbackAllowAnything(string redirectionUrl)
        {
            bool result = false; // The default for the validation callback is to reject the URL.
            RedirectionCount++;
            string sRedirectEmailAddress = string.Empty;

            _RedirectionUrls += "Url: " + redirectionUrl + "   * Redirect Count: " + RedirectionCount.ToString() + "\r\n";

            if (_DoAddressRedirectWorkAround == true)
            {
                sRedirectEmailAddress = GetPossibleRedirectAddress(redirectionUrl);

                if (_RedirectEmailAddress != string.Empty)
                {
                    if (_RedirectEmailAddress != AutodiscoveringAddress)
                    {
                        _RedirectionUrls += "   * New address found in redirect: Address: \"" + _RedirectEmailAddress + "\"\r\n";
                        return false;
                    }
                }
            }

            if (RedirectionCount >= MaxRedirects)
            {
                _RedirectionUrls += "  !! Error - Maximum redirects reached (" + MaxRedirects.ToString() + ") Count is (" + RedirectionCount + ")  Next redirect is: " + redirectionUrl + "\r\n";
 
                return false;
            }
 
            Uri redirectionUri = new Uri(redirectionUrl);

            // Validate the contents of the redirection URL. In this simple validation
            // callback, the redirection URL is considered valid if it is using HTTPS
            // to encrypt the authentication credentials. 
            //if (redirectionUri.Scheme == "https")
            //{
            //    result = true;
            //}
            result = true;  // Allow all redirects - no matter what.

            // Note: the code below is for testing in capturing more info on the redirect.



            //if (RedirectEmailAddress != EamilAdressBeingAutodiscoverd)
            //{
            //    RedirectUrl = redirectionUrl;
            //}
 
            return result;
        }

        private string GetPossibleRedirectAddress(string RedirectionUrl)
        {
            _RedirectionUrls += "\r\n";
            _RedirectionUrls += "+ GetPossibleRedirectAddress - Checking for redirection mail address.\r\n";
            _RedirectionUrls += "\r\n";
            string sAddress = string.Empty;
            string sAction = string.Empty;
            string sRedirectAddr = string.Empty;

 
            _RedirectionUrls += "+ Test POST to redirect URL: " + RedirectionUrl + "\r\n";

            string sRequest = 
                "<Autodiscover xmlns=\"http://schemas.microsoft.com/exchange/autodiscover/outlook/requestschema/2006\">\r\n"+
                "  <Request> \r\n" +
                "    <EMailAddress>" + AutodiscoveringAddress + "</EMailAddress>\r\n" +
                "    <AcceptableResponseSchema>http://schemas.microsoft.com/exchange/autodiscover/outlook/responseschema/2006a</AcceptableResponseSchema>\r\n" +
                "  </Request>\r\n" +
                "</Autodiscover>\r\n";

            HttpWebRequest oHttpWebRequest = null;
            try
            {

                oHttpWebRequest = (HttpWebRequest)WebRequest.Create(RedirectionUrl);
                oHttpWebRequest.UseDefaultCredentials = false;
                oHttpWebRequest.Credentials = UseCredentials;

                oHttpWebRequest.AllowAutoRedirect = false;
                oHttpWebRequest.Method = "POST";
                oHttpWebRequest.Timeout = 15000;


                UTF8Encoding oUTF8Encoding = new UTF8Encoding();
                byte[] bRequest = oUTF8Encoding.GetBytes(sRequest);

                oHttpWebRequest.ContentType = "text/xml; charset=utf-8";
                oHttpWebRequest.Headers.Add("charset", "utf-8");
                oHttpWebRequest.ContentLength = bRequest.Length;
                Stream oReqStream = oHttpWebRequest.GetRequestStream();
                oReqStream.Write(bRequest, 0, bRequest.Length);
                oReqStream.Close();
            }
            catch (Exception exBuildRequest)
            {
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "!! Error building test request for Test POST to get redirection information.\r\n";
                _RedirectionUrls += "    Error: " + exBuildRequest.Message + "\r\n";
                _RedirectionUrls += "    InnerException: " + exBuildRequest.InnerException + "\r\n";
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "    StackTrace: " + exBuildRequest.StackTrace + "\r\n";
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "- GetPossibleRedirectAddress - Checking for redirection mail address.\r\n";
                _RedirectionUrls += "\r\n";
 
                return string.Empty;
            }

            HttpWebResponse oHttpWebResponse = null;
            try
            {
                oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();
            }
            catch (Exception exTestPost)
            {
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "!! Test POST to redirect URL failed.\r\n";
                _RedirectionUrls += "    Error: " + exTestPost.Message + "\r\n";
                _RedirectionUrls += "    InnerException: " + exTestPost.InnerException + "\r\n";
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "    StackTrace: " + exTestPost.StackTrace + "\r\n";
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "- GetPossibleRedirectAddress - Checking for redirection mail address.\r\n";
                _RedirectionUrls += "\r\n";
                return string.Empty;
            }

            try
            {
                StreamReader oStreamReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                string ResponseXml = oStreamReader.ReadToEnd();

                System.Xml.XmlDocument oXmlDocument = new XmlDocument();
                oXmlDocument.LoadXml(ResponseXml);

                sAction = GetXmlDocumentElement(oXmlDocument, "Action");
                sRedirectAddr = GetXmlDocumentElement(oXmlDocument, "RedirectAddr");

            }
            catch (Exception exTestPostResponse)
            {
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "!! Error extracting Test POST response.  \r\n";
                _RedirectionUrls += "    Error: " + exTestPostResponse.Message + "\r\n";
                _RedirectionUrls += "    InnerException: " + exTestPostResponse.InnerException + "\r\n";
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "    StackTrace: " + exTestPostResponse.StackTrace + "\r\n";
                _RedirectionUrls += "\r\n";
                _RedirectionUrls += "- GetPossibleRedirectAddress - Checking for redirection mail address.\r\n";
                _RedirectionUrls += "\r\n";
                return string.Empty;
            }

            if (sRedirectAddr != string.Empty)
            {
                _RedirectionUrls += "  + Redirection Email address found.\r\n";
                _RedirectionUrls += "    Action: " + sAction + "\r\n";
                _RedirectionUrls += "    RedirectAddr: " + sRedirectAddr + "\r\n";
                _RedirectionUrls += "  - Redirection Email address found.\r\n";
            }
            else
            {
                _RedirectionUrls += "  * Redirection Email address not found.\r\n";
            }
 
            _RedirectionUrls += "- Test POST to redirect URL: " + RedirectionUrl + "\r\n";
 


            if (sRedirectAddr != string.Empty)
            {
                _RedirectUrl = RedirectionUrl;
                _RedirectEmailAddress = sRedirectAddr;
                _AddressRedirection = true;
            }
            _RedirectionUrls += "\r\n";
            _RedirectionUrls += "- GetPossibleRedirectAddress - Checking for redirection mail address.";
            _RedirectionUrls += "\r\n";

            return sRedirectAddr;
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

    }
}
