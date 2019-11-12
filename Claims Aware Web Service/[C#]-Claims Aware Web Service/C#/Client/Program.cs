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

using Client.ServiceReference1;
using System;
using System.ServiceModel;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the client for the service
            ClaimsAwareWebServiceClient client = new ClaimsAwareWebServiceClient();
            Console.WriteLine("-------------WCF Client Application--------------\n");

            while (!ShouldQuitApplication())
            {
                try
                {
                    Console.WriteLine(client.ComputeResponse("Hello World"));
                }
                catch (CommunicationException e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    Exception ex = e.InnerException;
                    while (ex != null)
                    {
                        Console.WriteLine("===========================");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        ex = ex.InnerException;
                    }
                }
                catch (TimeoutException)
                {
                    Console.WriteLine("Timed out...");
                }
                catch (Exception e)
                {
                    // For illustrative purposes only the sample code captures generic exceptions. 
                    // It is highly recommended that error messages should be explicitly trapped before used in production.
                    Console.WriteLine("An unexpected exception occured.");
                    Console.WriteLine(e.StackTrace);
                }
            }

            client.Close();

            if (client != null)
            {
                client.Abort();
            }
        }

        static bool ShouldQuitApplication()
        {
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("Press Enter key to invoke service, any other key to quit application:");
            Console.WriteLine("----------------------------------------------------------------------");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == ConsoleKey.Enter)
                return false;
            return true;
        }
    }
}

