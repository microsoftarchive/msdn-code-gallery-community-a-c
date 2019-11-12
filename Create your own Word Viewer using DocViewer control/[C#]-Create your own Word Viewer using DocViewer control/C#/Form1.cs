using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Open
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            //open a DOC document
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Word97-2003 files(*.doc)|*.doc|Word2007-2010 files (*.docx)|*.docx|All files (*.*)|*.*";
            dialog.Title = "Select a DOC file";
            dialog.Multiselect = false;
            dialog.InitialDirectory = System.IO.Path.GetFullPath(@"..\..\..\..\..\..\Data");

            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                try
                {
                    //Load DOC document from file.
                    this.docDocumentViewer1.LoadFromFile(dialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close current doc document.
            this.docDocumentViewer1.CloseDocument();
        }
    }
}
