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
using Microsoft.Xrm.Sdk.Samples;
using System;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CRMtoGo.Pages
{
    /// <summary>
    /// SetRegarding Page
    /// </summary>
    public sealed partial class SetRegardingPage : Page, IWebAuthenticationContinuable
    {
        #region Class Property

        private EntityMetadataEx entityMetadataEx; // Target EntityMetadata
        private Entity record; // SourceRecord
        private RelatedData relatedData; // relationship into

        #endregion

        /// <summary>
        /// Constructor for this page
        /// </summary>
        public SetRegardingPage()
        {
            this.InitializeComponent();

            // Register NavigationHelper
            this.navigationHelper = new NavigationHelper(this);

            // Register Event handler for item click.
            this.CRMGrid.lvList.ItemClick += lvList_ItemClick;
        }

        /// <summary>
        /// This method is called to initialze page.
        /// </summary>
        private async void Initialize()
        {
            // Set properties
            EntityMetadataExCollection lookForEntities = new EntityMetadataExCollection();
            lookForEntities.Add(entityMetadataEx);
            this.CRMGrid.LookForEntities = lookForEntities;
            // Then load data
            await this.CRMGrid.LoadData();
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

            // Check if there is any temporaryData
            object[] parameters = CRMHelper.temporaryData as object[];
            if (parameters.Count() != 3)
                throw new Exception("SetRegardingPage takes 3 parameters, SourceRecord, RelatedData and EntityMetadataEx");

            this.record = parameters[0] as Entity;
            this.relatedData = parameters[1] as RelatedData;
            this.entityMetadataEx = parameters[2] as EntityMetadataEx;

            // Then initialize page
            Initialize();

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
        /// This method is called when user Cancel button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abCancel_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        /// <summary>
        /// This method is called when user clicks Associate Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abAssociate_Click(object sender, RoutedEventArgs e)
        {
            EntityReferenceCollection references = new EntityReferenceCollection();
            // Associate selections
            foreach (ViewData item in CRMGrid.lvList.SelectedItems)
            {
                EntityReference refRecord = new EntityReference();
                refRecord.LogicalName = (string.IsNullOrEmpty(item.ActivityTypeName)) ? (CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName : item.ActivityTypeName;
                refRecord.Id = item.Id;
                references.Add(refRecord);
            }
            await CRMHelper.Associate(record.LogicalName, record.Id, new Relationship(relatedData.SchemaName), references);
            // Go back to original page
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        /// <summary>
        /// This method is called when user clicks a record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lvList_ItemClick(object sender, ItemClickEventArgs e)
        {
            EntityReferenceCollection references = new EntityReferenceCollection();

            // Associate selections
            EntityReference refRecord = new EntityReference();
            refRecord.LogicalName = (string.IsNullOrEmpty((e.ClickedItem as ViewData).ActivityTypeName)) ?
                (CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName : (e.ClickedItem as ViewData).ActivityTypeName;
            refRecord.Id = (e.ClickedItem as ViewData).Id;
            references.Add(refRecord);

            await CRMHelper.Associate(record.LogicalName, record.Id, new Relationship(relatedData.SchemaName), references);
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        #endregion
    }
}
