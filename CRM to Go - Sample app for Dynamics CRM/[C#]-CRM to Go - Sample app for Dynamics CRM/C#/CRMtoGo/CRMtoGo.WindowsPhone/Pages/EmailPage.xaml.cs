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
using MyTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel.Activation;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace CRMtoGo.Pages
{
    /// <summary>
    /// This page display Email form.
    /// </summary>
    public sealed partial class EmailPage : Page, IFileOpenPickerContinuable, IWebAuthenticationContinuable
    {
        #region Class Property

        private Entity record; // Current record
        private List<FormFieldData> fields; // Fields for this form
        private EntityMetadataEx entityMetadataEx; // Current record's EntityMetadata

        #endregion 

        public EmailPage()
        {
            this.InitializeComponent();

            // Register NavigationHelper
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += this.NavigationHelper_LoadState;
            this.navigationHelper.SaveState += this.NavigationHelper_SaveState;
        }

        /// <summary>
        /// This method is called to initialze page.
        /// </summary>
        private void Initialize()
        {
            // Assign properties
            this.CRMEmail.Record = record;
            // first field is From field, so store it separately and remove from fields.
            var from = fields[0];
            fields.RemoveAt(0);
            this.CRMEmail.Fields = fields;
            this.CRMEmail.EntityMetadataEx = entityMetadataEx;

            // Then load data
            this.CRMEmail.LoadData();
        }

        #region NavigationHelper registration

        private NavigationHelper navigationHelper;

        /// <summary>
        /// Gets the <see cref="NavigationHelper"/> associated with this <see cref="Page"/>.
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void NavigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {
        }

        /// <summary>
        /// Preserves state associated with this page in case the application is suspended or the
        /// page is discarded from the navigation cache.  Values must conform to the serialization
        /// requirements of <see cref="SuspensionManager.SessionState"/>.
        /// </summary>
        /// <param name="sender">The source of the event; typically <see cref="NavigationHelper"/></param>
        /// <param name="e">Event data that provides an empty dictionary to be populated with
        /// serializable state.</param>
        private void NavigationHelper_SaveState(object sender, SaveStateEventArgs e)
        {
        }       

        /// <summary>
        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// <para>
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="NavigationHelper.LoadState"/>
        /// and <see cref="NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.
        /// </para>
        /// </summary>
        /// <param name="e">Provides data for navigation methods and event
        /// handlers that cannot cancel the navigation request.</param>
        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.navigationHelper.OnNavigatedTo(e);

            progressRing.IsActive = true;

            // If UserInfo is null, then initialize the helper
            if (CRMHelper.UserInfo == null)
                await CRMHelper.Initialize();

            if (fields == null) // Just navigated to this page
            {
                // Check if there is any temporaryData
                object[] parameters = CRMHelper.temporaryData as object[];
                if (parameters.Count() != 3)
                    new Exception("EmailPage needs 3 parameters. Record, Fields, EntityMetadataEx");
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
                    fields.Where(x => x.FieldMetadata.LogicalName == formfieldData.FieldMetadata.LogicalName).
                        First().FieldData = formfieldData.FieldData;
                }
            }

            Initialize();

            progressRing.IsActive = false;
        }

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
        /// Call SendEmail method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void abSend_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            await this.CRMEmail.SendEmail();
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void abCancel_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        /// <summary>
        /// Obtain Attachment.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void abAttach_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add("*");
#if WINDOWS_PHONE_APP
            picker.ContinuationData["AttachmentFile"] = "AttachmentFile";
            picker.PickSingleFileAndContinue();
#endif
        }

        #endregion

        #region FilePickerHandler

        /// <summary>
        /// This metohd called once uesr picks up attachment. Create ActivityMimeAttachment and
        /// add to lvList.
        /// </summary>
        /// <param name="args"></param>
        public async void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
            // If attachment selected
            if ((args.ContinuationData["AttachmentFile"] as string) == "AttachmentFile" && args.Files != null && args.Files.Count > 0)
            {
                // Read attachemnt into Stream
                Stream fs = await args.Files[0].OpenStreamForReadAsync();
                byte[] binaryData = new byte[fs.Length];
                long bytesRead = fs.Read(binaryData, 0, (int)fs.Length);

                ActivityMimeAttachment attach = new ActivityMimeAttachment() 
                {
                    ObjectId= new EntityReference("email", Guid.Empty),
                    ObjectTypeCode = "email",
                    Subject = "email attachment",
                    Body = Convert.ToBase64String(binaryData),
                    FileName = args.Files[0].Name
                };
                CRMEmail.lvList.Items.Add(attach);
            }
        }

        #endregion
    }
}
