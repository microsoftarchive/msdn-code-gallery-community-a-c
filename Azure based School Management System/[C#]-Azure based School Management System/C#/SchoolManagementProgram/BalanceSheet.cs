using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchoolManagementProgram
{
    public partial class BalanceSheet : Form
    {
        public BalanceSheet()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double assets = Convert.ToDouble(textBox5.Text) + Convert.ToDouble(textBox4.Text) + Convert.ToDouble(textBox3.Text) + Convert.ToDouble(textBox2.Text) + Convert.ToDouble(textBox1.Text);
            double liabilities = Convert.ToDouble(textBox12.Text) + Convert.ToDouble(textBox11.Text) + Convert.ToDouble(textBox10.Text) + Convert.ToDouble(textBox9.Text) + Convert.ToDouble(textBox8.Text);

            textBox6.Text = assets.ToString();
            textBox7.Text = liabilities.ToString();


            DateTime date = DateTime.Now.Date;
            label17.Text = date.ToString("D");

            if (assets != liabilities)
            {
                label17.Text = "Error! Both sides must be equal"; // assets equal liabilities always
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            Hide();
        }
    }
}

