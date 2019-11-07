using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Shell
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = 
                new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            //Llamar a calculadora
            //proc.StartInfo.FileName = "calc";
            //Llamar a MS paintbrush
            //proc.StartInfo.FileName = "mspaint";
            //Llamar al manejador de servicios de Windows
            //proc.StartInfo.FileName = "services.msc";
            //Llamar al Event Viewer
              proc.StartInfo.FileName = "eventvwr.msc";


            proc.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "mspaint";
            proc.Start();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "iexplore";
            proc.StartInfo.Arguments = "http://www.google.com";            
            proc.Start();
            proc.WaitForExit();
            //Matar proceso
            //proc.Kill();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = @"c:\bienvenidos.htm";
            proc.Start();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            crearusuario(textBox1.Text,textBox2.Text);

        }
            
        private void crearusuario(string usuario, string password)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.EnableRaisingEvents = false;
            proc.StartInfo.FileName = "cmd";
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.StandardInput.WriteLine(@"net user "+usuario+" "+password+" /add");
            proc.StandardInput.Flush();
            proc.StandardInput.Close();
            proc.Close();
        }

    }
}
