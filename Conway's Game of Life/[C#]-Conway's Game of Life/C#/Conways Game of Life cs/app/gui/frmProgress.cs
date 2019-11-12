using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Conways_Game_of_Life_cs
{
    public partial class frmProgress : Form
    {
        public frmProgress(int max, string caption)
        {
            // This call is required by the Windows Form Designer.
            InitializeComponent();

            // Add any initialization after the InitializeComponent() call.
            this.Text = caption;
            ProgressBar1.Maximum = max;
        }

        public void performStep()
        {
            ProgressBar1.PerformStep();
            Label1.Text = ((ProgressBar1.Value / ProgressBar1.Maximum) * 100).ToString() + "% complete";
            this.Refresh();
            Application.DoEvents();
            if (ProgressBar1.Value == ProgressBar1.Maximum)
                this.Close();
        }
    }
}
