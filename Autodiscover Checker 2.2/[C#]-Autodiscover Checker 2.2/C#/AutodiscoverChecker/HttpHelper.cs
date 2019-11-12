using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Net;
using System.IO;

namespace AppHelpers
{
    public class HttpPosts
    {

        public static bool RawPost(string sUrl, string sBody, int iTimeoutSeconds, ref string sResult, ref string sError, ref string sResponseStatusCode, ref string sResponseStatusDescription)
        {
            string sRet = string.Empty;
            bool bSuccess = true;

            sResult = string.Empty;
            sError = string.Empty;
            sResponseStatusCode = string.Empty;
            sResponseStatusDescription = string.Empty;

            HttpWebResponse oHttpWebResponse = null;
            HttpWebRequest oHttpWebRequest = null;
            Stream   oStream  = null;
            StreamReader oStreamReader = null;

            byte[] bytes = Encoding.UTF8.GetBytes(sBody); 

 
            try
            {
                //oHttpWebRequest = (HttpWebRequest)WebRequest.Create(sUrl.Replace("LDAP:", "http:"));
                oHttpWebRequest = (HttpWebRequest)WebRequest.Create(sUrl);
                oHttpWebRequest.Method = "POST";
                oHttpWebRequest.ContentType = "text/xml";
                oHttpWebRequest.ContentLength = bytes.Length;

                oHttpWebRequest.Timeout = 1000 * iTimeoutSeconds;  
                //oHttpWebRequest.Credentials = CredentialCache.DefaultCredentials;
                oHttpWebRequest.Credentials = CredentialCache.DefaultNetworkCredentials;
                oHttpWebRequest.PreAuthenticate = true;


                oStream = oHttpWebRequest.GetRequestStream() ;
                oStream .Write(bytes, 0, bytes.Length);
                oStream .Close(); 

                oHttpWebResponse = (HttpWebResponse)oHttpWebRequest.GetResponse();

                oStreamReader = new StreamReader(oHttpWebResponse.GetResponseStream());
                sResponseStatusCode = oHttpWebResponse.StatusCode.ToString();
                sResponseStatusDescription = oHttpWebResponse.StatusDescription;
                 
                
                sResult = oStreamReader.ReadToEnd();
            }
            catch (Exception ex)
            {
                sError += "!!Error: " + ex.Message + "\r\n";
                sError += "    Message: " + ex.Message + "\r\n";
                sError += "    InnerException: " + ex.InnerException + "\r\n";
                sError += "\r\n";
                sError += "    StackTrace: " + ex.StackTrace + "\r\n";

                bSuccess = false;

            }
            finally
            {
               // oStream.Close();
                oStream = null;
            }


            return bSuccess;

            //    CredentialCache cache = new CredentialCache(); 
            //cache.Add(new NetworkCredential("username", "password", "domain"); 
            //req.Credentials = cache; 
            //WebResponse resp = req.GetResponse();  


        }
    }

}
