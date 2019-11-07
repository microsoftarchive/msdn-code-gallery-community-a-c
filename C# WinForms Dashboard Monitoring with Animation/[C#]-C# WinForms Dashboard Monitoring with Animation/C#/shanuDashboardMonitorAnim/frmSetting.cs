using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shanuDashboardMonitorAnim
{
    public partial class frmSetting : Form
    {
        #region Initialize
        public frmSetting()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void loadDashboard(int formDispCount)
        {
            switch (formDispCount)
            {
                case 1:
                    GlobalVariable.frmDisplayIndex = new int[6] { 1, 2, 3, 4, 5, 6 };
                    GlobalVariable.interval = new int[6] { 4000, 2000, 4000, 3000, 4000, 3000 };
                    break;
                case 2:
                    GlobalVariable.frmDisplayIndex = new int[6] { 0, 2, 0, 4,0, 6 };
                    GlobalVariable.interval = new int[6] { 1000, 3000, 1000, 4000, 1000, 3000 };
                    break;
                case 3:
                    GlobalVariable.frmDisplayIndex = new int[6] { 1, 0, 3, 4, 0, 6 };
                    GlobalVariable.interval = new int[6] { 1000, 2000, 3000, 2000, 1000, 2000 };
                    break;
                case 4:
                    GlobalVariable.frmDisplayIndex = new int[6] { 1, 2, 0, 4, 5, 6 };
                    GlobalVariable.interval = new int[6] { 5000, 5000, 6000, 4000, 6000, 3000 };
                    break;
                case 5:
                    GlobalVariable.frmDisplayIndex = new int[6] { 1, 2, 3, 4, 5, 0 };
                    GlobalVariable.interval = new int[6] { 3000, 5000, 6000, 2000, 6000, 3000 };
                    break;
                case 6:
                    GlobalVariable.frmDisplayIndex = new int[6] { 1, 2, 3, 0, 5, 6 };
                    GlobalVariable.interval = new int[6] { 4000, 5000, 2000, 6000, 2000, 4000 };
                    break;
            }
            this.Opacity = 0;
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
            this.Close();

        }
        #endregion

        #region FormLoad
        private void frmSetting_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Controls Events
        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMain objForm = new frmMain();

            objForm.ShowDialog();

        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            loadDashboard(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadDashboard(2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            loadDashboard(3);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            loadDashboard(4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            loadDashboard(5);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loadDashboard(6);
        }
    }
}
