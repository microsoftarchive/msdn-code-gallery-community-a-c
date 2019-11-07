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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using Microsoft.IdentityModel.Clients.ActiveDirectory;

namespace ToDoListClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int INTERNET_OPTION_END_BROWSER_SESSION = 42;

        // AAD or ADFS authority, ex: https://login.windows.net/treyresearch.onmicrosoft.com  
        // Set the authority to https://login.windows.net/common to defer choosing the AAD domain till the user signs in.
        // It is set to string.Empty here as we are going to get the value of authority from the RP, TodoListService, through 401 discovery.
        static string authority = string.Empty;

        // Client information
        static Uri redirectUri = new Uri("http://TodoListClient");

        static string clientId = "[client id ex: 5475e85d-ba2e-495d-a612-3e176e227c06]";

        // Along with authority, we are going to get the value of resourceAppIdUri from the RP, TodoListService.     
        static string resourceAppIdUri = string.Empty;
        static Uri resourceBaseAddress = new Uri("https://localhost:44300/");

        static AuthenticationContext _authenticationContext;

        public MainWindow()
        {
            try
            {
                // Use AuthenticationParameters to send a request to the RP and receive tenant information in the 401 challenge.
                AuthenticationParameters parameters = AuthenticationParameters.CreateFromResourceUrl(new Uri(resourceBaseAddress + "api/todoList"));

                authority = parameters.Authority;

                // validate resourceId that is obtained in a 401 challenge out of band to mitigate attacks from a malicious RP impersonating as a valid RP.
                // here we are doing a sanity check by verifying that the resourceId is bound to the physical address of the resource
                if (parameters.Resource.Contains(resourceBaseAddress.Host))
                {
                    resourceAppIdUri = parameters.Resource;
                }
                else
                {
                    throw new Exception(string.Format("The resource obtained in 401 challenge, {0}, is not bound to the resource's physical address, {1}", parameters.Resource, resourceBaseAddress));
                }

                // Initialize the AuthenticationContext by providing the tenant authority endpoint. 
                // By default, address validation of the authority endpoint is on. Always validate the tenant endpoint that's received in 401 challenge.
                // CredManCache is a custom cache that uses windows Credential Manager to manage the token cache.
                // When the authority is ADFS, apps must do authority validation out of band, so pass false as the second parameter in the below constructor.
                _authenticationContext = new AuthenticationContext(authority, new CredManCache());
            }
            catch (WebException e)
            {
                MessageBox.Show("401 discovery failed ", e.Message);
                return;
            }

            InitializeComponent();
        }

        void AddToDoItem(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(ToDoText.Text))
            {
                MessageBox.Show("Please enter a value for the to-do item name");
                return;
            }

            string authorizationHeader = GetAuthorizationHeader();

            if (authorizationHeader == null)
            {
                return;
            }

            try
            {
                ToDoItem item = new ToDoItem();
                item.Title = ToDoText.Text;

                // Call the ToDoListService
                GetResponseFromService("POST", authorizationHeader, item);

                ToDoText.Text = "";
                GetToDoList();
            }
            catch (WebException ex)
            {
                DisplayError(((HttpWebResponse)(ex.Response)).StatusCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.Message));
            }
        }

        void GetToDoList()
        {
            string authorizationHeader = GetAuthorizationHeader();

            if (authorizationHeader == null)
            {
                return;
            }
            try
            {
                HttpWebResponse response = GetResponseFromService("GET", authorizationHeader, null);

                // Read the response and databind to the GridView to display ToDo items
                string s = new StreamReader(response.GetResponseStream()).ReadToEnd();

                JavaScriptSerializer serializer = new JavaScriptSerializer();
                List<ToDoItem> toDoArray = serializer.Deserialize<List<ToDoItem>>(s);

                ToDoList.ItemsSource = toDoArray.Select(t => new { t.Title });
            }
            catch (WebException ex)
            {
                DisplayError(((HttpWebResponse)(ex.Response)).StatusCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show((ex.Message));
            }
        }

        HttpWebResponse GetResponseFromService(string httpRequestMethod, string authorizationHeader, ToDoItem item)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(resourceBaseAddress + "/api/todolist");
            request.Method = httpRequestMethod;
            request.ContentType = "application/json";

            // add the access token to the http authorization header on the call to access the resource.                      
            request.Headers["Authorization"] = authorizationHeader;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            if (item != null)
            {
                string content = serializer.Serialize(item);

                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(Encoding.UTF8.GetBytes(content), 0, content.Length);
                }
            }

            // Call the TodoListService
            return (HttpWebResponse)request.GetResponse();
        }

        /// <summary>
        /// Returns a http authorization header containing the access token 
        /// </summary>
        /// <returns></returns>
        string GetAuthorizationHeader()
        {
            AuthenticationResult authenticationResult = null;

            try
            {
                authenticationResult = _authenticationContext.AcquireToken(resourceAppIdUri, clientId, redirectUri);

                ClearCacheButton.IsEnabled = true;

                return authenticationResult.CreateAuthorizationHeader();
            }
            catch (ActiveDirectoryAuthenticationException ex)
            {
                string message = ex.Message;

                if (ex.InnerException != null)
                {
                    message += "InnerException : " + ex.InnerException.Message;
                }

                MessageBox.Show(message);
            }

            return null;
        }

        void DisplayError(HttpStatusCode statusCode)
        {
            switch (statusCode)
            {
                case HttpStatusCode.Unauthorized:
                    {
                        // An unauthorized error occurred, indicating the security token provided did not satisfy the service requirements
                        // acquiring a new token may fix the issue.   
                        MessageBoxResult result = MessageBox.Show("Would you like to clear the cache and reauthenticate? This may help fix the problem.", "Sorry, accessing your todo list has hit a problem.", MessageBoxButton.OKCancel);

                        if (result == MessageBoxResult.OK)
                        {
                            ClearCache();
                            GetToDoList();
                        }
                    }
                    break;
                default:
                    MessageBox.Show("Sorry, accessing your ToDo list has hit a problem.");
                    break;
            }
        }

        void ClearCache(object sender = null, RoutedEventArgs args = null)
        {
            ClearCacheButton.IsEnabled = false;
            ToDoList.ItemsSource = string.Empty;

            _authenticationContext.TokenCacheStore.Clear();

            // in the case of ADFS, uncomment ClearCookies() to delete ADFS session cookies
            // otherwise, during the next AcquireToken() call, ADFS will use the session cookie for authentication.
            // ClearCookies();
        }

        public void ClearCookies()
        {
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
        }

        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);
    }
}
