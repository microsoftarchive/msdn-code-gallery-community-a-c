using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InputBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var promptValue = MessageBoxInput.ShowDialog(@"Informe um valor para o campo:", @"- Título da Tela - ", MessageBoxInput.icon.SiidNetworkconnect);
            if (!String.IsNullOrEmpty(promptValue))
                label1.Text = promptValue;
            else
                label1.Text = @"Cancelado";

        }
    }
}
