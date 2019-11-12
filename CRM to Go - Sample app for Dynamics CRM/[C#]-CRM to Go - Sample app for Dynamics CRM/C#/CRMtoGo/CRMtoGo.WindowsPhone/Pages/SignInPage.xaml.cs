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

using CRMtoGo.Common;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// See http://www.cloudidentity.com/blog/2014/06/16/adal-for-windows-phone-8-1-deep-dive for ADAL for Windows Phone 8.1 detail.

namespace CRMtoGo.Pages
{
    /// <summary>
    /// SignIn page. Inherit IWebAuthenticationContinueable to use ADAL
    /// </summary>
    public sealed partial class SignInPage : Page, IWebAuthenticationContinuable
    {
        #region Class Property

        // Instantiate ResourceLoader to load strings for label
        private ResourceLoader loader = new ResourceLoader();

        #endregion

        /// <summary>
        /// Constructor for the Page
        /// </summary>
        public SignInPage()
        {
            this.InitializeComponent();

            // As this page only shows when user need to login, do not cache.
            this.NavigationCacheMode = NavigationCacheMode.Disabled;
            this.navigationHelper = new NavigationHelper(this);

            // Change SignIn Button IsEnabled depending on serverurl value
            this.btnSignIn.IsEnabled = (txtServerUrl.Text.Contains(".")) ? true : false;
            // Collapse downloading message.
            this.txtMessage.Visibility = Visibility.Collapsed;
        }

        #region Navigation

        private NavigationHelper navigationHelper;

        /// <summary>
        /// This method called when user navigated to this page. e.Parameter contains parameter object which 
        /// user passes when navigating to this page. 
        /// </summary>
        /// <param name="e"></param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            ShowProgressRing(true);
            this.navigationHelper.OnNavigatedTo(e);

            // if parameter is passed as bool, and that is true, then user want to SignOut
            if (e.Parameter != null && e.Parameter.GetType().Equals(typeof(bool)) && (bool)e.Parameter)
            {
                CRMHelper.SignOut = true;
            }

            // Restore Server Url from cache.
            string serverUrl = (string)await Util.ReadFromLocal<string>("serverUrl.dat");

            // If serverUrl is not null, then user simply clear the cache
            if (!String.IsNullOrEmpty(serverUrl) && serverUrl != "https://")
            {
                // Restore server URL
                txtServerUrl.Text = serverUrl;
                SignIn();       
            }
            // if serverUrl is not cached then show initial screen.
            else
            {
                txtServerUrl.Text = "https://";
                // As server address may change, reset OauthURL as well.
                CRMHelper.OAuthUrl = null;
                ShowProgressRing(false);
            }                        
        }

        /// <summary>
        /// This metohd called when user navigate away from the page.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        #region ADAL for Windows Phone 8.1

        /// <summary>
        /// This method called when user navigate back to appication after ADAL authentication page.
        /// </summary>
        /// <param name="args"></param>
        public void ContinueWebAuthentication(WebAuthenticationBrokerContinuationEventArgs args)
        {
            // pass the authentication interaction results to ADAL, which will conclude the token acquisition operation and invoke the callback specified in AcquireTokenAndContinue.
            Util.ContinueWebAuthentication(args);
        }

        #endregion

        #region Page methods

        /// <summary>
        /// Initialize and Obtain AccessToken
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            SignIn();
        }

        private async void SignIn()
        {
            ShowProgressRing(true);

            // First of all, try to get OAuth URL by using specified ServerUrl
            try
            {
                await CRMHelper.DiscoveryAuthority();
            }
            catch (Exception ex)
            {
                // If failed, then simply go back to page without doing anything more.
                ShowProgressRing(false);
                return;
            }

            // Assing ServerUrl, ResourceName to CRMHelper._proxy
            CRMHelper._proxy.ServiceUrl = CRMHelper.ResourceName = txtServerUrl.Text;

            // Cache ServerUrl
            await Util.SaveToLocal(txtServerUrl.Text, "serverUrl.dat");

            // Register background task. 
            await Util.RegisterBackgroundTask("CRMtoGoBackgroundTasks.UpdateSystemUserTimeZone",
                "UpdateSystemUserTimeZone",
                new SystemTrigger(SystemTriggerType.TimeZoneChange, false),
                new SystemCondition(SystemConditionType.InternetAvailable));

            // Initialize CRMHelper
            await CRMHelper.Initialize();

            Frame.Navigate(typeof(Home));
            // To prevent user from back to this page by pressing back button, remove this page history from Navigation history
            Frame.BackStack.RemoveAt(Frame.BackStackDepth - 1);
        }

        /// <summary>
        /// Show ProgressRing and hide others.
        /// </summary>
        /// <param name="show"></param>
        public void ShowProgressRing(bool show)
        {
            progressRing.IsActive = show;
            txtMessage.Visibility = (show) ? Visibility.Visible : Visibility.Collapsed;
            sp.Visibility = (show) ? Visibility.Collapsed : Visibility.Visible;
        }

        /// <summary>
        /// This method called when server url text is changed. By checking if URL has ".", 
        /// enable Signin Button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtServerUrl_TextChanged(object sender, TextChangedEventArgs e)
        {
            btnSignIn.IsEnabled = (txtServerUrl.Text.Contains('.'));
        }

        #endregion
    }
}
