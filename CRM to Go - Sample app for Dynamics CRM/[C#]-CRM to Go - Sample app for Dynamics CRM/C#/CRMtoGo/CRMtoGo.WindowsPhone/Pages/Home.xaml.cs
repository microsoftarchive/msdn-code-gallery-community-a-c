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
using CRMtoGo.DataModel;
using System;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CRMtoGo.Pages
{
    /// <summary>
    /// Home Page where Sitemap displays
    /// </summary>
    public sealed partial class Home : Page, IWebAuthenticationContinuable 
    {
        /// <summary>
        /// Constructor for the Page
        /// </summary>
        public Home()
        {
            this.InitializeComponent();
            this.NavigationCacheMode = NavigationCacheMode.Required;

            // Register NavigationHelper
            this.navigationHelper = new NavigationHelper(this);    
        }

        #region Navigation

        private NavigationHelper navigationHelper;

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

            LoadData();

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
        /// This methods load sitemap data and display to screen
        /// </summary>
        private void LoadData()
        {
            // Join SiteMap data and EntityMetadata stored in CRMHelper to decide
            // which entities to be displayed. If you want to change what entities 
            // to be displayed, modify here.
            this.Entities.DataContext = CRMHelper.EntityMetadataExCollection.
                Where(x => CRMHelper.SiteMapEntities.Contains(x.EntityMetadata.LogicalName) || x.EntityMetadata.LogicalName == "phonecall"
                || x.EntityMetadata.LogicalName == "task" || x.EntityMetadata.LogicalName == "appointment" || x.EntityMetadata.LogicalName == "email"
                || x.EntityMetadata.LogicalName == "letter").
                OrderBy(x => x.EntityMetadata.DisplayName.UserLocalizedLabel.Label);
        }

        /// <summary>
        /// This method called when user clicks sitemap item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Obtain clicked item
            EntityMetadataEx entityMetadataEx = e.ClickedItem as EntityMetadataEx;
            // Then nagivate to EntityGrid page.
            Frame.Navigate(typeof(EntityGridPage), (int)entityMetadataEx.EntityMetadata.ObjectTypeCode);
        }

        /// <summary>
        /// This method called when user clicks Settings menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abSettings_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Settings));
        }

        #endregion
    }
}
