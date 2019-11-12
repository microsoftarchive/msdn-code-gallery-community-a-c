// =====================================================================
//  This file is part of the Microsoft Dynamics CRM SDK code samples.
//
//  Copyright (C) Microsoft Corporation.  All rights reserved.
//
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
//
//  THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
// =====================================================================

using CRMtoGo.Pages;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CRMtoGo.Common
{
    /// <summary>
    /// Util class has helper methods which depend on each platform. Therefore you need
    /// separate Util class for each platform. This Util is for Windows/Windows Phone.
    /// </summary>
    static public class Util
    {
        #region Caching data locally

        // current application folder
        static private StorageFolder localFolder = ApplicationData.Current.LocalFolder;

        /// <summary>
        /// Cache data locally
        /// </summary>
        /// <param name="content">object to be cached</param>
        /// <param name="filename">file name for cache</param>
        /// <returns></returns>
        static public async Task SaveToLocal(object content, string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return;
            StorageFile File = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

            if (content.GetType().Equals(typeof(string)))
            {
                await FileIO.WriteTextAsync(File, content.ToString());
                return;
            }

            //DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, object>), SuspensionManager._knownTypes);
            using (Stream stream = await File.OpenStreamForWriteAsync())
            {
                serializer.WriteObject(stream, content);
            }
        }

        /// <summary>
        /// Restore from cached data
        /// </summary>
        /// <typeparam name="T">object type of the cached data</typeparam>
        /// <param name="filename">cached file name</param>
        /// <returns></returns>
        static public async Task<object> ReadFromLocal<T>(string filename)
        {
            if (string.IsNullOrEmpty(filename))
                return default(T);
            T result;
            StorageFile file;
            var data = await localFolder.GetFilesAsync();
            try
            {
                file = await localFolder.GetFileAsync(filename);
            }
            catch(Exception ex)
            {
                return null;
            }

            if (typeof(T) == typeof(string))
            {
                return await FileIO.ReadTextAsync(file);                
            }

            //DataContractSerializer serializer = new DataContractSerializer(typeof(T));
            DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<string, object>), SuspensionManager._knownTypes);

            try
            {
                using (Stream stream = await localFolder.OpenStreamForReadAsync(filename))
                {
                    result = (T)serializer.ReadObject(stream);
                }
            }
            catch (Exception ex)
            {
                return default(T);
            }

            return result;
        }

        /// <summary>
        /// Delete local cache
        /// </summary>
        /// <param name="filename">Specify file name to be deleted. If no file name specified, 
        /// then delete all cache.</param>
        /// <returns></returns>
        static public async Task DeleteLocalCache(string filename = null)
        {
            // If file name specified
            if(!string.IsNullOrEmpty(filename))
            {
                // delete specified file
                var file = await localFolder.GetFileAsync(filename);
                await file.DeleteAsync();
                return;
            }
            // otherwise, delete all
            var files = await localFolder.GetFilesAsync();
            foreach (var file in files)
            {
                await file.DeleteAsync();
            }
        }

        #endregion

        #region Show messages

        static public async Task ShowMessage(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }

        static public async Task<bool> ShowConfirmMessage(string message, string yes, string no, uint DefaultCommandIndex)
        {
            // Create Message with Yes/No
            MessageDialog dialog = new MessageDialog(message);
            dialog.Commands.Add(new UICommand(yes));
            dialog.Commands.Add(new UICommand(no));
            dialog.DefaultCommandIndex = DefaultCommandIndex;
            // Set cancel to No button
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
           
            // Return result
            if (result.Label == yes)
                return true;
            else
                return false;
        }

        #endregion

        #region Background Task Registration

        // Following section code is from http://msdn.microsoft.com/en-us/library/windows/apps/xaml/JJ553413(v=win.10).aspx
        // Register a background task with the specified taskEntryPoint, name, trigger,
        // and condition (optional).
        //
        // taskEntryPoint: Task entry point for the background task.
        // taskName: A name for the background task.
        // trigger: The trigger for the background task.
        // condition: Optional parameter. A conditional event that must be true for the task to fire.
        static public async System.Threading.Tasks.Task<BackgroundTaskRegistration>
            RegisterBackgroundTask(string taskEntryPoint, string taskName, IBackgroundTrigger trigger, IBackgroundCondition condition)
        {
            var result = await BackgroundExecutionManager.RequestAccessAsync();

            // Check for existing registrations of this background task.
            foreach (var cur in BackgroundTaskRegistration.AllTasks)
            {
                if (cur.Value.Name == taskName)
                {
                    // The task is already registered.
                    return (BackgroundTaskRegistration)(cur.Value);
                }
            }

            // Register the background task.
            var builder = new BackgroundTaskBuilder();

            builder.Name = taskName;
            builder.TaskEntryPoint = taskEntryPoint;
            builder.SetTrigger(trigger);

            if (condition != null)
            {
                builder.AddCondition(condition);
            }

            BackgroundTaskRegistration task = builder.Register();

            return task;
        }

        #endregion

        #region ADAL for Windows 8.1/Windows Phone 8.1

        static public AuthenticationContext authContext = null;

        /// <summary>
        /// This method try to obtain AccessToken by using OAuth2 authentication agianst Microsoft Azure AD.
        /// </summary>
        static public async Task GetTokenSilent()
        {
            // Before create AuthenticationContext, check if Authority(OAuthUrl) is available.
            if (String.IsNullOrEmpty(CRMHelper.OAuthUrl))
            {
                bool success = true;
                try
                {
                    await CRMHelper.DiscoveryAuthority();
                }
                catch (Exception ex)
                {
                    // If failed to retireve OAuthUrl, then make success as false
                    success = false;
                }

                // If failed to retrieve OAuthUrl, chances are user mistype ServerUrl.
                if (!success)
                {
                    MessageDialog dialog = new MessageDialog("OAuth Url retrieve failed. Please check Service URL again.");
                    await dialog.ShowAsync();
                    return;
                }
            }

            if (CRMHelper.SignOut)
            {
                if (authContext != null)
                    authContext.TokenCache.Clear();
                CRMHelper.SignOut = false;
            }

            // Create AuthenticationContext by using OAuthUrl.
            if (authContext == null)
                authContext = await AuthenticationContext.CreateAsync(CRMHelper.OAuthUrl);

            // Try to acquire token without prompting user first.
            AuthenticationResult result = await authContext.AcquireTokenSilentAsync(CRMHelper.ResourceName, CRMHelper.ClientId);

            // Check the result.
            if (result != null && result.Status == AuthenticationStatus.Success)
            {
                // A token was successfully retrieved. Then store it.
                StoreToken(result);
            }
            // If failed to obtain token without prompting, then prompt user for credentials
            else
            {
                // Clear AccessToken 
                CRMHelper._proxy.AccessToken = "";
                // In case credential was wrong, clear the token cache first.
                authContext.TokenCache.Clear();
                // Acquiring a token without user interaction was not possible. 
                // Trigger an authentication experience and specify that once a token has been obtained the StoreToken method should be called.
                authContext.AcquireTokenAndContinue(CRMHelper.ResourceName, CRMHelper.ClientId, new Uri(CRMHelper.RedirectUri), StoreToken);
            }
        }

        /// <summary>
        /// This mothod called when ADAL obtained AccessToken
        /// </summary>
        /// <param name="result"></param>
        static public void StoreToken(AuthenticationResult result)
        {
            if (result.Status == AuthenticationStatus.Success)
            {
                // Pass the obtained AccessToken.
                CRMHelper._proxy.AccessToken = result.AccessToken;
            }
            else
            {
               DisplayErrorWhenAcquireTokenFails(result);
            }
        }

        /// <summary>
        /// This method called when user navigate back to appication after ADAL authentication page.
        /// </summary>
        /// <param name="args"></param>
        static public async void ContinueWebAuthentication(WebAuthenticationBrokerContinuationEventArgs args)
        {
            // pass the authentication interaction results to ADAL, which will conclude the token acquisition operation and invoke the callback specified in AcquireTokenAndContinue.
            await authContext.ContinueAcquireTokenAsync(args);
        }

        /// <summary>
        /// This is helper method to display error detail.
        /// </summary>
        /// <param name="result"></param>
        static private async void DisplayErrorWhenAcquireTokenFails(AuthenticationResult result)
        {
            MessageDialog dialog;

            switch (result.Error)
            {
                case "authentication_canceled":
                    // User cancelled, so no need to display a message.
                    break;
                case "temporarily_unavailable":
                case "server_error":
                    dialog = new MessageDialog("Please retry the operation. If the error continues, please contact your administrator.", "Sorry, an error has occurred.");
                    await dialog.ShowAsync();
                    break;
                default:
                    // An error occurred when acquiring a token. Show the error description in a MessageDialog. 
                    dialog = new MessageDialog(string.Format("If the error continues, please contact your administrator.\n\nError: {0}\n\nError Description:\n\n{1}", result.Error, result.ErrorDescription), "Sorry, an error has occurred.");
                    await dialog.ShowAsync();
                    break;
            }
        }

        /// <summary>
        /// This method ensures AccessToken is valid. The reason why you need to this method is
        /// that when GetTokenSlient failed, the method released synchronization and does AndConitnue
        /// pattern, which let main thread execute. In that case, service may execute with invalid 
        /// AccessToken. This method ensures it waits until AccessToken aquired.
        /// </summary>
        /// <returns></returns>
        static public async Task EnsureToken()
        {
            // Make sure AccessToken is valid.
            await Util.GetTokenSilent();

            // Wait until AccessToken assigned
            while (String.IsNullOrEmpty(CRMHelper._proxy.AccessToken))
            {
                await System.Threading.Tasks.Task.Delay(10);
            }
        }

        #endregion
    }
}
