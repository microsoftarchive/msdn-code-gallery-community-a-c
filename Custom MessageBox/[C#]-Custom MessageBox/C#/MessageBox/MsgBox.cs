using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MessageBox
{
    public partial class MsgBox : Form
    {
        public MsgBox()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(string title, string text, int Cbtn, string btnOK, string btnNO, string btnYES, Image img)
        {
            pictureBox1.Image = img;
            this.Text = title;
            label1.Text = text;
            btn_OK.Text = btnOK;
            btn_No.Text = btnNO;
            btn_Yes.Text = btnYES;

            switch (Cbtn)
            {
                case 1:
                    btn_No.Visible = false;
                    btn_Yes.Visible = false;
                    break;
                case 2:
                    btn_OK.Visible = false;
                    break;
                case 3:
                    btn_OK.Visible = true;
                    btn_No.Visible = true;
                    btn_Yes.Visible = true;
                    break;
            }
            return this.ShowDialog();
        }

        private void btn_No_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Yes_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
