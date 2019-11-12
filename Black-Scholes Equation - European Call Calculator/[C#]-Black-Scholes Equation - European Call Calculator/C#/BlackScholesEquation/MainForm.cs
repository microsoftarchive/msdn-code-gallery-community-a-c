// reproduce the calculator found
// http://www.money-zine.com/calculators/investment-calculators/black-scholes-calculator/
// using the equations in
// http://finance.bi.no/~bernt/gcc_prog/algoritms_v1/algoritms/node8.html

using System;
using System.Windows.Forms;

namespace BlackScholesEquation
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                double c, p;
                double S = double.Parse(textBox1.Text);
                double X = double.Parse(textBox2.Text);
                double r = double.Parse(textBox3.Text);
                double s = double.Parse(textBox4.Text);
                double t = double.Parse(textBox5.Text);
                EuropeanCall ec = new EuropeanCall(S, X, r * 0.01, s, 0, t, out c, out p);

                MessageBox.Show("c = " + c.ToString("F5") + "\r\np = " + p.ToString("F5") + "\r\n",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
