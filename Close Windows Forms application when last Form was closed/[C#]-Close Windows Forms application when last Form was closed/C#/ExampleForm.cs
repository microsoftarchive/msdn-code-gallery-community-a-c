using System;
using System.Globalization;
using System.Windows.Forms;
using CloseApplicationAfterLastFormClosed.Properties;

namespace CloseApplicationAfterLastFormClosed
{
    /// <summary>
    /// An example form which offers the possibility to open more forms.
    /// </summary>
    public partial class ExampleForm : Form
    {
        /// <summary>
        /// Counter of the number of windows opened.
        /// </summary>
        private static int _counter;

        /// <summary>
        /// Creates a new instance of <see cref="ExampleForm"/>
        /// </summary>
        public ExampleForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles a click on OpenNewWindowButton
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")]
        private void OnOpenNewWindowButtonClick(object sender, EventArgs e)
        {
            new ExampleForm().Show();
        }

        /// <summary>
        /// Set the title when the form was loaded.
        /// </summary>
        private void OnExampleFormLoad(object sender, EventArgs e)
        {
            // increase counter and set titel.
            Text = string.Format(CultureInfo.CurrentCulture, Resources.FormTitle, ++_counter);
        }
    }
}
