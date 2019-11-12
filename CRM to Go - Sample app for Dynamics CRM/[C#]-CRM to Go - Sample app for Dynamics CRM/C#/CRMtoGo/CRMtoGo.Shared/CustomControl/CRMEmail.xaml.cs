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
using CRMtoGo.CustomControls;
using CRMtoGo.DataModel;
using Microsoft.Xrm.Sdk.Metadata.Samples;
using Microsoft.Xrm.Sdk.Samples;
using MyTypes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;

namespace CRMtoGo
{
    // Basically this is same as CRMRecordMofidy, but Email version
    public sealed partial class CRMEmail : UserControl
    {
        #region Class Property

        public event LookupButton_ClickEventHandler Lookup_Click;
        public event ActivityPartyAddButton_ClickEventHandler ActivityPartyAdd_Click;
        public EntityMetadataEx EntityMetadataEx { get; set; } // This Record's EntityMetadata which should be email
        public Guid Id { get; set; } // This records Id
        public Entity Record { get; internal set; } //This Record
        public List<FormFieldData> Fields { get; internal set; } // Field for this form

        private bool isUpdate = true;
        private bool isRegarding = false;

        // Instantiate ResourceLoader to load strings for label
        private ResourceLoader loader = new ResourceLoader();

        #endregion

        public CRMEmail()
        {
            this.InitializeComponent();
        }
        
        #region Control methods

        /// <summary>
        /// This methods LoadData to control
        /// </summary>
        public void LoadData()
        {
            progressRing.IsActive = true;

            // Check if Create or Update 
            // If there is no Record data, or data without id information, then it's for new Record
            if (Record == null || Record.Id == Guid.Empty)
            {
                isUpdate = false;
                // however, if Record is not null, then it is new operation for regarding item
                if (Record != null)
                    isRegarding = true;
            }
            foreach (var field in Fields)
            {
                if ((isUpdate && !(bool)field.FieldMetadata.IsValidForUpdate) || (!isUpdate && !(bool)field.FieldMetadata.IsValidForCreate))
                    continue;
                // do not show from field
                if (field.FieldMetadata.LogicalName == "from")
                    continue;
                if ((isUpdate || isRegarding) && field.FieldData == null)
                    field.FieldData = (Record.Attributes.Contains(field.FieldMetadata.LogicalName)) ? Record.Attributes[field.FieldMetadata.LogicalName] : null;
                if (field.FieldMetadata.LogicalName == "ownerid" && field.FieldData == null)
                {
                    EntityReference owner = new EntityReference(SystemUser.EntityLogicalName, (Guid)CRMHelper.UserInfo.SystemUserId);
                    owner.Name = CRMHelper.UserInfo.FullName;
                    field.FieldData = owner;
                }
                // Put description field to txtDescription in second grid row.
                if (field.FieldMetadata.LogicalName == "description")
                {
                    var w = Window.Current.Bounds.Width;
                    txtDescription.Width = w - 36;
                    txtDescription.DataContext = field;
                    Binding binding = new Binding();
                    binding.Path = new PropertyPath("FieldData");
                    binding.Mode = BindingMode.TwoWay;
                    txtDescription.SetBinding(TextBox.TextProperty, binding);
                    continue;
                }

                Grid grid = CRMHelper.GenerateField(field, isUpdate);

                if (grid.Children[1].GetType().Equals(typeof(LookupControl)))
                    (grid.Children[1] as LookupControl).LookupControlButton_Click += LookupButton_Click;
                if (grid.Children[1].GetType().Equals(typeof(ActivityPartyLookupControl)))
                {
                    (grid.Children[1] as ActivityPartyLookupControl).ActivityPartyDeleteButton_Click += ActivityPartyDelteButton_Click;
                    (grid.Children[1] as ActivityPartyLookupControl).ActivityPartyAddButton_Click += ActivityPartyAddButton_Click;
                }
                if (grid == null)
                    continue;
                
                this.lvFields.Items.Add(grid);
            }

            progressRing.IsActive = false;
        }

        /// <summary>
        /// This method is called when user clicks Add button for Activity Party
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ActivityPartyAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.ActivityPartyAdd_Click(sender, e);
        }

        /// <summary>
        /// This method is called when user clicks Delete button for Activity Party
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ActivityPartyDelteButton_Click(object sender, RoutedEventArgs e)
        {
            EntityCollection newCollection = new EntityCollection();
            newCollection.Entities.AddRange(((((sender as Button).Parent as Grid).DataContext as FormFieldData).FieldData as EntityCollection).Entities);
            Entity recordToRemove = (sender as Button).DataContext as Entity;
            newCollection.Entities.Remove(recordToRemove);
            (((sender as Button).Parent as Grid).DataContext as FormFieldData).FieldData = newCollection;
            ((((sender as Button).Parent as Grid).Parent as StackPanel).Parent as ActivityPartyLookupControl).Records = newCollection;
        }

        /// <summary>
        /// This method is called when user clicks Lookup button. Expose as Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void LookupButton_Click(object sender, RoutedEventArgs e)
        {
            this.Lookup_Click(sender, e);
        }

        /// <summary>
        /// Saves Email record with Attachments.
        /// </summary>
        /// <returns></returns>
        public async Task Save()
        {           
            Entity modifiedRecord;
            // If it is regarding, then pass all the record information which contains mapped data to modifiedrecord.
            if (isRegarding)
                modifiedRecord = Record;
            // Otherwise, create blank record
            else
                modifiedRecord = new Entity();
            modifiedRecord.LogicalName = EntityMetadataEx.EntityMetadata.LogicalName;

            // If update, then assign Id
            if (isUpdate)
                modifiedRecord.Id = Record.Id;
            foreach (var field in Fields)
            {
                // If no data changed, then no need to pass the value.
                if (isUpdate && field.FieldData == Record[field.FieldMetadata.LogicalName])
                    continue;
                // If required fields have no value, then show error message.
                if ((bool)field.FieldMetadata.IsValidForCreate && (field.FieldMetadata.RequiredLevel.Value == AttributeRequiredLevel.ApplicationRequired ||
                    field.FieldMetadata.RequiredLevel.Value == AttributeRequiredLevel.SystemRequired) &&
                    field.FieldData == null)
                {
                    MessageDialog dialog = new MessageDialog(string.Format(loader.GetString("RequiredField"), field.FieldMetadata.DisplayName.UserLocalizedLabel.Label));
                    await dialog.ShowAsync();
                    lvFields.SelectedItem = ((lvFields.FindName("lbl" + field.FieldMetadata.LogicalName) as TextBlock).Parent as StackPanel).Parent;
                    lvFields.UpdateLayout();
                    lvFields.ScrollIntoView(lvFields.SelectedItem);
                    return;
                }
                // If value has been changed, then pass the data to modified record.
                modifiedRecord[field.FieldMetadata.LogicalName] = field.FieldData;
            }

            progressRing.IsActive = true;

            // Create/Update record and store the id back original record
            Record =  await CRMHelper.UpsertRecord(modifiedRecord);

            // Now check attachments.
            foreach (ActivityMimeAttachment attachment in this.lvList.Items)
            {
                // Assign regarding activity. Attachment should have ObjectTypeCode already
                attachment.ObjectId = Record.ToEntityReference();
                // Then save it
                await CRMHelper.UpsertRecord(attachment);
            }

            progressRing.IsActive = false;
        }

        /// <summary>
        /// Removes attachment from email.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.lvList.Items.Remove(((sender as Image).Parent as Grid).DataContext);
        }

        /// <summary>
        /// Saved Record, then send email
        /// </summary>
        /// <returns></returns>
        public async Task SendEmail()
        {
            // If record does not have Id, then save it first.
            if (Record == null || Record.Id == null || Record.Id == Guid.Empty)
                await Save();

            // Send the email
            await CRMHelper.SendEmail(Record.Id);
        }

        #endregion
    }
}
