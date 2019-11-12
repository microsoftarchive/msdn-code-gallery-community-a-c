using System;
using System.Windows.Forms;

namespace CheckListBoxSimple_C_Sharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            checkedListBox1.Items.AddRange(new string[] { "John", "Paul", "George", "Ringo" });

            checkedListBox1.SetItemChecked(1, true);
            checkedListBox1.SetItemChecked(3, true);
        }

        private void cmdDemo_Click(object sender, EventArgs e)
        {
            checkedListBox1.FindItemAndSetChecked(txtDemoExt.Text, chkState.Checked);
        }
    }
}