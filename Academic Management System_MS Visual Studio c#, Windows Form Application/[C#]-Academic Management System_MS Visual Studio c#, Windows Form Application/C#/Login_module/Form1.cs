using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

        }

        private void Login_button_MouseHover(object sender, EventArgs e)
        {
            Login_button.Image = Properties.Resources.onmouse_over;
        }

        private void Login_button_Click(object sender, EventArgs e)
        {
            if (Username.Text == "admin" && Password.Text == "123")
            {
                Student_form std = new Student_form();
                std.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Error");
            }
        }

        private void Login_button_MouseLeave(object sender, EventArgs e)
        {
            Login_button.Image = Properties.Resources.Login_button;
        }

        private void close_button_MouseHover(object sender, EventArgs e)
        {
            close_button.Image = Properties.Resources.close;
        }

        private void close_button_MouseLeave(object sender, EventArgs e)
        {
            close_button.Image = Properties.Resources.close_normal;
        }

        private void close_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Minimize_button_MouseHover(object sender, EventArgs e)
        {
            Minimize_button.Image = Properties.Resources.minimize;
        }

        private void Minimize_button_MouseLeave(object sender, EventArgs e)
        {
            Minimize_button.Image = Properties.Resources.minimize_normal;
        }

        private void Minimize_button_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Login_Load(object sender, EventArgs e)
        {

            progressBar1.Value = 0;
            progressBar1.Minimum = 0;

            progressBar1.Maximum = 100;
            progressBar1.Step = 1;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value <= progressBar1.Maximum)
            {
                progressBar1.PerformStep();
            }
            else
            {
                timer1.Enabled = false;
                timer1.Dispose();
            }
        }

    }
}
