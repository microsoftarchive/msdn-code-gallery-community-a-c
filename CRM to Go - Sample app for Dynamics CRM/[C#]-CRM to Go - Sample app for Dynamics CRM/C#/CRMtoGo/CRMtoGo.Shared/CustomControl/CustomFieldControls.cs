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

using CRMtoGo.DataModel;
using Microsoft.Xrm.Sdk.Metadata.Samples;
using Microsoft.Xrm.Sdk.Samples;
using MyTypes;
using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Windows.ApplicationModel.Resources;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace CRMtoGo.CustomControls
{
    #region NumberBox

    /// <summary>
    /// Custom Control for Number type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class NumberBox<T> : TextBox where T : new()
    {
        // Instantiate ResourceLoader to load strings for label
        private ResourceLoader loader = new ResourceLoader();

        public T GetNewItem()
        {
            return new T();
        }
        public NumberBox()
        {          
            // Assign validation method for keydown
            this.KeyDown += NumericTextBox_KeyDown;
            // Assign validation method for Lostfocus
            this.LostFocus += ValidateValue;

            // Set defalut Pricision
            this.Precision = 0;
          
            // Set default Min/Max Value by checking it's type.
            MinValue = (T)typeof(T).GetRuntimeField("MinValue").GetValue(null);
            MaxValue = (T)typeof(T).GetRuntimeField("MaxValue").GetValue(null);

            // User Number keyboard layout
            this.InputScope = new InputScope() { Names = { new InputScopeName(InputScopeNameValue.Number) } };
        }

        public T MaxValue { get; set; }
        public T MinValue { get; set; }
        public AttributeMetadata AttributeMetadata { get; set; } // For money only
        public int Precision { get; set; }

        /// <summary>
        /// This method validate for Format of each type.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ValidateValue(object sender, RoutedEventArgs e)
        {
            // If there is no data, then do nothing.
            if (string.IsNullOrEmpty(Text))
                return;

            T value = new T();
            bool success;
            string message = "";
            try
            {
                // Try parsing the text value to it's type.
                value = (T)typeof(T).GetRuntimeMethod("Parse", new Type[] { typeof(string) }).Invoke(null, new object[] { this.Text });
                success = true;
            }
            catch
            {
                success = false;
                message = loader.GetString("WrongFormat");
            }
            
            // If parse succeeded, then check if the value is in its range.
            if (success && ((int)typeof(T).GetRuntimeMethod("CompareTo", new Type[] { typeof(T) }).Invoke(value, new object[] { MinValue }) < 0 ||
                (int)typeof(T).GetRuntimeMethod("CompareTo", new Type[] { typeof(T) }).Invoke(value, new object[] { MaxValue }) > 0))
            {
                success = false;
                message = String.Format(loader.GetString("WrongFormatMoreLess"), MinValue.ToString(), MaxValue.ToString());
            }

            // If value is in its range, then check Precision 
            if (success)
            {
                // Use Regex to check the pricision
                string pattern = @"^[0-9]+\.*[0-9]{0," + Precision + "}$";
                System.Text.RegularExpressions.Match match = Regex.Match(((TextBox)sender).Text.Trim(), pattern, RegexOptions.IgnoreCase);
                
                // If not match, then considered to be failed.
                if (!match.Success)
                {
                    success = false;
                    message = String.Format(loader.GetString("WrongPrecision"), Precision);
                }
            }

            // Finally set the value back to DataContext
            if (success)
            {
                // If it is Money type, then create Money instance
                if (AttributeMetadata.GetType().Equals(typeof(MoneyAttributeMetadata)))
                    (this.DataContext as FormFieldData).FieldData = new Money(decimal.Parse(value.ToString()));
                else
                    (this.DataContext as FormFieldData).FieldData = value;
            }
            else
            {
                // Restore the original value.
                if (AttributeMetadata.GetType().Equals(typeof(MoneyAttributeMetadata)))
                    ((TextBox)sender).Text = ((((TextBox)sender).DataContext as FormFieldData).FieldData == null) ?
                    "" : ((((TextBox)sender).DataContext as FormFieldData).FieldData as Money).Value.ToString();
                else
                    ((TextBox)sender).Text = ((((TextBox)sender).DataContext as FormFieldData).FieldData == null) ?
                    "" : (((TextBox)sender).DataContext as FormFieldData).FieldData.ToString();

                // If something happens, show the error message and back forcus to the text box.
                MessageDialog messageDialog = new MessageDialog(message);
                await messageDialog.ShowAsync();
                ((TextBox)sender).Focus(Windows.UI.Xaml.FocusState.Keyboard);
            }
        }

        /// <summary>
        /// This method validate if use only types number.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
    
        void NumericTextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            base.OnKeyDown(e);

            NumberFormatInfo numberFormatInfo = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string decimalSeparator = numberFormatInfo.NumberDecimalSeparator;
            string groupSeparator = numberFormatInfo.NumberGroupSeparator;
            string negativeSign = numberFormatInfo.NegativeSign;

            string keyInput = e.Key.ToString();
            char keyChar = e.Key.ToString().ToCharArray()[e.Key.ToString().Length - 1];

            if (Char.IsDigit(keyChar))
            {
                // Digits are OK
            }
            else if (keyInput.Equals(decimalSeparator) || keyInput.Equals(groupSeparator) ||
             keyInput.Equals(negativeSign))
            {
                // Decimal separator is OK
            }
            else if (keyInput == "Back")
            {
                // Backspace key is OK
            }
            else
            {
                // Consume this invalid key and do nothing.
                e.Handled = true;
            }
        }
    }

    #endregion

    #region CheckBoxEx
    /// <summary>
    /// This is Custom Control for CRM CheckBox
    /// </summary>
    public class CheckBoxEx : Grid
    {
        // Mark this internal so that CRMHelper can use this as Dependency Tracking
        internal CheckBox checkBox;
        private ComboBox comboBox;

        // Label for True option
        public string TrueLabel { get; set; }
        
        // Label for False option
        public string FalseLabel { get; set; }

        // Constructor
        public CheckBoxEx(string trueLabel, string falseLabel)
            : base()
        {
            this.TrueLabel = trueLabel;
            this.FalseLabel = falseLabel;

            // Display checkbox information
            comboBox = new ComboBox();

            // Add labels
            comboBox.Items.Add(TrueLabel);
            comboBox.Items.Add(FalseLabel);
            // default to true, which will be changed from outside
            comboBox.SelectedIndex = 0;
            comboBox.SelectionChanged += comboBox_SelectionChanged;
            this.Children.Add(comboBox);

            // Checkbox to hold checked information
            checkBox = new CheckBox();
            checkBox.Checked += checkBox_Checked;
            checkBox.Unchecked += checkBox_Unchecked;
        }

        // When user changes selection, then update checkbox
        void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            checkBox.IsChecked = ((sender as ComboBox).SelectedIndex == 0) ? true : false;
        }

        void textBlock_Tapped(object sender, TappedRoutedEventArgs e)
        {
            checkBox.IsChecked = ((bool)checkBox.IsChecked) ? false : true;
        }

        /// <summary>
        /// When checkbox unchecked, then display False Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_Unchecked(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = 1;
        }

        /// <summary>
        /// When checkbox checked, display True Label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox_Checked(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedIndex = 0;
        }
    }

    #endregion

    #region LookupControl

    // Lookup Delegate for Event
    public delegate void LookupControlButton_ClickEventHandler(object sender, RoutedEventArgs e);

    /// <summary>
    /// Custom Control for Lookup
    /// </summary>
    public class LookupControl : Grid
    {
        // Expose Event
        public event LookupControlButton_ClickEventHandler LookupControlButton_Click;

        private TextBox textBox;
        internal Button lookupButton;

        public LookupControl()
        {
            // TextBox to show Primary Name of Reference
            textBox = new TextBox();
            textBox.IsReadOnly = true;
            
            // Button to trigger Lookup
            lookupButton = new Button();
            // Place the button on the right end and set size.
            lookupButton.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Right;
            lookupButton.BorderThickness = new Thickness(0);
            lookupButton.MinWidth = lookupButton.MaxWidth = 36;
            // Set search icon
            ImageBrush brush = new ImageBrush();
            ImageSource source = new BitmapImage(new Uri("ms-appx:///Assets/Search-Find.png"));
            brush.ImageSource = source;
            brush.Stretch = Stretch.Uniform;
            lookupButton.Background = brush;
            // Add click event
            lookupButton.Click += lookupButton_Click;

            this.DataContextChanged += LookupControl_DataContextChanged;

            // Add them to parent
            this.Children.Add(textBox);
            this.Children.Add(lookupButton);
        }

        /// <summary>
        /// Thie method is called when user click LookupButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void lookupButton_Click(object sender, RoutedEventArgs e)
        {
            this.LookupControlButton_Click(sender, e);
        }

        /// <summary>
        /// This method called when new EntityReference is set.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        void LookupControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
        {
            // Retrieve Field data
            object fieldData = (this.DataContext as FormFieldData).FieldData;

            // If field data is not null and type if EntityReference, then display the name to textbox
            if (fieldData != null && fieldData.GetType().Equals(typeof(EntityReference)))
                this.textBox.Text = (fieldData as EntityReference).Name;
        }
    }

    #endregion

    #region ActivityPartyLookupControl

    // Activity Party Delegate for Event
    public delegate void ActivityPartyLookupControlDeleteButton_ClickEventHandler(object sender, RoutedEventArgs e);
    public delegate void ActivityPartyLookupControlAddButton_ClickEventHandler(object sender, RoutedEventArgs e);
    
    
    /// <summary>
    /// Custom Control for ActivityParty
    /// </summary>
    public class ActivityPartyLookupControl : Grid
    {
       
        // Expose Event
        public event ActivityPartyLookupControlDeleteButton_ClickEventHandler ActivityPartyDeleteButton_Click;
        public event ActivityPartyLookupControlAddButton_ClickEventHandler ActivityPartyAddButton_Click;

        // this record
        private EntityCollection records;

        // Resource Loader for Multilanguage
        ResourceLoader loader = new ResourceLoader();

        // ActivityParties
        public EntityCollection Records
        {
            get { return records; }
            set
            {
                // When records set, display each ActivityParty separately
                // Store value
                records = value;
                // Clear components from Grid once.
                this.Children.Clear();

                // Craete Stackpanel to host records
                StackPanel sp = new StackPanel();
 
                // Go through each ActivityParty
                foreach (Entity item in (value as EntityCollection).Entities)
                {
                    // Create Grid as parent
                    Grid childGrid = new Grid();
                    // ActivityParty Name text.
                    TextBox fieldValue = new TextBox();
                    fieldValue.IsReadOnly = true;
                    fieldValue.Text = ((ActivityParty)item).PartyId.Name;                   

                    // Add a button to "remove" the activtyParty from Records.
                    Button deleteButton = new Button();
                    // Place it on the right end
                    deleteButton.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Right;
                    // Hide the borderline
                    deleteButton.BorderThickness = new Thickness(0);
                    // Make it squre
                    deleteButton.MinWidth = deleteButton.MaxWidth = 36;
                    // Assign Click event
                    deleteButton.Click += deleteButton_Click;
                    // Store the ActivityPart to button's context so that it is easy to pass the info when button clicked.
                    deleteButton.DataContext = item;
                    // Create Brush for Delete Button
                    ImageBrush brush = new ImageBrush();
                    ImageSource source = new BitmapImage(new Uri("ms-appx:///Assets/Delete.png"));
                    brush.ImageSource = source;
                    brush.Stretch = Stretch.Uniform;
                    // Assign the brush to the button.
                    deleteButton.Background = brush;
                    
                    // Put display name and button
                    childGrid.Children.Add(fieldValue);
                    childGrid.Children.Add(deleteButton);
                    sp.Children.Add(childGrid);
                }

                // Under ActivityParties, add "Add" button to add another ActivityParty
                Button btnAdd = new Button();
                btnAdd.Content = loader.GetString("btnAdd\\Content");
                // Assign click event
                btnAdd.Click += btnAdd_Click;
                // Add it
                sp.Children.Add(btnAdd);
                this.Children.Add(sp);                
            }
        }

        public ActivityPartyLookupControl()
        {
        }

        /// <summary>
        /// Thie method is called when user want to add another ActivityParty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.ActivityPartyAddButton_Click(sender, e);
        }

        /// <summary>
        /// Thie method is called when user want to remove the ActivityParty.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.ActivityPartyDeleteButton_Click(sender, e);
        }  
    }

    #endregion

    #region PicklistControl

    /// <summary>
    /// Custom Control for PickList field.
    /// </summary>
    public class PicklistControl : ComboBox
    {
        public OptionSetMetadata OptionSetMetadata { get; set; }

        public PicklistControl(OptionSetMetadata optionSetMetadata)
        {
            // Create OptionSet
            this.OptionSetMetadata = optionSetMetadata;
            foreach(OptionMetadata item in OptionSetMetadata.Options)
            {
                this.Items.Add(item);
            }
            // Set OptionSet display path
            this.DisplayMemberPath = "Label.UserLocalizedLabel.Label";
            // Assign SelctionChanged Event
            this.SelectionChanged += PicklistControl_SelectionChanged;
        }

        // this method called when user select different option.
        void PicklistControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Reassign the new value.
            if ((sender as PicklistControl).DataContext != null)
                ((sender as PicklistControl).DataContext as FormFieldData).FieldData = new OptionSetValue((int)((sender as PicklistControl).SelectedItem as OptionMetadata).Value);            
        }
    }

    #endregion

    #region TextBoxEx
    /// <summary>
    /// Custom Control for Text field. Add Validation for each type and show selective keyboard.
    /// </summary>
    public class TextBoxEx : TextBox
    {
        // Instantiate ResourceLoader to load strings for label
        private ResourceLoader loader = new ResourceLoader();

        public StringAttributeMetadata StringAttributeMetadata { get; set; }
        public TextBoxEx(StringAttributeMetadata stringAttributeMetadata)
        {
            this.StringAttributeMetadata = stringAttributeMetadata;
            // Store MaxLength of the string
            this.MaxLength = (int)StringAttributeMetadata.MaxLength;

            // Check String Format and assign appropriate keyboard
            if (StringAttributeMetadata.Format == StringFormat.Email)
            {
                this.LostFocus += textBox_LostFocus_ValidateEmailFormat;
                this.InputScope = new InputScope() { Names = { new InputScopeName(InputScopeNameValue.EmailSmtpAddress) } };
            }
            else if (StringAttributeMetadata.Format == StringFormat.Url)
            {
                this.LostFocus += textBox_LostFocus_ValidateUrlFormat;
                this.InputScope = new InputScope() { Names = { new InputScopeName(InputScopeNameValue.Url) } };
            }
            else if (StringAttributeMetadata.FormatName.Value == StringFormatName.Phone.Value)
            {
                this.LostFocus += textBox_LostFocus_ValidatePhoneFormat;
                this.InputScope = new InputScope() { Names = { new InputScopeName(InputScopeNameValue.TelephoneNumber) } };
            }
            else if (StringAttributeMetadata.Format == StringFormat.TextArea)
            {
                this.AcceptsReturn = true;
            }
            else if (StringAttributeMetadata.LogicalName.Contains("postal"))
            {
                this.InputScope = new InputScope() { Names = { new InputScopeName(InputScopeNameValue.TelephoneNumber) } };
            }
        }

        private async void textBox_LostFocus_ValidatePhoneFormat(object sender, RoutedEventArgs e)
        {
            // If the value is null or empty
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
                return;

            // If the value has not been changed
            if ((((TextBox)sender).DataContext as FormFieldData).FieldData != null 
                && ((TextBox)sender).Text == (((TextBox)sender).DataContext as FormFieldData).FieldData.ToString())
                return;

            string pattern = @"^[0-9]+[0-9|-]*[0-9]$";
            System.Text.RegularExpressions.Match match = Regex.Match(((TextBox)sender).Text.Trim(), pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                // Restore the original value.
                ((TextBox)sender).Text = ((((TextBox)sender).DataContext as FormFieldData).FieldData == null) ?
                    "" : (((TextBox)sender).DataContext as FormFieldData).FieldData.ToString();
                // Show the error message.
                MessageDialog messageDialog = new MessageDialog(loader.GetString("WrongPhoneFormat"));
                await messageDialog.ShowAsync();
                ((TextBox)sender).Focus(Windows.UI.Xaml.FocusState.Keyboard);
            }
        }
        private async void textBox_LostFocus_ValidateUrlFormat(object sender, RoutedEventArgs e)
        {
            // If the value is null or empty
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
                return;

            // If the value has not been changed
            if ((((TextBox)sender).DataContext as FormFieldData).FieldData != null
                && ((TextBox)sender).Text == (((TextBox)sender).DataContext as FormFieldData).FieldData.ToString()) 
                return;

            string pattern = @"http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            System.Text.RegularExpressions.Match match = Regex.Match(((TextBox)sender).Text.Trim(), pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                // Restore the original value.
                ((TextBox)sender).Text = ((((TextBox)sender).DataContext as FormFieldData).FieldData == null) ?
                    "" : (((TextBox)sender).DataContext as FormFieldData).FieldData.ToString();
                MessageDialog messageDialog = new MessageDialog(loader.GetString("WrongUrlFormat"));                
                await messageDialog.ShowAsync();
                ((TextBox)sender).Focus(Windows.UI.Xaml.FocusState.Keyboard);
            }
        }
        private async void textBox_LostFocus_ValidateEmailFormat(object sender, RoutedEventArgs e)
        {
            // If the value is null or empty
            if (String.IsNullOrEmpty(((TextBox)sender).Text))
                return;

            // If the value has not been changed
            if ((((TextBox)sender).DataContext as FormFieldData).FieldData != null
                && ((TextBox)sender).Text == (((TextBox)sender).DataContext as FormFieldData).FieldData.ToString()) 
                return;

            string pattern = @"^[a-z][a-z|0-9|]*([_][a-z|0-9]+)*([.][a-z|0-9]+([_][a-z|0-9]+)*)?@[a-z][a-z|0-9|]*\.([a-z][a-z|0-9]*(\.[a-z][a-z|0-9]*)?)$";
            System.Text.RegularExpressions.Match match = Regex.Match(((TextBox)sender).Text.Trim(), pattern, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                // Restore the original value.
                ((TextBox)sender).Text = ((((TextBox)sender).DataContext as FormFieldData).FieldData == null) ? 
                    "" : (((TextBox)sender).DataContext as FormFieldData).FieldData.ToString();

                MessageDialog messageDialog = new MessageDialog(loader.GetString("WrongEmailFormat"));
                await messageDialog.ShowAsync();
                ((TextBox)sender).Focus(Windows.UI.Xaml.FocusState.Keyboard);
            }
        }
    }

    #endregion

    #region DateTimeControl
    /// <summary>
    /// Custom Control for DateTime
    /// </summary>
    public class DateTimeControl : Grid
    {
        // AttributeMetadata for the field
        public DateTimeAttributeMetadata DateTimeAttributeMetadata { get; set; }
        public DatePicker datePicker;
        public TimePicker timePicker;
        private DateTime _date;
        public DateTime Date 
        {
            get 
            {
                return _date;
            }
            set
            {
                // Set Date to DatePicker
                this.datePicker.Date = value;
                // If TimePicker is instance, then set Time to TimePicker
                if (timePicker != null)
                    timePicker.Time = value.TimeOfDay;
                _date = value;
            }
        }

        public DateTimeControl(DateTimeAttributeMetadata dateTimeAttributeMetadata)
        {
            // Initialize DateTimeControl
            // Initialize StackPanel to host DatePicker and/or TimePicker
            StackPanel childsp = new StackPanel();
            childsp.Orientation = Orientation.Horizontal;

            // Add DatePicker and changed event.
            this.DateTimeAttributeMetadata = dateTimeAttributeMetadata;
            this.datePicker = new DatePicker();
            datePicker.DateChanged += datePicker_DateChanged;
            childsp.Children.Add(datePicker);

            // If the field has Time as well, add TimePicker
            if (DateTimeAttributeMetadata.Format == Microsoft.Xrm.Sdk.Metadata.Samples.DateTimeFormat.DateAndTime)
            {
                timePicker = new TimePicker();
                timePicker.TimeChanged += timePicker_TimeChanged;
                childsp.Children.Add(timePicker);
            }

            this.Children.Add(childsp);
        }

        /// <summary>
        /// Called when user changes Time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timePicker_TimeChanged(object sender, TimePickerValueChangedEventArgs e)
        {
            // Update Time of fieldValue by keeping Date as it is.
            this.DataContext = this.datePicker.Date.Date + e.NewTime;
        }

        /// <summary>
        /// Called when user changes Date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void datePicker_DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            // Update Date of fieldvalue by keeping Time as it is.
            this.DataContext = e.NewDate.Date + this.datePicker.Date.Date.TimeOfDay;
        }
    }

    #endregion

    #region EntityImageControl

    /// <summary>
    /// Custom Control for EntityImage
    /// </summary>
    public class EntityImageControl : Grid
    {
        private Image image;
        
        // If this is readonly 
        public bool ReadOnly 
        { 
            set
            {
                // If this set as ReadOnly, then remove the tappped event
                if(value)
                    image.Tapped -= image_Tapped;
            } 
        }

        public byte[] ImageBytes
        {
            set
            {
                SetImage(value);
            }
        }

        public EntityImageControl()
        {
            // Initialize Image and set height/width
            image = new Image();
            // Set Height and Width
            image.MaxHeight = image.MaxWidth = 150;
            // Place the image on the left side
            image.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Left;
            // Assign Tapped event to replace picture.
            image.Tapped += image_Tapped;
            this.Children.Add(image);
        }

        /// <summary>
        /// This method launch camera app and take picture.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void image_Tapped(object sender, TappedRoutedEventArgs e)
        {
            // Instantiate FileOpenPicker, which you can both take picture or select existing picture.
            var picker = new FileOpenPicker();
            // Specify extension
            picker.FileTypeFilter.Add(".jpg");
            picker.FileTypeFilter.Add(".jpeg");
            picker.FileTypeFilter.Add(".png");

#if WINDOWS_PHONE_APP
            // If this is WP8.1, then use AndContinue model
            picker.ContinuationData["EntityImage"] = "EntityImage";
            picker.PickSingleFileAndContinue();
#endif
        }

        /// <summary>
        /// This method set ImageSource to image.
        /// </summary>
        /// <param name="imageBytes"></param>
        private async void SetImage(byte[] imageBytes)
        {
            BitmapImage im;
            
            // If imageBytes has data in it, then use it.
            if (imageBytes != null)
            {
                 im = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(imageBytes))
                {
                    await im.SetSourceAsync(ms.AsRandomAccessStream());
                }
            }
            // Otherwise use default picture.
            else
                im = new BitmapImage(new Uri("ms-appx:///Assets/noimage.PNG"));                   
            
            image.Source = im;
        }     
    }

    #endregion
 
}
