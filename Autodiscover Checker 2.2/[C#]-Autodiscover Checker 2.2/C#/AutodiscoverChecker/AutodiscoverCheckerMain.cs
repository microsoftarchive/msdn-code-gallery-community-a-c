using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AutodiscoverChecker
{
    public partial class AutodiscoverCheckerMain : Form
    {
        public AutodiscoverCheckerMain()
        {
            InitializeComponent();
        }

        private void AutodiscoverChecker_Load(object sender, EventArgs e)
        {
 
        }

        private void btnRawCodeChecker_Click(object sender, EventArgs e)
        {
            AutodisoverRawCode oForm = new AutodisoverRawCode();
            oForm.ShowDialog();
            oForm = null;
        }

        private void btnManagedApiChecker_Click(object sender, EventArgs e)
        {
            AutodiscoverViewerForm oForm = new AutodiscoverViewerForm();
            oForm.ShowDialog();
            oForm = null;
        }

        private void btnRawScpChecker_Click(object sender, EventArgs e)
        {
            ScpChecker oForm = new ScpChecker();
            oForm.ShowDialog();
            oForm = null;
        }
    }
}
