using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgressBarEx_Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            progressBarEx8.Value = 0;
            progressBarEx8.ShowPercentage = true;
            progressBarEx8.ShowText = false;
            timer1.Interval = 75;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBarEx8.Value += 1;
            if (progressBarEx8.Value == 100)
            {
                timer1.Stop();
                progressBarEx8.ShowPercentage = false;
                progressBarEx8.ShowText = true;
                progressBarEx8.Text = "Finished";
            }
        }
    }
}
