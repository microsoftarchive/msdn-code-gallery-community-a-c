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
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.Resources;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CRMtoGo
{
    public delegate void ActivityParty_TappedEventHandler(object sender, TappedRoutedEventArgs e);
    public sealed partial class CRMRecordDetail : UserControl
    {
        #region Class Property

        public event ActivityParty_TappedEventHandler ActivityParty_Tapped;

        // The record's EntityMetadata
        public EntityMetadataEx EntityMetadataEx { get; set; }

        // The record's Id
        public Guid Id { get; set; }
        
        //The record data
        public Entity Record { get; internal set; }

        // Fields for this form with AttributeMetadata and data
        public List<FormFieldData> Fields { get; internal set; }

        // Requested fields for this form. If not specified, then use mobile form definition.
        public List<String> RequestFields { get;  set; }

        // Resource Loader for Multilanguage
        ResourceLoader loader = new ResourceLoader();

        #endregion

        public CRMRecordDetail()
        {
            this.InitializeComponent();
        }

        #region Control methods

        /// <summary>
        /// Loading data 
        /// </summary>
        public async System.Threading.Tasks.Task LoadData()
        {
            // Get windows width
            var w = Window.Current.Bounds.Width;

            // Show ProgressRing
            progressRing.IsActive = true;

            // If there is not cache, then retrieve the fields 
            if (Fields == null)
                Fields = await CRMHelper.RetrieveFormFields(EntityMetadataEx, RequestFields);

            // Store field logical name to ColumnSet 
            ColumnSet cols = new ColumnSet(Fields.Select(x=>x.FieldMetadata.LogicalName).ToArray());

            // If there is not cache, then retrieve the record 
            if (Record == null)                
                Record = await CRMHelper.RetrieveRecord(EntityMetadataEx.EntityMetadata, Id, cols);

            // Create fields on the form
            foreach (var field in Fields)
            {
                // Instantiate StackPanel which represents a field
                StackPanel sp = new StackPanel();

                // Skip if there is no value returned or if the field is not for read
                if (!Record.Attributes.Contains(field.FieldMetadata.LogicalName) || !(bool)field.FieldMetadata.IsValidForRead)
                    continue;

                // If it is primray field, then just store it (which will be used in Page Title in this sample)
                if (field.FieldMetadata.LogicalName == EntityMetadataEx.EntityMetadata.PrimaryNameAttribute)
                {
                    field.FieldData = Record.Attributes[field.FieldMetadata.LogicalName].ToString();
                    continue;
                }

                // If it is image field, then place it on the top
                if (field.FieldMetadata.LogicalName == EntityMetadataEx.EntityMetadata.PrimaryImageAttribute)
                {
                    // Store data
                    field.FieldData = Record.Attributes[field.FieldMetadata.LogicalName];
                    
                    // Instantiate Image and give same height/width.
                    EntityImageControl imageControl = new EntityImageControl();
                    imageControl.ImageBytes = field.FieldData as byte[];
                    // Mark it as ReadOnly
                    imageControl.ReadOnly = true;

                    // Finally add it.
                    sp.Children.Add(imageControl);
                    sp.DataContext = field;

                    // Add imgae to top of the form.
                    this.lvFields.Items.Insert(0, sp);
                    
                    // Image Field doesn't need further processing.
                    continue;
                }

                // Skip if it is address field (not email address though) and not composite field,
                // as Composite contorl data will be displayed on the form instead individual field.
                if (field.FieldMetadata.GetType().Equals(typeof(StringAttributeMetadata)) 
                    && (field.FieldMetadata as StringAttributeMetadata).Format != StringFormat.Email
                    && (field.FieldMetadata.LogicalName.Contains("address") 
                    && !field.FieldMetadata.LogicalName.Contains("composite")))
                    continue;
                
                // For other fields

                // Set field name on the left of the field. If you want to set field name
                // above the data, change folloing to sp.Orientation = Orientation.Vertical;
                sp.Orientation = Orientation.Horizontal;
                // Assign data to FieldData
                field.FieldData = Record.Attributes[field.FieldMetadata.LogicalName];                
                // Set Field Displayname
                TextBlock label = new TextBlock();
                label.Text = field.FieldMetadata.DisplayName.UserLocalizedLabel.Label + ": ";
                // Changing stile
                label.Style = (Style)Application.Current.Resources["BodyTextBlockStyle"];
                // Fix the field name width but mark it as Wrap so that long field name can be shown.
                label.Width = 100;
                label.TextWrapping = TextWrapping.Wrap;
                // Finally add it.
                sp.Children.Add(label);

                // Set field data. User Formatted Value if available.
                object value = CRMHelper.GetValue((Record.FormattedValues.Contains(field.FieldMetadata.LogicalName) ?
                    Record.FormattedValues[field.FieldMetadata.LogicalName] : Record.Attributes[field.FieldMetadata.LogicalName]));

                // If value is string type
                if (value.GetType() == typeof(string))
                {
                    TextBlock fieldValue = new TextBlock();
                    fieldValue.Text = value.ToString();
                    fieldValue.Style = (Style)Application.Current.Resources["BodyTextBlockStyle"];
                    fieldValue.TextWrapping = TextWrapping.Wrap;
                    // Set width. The value is calculated by using field name width and mergin of List.
                    fieldValue.Width = w - 136;
                    sp.Children.Add(fieldValue);
                }
                // If value is Array type (which infer this is ActivityParty)
                else if (value.GetType().IsArray)
                {
                    // To represent each ActivityParty, create another StackPanel
                    //StackPanel childsp = new StackPanel();
                    // Loop items in Array
                    foreach (var item in value as Array)
                    {
                        TextBlock fieldValue = new TextBlock();
                        // Add tap event. When an ActivityParty tapped, it navigates to the record.
                        fieldValue.IsTapEnabled = true;
                        fieldValue.Tapped += ActivityPartyField_Tapped;
                        // Set an ActivityParty to DataContext
                        fieldValue.DataContext = item;
                        fieldValue.Text = ((ActivityParty)item).PartyId.Name;
                        fieldValue.Style = (Style)Application.Current.Resources["BodyTextBlockStyle"];
                        sp.Children.Add(fieldValue);
                    }
                    //sp.Children.Add(childsp);
                }

                // Set field data to DataContext
                sp.DataContext = field;
                // Add to form
                this.lvFields.Items.Add(sp);
            }

            // Suppress ProgressRing
            progressRing.IsActive = false;       
        }
     
        /// <summary>
        /// This called when ActivityParty (which may have more than 1 item in a field) is touched.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ActivityPartyField_Tapped(object sender, TappedRoutedEventArgs e)
        {
            ActivityParty_Tapped(sender, e);  
        }

        /// <summary>
        /// Delete current record
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<bool> DeleteRecord()
        {
            // Display confirm message with Yes/No option
            var result = await Util.ShowConfirmMessage(loader.GetString("ConfirmDelete"), loader.GetString("Yes"), loader.GetString("No"), 1);

            // If user click no, then do nothing.
            if (!result)
                return false;

            // Otherwise delete recrod(s). Show progress ring first.
            progressRing.IsActive = true;

            // Then delete
            await CRMHelper.DeleteRecord(Record);

            progressRing.IsActive = false;
            
            // Let page handle navigation
            return true;
        }

        #endregion
    }
}
