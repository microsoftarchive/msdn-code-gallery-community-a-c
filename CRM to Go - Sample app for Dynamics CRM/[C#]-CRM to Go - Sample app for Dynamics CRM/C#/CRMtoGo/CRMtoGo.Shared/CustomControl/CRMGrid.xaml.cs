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
using Microsoft.Xrm.Sdk.Metadata.Samples;
using Microsoft.Xrm.Sdk.Samples;
using MyTypes;
using System;
using System.Linq;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CRMtoGo
{
    /// <summary>
    /// This works as Normal Grid, Regarding Grid, and Lookup Grid.
    /// </summary>
    public sealed partial class CRMGrid : UserControl
    {
        #region Class Property

        // Available Entites for Grid
        public EntityMetadataExCollection LookForEntities { get; set; }

        // Source Entity LogicalName. By assigning this, Grid becomes Regarding Grid.
        public string ReferencedEntityLogicalName { get; set; }
        
        // Source record id. By assigning this, Grid becomes Regarding Grid.
        public Guid ReferencedEntityId { get; set; }
        
        // Source Feild data. By assigning this, Grid becomes Lookup Grid.
        public FormFieldData FormFieldData { get; set; } 

        // Specify if you want to make this as normal Grid.
        // This gives you control where you want to display Entity Name as Text or combobox
        public bool IsGrid { get; set; }
        
        private bool isRegarding;
        private bool isLookup;

        private DataCollection<SavedQuery> views;
        private RelatedData relatedData;
        private string primaryFieldName;

        // To restore state, hold current selection
        private int cbLookIn_SelectedIndex;

        // ResourceLoader for MultiLanguage
        ResourceLoader loader = new ResourceLoader();

        #endregion

        public CRMGrid()
        {            
            this.InitializeComponent();

            // Make Combobox Disable to avoid first item re-selected issue.
            // The issue is if I display this before binding, display name becomes blank
            // if I select different item, and re-select original item.
            cbLookFor.Visibility = Visibility.Collapsed;
            lblLookFor.Visibility = Visibility.Collapsed;
            cbLookIn.Visibility = Visibility.Collapsed;
            cbLookFor.IsEnabled = false;
            cbLookIn.IsEnabled = false;

            // Hide Cancel Button by defaul
            btnCancelSearch.Visibility = Visibility.Collapsed;
        }

        #region Control methods

        /// <summary>
        /// Loading data to Grid. By passing indexes to ComboBox, it restores selection 
        /// </summary>
        /// <param name="cbLookFor_SelectedIndex">pass SelectedIndex to restore selection</param>
        /// <param name="cbLookIn_SelectedIndex">pass SelectedIndex to restore selection</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task LoadData(int cbLookFor_SelectedIndex = 0, int cbLookIn_SelectedIndex = 0)
        {
            // Assign selection value for LookIn combobox
            this.cbLookIn_SelectedIndex = cbLookIn_SelectedIndex;

            // Show ProgressRing until data loading completes
            progressRing.IsActive = true;

            // If ReferencedEntityLogicalName passed, then this is Regarding Grid
            isRegarding = (string.IsNullOrEmpty(ReferencedEntityLogicalName)) ? false : true;

            // If FormFieldData passed, then this is Lookup Grid
            isLookup = (FormFieldData == null) ? false : true;

            // If there is no entities, then throw error
            if (LookForEntities == null)
                throw new Exception("LookForEntities is null");

            // Assign available entities to Lookup For combobox
            cbLookFor.ItemsSource = LookForEntities;
            // Assign display name (use user localized label)
            cbLookFor.DisplayMemberPath = "EntityMetadata.DisplayName.UserLocalizedLabel.Label";
            // Restore selection
            cbLookFor.SelectedIndex = cbLookFor_SelectedIndex;

            // If this is Grid
            if (IsGrid)
            {
                // then display Entity Name rather than combobox for entities.
                lblEntityName.Visibility = Visibility.Visible;
                // Set display name
                lblEntityName.Text = LookForEntities[0].EntityMetadata.DisplayName.UserLocalizedLabel.Label;
#if WINDOWS_PHONE_APP
                // If this is windows phone, then apply "MessageDialogTitleStyle" style
                lblEntityName.Style = (Style)Application.Current.Resources["MessageDialogTitleStyle"];
#endif
            }
            else
            {
                // otherwise just display combobox and its label
                cbLookFor.Visibility = Visibility.Visible;
                lblLookFor.Visibility = Visibility.Visible;
            }          

            // Wait until cbLookIn has selected item.
            while (cbLookIn.SelectedIndex == -1)
            {
                await System.Threading.Tasks.Task.Delay(10);
            }
            // Once LookIn has value, then display it.
            cbLookIn.Visibility = Visibility.Visible;
        }
        
        /// <summary>
        /// Invoked when LookFor combobox selection item changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cbLookFor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            progressRing.IsActive = true;

            // Clear search criteria
            txtSearch.Text = "";
            // Clear data
            lvList.ItemsSource = null;
            // Show Search Button and Hide Cancel Button
            btnSearch.Visibility = Visibility.Visible;
            btnCancelSearch.Visibility = Visibility.Collapsed;

            // Set the cbLookFor and searchbox disabled until views/records loaded.
            cbLookFor.IsEnabled = false;
            cbLookIn.IsEnabled = false;
            txtSearch.IsEnabled = false;

            // Check if selected Entity is available for mobile, otherwise cannot retrieve data.
            EntityMetadataEx entityMetadata = CRMHelper.EntityMetadataExCollection.Where(x => x.EntityMetadata.LogicalName == 
                ((sender as ComboBox).SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName).FirstOrDefault();
            if (entityMetadata == null)
            {
                MessageDialog dialog = new MessageDialog(
                    String.Format(loader.GetString("NotValidForMobile"),((sender as ComboBox).SelectedItem as EntityMetadata).DisplayName));
                await dialog.ShowAsync();

                // Reset the selection back to original
                (sender as ComboBox).SelectedItem = e.RemovedItems[0];

                return;
            }

            // Retrieve available view definitions depending on conditions.
            cbLookIn.ItemsSource = await CRMHelper.RetrieveViews(
                (int)entityMetadata.EntityMetadata.ObjectTypeCode, isRegarding, isLookup, txtSearch.Text);
            // Assign display name
            cbLookIn.DisplayMemberPath = "Name";
            cbLookIn.SelectedIndex = cbLookIn_SelectedIndex;            
        }

        /// <summary>
        /// Invoked when LookIn combobox selection item changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void cbLookIn_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {           
            // Wait until LookIn seleciton has value
            while (cbLookIn.SelectedIndex == -1)
            {
                await System.Threading.Tasks.Task.Delay(10);
            }
            // Then load data
            await RefreshList();
        }

        /// <summary>
        /// Load/Refresh data
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task RefreshList()
        {
            // Start progress ring until records loaded.
            progressRing.IsActive = true;

            // Set the cbLookFor, cbLookIn and searchbox disabled until views/records loaded.
            cbLookFor.IsEnabled = false;
            cbLookIn.IsEnabled = false;
            txtSearch.IsEnabled = false;

            // Clear data.
            this.lvList.ItemsSource = null;
            // Show Search button and hide Cancel Button
            btnSearch.Visibility = Visibility.Visible;
            btnCancelSearch.Visibility = Visibility.Collapsed;
            // Clear any search
            txtSearch.Text = "";
            

            // If it's regarding, then check if 1st view is selected, which is regarding view.
            if (isRegarding && cbLookIn.SelectedIndex == 0)
            {
                // Then get RelatedData and assign Id
                relatedData = CRMHelper.EntityMetadataExCollection.Where(x => x.EntityMetadata.LogicalName == ReferencedEntityLogicalName).First().RelatedEntities.Where(r => r.ReferencingEntity == (cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName).First();
                if (relatedData != null)
                    relatedData.Id = ReferencedEntityId;
            }
            else
                relatedData = null;
           
            // If lookup then obtain PrimaryFieldName
            if (isLookup)
                primaryFieldName = (cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.PrimaryNameAttribute;

            // Get Records by passing necessary data.
            this.lvList.ItemsSource = await CRMHelper.RetrieveByFetchXmlForView(
                cbLookIn.SelectedItem as SavedQuery, relatedData, primaryFieldName);

            cbLookFor.IsEnabled = true;
            cbLookIn.IsEnabled = true;
            txtSearch.IsEnabled = true;
            lvList.SelectionMode = ListViewSelectionMode.Single;
            lvList.IsItemClickEnabled = true;

            //once record loaded, then stop progress ring, and enable comboboxes and search textbox.
            progressRing.IsActive = false;
        }       

        /// <summary>
        /// Do search when serach button clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DoSearch();
        }

        /// <summary>
        /// This method check if user click "return" key, then do search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtSearch_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
                DoSearch();
        }

        /// <summary>
        /// Does Quick Find Search
        /// </summary>
        public async void DoSearch()
        {
            // Check Search Criteria
            if (string.IsNullOrEmpty(txtSearch.Text))
                return;

            // Start progress ring until records loaded.
            progressRing.IsActive = true;

            // Set the cbLookFor, cbLookIn and searchbox disabled until views/records loaded.
            cbLookFor.IsEnabled = false;
            cbLookIn.IsEnabled = false;
            txtSearch.IsEnabled = false;

            // Clear data.
            this.lvList.ItemsSource = null;

            // Retrieve views by specifing search text, which should return 1 view (quick find view)
            // But do not set views to cbLookIn to let users select any views later on.
            views = await CRMHelper.RetrieveViews((int)CRMHelper.EntityMetadataExCollection.
                Where(x => x.EntityMetadata.LogicalName == (cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName).
                Select(x => x.EntityMetadata.ObjectTypeCode).FirstOrDefault(),
                false, false, txtSearch.Text + "%");

            // Then retrieve record and assign to ListView
            if (views != null && views.Count != 0)
                this.lvList.ItemsSource = await CRMHelper.RetrieveByFetchXmlForView(views[0], relatedData, primaryFieldName);

            // Once record loaded, then enable comboboxes and search textbox.
            cbLookFor.IsEnabled = true;
            cbLookIn.IsEnabled = true;
            txtSearch.IsEnabled = true;

            // Hide btnSearch and show btnCancelSearch only after finish searching
            btnSearch.Visibility = Visibility.Collapsed;
            btnCancelSearch.Visibility = Visibility.Visible;

            progressRing.IsActive = false;
        }

        /// <summary>
        /// Delete selected record(s)
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task DeleteRecords()
        {
            // Display confirm message with Yes/No option
            MessageDialog dialog = new MessageDialog(loader.GetString("ConfirmDelete"));
            dialog.Commands.Add(new UICommand(loader.GetString("Yes")));
            dialog.Commands.Add(new UICommand(loader.GetString("No")));
            dialog.DefaultCommandIndex = 1;
            dialog.CancelCommandIndex = 1;
            var result = await dialog.ShowAsync();
            // If user clicks No, then do nothing.
            if (result.Label == loader.GetString("No"))
                return;

            // Otherwise delete recrod(s). Show progress ring first.
            progressRing.IsActive = true;

            // Then delete record(s)
            foreach (ViewData item in lvList.SelectedItems)
            {
                Entity record = new Entity();
                record.LogicalName = (string.IsNullOrEmpty(item.ActivityTypeName)) ? (cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName : item.ActivityTypeName;
                record.Id = item.Id;
                await CRMHelper.DeleteRecord(record);
            }
            
            // Finally Refresh data
            await RefreshList();
        }

        /// <summary>
        /// When cancel button clicked, then simply refresh data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCancelSearch_Click(object sender, RoutedEventArgs e)
        {            
            await RefreshList();
        }

        #endregion
    }
}
