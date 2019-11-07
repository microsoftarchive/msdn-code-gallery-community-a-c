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
    public partial class FinancingPage : Form
    {
        public FinancingPage()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BalanceSheet page6 = new BalanceSheet();
            page6.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IncomeStatement page7 = new IncomeStatement();
            page7.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            Hide();
        }
    }
}
