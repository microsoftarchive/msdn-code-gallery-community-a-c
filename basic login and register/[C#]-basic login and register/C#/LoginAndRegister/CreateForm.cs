using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LoginAndRegister
{
    public partial class CreateForm : Form
    {
        public CreateForm()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            System.IO.TextWriter tw = new System.IO.StreamWriter(txtUsername.Text + ".txt");
            tw.WriteLine(txtPassword.Text);
            tw.Close();
            tw.Dispose();
            this.Close();
        }
    }
}
