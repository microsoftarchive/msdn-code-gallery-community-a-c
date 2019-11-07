using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zeller_I_Forms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        string[] dias = new string[] { " Domingo ", " Lunes ", " Martes ", " Miercoles ", " Jueves ", " Viernes ", " Sabado " };

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int dia, mes, año;
            dia = int.Parse(textBox1.Text);
            mes = int.Parse(textBox2.Text);
            año = int.Parse(textBox3.Text);

            if ((dia < 32) && (mes < 13) && (año < 10000))
            {
                int a = (14 - mes) / 12;
                int y = año - a;
                int m = mes + 12 * a - 2;
                int d = (dia + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;
                textBox4.Text = dias[d];

            }
        }
    }
}
