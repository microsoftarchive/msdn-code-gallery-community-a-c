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
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

namespace CRMtoGo.Pages
{
    /// <summary>
    /// This page is used to Create/Modify record. Inherit IFileOpenPickerContinuable to take picture.
    /// </summary>
    public sealed partial class RecordModifyPage : Page, IFileOpenPickerContinuable, IWebAuthenticationContinuable
    {
        #region Class Property

        private Entity record; // Current record
        private List<FormFieldData> fields; // Fields for this form
        private EntityMetadataEx entityMetadataEx; // Current record's EntityMetadata

        #endregion

        /// <summary>
        /// Constructor for this page.
        /// </summary>
        public RecordModifyPage()
        {
            this.InitializeComponent();

            // Register NavigationHelper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;

            // Register Event handler for lookup and ActivityParty Add click
            this.CRMRecordModify.Lookup_Click += Lookup_Click;
            this.CRMRecordModify.ActivityPartyAdd_Click += ActivityPartyAdd_Click;
        }

        /// <summary>
        /// This method is called to initialze page.
        /// </summary>
        private void Initialize()
        {
            // Assign properties
            this.CRMRecordModify.Record = record;
            this.CRMRecordModify.Fields = fields;
            this.CRMRecordModify.EntityMetadataEx = entityMetadataEx;
            // Then load data
            this.CRMRecordModify.LoadData();
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
            if (e.PageState != null && e.PageState.ContainsKey("record"))
            {
                this.record = e.PageState["record"] as Entity;
            }
            if (e.PageState != null && e.PageState.ContainsKey("fields"))
            {
                this.fields = e.PageState["fields"] as List<FormFieldData>;
            }
            if (e.PageState != null && e.PageState.ContainsKey("fields"))
            {
                this.entityMetadataEx = e.PageState["entityMetadataEx"] as EntityMetadataEx;
            }
        }

        /// <summary>
        /// This method called when page is unloaded to save state
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
            e.PageState["record"] = record;
            e.PageState["fields"] = fields;
            e.PageState["entityMetadataEx"] = entityMetadataEx;
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

            if (fields == null) // If fields are not yet has value, means just navigated to this page
            {
                // Check if there is any temporaryData
                object[] parameters = CRMHelper.temporaryData as object[];
                if (parameters.Count() != 3)
                    new Exception("RecordModifyPage needs 3 parameters. Record, Fields, EntityMetadataEx");
                this.record = parameters[0] as Entity; // record for update/related new
                this.fields = parameters[1] as List<FormFieldData>; // form fields
                this.entityMetadataEx = parameters[2] as EntityMetadataEx; // target entity  
            }
            else // It has been restored of page back from lookup page
            {
                // Assign lookup value when retruning from lookup page.
                if (CRMHelper.temporaryData != null &&
                    CRMHelper.temporaryData.GetType().Equals(typeof(FormFieldData)))
                {
                    FormFieldData formfieldData = CRMHelper.temporaryData as FormFieldData;
                    fields.Where(x => x.FieldMetadata.LogicalName == formfieldData.FieldMetadata.LogicalName).First().FieldData = formfieldData.FieldData;
                }
            }

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
        /// This method is called when user clicks Lookup icon.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Lookup_Click(object sender, RoutedEventArgs e)
        {
            // LookupDialogPage requires 4 parameters: CRMHelper, Targets, EntityMetadataCollection and FormFieldData
            string[] targets = (((sender as Button).DataContext as FormFieldData).FieldMetadata as LookupAttributeMetadata).Targets;

            // Pass FormFieldObject by using temporaryData of CRMHelpre
            CRMHelper.temporaryData = new object[] { (sender as Button).DataContext as FormFieldData, targets };
            // Then navigate to LookupDialogPage
            Frame.Navigate(typeof(LookupDialogPage));
        }

        /// <summary>
        /// This method is called when user click Add ActivityParty
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ActivityPartyAdd_Click(object sender, RoutedEventArgs e)
        {
            // LookupDialogPage requires 4 parameters: CRMHelper, Targets, EntityMetadataCollection and FormFieldData
            string[] targets = ((((sender as Button).Parent as StackPanel).DataContext as FormFieldData).FieldMetadata as LookupAttributeMetadata).Targets;

            // Pass FormFieldObject by using temporaryData of CRMHelpre
            CRMHelper.temporaryData = new object[] { (sender as Button).DataContext as FormFieldData, targets };
            // Then navigate to LookupDialogPage
            Frame.Navigate(typeof(LookupDialogPage));
        }

        /// <summary>
        /// This method called when user clicks Save Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abSave_Click(object sender, RoutedEventArgs e)
        {
            // Save the record.
            Entity result = await this.CRMRecordModify.Save();
            // If saved, then set the data and go back
            if (result != null)
            {
                object[] parameters = new object[] { result };
                CRMHelper.temporaryData = parameters;
                if (Frame.CanGoBack)
                    Frame.GoBack();
            }
            // Otherwise stay  
            else
            {
            }
        }

        /// <summary>
        /// This method called when user clicks Cancel Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abCancel_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        #endregion

        #region FilePickerHandler

        // For picture
        public async void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
            if ((args.ContinuationData["EntityImage"] as string) == "EntityImage" && args.Files != null && args.Files.Count > 0)
            {
                // Check if the entity has entityimage anyway.
                var imageField = fields.Where(x => x.FieldMetadata.LogicalName == "entityimage").FirstOrDefault();
                if (imageField != null)
                {
                    StorageFile file = args.Files[0];
                    IRandomAccessStreamWithContentType fileStream = await file.OpenReadAsync();
                    BitmapImage im = new BitmapImage();
                    im.SetSource(fileStream);
                    fileStream.Seek(0);
                    byte[] fileBytes = null;
                    fileBytes = new byte[fileStream.Size];
                    using (DataReader reader = new DataReader(fileStream))
                    {
                        await reader.LoadAsync((uint)fileStream.Size);

                        reader.ReadBytes(fileBytes);
                    }

                    imageField.FieldData = fileBytes;
                    ((this.CRMRecordModify.lvFields.Items.First() as Grid).Children[1] as EntityImageControl).ImageBytes = fileBytes;

                }
                return;
            }
        }

        #endregion
    }
}
