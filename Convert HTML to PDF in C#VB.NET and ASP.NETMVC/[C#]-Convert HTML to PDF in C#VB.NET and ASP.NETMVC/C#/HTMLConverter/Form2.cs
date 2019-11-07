using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTMLConverter
{
    public partial class Form2 : Form
    {
        #region Constructor

        Form1 form1;  
        public Form2(Form1 form1)
        {
            // TODO: Complete member initialization
            this.form1 = form1;
            
            InitializeComponent();
            string str = System.IO.Path.GetFullPath("../../Resources/");
            this.BaseURL_Txt.Text = str;
            if (form1.htmlString_txtBox.Text != string.Empty)
            {
                this.htmlStringTxt.Text = form1.htmlString_txtBox.Text;
                this.BaseURL_Txt.Text = form1.baseURL_txtBox.Text;
            }
        }

        #endregion

        #region Events
        
        //Enable form1 while closing form2 
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.form1.Enabled = true;
            if (!isclose)
                this.form1.rdo_urlBtn.Checked = true;
        }

        //Get HTML string and Base URL and set to Form1
        private void button1_Click(object sender, EventArgs e)
        {
            isclose = true;
            form1.htmlString_txtBox.Text = htmlStringTxt.Text;
            form1.baseURL_txtBox.Text = BaseURL_Txt.Text;
            form1.groupBox6.Visible = true;
            form1.groupBox7.Visible = false;
            this.Close();
        }

        //Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            form1.rdo_urlBtn.Checked = true;
        }

        #endregion
    }
}
