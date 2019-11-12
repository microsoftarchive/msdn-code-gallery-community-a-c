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
using Microsoft.Crm.Sdk.Messages.Samples;
using Microsoft.Xrm.Sdk.Metadata.Samples;
using System;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CRMtoGo.Pages
{
    /// <summary>
    /// This page display CRM Grid for particular Entity.
    /// </summary>
    public sealed partial class EntityGridPage : Page, IWebAuthenticationContinuable
    {
        #region Class Property

        // EntityMetadata for this Grid
        private EntityMetadataEx entityMetadataEx;

        // Selected view index
        private int cbLookIn_SelectedIndex = 0;

        // Instantiate ResourceLoader to load strings for label
        ResourceLoader loader = new ResourceLoader();

        // AppBarButton
        AppBarButton abAdd;
        AppBarButton abDelete;

        #endregion

        /// <summary>
        /// Constructor for this page.
        /// </summary>
        public EntityGridPage()
        {
            this.InitializeComponent();

            // Register NavigationHelper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            // Register Event handler for view change and item clicks
            this.CRMGrid.lvList.SelectionChanged += lvList_SelectionChanged;
            this.CRMGrid.lvList.ItemClick += lvList_ItemClick;
        }

        /// <summary>
        /// This method is called to initialze page.
        /// </summary>
        private async void Initialize()
        {
            // First of all, set schemaName to check privilege
            string schemaName = "";
            // i want to add activity selector for activitypointer when adding new
            if (entityMetadataEx.EntityMetadata.IsActivity == true)
                schemaName = "Activity";
            else
                schemaName = entityMetadataEx.EntityMetadata.SchemaName;

            // Render Add button
            if (CRMHelper.CheckPrivilege(schemaName, PrivilegeType.Create, PrivilegeDepth.Basic))
            {
                abAdd = new AppBarButton();
                abAdd.Icon = new SymbolIcon(Symbol.Add);
                abAdd.Name = "abAdd";
                abAdd.Label = loader.GetString("abAdd\\Label");
                abAdd.Click += abAdd_Click;
                commandBar.PrimaryCommands.Insert(0, abAdd);
            }
            
            // Render Delete button
            if (CRMHelper.CheckPrivilege(schemaName, PrivilegeType.Delete, PrivilegeDepth.Basic))
            {
                abDelete = new AppBarButton();
                abDelete.Icon = new SymbolIcon(Symbol.Delete);
                abDelete.Name = "abDelete";
                abDelete.Label = loader.GetString("abDelete\\Label");
                abDelete.Click += abDelete_Click;
                abDelete.IsEnabled = false;
                abDelete.Visibility = Visibility.Collapsed;
                commandBar.PrimaryCommands.Insert(commandBar.PrimaryCommands.IndexOf(abCancel), abDelete);
            }

            // Instantiate collection for lookFor combobox
            EntityMetadataExCollection lookForEntities = new EntityMetadataExCollection();
            lookForEntities.Add(entityMetadataEx);

            // Assign parameters
            this.CRMGrid.IsGrid = true;
            this.CRMGrid.LookForEntities = lookForEntities;
            // Then load data.
            await this.CRMGrid.LoadData(cbLookIn_SelectedIndex: cbLookIn_SelectedIndex);
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
            // Restore selected view.
            if (e.PageState != null && e.PageState.ContainsKey("cbLookIn_SelectedIndex"))
            {
                cbLookIn_SelectedIndex = int.Parse(e.PageState["cbLookIn_SelectedIndex"].ToString());
            }
        }

        /// <summary>
        /// This method called when page is unloaded to save state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            // Save which view is selected
            if (CRMGrid.cbLookIn.SelectedIndex != -1)
                e.PageState["cbLookIn_SelectedIndex"] = CRMGrid.cbLookIn.SelectedIndex;
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
            
            // Retrieve EntityMetadataEx by using passed parameter (ObjectTypeCode)
            this.entityMetadataEx = CRMHelper.EntityMetadataExCollection.Where(x => x.EntityMetadata.ObjectTypeCode == (int)e.Parameter).First();
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
        private async void abAdd_Click(object sender, RoutedEventArgs e)
        {
            // Generate parameters. As this is new record, passing null for record object.
            object[] parameters = new object[] { null, await CRMHelper.RetrieveFormFields(entityMetadataEx), entityMetadataEx };
            CRMHelper.temporaryData = parameters;
            Frame.Navigate(typeof(RecordModifyPage));
        }

        private void abSelect_Click(object sender, RoutedEventArgs e)
        {
            CRMGrid.lvList.SelectionMode = ListViewSelectionMode.Multiple;
            CRMGrid.lvList.IsItemClickEnabled = false;
            commandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;

            if (abAdd != null)
                abAdd.Visibility = Visibility.Collapsed;
            abSelect.Visibility = Visibility.Collapsed;
            if (abDelete != null)
            {
                abDelete.Visibility = Visibility.Visible;
                abDelete.IsEnabled = false;
            }
            abCancel.Visibility = Visibility.Visible;
        }

        private void abCancel_Click(object sender, RoutedEventArgs e)
        {
            Cancel();
        }

        private async void abDelete_Click(object sender, RoutedEventArgs e)
        {
            await this.CRMGrid.DeleteRecords();
            Cancel();
        }

        private void lvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (abDelete != null)
                abDelete.IsEnabled = (CRMGrid.lvList.SelectedItems.Count() > 0) ? true : false;
        }

        private void Cancel()
        {
            CRMGrid.lvList.SelectionMode = ListViewSelectionMode.None;
            CRMGrid.lvList.IsItemClickEnabled = true;
            commandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Minimal;
            commandBar.IsOpen = false;

            if (abAdd != null)
                abAdd.Visibility = Visibility.Visible;
            abSelect.Visibility = Visibility.Visible;
            if (abDelete != null)
                abDelete.Visibility = Visibility.Collapsed;
            abCancel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// This method is called when user clicks a record in a Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Obtain ViewData.
            var item = e.ClickedItem as ViewData;
            EntityMetadataEx entityMetadataEx;
            // Obtain entityMetadata
            if (!string.IsNullOrEmpty(item.ActivityTypeName)) //Activities
                entityMetadataEx = CRMHelper.EntityMetadataExCollection.
                    Where(x => x.EntityMetadata.LogicalName == item.ActivityTypeName).FirstOrDefault();
            else
                entityMetadataEx = CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx;

            // Put temporary data for RecordDetailPage and Navigate to RecordDetailPage.
            CRMHelper.temporaryData = new object[] { item.Id, entityMetadataEx };
            Frame.Navigate(typeof(RecordDetailPage));
        }

        #endregion
    }
}
