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
using Windows.Storage;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace CRMtoGo.Pages
{
    /// <summary>
    /// This page displays record detail, its related entities and note. Inherit IFileOpenPickerContinuable to 
    /// attach file to note, and IFileSavePickerContinuable to save downloaded attach files from note
    /// </summary>
    public sealed partial class RecordDetailPage : Page, IFileOpenPickerContinuable, IFileSavePickerContinuable, IWebAuthenticationContinuable
    {
        #region Class Property

        private Guid id; // This record's Guid
        private EntityMetadataEx entityMetadataEx; // This record's metadata
        private Entity record; // This record data
        private List<FormFieldData> fields; // Fields to display
        private string MainRecordSchemaName; // This record's SchemaName

        // Selected combobox/pivot indexes
        private int pvRecord_SelectedIndex;
        private int cbLookFor_SelectedIndex;
        private int cbLookIn_SelectedIndex;

        // AppButton for record
        AppBarButton abAdd;
        AppBarButton abEdit;
        AppBarButton abDelete;

        // AppButton for related
        AppBarButton abAddExisting;
        AppBarButton abRelatedAdd;
        AppBarButton abRelatedDelete;
        AppBarButton abSelect;
        AppBarButton abCancel;

        // AppButton for notes
        AppBarButton abNoteAdd;
        AppBarButton abNoteSave;
        AppBarButton abNoteDelete;
        AppBarButton abNoteSelect;
        AppBarButton abNoteCancel;

        // Instantiate ResourceLoader to load strings for label
        ResourceLoader loader = new ResourceLoader();

        #endregion

        /// <summary>
        /// Constructor for this page.
        /// </summary>
        public RecordDetailPage()
        {
            this.InitializeComponent();

            // Register NavigationHelper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            // Assign item click handler for detail and grid page item.
            this.CRMRecordDetail.lvFields.ItemClick += CRMHelper.lvFields_ItemClick;
            this.CRMRecordDetail.ActivityParty_Tapped += ActivityParty_Tapped;
            this.CRMGrid.lvList.SelectionChanged += lvList_SelectionChanged;
            this.CRMGrid.lvList.ItemClick += lvList_ItemClick;
            this.CRMGrid.cbLookFor.SelectionChanged += cbLookFor_SelectionChanged;
            this.CRMNotes.lvList.SelectionChanged += crmNotes_lvList_SelectionChanged;
            this.CRMNotes.lvListItem_Click += crmNotes_lvList_ItemClick;
        }

        /// <summary>
        /// This method is called to initialze page.
        /// </summary>
        private async void Initialize()
        {
            #region Initialize AppBarButtons

            // First of all, set schemaName to check privilege
            if (entityMetadataEx.EntityMetadata.IsActivity == true)
                MainRecordSchemaName = "Activity";
            else
                MainRecordSchemaName = entityMetadataEx.EntityMetadata.SchemaName;

            // Render AppBarButtons for record.
            if (CRMHelper.CheckPrivilege(MainRecordSchemaName, PrivilegeType.Create, PrivilegeDepth.Basic))
            {
                abAdd = new AppBarButton();
                abAdd.Icon = new SymbolIcon(Symbol.Add);
                abAdd.Name = "abAdd";
                abAdd.Label = loader.GetString("abAdd\\Label");
                abAdd.Click += abAdd_Click;
                commandBar.PrimaryCommands.Add(abAdd);
            }
            if (CRMHelper.CheckPrivilege(MainRecordSchemaName, PrivilegeType.Write, PrivilegeDepth.Basic))
            {
                abEdit = new AppBarButton();
                abEdit.Icon = new SymbolIcon(Symbol.Edit);
                abEdit.Name = "abEdit";
                abEdit.Label = loader.GetString("abEdit\\Label");
                abEdit.Click += abEdit_Click;
                commandBar.PrimaryCommands.Add(abEdit);
            }
            if (CRMHelper.CheckPrivilege(MainRecordSchemaName, PrivilegeType.Delete, PrivilegeDepth.Basic))
            {
                abDelete = new AppBarButton();
                abDelete.Icon = new SymbolIcon(Symbol.Delete);
                abDelete.Name = "abDelete";
                abDelete.Label = loader.GetString("abDelete\\Label");
                abDelete.Click += abDelete_Click;
                commandBar.PrimaryCommands.Add(abDelete);
            }

            // Check privilege to display Note AppBarButton
            if (CRMHelper.CheckPrivilege("Note", PrivilegeType.Read, PrivilegeDepth.Basic))
            {
                // If use has read access, then check other privileges too.
                // AppBarButtons for record.
                if (CRMHelper.CheckPrivilege("Note", PrivilegeType.Create, PrivilegeDepth.Basic) &&
                    CRMHelper.CheckPrivilege(MainRecordSchemaName, PrivilegeType.AppendTo, PrivilegeDepth.Basic))
                {
                    abNoteAdd = new AppBarButton();
                    abNoteAdd.Icon = new SymbolIcon(Symbol.Add);
                    abNoteAdd.Name = "abNoteAdd";
                    abNoteAdd.Label = loader.GetString("abNoteAdd\\Label");
                    abNoteAdd.Click += abNoteAdd_Click;
                    commandBar.PrimaryCommands.Add(abNoteAdd);
                    abNoteSave = new AppBarButton();
                    abNoteSave.Icon = new SymbolIcon(Symbol.Save);
                    abNoteSave.Name = "abNoteSave";
                    abNoteSave.Label = loader.GetString("abNoteSave\\Label");
                    abNoteSave.Click += abNoteSave_Click;
                    commandBar.PrimaryCommands.Add(abNoteSave);
                }
                if (CRMHelper.CheckPrivilege("Note", PrivilegeType.Delete, PrivilegeDepth.Basic))
                {
                    abNoteDelete = new AppBarButton();
                    abNoteDelete.Icon = new SymbolIcon(Symbol.Delete);
                    abNoteDelete.Name = "abNoteDelete";
                    abNoteDelete.Label = loader.GetString("abNoteDelete\\Label");
                    abNoteDelete.Click += abNoteDelete_Click;
                    commandBar.PrimaryCommands.Add(abNoteDelete);
                    abNoteSelect = new AppBarButton();
                    abNoteSelect.Icon = new SymbolIcon(Symbol.List);
                    abNoteSelect.Name = "abNoteSelect";
                    abNoteSelect.Label = loader.GetString("abNoteSelect\\Label");
                    abNoteSelect.Click += abNoteSelect_Click;
                    commandBar.PrimaryCommands.Add(abNoteSelect);
                    abNoteCancel = new AppBarButton();
                    abNoteCancel.Icon = new SymbolIcon(Symbol.Cancel);
                    abNoteCancel.Name = "abNoteCancel";
                    abNoteCancel.Label = loader.GetString("abNoteCancel\\Label");
                    abNoteCancel.Click += abNoteCancel_Click;
                    commandBar.PrimaryCommands.Add(abNoteCancel);
                }
            }
            else
                // If no read privilege for note, then hide the pivotitem
                piNotes.Visibility = Visibility.Collapsed;

            #endregion

            #region Initialize CRMRecordDetail

            // Assign properties
            this.CRMRecordDetail.EntityMetadataEx = entityMetadataEx;
            this.CRMRecordDetail.Id = id;
            // Assign fields and record if it's cached. If you want to always retrieve latest data, then
            // do not restore data from cache
            if (fields != null || record != null)
            {
                this.CRMRecordDetail.Record = record;
                this.CRMRecordDetail.Fields = fields;
            }
            // Then road the record
            await this.CRMRecordDetail.LoadData();

            // Get it as reference
            this.record = CRMRecordDetail.Record;
            // Get fields as reference
            this.fields = CRMRecordDetail.Fields;

            // Put the title
            this.pvRecord.Title = entityMetadataEx.EntityMetadata.DisplayName.UserLocalizedLabel.Label + ": " +
                record[entityMetadataEx.EntityMetadata.PrimaryNameAttribute];

            #endregion

            #region Initialize CRMGrid

            // Now work for related entities pivotitem
            // Instantiate collection for lookFor combobox
            EntityMetadataExCollection lookForEntities = new EntityMetadataExCollection();

            // Assign all related entities
            foreach (RelatedData item in entityMetadataEx.RelatedEntities)
            {
                EntityMetadataEx em = CRMHelper.EntityMetadataExCollection.Where(x => x.EntityMetadata.ObjectTypeCode == item.ObjectTypeCode).First();
                lookForEntities.Add(em);
            }

            // Check if there is related entities
            if (lookForEntities.Count() != 0)
            {
                // Assign properties
                this.CRMGrid.LookForEntities = lookForEntities;
                CRMGrid.ReferencedEntityLogicalName = entityMetadataEx.EntityMetadata.LogicalName;
                CRMGrid.ReferencedEntityId = id;
                // Then load data
                await this.CRMGrid.LoadData(cbLookFor_SelectedIndex, cbLookIn_SelectedIndex);
            }

            #endregion

            #region Initialize CRMNote

            // Assign properties
            this.CRMNotes.Id = id;
            this.CRMNotes.EntityMetadataEx = entityMetadataEx;

            // Then load the data
            await this.CRMNotes.LoadData();

            #endregion
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
            if (e.PageState != null && e.PageState.ContainsKey("id"))
            {
                id = Guid.Parse(e.PageState["id"].ToString());
            }
            if (e.PageState != null && e.PageState.ContainsKey("entityMetadataEx"))
            {
                entityMetadataEx = e.PageState["entityMetadataEx"] as EntityMetadataEx;
            }            
            if (e.PageState != null && e.PageState.ContainsKey("pvRecord_SelectedIndex"))
            {
                pvRecord_SelectedIndex = int.Parse(e.PageState["pvRecord_SelectedIndex"].ToString());
                pvRecord.SelectedIndex = pvRecord_SelectedIndex;
            }
            if (e.PageState != null && e.PageState.ContainsKey("cbLookFor_SelectedIndex"))
            {
                cbLookFor_SelectedIndex = int.Parse(e.PageState["cbLookFor_SelectedIndex"].ToString());
            }
            if (e.PageState != null && e.PageState.ContainsKey("cbLookIn_SelectedIndex"))
            {
                cbLookIn_SelectedIndex = int.Parse(e.PageState["cbLookIn_SelectedIndex"].ToString());
            }
            // Restore fields and record.  If you want to always retrieve latest data, then
            // do not restore from cache
            if (e.PageState != null && e.PageState.ContainsKey("fields"))
            {
                fields = e.PageState["fields"] as List<FormFieldData>;
            }
            if (e.PageState != null && e.PageState.ContainsKey("record"))
            {
                record = e.PageState["record"] as Entity;
            }
        }

        /// <summary>
        /// This method called when page is unloaded to save state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            e.PageState["pvRecord_SelectedIndex"] = pvRecord.SelectedIndex;
            e.PageState["id"] = id;
            e.PageState["entityMetadataEx"] = entityMetadataEx;            
            if (CRMGrid.cbLookFor.SelectedIndex != -1)
                e.PageState["cbLookFor_SelectedIndex"] = CRMGrid.cbLookFor.SelectedIndex;
            if (CRMGrid.cbLookIn.SelectedIndex != -1)
                e.PageState["cbLookIn_SelectedIndex"] = CRMGrid.cbLookIn.SelectedIndex;
            // Save fields and record.  If you want to always retrieve latest data, then
            // do not cache data
            e.PageState["fields"] = fields;
            e.PageState["record"] = record;
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

            if (id == Guid.Empty) // If id does not have value, this is new page.
            {
                // Check if there is any temporaryData
                object[] parameters = CRMHelper.temporaryData as object[];
                this.id = Guid.Parse(parameters[0].ToString());
                this.entityMetadataEx = parameters[1] as EntityMetadataEx;
            }
            // if id has value, then this page is navigate back from another page.
            else
            {
                // Check parameter
                object[] parameters = CRMHelper.temporaryData as object[];
                // If first parameter is Entity, then this is back from Modify Page.
                // In this case, as record may have newer value, clear the cache.
                if (parameters != null && parameters.Count() == 1 && parameters[0].GetType().Equals(typeof(Entity)))
                {
                    fields = null;
                    record = null;
                }
            }

            // Initalize the page.
            Initialize();

            progressRing.IsActive = false;
        }

        /// <summary>
        /// This metohd called when user navigate away from the page.
        /// </summary>
        /// <param name="e"></param>
        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedFrom(e);
            
            // When nagivate away, delete temporary data for attachment if exists
            if(e.NavigationMode== NavigationMode.Back)
                await CRMNotes.DeleteTemporaryData();
            
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

        #region AppBarButtonReset

        /// <summary>
        /// This method reset AppBarButton Display for Record PivotItem
        /// </summary>
        /// <param name="display"></param>
        private void ResetRecordAppBarButtonDisplay(bool display)
        {            
            // if Record Pivot Item is selected, then display AppBarButtons, otherwise collapsed them
            if (abAdd != null)
                abAdd.Visibility = (display) ? Visibility.Visible : Visibility.Collapsed;
            if (abEdit != null)
            {
                abEdit.Visibility = (display) ? Visibility.Visible : Visibility.Collapsed;
                // If record status is not 0, then it is not active, thus make edit button disabled.
                if (record != null && record.Contains("statecode") && ((OptionSetValue)record["statecode"]).Value != 0)
                    abEdit.IsEnabled = false;
            }
            if (abDelete != null)
                abDelete.Visibility = (display) ? Visibility.Visible : Visibility.Collapsed;

            // Change commandBar DisplayMode only when the PivotItem is Selected
            if(display)
                commandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Minimal;
        }

        /// <summary>
        /// This method reset AppBarButton Display for Related PivotItem
        /// </summary>
        /// <param name="display"></param>
        private void ResetRelatedAppBarButtonDisplay(bool display)
        {
            // if Related Pivot Item is selected, then change display depending on lvList.SelectionMode
            if (abRelatedAdd != null)
                abRelatedAdd.Visibility = (display && CRMGrid.lvList.SelectionMode != ListViewSelectionMode.Multiple) ? Visibility.Visible : Visibility.Collapsed;
            if (abAddExisting != null)
                abAddExisting.Visibility = (display && CRMGrid.lvList.SelectionMode != ListViewSelectionMode.Multiple) ? Visibility.Visible : Visibility.Collapsed;
            if (abRelatedDelete != null)
                abRelatedDelete.Visibility = (display && CRMGrid.lvList.SelectionMode == ListViewSelectionMode.Multiple) ? Visibility.Visible : Visibility.Collapsed;
            if (abSelect != null)
                abSelect.Visibility = (display && CRMGrid.lvList.SelectionMode != ListViewSelectionMode.Multiple) ? Visibility.Visible : Visibility.Collapsed;
            if (abCancel != null)
                abCancel.Visibility = (display && CRMGrid.lvList.SelectionMode == ListViewSelectionMode.Multiple) ? Visibility.Visible : Visibility.Collapsed;

            // Change commandBar DisplayMode only when the PivotItem is Selected
            if (display)
                commandBar.ClosedDisplayMode = (CRMGrid.lvList.SelectionMode != ListViewSelectionMode.Multiple) ? AppBarClosedDisplayMode.Minimal : AppBarClosedDisplayMode.Compact;
        }

        /// <summary>
        /// This method reset AppBarButton Display for Note PivotItem
        /// </summary>
        /// <param name="display"></param>
        private void ResetNoteAppBarButtonDisplay(bool display)
        {
            // if Note Pivot Item is selected, then change display depending on lvList.Visibitily and SelectionMode
            if (abNoteAdd != null)
                abNoteAdd.Visibility = (display && CRMNotes.lvList.Visibility == Visibility.Visible && CRMNotes.lvList.SelectionMode != ListViewSelectionMode.Multiple) ? Visibility.Visible : Visibility.Collapsed;
            if (abNoteSave != null)
                abNoteSave.Visibility = (display && CRMNotes.lvList.Visibility != Visibility.Visible) ? Visibility.Visible : Visibility.Collapsed;
            if (abNoteDelete != null)
                abNoteDelete.Visibility = (display && CRMNotes.lvList.Visibility == Visibility.Visible && CRMNotes.lvList.SelectionMode == ListViewSelectionMode.Multiple) ? Visibility.Visible : Visibility.Collapsed;
            if (abNoteSelect != null)
                abNoteSelect.Visibility = (display && CRMNotes.lvList.Visibility == Visibility.Visible && CRMNotes.lvList.SelectionMode != ListViewSelectionMode.Multiple) ? Visibility.Visible : Visibility.Collapsed;
            if (abNoteCancel != null)
                abNoteCancel.Visibility = (display && (CRMNotes.lvList.Visibility != Visibility.Visible ||
                    (CRMNotes.lvList.Visibility == Visibility.Visible && CRMNotes.lvList.SelectionMode == ListViewSelectionMode.Multiple)))
                    ? Visibility.Visible : Visibility.Collapsed;

            // Change commandBar DisplayMode only when the PivotItem is Selected
            if (display)
                commandBar.ClosedDisplayMode = (CRMNotes.lvList.Visibility == Visibility.Visible && CRMNotes.lvList.SelectionMode != ListViewSelectionMode.Multiple)
                    ? AppBarClosedDisplayMode.Minimal : AppBarClosedDisplayMode.Compact;
        }

        /// <summary>
        /// This method called when Resetting AppBarButton
        /// </summary>
        private async void ResetAppBarButtonDisplay()
        {
            // Wait until record data obtained
            while(record == null)
            {
                // if no record data yet, then wait 10 millisec
                await System.Threading.Tasks.Task.Delay(10);
            }

            // Reset AppBarButton
            ResetRecordAppBarButtonDisplay((pvRecord.SelectedItem as PivotItem).Name == "piRecord");
            ResetRelatedAppBarButtonDisplay((pvRecord.SelectedItem as PivotItem).Name == "piRelatedView");
            ResetNoteAppBarButtonDisplay((pvRecord.SelectedItem as PivotItem).Name == "piNotes");    
        }

        #endregion

        #region Page methods

        /// <summary>
        /// This method called when user select records. Update abRelatedDelete button IsEnabled depending on selection count 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (abRelatedDelete != null)
                abRelatedDelete.IsEnabled = (CRMGrid.lvList.SelectedItems.Count() > 0) ? true : false;
        }

        /// <summary>
        /// This method called when user select notes. Update abNoteDelete button IsEnabled depending on selection count 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crmNotes_lvList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (abNoteDelete != null)
                abNoteDelete.IsEnabled = (CRMNotes.lvList.SelectedItems.Count() > 0) ? true : false;
        }

        /// <summary>
        /// This method called when user clicks Add button in record PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abAdd_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve fields for new records. (existing one already have data in it)
            List<FormFieldData> fields = await CRMHelper.RetrieveFormFields(entityMetadataEx);

            // Generate parameters. As this is new record, passing null for record object.
            object[] parameters = new object[] { null, fields, entityMetadataEx };
            CRMHelper.temporaryData = parameters;
            // Then navigate to RecordModify Page.
            Frame.Navigate(typeof(RecordModifyPage));
        }

        /// <summary>
        /// This method is called when user clicks Edit button in record PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abEdit_Click(object sender, RoutedEventArgs e)
        {
            // Generate parameters. As this is edit record, passing current record.
            object[] parameters = new object[] { record, fields, entityMetadataEx };
            CRMHelper.temporaryData = parameters;
            // Then navigate to RecordModify Page.
            Frame.Navigate(typeof(RecordModifyPage));
        }

        /// <summary>
        /// This method is called when user clicks Delete button in record PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abDelete_Click(object sender, RoutedEventArgs e)
        {
            // Try delete record
            bool result = await CRMRecordDetail.DeleteRecord();

            // If successfully deleted record, then go back to Grid
            if (result)
            {
                if (Frame.CanGoBack)
                    Frame.GoBack();
                else
                    Frame.Navigate(typeof(EntityGridPage), (int)entityMetadataEx.EntityMetadata.ObjectTypeCode);
            }
                
        }

        /// <summary>
        /// This method is called when user clicks Add button in Related PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abRelatedAdd_Click(object sender, RoutedEventArgs e)
        {
            // Get RelatedData to create related record
            RelatedData relatedData = entityMetadataEx.RelatedEntities.Where(x => x.ReferencingEntity == (CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName).First();

            // Create Entity instance to created record, by fulling mapped values.
            Entity targetRecord = await CRMHelper.RetrieveRecordForRelated(record, relatedData, entityMetadataEx);
            // Make id to empty for sure (not mandatory?)
            targetRecord.Id = Guid.Empty;
            // Get Related entity's EntityMetadata
            EntityMetadataEx targetEntityMetadataEx = CRMHelper.EntityMetadataExCollection.Where(x => x.EntityMetadata.LogicalName == relatedData.ReferencingEntity).First();
            // Get fields for create form
            List<FormFieldData> targetFields = await CRMHelper.RetrieveFormFields(targetEntityMetadataEx);

            // Resets all the buttons
            ResetAppBarButtonDisplay();
            // Generate parameters. As this is new record, passing null for record object.
            object[] parameters = new object[] { targetRecord, targetFields, targetEntityMetadataEx };
            CRMHelper.temporaryData = parameters;
            // Then Navigate to RecordModifyPage
            Frame.Navigate(typeof(RecordModifyPage));
        }

        /// <summary>
        /// This method is called when user clicks Add Existing button in Related PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abAddExisting_Click(object sender, RoutedEventArgs e)
        {
            // Obtain related Datafrom selected entity
            RelatedData relatedData = entityMetadataEx.RelatedEntities.
                Where(x => x.ObjectTypeCode == (CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.ObjectTypeCode).First();
            // Pass FormFieldObject by using temporaryData of CRMHelpre
            CRMHelper.temporaryData = new object[] { record, relatedData, CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx };
            // Then navigate to SetRegardingPage
            Frame.Navigate(typeof(SetRegardingPage));
        }

        /// <summary>
        /// This method called when user clicks Select button in Related PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abSelect_Click(object sender, RoutedEventArgs e)
        {
            // Change seleciton mode to multiple
            CRMGrid.lvList.SelectionMode = ListViewSelectionMode.Multiple;
            // Suppress item click event
            CRMGrid.lvList.IsItemClickEnabled = false;
            // Change AppBarButton displays
            commandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
            if (abRelatedAdd != null)
                abRelatedAdd.Visibility = Visibility.Collapsed;
            if (abAddExisting != null)
                abAddExisting.Visibility = Visibility.Collapsed;
            abSelect.Visibility = Visibility.Collapsed;
            abRelatedDelete.Visibility = Visibility.Visible;
            abRelatedDelete.IsEnabled = false;
            abCancel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// This method called when user clicks Delete button in Related PivotItem after Select button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abRelatedDelete_Click(object sender, RoutedEventArgs e)
        {
            // Delete Selected Record
            await this.CRMGrid.DeleteRecords();
            // Reload data.
            Cancel();
        }

        /// <summary>
        /// This method called when user clicks Cancel button in Related PivotItem after Select button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abCancel_Click(object sender, RoutedEventArgs e)
        {
            // Reload data.
            Cancel();
        }

        /// <summary>
        /// This method simply reload data for Related PivotItem
        /// </summary>
        private void Cancel()
        {
            // Change selection mode to none
            CRMGrid.lvList.SelectionMode = ListViewSelectionMode.None;
            // Then enable item click event.
            CRMGrid.lvList.IsItemClickEnabled = true;
            // Change AppBarButton displays
            commandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Minimal;
            commandBar.IsOpen = false;
            if (abRelatedAdd != null)
                abRelatedAdd.Visibility = Visibility.Visible;
            if (abAddExisting != null)
                abAddExisting.Visibility = Visibility.Visible;

            abRelatedDelete.Visibility = Visibility.Collapsed;
            abSelect.Visibility = Visibility.Visible;
            abCancel.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// This method is called when user clicks Add button in Note PivotItem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abNoteAdd_Click(object sender, RoutedEventArgs e)
        {
            NoteAdd();
        }

        /// <summary>
        /// This method is called when user clicks Save button in Note PivotItem.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abNoteSave_Click(object sender, RoutedEventArgs e)
        {
            // Saves note first.
            await CRMNotes.SaveNote();
            // Restore AppBarButtons
            ResetAppBarButtonDisplay();
        }

        /// <summary>
        /// This method called when user clicks Select Button in Note PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abNoteSelect_Click(object sender, RoutedEventArgs e)
        {
            // Change Selection mode to Multiple
            CRMNotes.lvList.SelectionMode = ListViewSelectionMode.Multiple;
            // Suppress Item click event
            CRMNotes.lvList.IsItemClickEnabled = false;
            // Render AppBarButtons
            commandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
            if (abNoteAdd != null)
                abNoteAdd.Visibility = Visibility.Collapsed;
            abNoteSelect.Visibility = Visibility.Collapsed;
            abNoteDelete.Visibility = Visibility.Visible;
            abNoteDelete.IsEnabled = false;
            abNoteCancel.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// This method is called when user clicks Delete button in Note PivotItem after Select button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abNoteDelete_Click(object sender, RoutedEventArgs e)
        {
            // Delete note
            await CRMNotes.DeleteRecords();
            // Then reset page
            NoteCancel();
            await CRMNotes.LoadData();
        }

        /// <summary>
        /// This method is called when user clicks Cancel button in Note PivotItem after Select button clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abNoteCancel_Click(object sender, RoutedEventArgs e)
        {
            NoteCancel();
        }

        /// <summary>
        /// simply reload data for Note PivotItem
        /// </summary>
        private void NoteCancel()
        {
            // Change the selection mode back to None
            CRMNotes.lvList.SelectionMode = ListViewSelectionMode.None;
            // Then restore item click action
            CRMNotes.lvList.IsItemClickEnabled = true;
            // Render AppBarButton
            commandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Minimal;
            commandBar.IsOpen = false;
            if (abNoteAdd != null)
                abNoteAdd.Visibility = Visibility.Visible;
            if (abNoteSave != null)
                abNoteSave.Visibility = Visibility.Collapsed;

            abNoteDelete.Visibility = Visibility.Collapsed;
            abNoteSelect.Visibility = Visibility.Visible;
            abNoteCancel.Visibility = Visibility.Collapsed;

            // Swich the view to list
            CRMNotes.Cancel();
        }

        /// <summary>
        /// This method is called when user clicks Add button in Note PivotItem
        /// </summary>
        /// <param name="note"></param>
        private void NoteAdd(Annotation note = null)
        {
            // Add note
            CRMNotes.AddNote(note);
            // Then update controls
            abNoteAdd.Visibility = Visibility.Collapsed;
            abNoteSave.Visibility = Visibility.Visible;
            if (abNoteSelect != null)
                abNoteSelect.Visibility = Visibility.Collapsed;
            if (abNoteCancel != null)
                abNoteCancel.Visibility = Visibility.Visible;
            commandBar.ClosedDisplayMode = AppBarClosedDisplayMode.Compact;
        }

        #endregion

        #region Event handler

        /// <summary>
        /// This method called when user swipe to change PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pvRecord_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // When pivot item selection changed, then render AppBarButton for the item.
            ResetAppBarButtonDisplay();
        }

        /// <summary>
        /// This called when ActivityParty (which may have more than 1 item in a field) is touched.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ActivityParty_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Cast item to ActivityParty
            ActivityParty ap = (e.OriginalSource as TextBlock).DataContext as ActivityParty;
            // Find EntityMetadata (usually its SystemUser)
            EntityMetadataEx entityMetadataEx = CRMHelper.EntityMetadataExCollection.Where(x => x.EntityMetadata.LogicalName == ap.PartyId.LogicalName).FirstOrDefault();
            if (entityMetadataEx == null)
                return;

            // Pass data by using TemporaryData
            CRMHelper.temporaryData = new object[] { ap.PartyId.Id, entityMetadataEx };
            Frame.Navigate(typeof(RecordDetailPage));
        }

        /// <summary>
        /// This metohd called when Entity Selection changed in Related PivotItem
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void cbLookFor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Firstly remove existing AppBarButtons.
            if (abRelatedAdd != null)
                commandBar.PrimaryCommands.Remove(abRelatedAdd);
            if (abAddExisting != null)
                commandBar.PrimaryCommands.Remove(abAddExisting);
            if (abRelatedDelete != null)
            {
                commandBar.PrimaryCommands.Remove(abRelatedDelete);
                commandBar.PrimaryCommands.Remove(abSelect);
                commandBar.PrimaryCommands.Remove(abCancel);
            }

            //  Set schemaName to check privilege
            string RelatedRecordSchemaName = "";
            if (((sender as ComboBox).SelectedItem as EntityMetadataEx).EntityMetadata.IsActivity == true)
                RelatedRecordSchemaName = "Activity";
            else
                RelatedRecordSchemaName = ((sender as ComboBox).SelectedItem as EntityMetadataEx).EntityMetadata.SchemaName;

            // Render AppBarButton
            if (CRMHelper.CheckPrivilege(MainRecordSchemaName, PrivilegeType.AppendTo, PrivilegeDepth.Basic) &&
                CRMHelper.CheckPrivilege(RelatedRecordSchemaName, PrivilegeType.Append, PrivilegeDepth.Basic) &&
                CRMHelper.CheckPrivilege(RelatedRecordSchemaName, PrivilegeType.Create, PrivilegeDepth.Basic))
            {
                abRelatedAdd = new AppBarButton();
                abRelatedAdd.Icon = new SymbolIcon(Symbol.Add);
                abRelatedAdd.Name = "abRelatedAdd";
                abRelatedAdd.Label = loader.GetString("abRelatedAdd\\Label");
                abRelatedAdd.Click += abRelatedAdd_Click;
                commandBar.PrimaryCommands.Add(abRelatedAdd);
            }
            if (CRMHelper.CheckPrivilege(MainRecordSchemaName, PrivilegeType.AppendTo, PrivilegeDepth.Basic) &&
               CRMHelper.CheckPrivilege(RelatedRecordSchemaName, PrivilegeType.Append, PrivilegeDepth.Basic))
            {
                abAddExisting = new AppBarButton();
                BitmapIcon bitmapIcon = new BitmapIcon();
                bitmapIcon.UriSource = new Uri("ms-appx:///Assets/Data-Add.png");
                abAddExisting.Icon = bitmapIcon;
                abAddExisting.Name = "abAddExisting";
                abAddExisting.Label = loader.GetString("abAddExisting\\Label");
                abAddExisting.Click += abAddExisting_Click;
                commandBar.PrimaryCommands.Add(abAddExisting);
            }
            if (CRMHelper.CheckPrivilege(MainRecordSchemaName, PrivilegeType.AppendTo, PrivilegeDepth.Basic) &&
                CRMHelper.CheckPrivilege(RelatedRecordSchemaName, PrivilegeType.Append, PrivilegeDepth.Basic))
            {
                abRelatedDelete = new AppBarButton();
                abRelatedDelete.Icon = new SymbolIcon(Symbol.Delete);
                abRelatedDelete.Name = "abRelatedDelete";
                abRelatedDelete.Label = loader.GetString("abRelatedDelete\\Label");
                abRelatedDelete.Click += abRelatedDelete_Click;
                commandBar.PrimaryCommands.Add(abRelatedDelete);
                abSelect = new AppBarButton();
                abSelect.Icon = new SymbolIcon(Symbol.List);
                abSelect.Name = "abSelect";
                abSelect.Label = loader.GetString("abSelect\\Label");
                abSelect.Click += abSelect_Click;
                commandBar.PrimaryCommands.Add(abSelect);
                abCancel = new AppBarButton();
                abCancel.Icon = new SymbolIcon(Symbol.Cancel);
                abCancel.Name = "abCancel";
                abCancel.Label = loader.GetString("abCancel\\Label");
                abCancel.Click += abCancel_Click;
                commandBar.PrimaryCommands.Add(abCancel);
            }

            // Reset selection mode
            CRMGrid.lvList.SelectionMode = ListViewSelectionMode.None;

            // Call ResetRelatedAppBarButtonDisplay when Related view is displayed.
            if (pvRecord.SelectedItem !=null && (pvRecord.SelectedItem as PivotItem).Name == "piRelatedView")
                ResetRelatedAppBarButtonDisplay((pvRecord.SelectedItem as PivotItem).Name == "piRelatedView");
        }

        /// <summary>
        /// This method is called when usre click a record in Related Grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lvList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Obtain clicked ViewData
            var item = e.ClickedItem as ViewData;
            // Retrieve EntityName
            string entityName = (string.IsNullOrEmpty(item.ActivityTypeName)) ?
                (CRMGrid.cbLookFor.SelectedItem as EntityMetadataEx).EntityMetadata.LogicalName : item.ActivityTypeName;

            // Then retrieve Metadata for it.
            EntityMetadataEx entityMetadataEx = CRMHelper.EntityMetadataExCollection.
                Where(x => x.EntityMetadata.LogicalName == entityName).FirstOrDefault();

            if (entityMetadataEx == null)
            {
                MessageDialog dialog = new MessageDialog(loader.GetString("NotValidForMobile"), entityName);
                await dialog.ShowAsync();
                return;
            }

            // Put temporary data for RecordDetailPage
            CRMHelper.temporaryData = new object[] { item.Id, entityMetadataEx };
            // Then nagivate to RecordDetailPage
            Frame.Navigate(typeof(RecordDetailPage));
        }

        /// <summary>
        /// This method is called when usre clicks a note
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void crmNotes_lvList_ItemClick(object sender, RoutedEventArgs e)
        {
            NoteAdd((sender as TextBlock).DataContext as Annotation);
        }

        #endregion

        #region FilePickerHandler

        // to add attachment to note
        public void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
            // Restore AppBarButton Display
            abNoteAdd_Click(null, null);

            if ((args.ContinuationData["AttachmentFile"] as string) == "AttachmentFile" && args.Files != null && args.Files.Count > 0)
            {
                StorageFile file = args.Files[0];
                CRMNotes.FileName = file.Name;
                CRMNotes.AttachmentFile = file;
            }
        }

        // For attachemnt to save and open
        public async void ContinueFileSavePicker(FileSavePickerContinuationEventArgs args)
        {
            if ((args.File != null))
            {
                // open existing file
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFile noteAttachment = await localFolder.GetFileAsync(args.File.Name);
                
                // save to new location
                await FileIO.WriteBufferAsync(args.File, await FileIO.ReadBufferAsync(noteAttachment));
                // delete old one
                await CRMNotes.DeleteTemporaryData();
                // Then open 
                await Launcher.LaunchFileAsync(args.File);
            }
        }

        #endregion 

    }
}
