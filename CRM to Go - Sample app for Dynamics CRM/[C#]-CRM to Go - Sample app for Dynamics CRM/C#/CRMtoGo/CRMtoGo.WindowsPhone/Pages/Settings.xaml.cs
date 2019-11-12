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
using MyTypes;
using System;
using System.Linq;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CRMtoGo.Pages
{
    /// <summary>
    /// Settings page
    /// </summary>
    public sealed partial class Settings : Page, IWebAuthenticationContinuable
    {
        #region Class Property

        // Store selected combobox
        private int originalTimeZoneIndex = -1;
        private int originalRecrodsPerViewIndex = -1;

        // Instantiate ResourceLoader to load strings for label
        ResourceLoader loader = new ResourceLoader();

        #endregion

        /// <summary>
        /// Constructor for this page
        /// </summary>
        public Settings()
        {
            this.InitializeComponent();

            // Register NavigationHelper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        private void Initialize()
        {  
            // Initialize Timezone
            this.cbTimeZones.ItemsSource = CRMHelper.TimeZones;
            cbTimeZones.DisplayMemberPath = "UserInterfaceName";
            cbTimeZones.SelectedItem = CRMHelper.TimeZones.Where(x => x.TimeZoneCode == CRMHelper.UserSettings.TimeZoneCode).FirstOrDefault();
            originalTimeZoneIndex = cbTimeZones.SelectedIndex;

            // Initialize Records Per View
            cbRecordsPerView.SelectedItem = cbRecordsPerView.Items.Where(x => (x as TextBlock).Text == CRMHelper.UserSettings.PagingLimit.ToString()).First();
            originalRecrodsPerViewIndex = cbRecordsPerView.SelectedIndex;
        }

        #region Navigation

        private NavigationHelper navigationHelper;
       
        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// This method called when page is loaded to restore state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// This method called when page is unloaded to save state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }

        /// <summary>
        /// This method called when user navigated to this page. 
        /// </summary>
        /// <param name="e"></param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);

            progressRing.IsActive = true;

            // If UserInfo is null, then initialize the helper
            if (CRMHelper.UserInfo == null)
                await CRMHelper.Initialize();

            Initialize();

            // If there is a parameter, then this is called from BackGround Task
            if (e.Parameter != null)
            {
                // check if equivalent timezone info is available for CRM
                TimeZoneDefinition timeZoneDefinition = CRMHelper.TimeZones.
                    Where(x => x.UserInterfaceName == e.Parameter.ToString()).FirstOrDefault();
                if (timeZoneDefinition == null)
                    return;
                //Show message to confirm if user want to update TimeZone
                string message = loader.GetString("ConfirmTimeZone");
                MessageDialog dialog = new MessageDialog(message);
                dialog.Commands.Add(new UICommand(loader.GetString("Yes")));
                dialog.Commands.Add(new UICommand(loader.GetString("No")));
                dialog.DefaultCommandIndex = 1;
                dialog.CancelCommandIndex = 1;
                var result = await dialog.ShowAsync();

                // If user wants to update TimeZone data, then do it.
                if (result.Label == loader.GetString("Yes"))
                {
                    CRMHelper.UserSettings.TimeZoneCode = timeZoneDefinition.TimeZoneCode;
                    cbTimeZones.SelectedItem = timeZoneDefinition;
                    await SaveSettings();
                }
            }

            progressRing.IsActive = false;
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
        /// This method is called when user clicks Cancel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        /// <summary>
        /// This method is called when Timezone selection is changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbTimeZones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (originalTimeZoneIndex > 0 && originalTimeZoneIndex != (sender as ComboBox).SelectedIndex)
                abAccept.IsEnabled = true;
            else
                abAccept.IsEnabled = false;
        }

        /// <summary>
        /// This method is called when RecordsPerView is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbRecordsPerView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (originalRecrodsPerViewIndex > 0 && originalRecrodsPerViewIndex != (sender as ComboBox).SelectedIndex)
                abAccept.IsEnabled = true;
            else
                abAccept.IsEnabled = false;
        }

        /// <summary>
        /// This method is called when user clicks Accept button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abAccept_Click(object sender, RoutedEventArgs e)
        {
           await SaveSettings();
        }
        
        /// <summary>
        /// This methos update UserSettings
        /// </summary>
        /// <returns></returns>
        private async Task SaveSettings()
        {
            // Update User Settings.
            UserSettings userSettings = new UserSettings();
            userSettings.Id = CRMHelper.UserSettings.Id;
            userSettings.PagingLimit = int.Parse((cbRecordsPerView.SelectedItem as TextBlock).Text);
            userSettings.TimeZoneCode = (cbTimeZones.SelectedItem as TimeZoneDefinition).TimeZoneCode;

            // Call update 
            await CRMHelper.UpsertRecord(userSettings);

            // Now update cache data
            CRMHelper.UserSettings.TimeZoneCode = userSettings.TimeZoneCode;
            CRMHelper.UserSettings.PagingLimit = userSettings.PagingLimit;
            await Util.SaveToLocal(CRMHelper.UserSettings, "userSettings.dat");
            abAccept.IsEnabled = false;
        }

        /// <summary>
        /// This method is called when user clicks SignOut button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSignOut_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to SignInPage by speficying SignOut
            Frame.Navigate(typeof(SignInPage), true);
            this.Frame.BackStack.RemoveAt(Frame.BackStackDepth - 1);
        }

        /// <summary>
        /// This method is called when user clicks Reconfigure button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnReconfigure_Click(object sender, RoutedEventArgs e)
        {
            // to reconfigure delete serverUrl.
            await Util.DeleteLocalCache();

            // then navigate to SignInPage by speficying SignOut
            Frame.Navigate(typeof(SignInPage), true);
            this.Frame.BackStack.RemoveAt(Frame.BackStackDepth - 1);
        }

        /// <summary>
        /// This method is called when user clicks Clear Cache button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnClearCache_Click(object sender, RoutedEventArgs e)
        {
            // to clear cache, delete all local files except serverUrl
            string serverUrl = (string)await Util.ReadFromLocal<string>("serverUrl.dat");
            string OAuthUrl = (string)await Util.ReadFromLocal<string>("OAuthUrl.dat");

            // delete all cache files.
            await Util.DeleteLocalCache();

            // Then just cache serverUrl only.
            await Util.SaveToLocal(serverUrl, "serverUrl.dat");
            await Util.SaveToLocal(OAuthUrl, "OAuthUrl.dat");

            // then navigate to SignInPage.
            Frame.Navigate(typeof(SignInPage));
            this.Frame.BackStack.RemoveAt(Frame.BackStackDepth - 1);
        }

        #endregion
    }
}
