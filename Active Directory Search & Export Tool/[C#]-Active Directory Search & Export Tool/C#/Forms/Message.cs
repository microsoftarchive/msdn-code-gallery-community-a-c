
using System;
using System.Windows.Forms;

namespace ADSearch.Forms
{
    /// <summary>
    /// A form to display the results from the command prompt
    /// </summary>
    public partial class Message : Form
    {
        /// <summary>
        /// Text to display in the form
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The title of the form
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Message()
        {
            InitializeComponent();
        }

        /// <summary>
        /// To copy the displayed text into the clipboard
        /// </summary>
        /// <param name="sender">contains the sender of the event, so if you had one method bound to multiple controls, you can distinguish them.</param>
        /// <param name="e">refers to the event arguments for the used event, they usually come in the form of properties/functions/methods that get to be available on it.</param>
        private void tsbCopy_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(Text);
        }

        /// <summary>
        /// Load the form with a title and text
        /// </summary>
        /// <param name="sender">contains the sender of the event, so if you had one method bound to multiple controls, you can distinguish them.</param>
        /// <param name="e">refers to the event arguments for the used event, they usually come in the form of properties/functions/methods that get to be available on it.</param>
        private void frmMessage_Load(object sender, EventArgs e)
        {
            this.txtText.Text = Text; // pass argument for text
            this.Text = Title; // pass argument for title
        }

    }
}
