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
using Windows.ApplicationModel.Resources;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.System;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace CRMtoGo
{
    public delegate void lvListItem_ClickEventHandler(object sender, RoutedEventArgs e);
    public sealed partial class CRMNotes : UserControl
    {
        #region Class Property

        // Exposed Event
        public event lvListItem_ClickEventHandler lvListItem_Click;

        public Guid Id { get; set; }
        public EntityMetadataEx EntityMetadataEx { get; set; }
        // For new record
        public StorageFile AttachmentFile { get; set; }
        public string FileName {
            set
            {
                lblFileName.Text = value;
            }
        }

        private StorageFile noteAttachment;

        private double w;

        ResourceLoader loader = new ResourceLoader();

        #endregion

        public CRMNotes()
        {
            this.InitializeComponent();
        }

        #region Control methods

        /// <summary>
        /// This method load data to control
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task LoadData()
        {
            // Obtain page width
            w = Window.Current.Bounds.Width;

            progressRing.IsActive = true;

            // Load notes
            lvList.ItemsSource = await CRMHelper.RetrieveNotes(Id, (int)EntityMetadataEx.EntityMetadata.ObjectTypeCode);

            progressRing.IsActive = false;
        }

        /// <summary>
        /// Invoked when user clicks filename, which downloads attachment file and open.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void lblFileName_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Get note item from sender
            StackPanel sp = (sender as TextBlock).Parent as StackPanel;
            Annotation note = sp.DataContext as Annotation;

            // I may need to cache and try to get from cache for attachment as some are big.
            // At least i can let users decide if they want to download or not.

            // Show download message.
            var result = await Util.ShowConfirmMessage(loader.GetString("ConfirmDownloadAttachment"), loader.GetString("Yes"), loader.GetString("No"), 0);

            // If user doesn't want to download it, then do nothing.
            if (!result)
                return;

            progressRing.IsActive = true;

            // Delete temporary data first
            await DeleteTemporaryData();
            // Then obtain attachment
            noteAttachment = await CRMHelper.RetrieveNoteAttachment((Guid)note.AnnotationId);

            progressRing.IsActive = false;

            // Show confirm message
            result = await Util.ShowConfirmMessage(loader.GetString("ConfirmOpenSave"), loader.GetString("Open"), loader.GetString("Save"), 0);

            // if user just want to open it, then open it.
            if (result)
            {
                await Launcher.LaunchFileAsync(noteAttachment);
            }
            else
            {
                // Save to any location.
                var picker = new FileSavePicker();

#if WINDOWS_PHONE_APP
                picker.SuggestedFileName = noteAttachment.Name;
                picker.FileTypeChoices.Add(noteAttachment.DisplayType.ToString(), new List<string> { noteAttachment.FileType.ToString() });
                picker.SuggestedSaveFile = noteAttachment;
                picker.PickSaveFileAndContinue();
#endif
            }
        }

        /// <summary>
        /// This method delete temporary saved data
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task DeleteTemporaryData()
        {
            if (noteAttachment != null)
            {
                await noteAttachment.DeleteAsync();
                noteAttachment = null;
            }
        }

        /// <summary>
        /// This method deletes a note record
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task DeleteRecords()
        {
            // Show download message.
            var result = await Util.ShowConfirmMessage(loader.GetString("ConfirmDeleteNote"), loader.GetString("Yes"), loader.GetString("No"), 1);

            if (!result)
                return;

            progressRing.IsActive = true;

            // Delete selected notes.
            foreach (Annotation note in lvList.SelectedItems)
            {
                await CRMHelper.DeleteRecord(note);
            }

            progressRing.IsActive = false;
        }

        /// <summary>
        /// This methods display new note control
        /// </summary>
        /// <param name="record"></param>
        public void AddNote(Annotation record = null)
        {
            lvList.Visibility = Visibility.Collapsed;
            spNote.Visibility = Visibility.Visible;
            spNote.DataContext = record;
        }

        /// <summary>
        /// This method saves note.
        /// </summary>
        /// <returns></returns>
        public async System.Threading.Tasks.Task SaveNote()
        {
            progressRing.IsActive = true;

            // Instantiate note
            Annotation annotation = new Annotation();

            // Set regarding
            annotation.ObjectId = new EntityReference(EntityMetadataEx.EntityMetadata.LogicalName, Id);
            annotation.Subject = txtTitle.Text;
            annotation.NoteText = txtNoteText.Text;

            // If there is an attachment file, then handle it.
            if (AttachmentFile != null)
            {
                annotation.FileName = AttachmentFile.Name;

                IRandomAccessStreamWithContentType fileStream = await AttachmentFile.OpenReadAsync();
                byte[] fileBytes = null;
                fileBytes = new byte[fileStream.Size];
                using (DataReader reader = new DataReader(fileStream))
                {
                    await reader.LoadAsync((uint)fileStream.Size);
                    reader.ReadBytes(fileBytes);
                }
                annotation.DocumentBody = Convert.ToBase64String(fileBytes);
            }
            if (!String.IsNullOrEmpty(txtId.Text))
                annotation.Id = Guid.Parse(txtId.Text);

            // Create a note
            await CRMHelper.UpsertRecord(annotation);

            // Reverse the control visibility
            lvList.Visibility = Visibility.Visible;
            spNote.Visibility = Visibility.Collapsed;

            // Reload data
            await LoadData();
            
            progressRing.IsActive = false;
        }

        public void Cancel()
        {
            lvList.Visibility = Visibility.Visible;
            spNote.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// This method let user pickup file from local/remote storage
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAttach_Click(object sender, RoutedEventArgs e)
        {
            var picker = new FileOpenPicker();
            picker.FileTypeFilter.Add("*");
#if WINDOWS_PHONE_APP
            picker.ContinuationData["AttachmentFile"] = "AttachmentFile";
            picker.PickSingleFileAndContinue();
#endif
        }

        // Raise ItemClick event
        private void lblTitle_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.lvListItem_Click(sender, e);
        }

        // Raise ItemClick event
        private void lblNoteText_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.lvListItem_Click(sender, e);
        }

        #endregion
    }
}
