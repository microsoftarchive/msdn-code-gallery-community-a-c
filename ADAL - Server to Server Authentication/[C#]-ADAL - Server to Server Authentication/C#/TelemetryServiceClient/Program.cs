//----------------------------------------------------------------------------------------------
//    Copyright 2013 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
//----------------------------------------------------------------------------------------------


namespace Microsoft.Samples.Adal.TelemetryServiceClient
{
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System;
    using System.Configuration;
    using System.Globalization;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading;

    public class DeviceClient
    {
        const int StatusRefreshTime = 10;  // time in secs
        private static int RetryDelay = 0; //Counter for retry delay

        private AuthenticationContext authenticationContext;
        private AuthenticationResult authenticationResult;

        string clientId = ConfigurationManager.AppSettings["ClientId"];
        string clientSecret = ConfigurationManager.AppSettings["ClientSecret"];
        string resource = ConfigurationManager.AppSettings["AppIdUri"];
        string resourceurl = ConfigurationManager.AppSettings["ResourceUrl"];

        public DeviceClient()
        {
            // Create an ADAL AuthenticationContext object and link it to the tenant backing the Telemetry Service
            authenticationContext = new AuthenticationContext(ConfigurationManager.AppSettings["Tenant"]);

        }

        static void Main()
        {
            DeviceClient monitor = new DeviceClient();
            monitor.MonitorClient();
        }

        public void MonitorClient()
        {

            using (HttpClient httpClient = new HttpClient())
            {
                // Add an Accept header for JSON format.
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Initialize DriveInfo for C Drive
                DriveInfo driveInfo = new DriveInfo(@"C:");

                Console.WriteLine("******************************************************************************");
                Console.WriteLine("This console monitors the Telemetry Service for all past device Memory availability updates every {0} seconds.", StatusRefreshTime);
                Console.WriteLine("******************************************************************************");
                do
                {
                    try
                    {
                        //Client Cerdential Object used while Acquiring a token from Windows Azure AD
                        ClientCredential clientCred = new ClientCredential(clientId, clientSecret);

                        // Invoke AuthenticationContext.AcquireToken to obtain an AccessToken to access the Telemetry service. 
                        // Uses previously-created ClientCredential to authenticate
                        authenticationResult = authenticationContext.AcquireToken(resource, clientCred);
                        RetryDelay = 0;
                    }
                    catch (ActiveDirectoryAuthenticationException ex)
                    {
                        authenticationResult = null;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Acquiring a token failed with the following error: {0}", ex.Message);
                        // You should implement retry and back-off logic per the guidance given here:http://msdn.microsoft.com/en-us/library/dn168916.aspx
                        // InnerException Message will contain the HTTP error status codes mentioned in the link above
                        Console.ResetColor();
                        RetryDelay++;
                        if (ex.InnerException is WebException)
                        {
                            HttpWebResponse response = (HttpWebResponse)((WebException)ex.InnerException).Response;
                            //Sample retry to logic that retries 5 times with the delay between retries increasing exponentially, you should customize the retry logic per the requirements of your specific scenario
                            if (response != null)
                            {
                                int HttpStatusCode;
                                HttpStatusCode = (int)response.StatusCode;
                                if (HttpStatusCode >= 500 && HttpStatusCode < 600 && (RetryDelay < 6))
                                {
                                    Console.WriteLine("Error detail: {0}", ex.InnerException.Message);
                                    Thread.Sleep((3 ^ RetryDelay) * 1000);
                                }
                                else
                                {
                                    Console.WriteLine("The client or tenant has configuration issues you might want to work with your Admin or client app developer, Error detail: {0}", ex.InnerException.Message);
                                    break;
                                }
                            }
                        }
                    }
                    if (authenticationResult != null)
                    {
                        try
                        {
                            httpClient.DefaultRequestHeaders.Clear();
                            //Add authorization header to HttpClient
                            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authenticationResult.AccessToken);
                            var deviceUpdate = new Device() { Name = "Device1", Memory = driveInfo.AvailableFreeSpace.ToString(CultureInfo.InvariantCulture), TimeStamp = DateTime.UtcNow.ToString() };

                            // Call the TelemetryService web api to update device status
                            HttpResponseMessage response = httpClient.PostAsJsonAsync(resourceurl + "api/devices", deviceUpdate).Result;

                            if (response.IsSuccessStatusCode)
                            {
                                //Print updated status on client console
                                Console.WriteLine("{0}\t{1}\t{2}", deviceUpdate.Name, deviceUpdate.Memory, deviceUpdate.TimeStamp);
                            }
                            else
                            {
                                Console.WriteLine("{0}\t{1}\n", (int)response.StatusCode, response.StatusCode);
                            }

                            Console.WriteLine("******************************************************************************");
                        }
                        catch (HttpRequestException ex)
                        {
                            httpClient.Dispose();
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error getting information from the Telemetry Service. {0}", ex.Message);
                            Console.ResetColor();
                        }
                    }
                    if (!Console.KeyAvailable)
                    {
                        Thread.Sleep(StatusRefreshTime * 1000);
                    }
                } while (!Console.KeyAvailable);
            }
        }
    }
}
