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
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            helpMenu page3 = new helpMenu();
            page3.Show();
            Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StdEnroll stdEnroll = new StdEnroll();
            stdEnroll.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            FinancingPage f = new FinancingPage();
            f.Show();
            Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Academic a = new Academic();
            a.Show();
            Hide();
        }
    }
}
