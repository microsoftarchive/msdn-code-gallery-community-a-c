using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace ServoControl
{
    public partial class Form1 : Form
    {
        SerialPort port = new SerialPort();
        
        public Form1()
        {
            InitializeComponent();
            init();
        }

        void init()
        {
            
            port.PortName = "COM29";
            port.BaudRate = 9600;
            try
            {
                port.Open();
            }
            catch { }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (port.IsOpen)
            {
                port.WriteLine(trackBar1.Value.ToString());
            }
        }
        
    }
}
