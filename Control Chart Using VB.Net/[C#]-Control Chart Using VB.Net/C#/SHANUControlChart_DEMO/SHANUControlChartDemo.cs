using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SHANUControlChart_DEMO
{
    public partial class SHANUControlChartDemo : Form
    {
        public SHANUControlChartDemo()
        {
            InitializeComponent();
        }

        private void SHANUControlChartDemo_Load(object sender, EventArgs e)
        {
           
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            shanuControlChart.USLData = txtusl.Text;
            shanuControlChart.LSLData = txtLSL.Text;
            shanuControlChart.NominalData = txtNominal.Text;
            shanuControlChart.MasterData = txtData.Text;
        }

        private void btnRealTime_Click(object sender, EventArgs e)
        {
            if (btnRealTime.Text == "Real Time Data ON")
            {
                 btnRealTime.Text = "Real Time Data OFF";
                 btnRealTime.ForeColor = Color.Red;
                 timer1.Enabled = true;
                 timer1.Start();
            }
            else
            {
                btnRealTime.Text = "Real Time Data ON";
                btnRealTime.ForeColor = Color.DarkGreen;
                timer1.Enabled = false;
                timer1.Stop();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           Random rnd =new Random();

        Double rndval = rnd.Next(1, 20);

        txtData.Text = rndval.ToString("0.000");//FormatNumber(rndval.ToString(), 3, , 0)

        shanuControlChart.USLData = txtusl.Text;
        shanuControlChart.LSLData = txtLSL.Text;
        shanuControlChart.NominalData = txtNominal.Text;
        shanuControlChart.MasterData = txtData.Text;
        }

        private void txtData_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
        && !char.IsDigit(e.KeyChar)
        && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point 
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            } 

        }

        private void txtNominal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
     && !char.IsDigit(e.KeyChar)
     && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // only allow one decimal point 
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            } 
        }

        private void txtLSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point 
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            } 
        }

        private void txtusl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsDigit(e.KeyChar)
                 && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // only allow one decimal point 
            if (e.KeyChar == '.'
                && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            } 
        }
    }
}
