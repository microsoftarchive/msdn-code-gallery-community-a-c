namespace CodedUITestProject
{
    using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
    using System;
    using System.Collections.Generic;
    using System.CodeDom.Compiler;
    using Microsoft.VisualStudio.TestTools.UITest.Extension;
    using Microsoft.VisualStudio.TestTools.UITesting;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    using System.Drawing;
    using System.Windows.Input;
    using System.Text.RegularExpressions;


    public partial class UIMap
    {

        /// <summary>
        /// AssertMethodIndexPageLoaded - Use 'AssertMethodIndexPageLoadedExpectedValues' to pass parameters into this method.
        /// </summary>
        public void AssertMethodIndexPageLoaded()
        {
            #region Variable Declarations
            HtmlHyperlink uICreateNewHyperlink = this.UIIndexCodedUItestautoWindow.UIIndexCodedUItestautoDocument.UICreateNewHyperlink;
            #endregion

            // Wait for 1 seconds for user delay between actions; Verify that the 'InnerText' property of 'Create New' link equals 'Create New'
            //Playback.Wait(1000);
            uICreateNewHyperlink.WaitForControlReady();
            Assert.AreEqual(this.AssertMethodIndexPageLoadedExpectedValues.UICreateNewHyperlinkInnerText, uICreateNewHyperlink.InnerText, "Page load error");
        }

        public virtual AssertMethodIndexPageLoadedExpectedValues AssertMethodIndexPageLoadedExpectedValues
        {
            get
            {
                if ((this.mAssertMethodIndexPageLoadedExpectedValues == null))
                {
                    this.mAssertMethodIndexPageLoadedExpectedValues = new AssertMethodIndexPageLoadedExpectedValues();
                }
                return this.mAssertMethodIndexPageLoadedExpectedValues;
            }
        }

        private AssertMethodIndexPageLoadedExpectedValues mAssertMethodIndexPageLoadedExpectedValues;

        /// <summary>
        /// RecordedMethodCreate - Use 'RecordedMethodCreateParams' to pass parameters into this method.
        /// </summary>
        public void RecordedMethodCreate()
        {
            Playback.PlaybackSettings.LoggerOverrideState = HtmlLoggerState.AllActionSnapshot;

            #region Variable Declarations
            HtmlEdit uIFirstNameEdit = this.UIIndexCodedUItestautoWindow.UICreateCodedUItestautDocument.UIFirstNameEdit;
            HtmlEdit uILastNameEdit = this.UIIndexCodedUItestautoWindow.UICreateCodedUItestautDocument.UILastNameEdit;
            HtmlEdit uIEmailEdit = this.UIIndexCodedUItestautoWindow.UICreateCodedUItestautDocument.UIEmailEdit;
            HtmlEdit uIDateofBirthEdit = this.UIIndexCodedUItestautoWindow.UICreateCodedUItestautDocument.UIDateofBirthEdit;
            HtmlComboBox uIItemComboBox = this.UIIndexCodedUItestautoWindow.UICreateCodedUItestautDocument.UIUidatepickerdivPane.UIItemComboBox;
            HtmlHyperlink uIItem5Hyperlink = this.UIIndexCodedUItestautoWindow.UICreateCodedUItestautDocument.UIUidatepickerdivPane.UIItem5Hyperlink;
            HtmlInputButton uICreateButton = this.UIIndexCodedUItestautoWindow.UICreateCodedUItestautDocument.UICreateButton;
            HtmlHyperlink uIEmailAddressHyperlink = this.UIIndexCodedUItestautoWindow.UIIndexCodedUItestautoDocument.UIBobsmithsomedomaincoHyperlink;
            #endregion

            // Type 'Bob' in 'First Name' text box
            uIFirstNameEdit.Text = this.RecordedMethodCreateParams.UIFirstNameEditText;

            // Type '{Tab}' in 'First Name' text box
            Keyboard.SendKeys(uIFirstNameEdit, this.RecordedMethodCreateParams.UIFirstNameEditSendKeys, ModifierKeys.None);

            // Type 'Smith' in 'Last Name' text box
            uILastNameEdit.Text = this.RecordedMethodCreateParams.UILastNameEditText;

            // Type '{Tab}' in 'Last Name' text box
            Keyboard.SendKeys(uILastNameEdit, this.RecordedMethodCreateParams.UILastNameEditSendKeys, ModifierKeys.None);

            // Type 'bobsmith@somedomain.com' in 'Email' text box
            uIEmailEdit.Text = this.RecordedMethodCreateParams.UIEmailEditText;

            // Click 'Date of Birth' text box
            Mouse.Click(uIDateofBirthEdit, new Point(319, 29));

            // Type '03/05/1996' in 'Date of Birth' text box
            uIDateofBirthEdit.Text = this.RecordedMethodCreateParams.UIDateOfBirthEditText;

            // Click 'Create' button
            Mouse.Click(uICreateButton, new Point(56, 27));

            // Hover on email address link when the Index page reloads
            uIEmailAddressHyperlink.WaitForControlReady();
            Mouse.Hover(uIEmailAddressHyperlink);
        }

        public virtual RecordedMethodCreateParams RecordedMethodCreateParams
        {
            get
            {
                if ((this.mRecordedMethodCreateParams == null))
                {
                    this.mRecordedMethodCreateParams = new RecordedMethodCreateParams();
                }
                return this.mRecordedMethodCreateParams;
            }
        }

        private RecordedMethodCreateParams mRecordedMethodCreateParams;
    }
    /// <summary>
    /// Parameters to be passed into 'AssertMethodIndexPageLoaded'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class AssertMethodIndexPageLoadedExpectedValues
    {

        #region Fields
        /// <summary>
        /// Wait for 1 seconds for user delay between actions; Verify that the 'InnerText' property of 'Create New' link equals 'Create New'
        /// </summary>
        public string UICreateNewHyperlinkInnerText = "Create New";
        #endregion
    }
    /// <summary>
    /// Parameters to be passed into 'RecordedMethodCreate'
    /// </summary>
    [GeneratedCode("Coded UITest Builder", "14.0.23107.0")]
    public class RecordedMethodCreateParams
    {

        #region Fields
        /// <summary>
        /// Type 'Bob' in 'First Name' text box
        /// </summary>
        public string UIFirstNameEditText = "Bob";

        /// <summary>
        /// Type '{Tab}' in 'First Name' text box
        /// </summary>
        public string UIFirstNameEditSendKeys = "{Tab}";

        /// <summary>
        /// Type 'Smith' in 'Last Name' text box
        /// </summary>
        public string UILastNameEditText = "Smith";

        /// <summary>
        /// Type '{Tab}' in 'Last Name' text box
        /// </summary>
        public string UILastNameEditSendKeys = "{Tab}";

        /// <summary>
        /// Type 'bobsmith@somedomain.com' in 'Email' text box
        /// </summary>
        public string UIEmailEditText = "bobsmith@somedomain.com";

        /// <summary>
        /// Type '03/05/1996' in 'Date of Birth' text box
        /// </summary>
        public string UIDateOfBirthEditText = "03/05/1996";
        #endregion
    }
}
