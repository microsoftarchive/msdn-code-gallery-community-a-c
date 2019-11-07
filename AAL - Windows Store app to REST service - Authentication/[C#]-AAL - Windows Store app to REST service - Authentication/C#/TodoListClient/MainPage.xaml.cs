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

using Microsoft.Preview.WindowsAzure.ActiveDirectory.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Windows.Data.Json;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace TodoListClient
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Domain name or Tenant name
        const string domainName = "[Your domain name. Example: contoso.onmicrosoft.com]";

        // Client app information
        const string clientID = "[Your client id. Example: de119d9a-c0b9-4ac0-b794-ca82e9d7dcd4]";

        // Resource information
        const string resourceAppIDUri = "[Your service application Uri. Example: http://localhost:40316/]";
        const string resourceBaseAddress = "[The base address at which your service can be reached. Example: http://localhost:40316/]";


        private HttpClient httpClient = new HttpClient();

        // Initialize the AuthenticationContext by providing the tenant authority endpoint. By default, address validation
        // of the authority endpoint is on. 
        private AuthenticationContext authenticationContext = new AuthenticationContext("https://login.windows.net/" + domainName);

        public MainPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.  The Parameter
        /// property is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            GetTodoList();
        }

        // Get the current user's todo items
        private async void GetTodoList()
        {
            HttpResponseMessage response;

            // Acquire a token from AAL. AAL will cache the authorization state in a persistent cache.
            AuthenticationResult result = await authenticationContext.AcquireTokenAsync(resourceAppIDUri, clientID);

            // Verify that an access token was successfully acquired
            if (AuthenticationStatus.Succeeded != result.Status)
            {
                DisplayErrorWhenAcquireTokenFails(result);
                return;
            }

            // Once the token has been returned by AAL, add it to the http authorization header, before making the call to access
            // the resoruce service.
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

            // Call the todolist web api
            response = await httpClient.GetAsync(resourceBaseAddress + "/api/todolist");

            // Verify the call to the todo list service succeeded
            if (response.IsSuccessStatusCode)
            {
                // Read the response as a Json Array and databind to the GridView to display todo items
                var todoArray = JsonArray.Parse(await response.Content.ReadAsStringAsync());

                TodoList.ItemsSource = from todo in todoArray
                                       select new
                                       {
                                           Title = todo.GetObject()["Title"].GetString()
                                       };
            }
            else
            {
                DisplayErrorWhenCallingResourceServiceFails(response.StatusCode);
            }
        }

        // Add a new todo item
        private async void Button_Click_Add_Todo(object sender, RoutedEventArgs e)
        {
            // Acquire a token from AAL. AAL will cache the authorization state.
            AuthenticationResult result = await authenticationContext.AcquireTokenAsync(resourceAppIDUri, clientID);

            // Verify that an access token was successfully acquired
            if (AuthenticationStatus.Succeeded != result.Status)
            {
                DisplayErrorWhenAcquireTokenFails(result);
                return;
            }

            // Once the token has been returned by AAL, add it to the http authorization header, before making the call to access
            // the resoruce service.
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", result.AccessToken);

            // Forms encode todo item, to POST to the todo list web api
            HttpContent content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("Title", TodoText.Text) });

            // Call the todolist web api
            var response = await httpClient.PostAsync(resourceBaseAddress + "/api/todolist", content);

            if (response.IsSuccessStatusCode)
            {
                TodoText.Text = "";
                GetTodoList();
            }
            else
            {
                DisplayErrorWhenCallingResourceServiceFails(response.StatusCode);
            }
        }

        // Clear the authorization state in the application
        private void HyperlinkButton_Click_Remove_Account(object sender, RoutedEventArgs e)
        {
            // Clear session state from the token cache
            (AuthenticationContext.TokenCache as DefaultTokenCache).Clear();

            // Reset UI elements
            TodoList.ItemsSource = null;
            TodoText.Text = "";
        }

        // Displays appropriate error when acquiring a token fails
        private async void DisplayErrorWhenAcquireTokenFails(AuthenticationResult result)
        {
            MessageDialog dialog;

            switch (result.Error)
            {
                case "authentication_canceled":
                    // User cancelled, no need to display a message
                    break;

                case "temporarily_unavailable":

                case "server_error":
                    dialog = new MessageDialog("Please retry the operation. If the error continues, please contact your administrator.", "Sorry, an error has occurred.");
                    await dialog.ShowAsync();
                    break;

                default:
                    // An error occurred when acquiring a token, show the error description in a MessageDialog                     
                    dialog = new MessageDialog(string.Format("If the error continues, please contact your administrator.\n\nError: {0}\n\n Error Description:\n\n{1}", result.Error, result.ErrorDescription), "Sorry, an error has occurred.");
                    await dialog.ShowAsync();
                    break;
            }
        }

        // Displays appropriate error when calling a resource service fails
        private async void DisplayErrorWhenCallingResourceServiceFails(HttpStatusCode statuscode)
        {
            MessageDialog dialog;

            switch (statuscode)
            {
                case HttpStatusCode.Unauthorized:

                    // An unauthorized error occurred, indicating the security token provided did not satisfy the service requirements
                    // acquiring a new token may fix the issue, this requires clearing state in the AAL cache.                    // 
                    dialog = new MessageDialog("Would you like to reset your connection? This may help fix the problem.", "Sorry, accessing your todo list has hit a problem.");

                    dialog.Commands.Add(new UICommand("Yes", (c) =>
                    {
                        (AuthenticationContext.TokenCache as DefaultTokenCache).Clear();
                        GetTodoList();
                    }));

                    dialog.Commands.Add(new UICommand("No"));

                    await dialog.ShowAsync();
                    break;

                default:
                    dialog = new MessageDialog("If the error continues, please contact your administrator.”, “Sorry, an error has occurred.");
                    await dialog.ShowAsync();
                    break;
            }
        }
    }
}
