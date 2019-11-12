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
using Microsoft.Xrm.Sdk.Query.Samples;
using Microsoft.Xrm.Sdk.Samples;
using MyTypes;
using System;
using System.Linq;
using System.Collections.Generic;
using Windows.ApplicationModel.Resources;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace CRMtoGo
{
    public delegate void LookupButton_ClickEventHandler(object sender, RoutedEventArgs e);
    public delegate void ActivityPartyAddButton_ClickEventHandler(object sender, RoutedEventArgs e);
    public sealed partial class CRMRecordModify : UserControl
    {
        #region Class Property

        public event LookupButton_ClickEventHandler Lookup_Click;

        public event ActivityPartyAddButton_ClickEventHandler ActivityPartyAdd_Click;

        // The record's EntityMetadata
        public EntityMetadataEx EntityMetadataEx { get; set; }

        // The record's Id
        public Guid Id { get; set; }

        //The record data
        public Entity Record { get; internal set; }

        // Fields for this form with AttributeMetadata and data
        public List<FormFieldData> Fields { get; internal set; }
        
        // Parameters
        private bool isUpdate = true;
        private bool isRegarding = false;

        // Instantiate ResourceLoader to load strings for label
        ResourceLoader loader = new ResourceLoader();

        #endregion

        public CRMRecordModify()
        {
            this.InitializeComponent();
        }

        #region Control methods

        /// <summary>
        /// Loading data 
        /// </summary>
        public void LoadData()
        {
            // Show ProgressRing
            progressRing.IsActive = true;

            // Check if this is Create or Update 
            // If there is no Record data then it is Create, or data without Id information, then it's for new Record
            if (Record == null)
            {
                isUpdate = false;
            }
            // If record is not null but Id is empty, then this is regarding (as if it comes from regarding record data is filled depending on mapping)
            else if (Record.Id == Guid.Empty)
            {
                isUpdate = false;
                isRegarding = true;
            }

            // Iterate through each Field and display on the form
            foreach (var field in Fields)
            {
                // If this is update form yet the field is not valid for update, then go next field.
                // If this is create form yet the field is not valid for create, then go next field.
                if ((isUpdate && !(bool)field.FieldMetadata.IsValidForUpdate) || (!isUpdate && !(bool)field.FieldMetadata.IsValidForCreate))
                    continue;

                // If this is create or new as regarding yet no data exist, then fill it.
                if ((isUpdate || isRegarding) && field.FieldData == null)
                    field.FieldData = (Record.Attributes.Contains(field.FieldMetadata.LogicalName)) ? 
                        Record.Attributes[field.FieldMetadata.LogicalName] : null;

                // If the field is owner but no data filled, assign current user as owner.
                if (field.FieldMetadata.LogicalName == "ownerid" && field.FieldData == null)
                {
                    EntityReference owner = new EntityReference(SystemUser.EntityLogicalName, (Guid)CRMHelper.UserInfo.SystemUserId);
                    owner.Name = CRMHelper.UserInfo.FullName;
                    field.FieldData = owner;
                }

                // Create field
                Grid grid = CRMHelper.GenerateField(field, isUpdate);

                // If nothing returned, then go to next field.
                if (grid == null)
                    continue;

                // If the field has LookupControl in it (means this is owner, lookup, customer), then assing click event.
                if (grid.Children[1].GetType().Equals(typeof(LookupControl)))
                    (grid.Children[1] as LookupControl).LookupControlButton_Click += LookupButton_Click;

                // If the field has ActivityPartyLookupControl, then assign Add/Delete method.
                if (grid.Children[1].GetType().Equals(typeof(ActivityPartyLookupControl)))
                {
                    (grid.Children[1] as ActivityPartyLookupControl).ActivityPartyAddButton_Click += ActivityPartyAddButton_Click;
                    (grid.Children[1] as ActivityPartyLookupControl).ActivityPartyDeleteButton_Click += ActivityPartyDelteButton_Click;
                }
                
                // If the field has EntityImageControl, then place it on the top of the form.
                if(grid.Children[1].GetType().Equals(typeof(EntityImageControl)))
                    this.lvFields.Items.Insert(0, grid);
                // Anything else, just add to the form.
                else
                    this.lvFields.Items.Add(grid);
            }

            // Supress ProgressRing
            progressRing.IsActive = false;
        }

        /// <summary>
        /// This method "remove" activity party from the record. Does not "delete" actual record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ActivityPartyDelteButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtain current ActityParties
            EntityCollection currentParties = new EntityCollection();
            currentParties.Entities.AddRange(((((sender as Button).Parent as Grid).DataContext as FormFieldData).FieldData as EntityCollection).Entities);
 
            // Obtain remove ActivityParty
            Entity recordToRemove = (sender as Button).DataContext as Entity;

            // Remove it
            currentParties.Entities.Remove(recordToRemove);

            (((sender as Button).Parent as Grid).DataContext as FormFieldData).FieldData = currentParties;
            ((((sender as Button).Parent as Grid).Parent as StackPanel).Parent as ActivityPartyLookupControl).Records = currentParties;
        }

        void ActivityPartyAddButton_Click(object sender, RoutedEventArgs e)
        {
            this.ActivityPartyAdd_Click(sender, e);
        }


        void LookupButton_Click(object sender, RoutedEventArgs e)
        {
            this.Lookup_Click(sender, e);
        }

        /// <summary>
        /// This method saves the record
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<Entity> Save()
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

            // Only update modified fields
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
                    return null;
                }
                // If value has been changed, then pass the data to modified record.
                modifiedRecord[field.FieldMetadata.LogicalName] = field.FieldData;
            }

            progressRing.IsActive = true;
            
            // Create/Update record.
            Entity result = await CRMHelper.UpsertRecord(modifiedRecord);
            // If this is update then retrieve latest data again from server after update and return.
            if (isUpdate)
            {
                ColumnSet columnSet = new ColumnSet();
                columnSet.AddColumns(Fields.Select(x => x.FieldMetadata.LogicalName).ToArray());

                return await CRMHelper.RetrieveRecord(EntityMetadataEx.EntityMetadata, result.Id, columnSet);
            }
            // If this is new record, then simply return result.
            else
                return result;
        }

        #endregion
    }
}
