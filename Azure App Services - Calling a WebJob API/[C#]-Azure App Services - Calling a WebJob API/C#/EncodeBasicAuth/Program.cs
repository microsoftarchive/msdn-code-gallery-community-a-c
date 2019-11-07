using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace EncodeBasicAuth
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //App Service Publish Profile Credentials
                string userName = "userName"; //userName
                string userPassword = "userPWD"; //userPWD

                //change webJobName to your WebJob name
                string webJobName = "WEBJOBNAME";

                var unEncodedString = String.Format($"{userName}:{userPassword}");
                var encodedString = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(unEncodedString));
                //WriteLine(encodedString);

                //Decodes the string just for fun...this is why you must always use HTTPS with basic
                //string authorizationHeader = encodedString;
                //var beginPasswordIndexPosition = authorizationHeader.IndexOf(" ") + 1;
                //var encodedAuth = authorizationHeader.Substring(beginPasswordIndexPosition);
                //var decodedAuth = Encoding.UTF8.GetString(Convert.FromBase64String(encodedAuth));
                //WriteLine(decodedAuth);

                //Change this URL to your WebApp hosting the 
                string URL = "https://?.scm.azurewebsites.net/api/triggeredwebjobs/" + webJobName + "/run";
                System.Net.WebRequest request = System.Net.WebRequest.Create(URL);
                request.Method = "POST";
                request.ContentLength = 0;
                request.Headers["Authorization"] = "Basic " + encodedString;
                System.Net.WebResponse response = request.GetResponse();
                System.IO.Stream dataStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                reader.Close();
                response.Close();
                Console.WriteLine("OK");  //no response
                ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }

        }
    }
}
