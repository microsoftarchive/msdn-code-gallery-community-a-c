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
using Microsoft.Xrm.Sdk.Samples;
using MyTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CRMtoGo.Pages
{
    /// <summary>
    /// Lookup dialog page.
    /// </summary>
    public sealed partial class LookupDialogPage : Page, IWebAuthenticationContinuable
    {
        #region Class Property

        private EntityMetadataExCollection lookForEntities; // Entities for Lookup Dialog
        private FormFieldData formFieldData; 
        private string searchCriteria;

        // AppBarButton
        AppBarButton abAdd;

        // Selected view index
        private int cbLookFor_SelectedIndex;
        private int cbLookIn_SelectedIndex;

        // Instantiate ResourceLoader to load strings for label
        ResourceLoader loader = new ResourceLoader();

        #endregion

        /// <summary>
        /// Constructor for this page
        /// </summary>
        public LookupDialogPage()
        {
            this.InitializeComponent();

            // Register NavigationHelper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            lookForEntities = new EntityMetadataExCollection();

            // Register Event handler for view change.
            this.CRMGrid.lvList.ItemClick += lvList_ItemClick;
            this.CRMGrid.cbLookFor.SelectionChanged += cbLookFor_SelectionChanged;
        }

        /// <summary>
        /// This method is called to initialze page.
        /// </summary>
        private async void Initialize()
        {
            // Set properties
            this.CRMGrid.FormFieldData = formFieldData;
            this.CRMGrid.LookForEntities = lookForEntities;
            // Then load data
            await this.CRMGrid.LoadData(cbLookFor_SelectedIndex, cbLookIn_SelectedIndex);
            // If search criteria is passed, then search it now.
            if (!string.IsNullOrEmpty(searchCriteria))
            {
                this.CRMGrid.txtSearch.Text = searchCriteria;
                CRMGrid.DoSearch();
            }
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
            if (e.PageState != null && e.PageState.ContainsKey("formFieldData"))
            {
                formFieldData = e.PageState["formFieldData"] as FormFieldData;
            }
            if (e.PageState != null && e.PageState.ContainsKey("lookForEntities"))
            {
                lookForEntities = e.PageState["lookForEntities"] as EntityMetadataExCollection;
            }
            if (e.PageState != null && e.PageState.ContainsKey("cbLookFor_SelectedIndex"))
            {
                cbLookFor_SelectedIndex = int.Parse(e.PageState["cbLookFor_SelectedIndex"].ToString());
            }
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
            e.PageState["formFieldData"] = formFieldData;
            e.PageState["lookForEntities"] = lookForEntities;
            if (CRMGrid.cbLookFor.SelectedIndex != -1)
                e.PageState["cbLookFor_SelectedIndex"] = CRMGrid.cbLookFor.SelectedIndex;
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

            // Check if there is any temporaryData. if restored, then temporary data does not exist
            object[] parameters = CRMHelper.temporaryData as object[];
            if (parameters != null)
            {
                // if this if first navigation, then no formFieldData, otherwise its restored or back from new record
                if (formFieldData == null)
                    this.formFieldData = parameters[0] as FormFieldData;
                else // assume back after created new record or back just by clicking cancel button.
                {
                    Entity record = parameters[0] as Entity;
                    // If record is created, then filter result down to the created record.
                    if (record != null)
                        searchCriteria = record[lookForEntities.
                            Where(x => x.EntityMetadata.LogicalName == record.LogicalName).First().EntityMetadata.PrimaryNameAttribute].ToString();
                }
            }

            //if restored, then temporary data does not exist
            if (lookForEntities == null || lookForEntities.Count() == 0) 
            {
                List<EntityMetadataEx> targetList = new List<EntityMetadataEx>();
                targetList.AddRange(CRMHelper.EntityMetadataExCollection.Where(x => (parameters[1] as string[]).Contains(x.EntityMetadata.LogicalName)));
                foreach (var target in targetList)
                {
                    lookForEntities.Add(target);
                }
            }

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
        /// This method called when user clicks item in a Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Obtain clicked item
            var item = e.ClickedItem as ViewData;
            EntityMetadataEx entityMetadataEx;
            if (!string.IsNullOrEmpty(item.ActivityTypeName)) //Activities
                entityMetadataEx = CRMHelper.EntityMetadataExCollection.
                    Where(x => x.EntityMetadata.LogicalName == item.ActivityTypeName).FirstOrDefault();
            else
                entityMetadataEx = CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx;
            
            // If this is for Party
            if (formFieldData.FieldMetadata.AttributeType == AttributeTypeCode.PartyList)
            {
                // Create Collection to host multiple records
                EntityCollection newCollection = new EntityCollection();
                // Store existing ActityParties
                newCollection.Entities.AddRange((formFieldData.FieldData as EntityCollection).Entities);
                // Create new ActivityParty
                ActivityParty recordToAdd = new ActivityParty();
                recordToAdd.PartyId = new EntityReference();
                recordToAdd.PartyId.Id = item.Id;
                recordToAdd.PartyId.LogicalName = (CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName;
                recordToAdd.PartyId.Name = item.PrimaryFieldValue;
                // Then add to the list.
                newCollection.Entities.Add(recordToAdd);
                // Store it to FieldData
                formFieldData.FieldData = newCollection;
                // Assign the value to temporary data
                CRMHelper.temporaryData = formFieldData;
            }
            // If this is normal lookup
            else
            {
                // Generate new EntityReference
                EntityReference newReference = new EntityReference();
                newReference.Id = item.Id;
                newReference.LogicalName = entityMetadataEx.EntityMetadata.LogicalName;
                newReference.Name = item.PrimaryFieldValue;
                // Assign new value to FieldData
                formFieldData.FieldData = newReference;
                // Assign the value to temporary data
                CRMHelper.temporaryData = formFieldData;
            }
            // Then Go back to original page
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        /// <summary>
        /// This method is called when user changes Entity
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cbLookFor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Firstly remove existing buttons
            if (abAdd != null)
                commandBar.PrimaryCommands.Remove(abAdd);

            string schemaName = "";
            if (((sender as ComboBox).SelectedItem as EntityMetadataEx).EntityMetadata.IsActivity == true)
                schemaName = "Activity";
            else
                schemaName = ((sender as ComboBox).SelectedItem as EntityMetadataEx).EntityMetadata.SchemaName;

            // Render AppBarButton
            if (CRMHelper.CheckPrivilege(schemaName, PrivilegeType.Create, PrivilegeDepth.Basic))
            {
                abAdd = new AppBarButton();
                abAdd.Icon = new SymbolIcon(Symbol.Add);
                abAdd.Name = "abAdd";
                abAdd.Label = loader.GetString("abAdd\\Label");
                abAdd.Click += abAdd_Click;
                commandBar.PrimaryCommands.Insert(0, abAdd);
            }
        }

        /// <summary>
        /// This method is called when user clicks Add button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abAdd_Click(object sender, RoutedEventArgs e)
        {
            EntityMetadataEx entityMetadataEx = CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx;
            // Retrieve fields for new records. (existing one already have data in it)
            List<FormFieldData> fields = await CRMHelper.RetrieveFormFields(entityMetadataEx);
            // Generate parameters. As this is new record, passing null for record object.
            object[] parameters = new object[] { null, fields, entityMetadataEx };
            CRMHelper.temporaryData = parameters;
            Frame.Navigate(typeof(RecordModifyPage));
        }

        #endregion
    }
}
