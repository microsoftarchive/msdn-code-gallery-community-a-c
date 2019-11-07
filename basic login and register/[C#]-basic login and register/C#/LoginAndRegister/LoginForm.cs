using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LoginAndRegister.Properties;

namespace LoginAndRegister
{
    public partial class LoginForm : Form
    {
        ErrorProvider err = new ErrorProvider();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.Remember == true) 
            {
                txtPassword.Text = Settings.Default.Password;
                txtUsername.Text = Settings.Default.Username;
                cbRememberMe.Checked = Settings.Default.Remember;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            ApplicationForm app = new ApplicationForm();
            if (Properties.Settings.Default.Remember == true)
            {
                Settings.Default.Password = txtPassword.Text;
                Settings.Default.Username = txtUsername.Text;
                Settings.Default.Save();
            }

            if (!File.Exists(txtUsername.Text + ".txt"))
            {
                err.SetError(txtUsername, "User does not exist"); //sets the error
            }
            else 
            {
                err.SetError(txtUsername, ""); //clears the error
                err.SetError(txtPassword, "");
                TextReader tr = new StreamReader(txtUsername.Text + ".txt");
                string pass = tr.ReadLine();
                if (pass == txtPassword.Text)
                {
                    app.Show();
                    this.Hide();
                }
                else 
                {
                    err.SetError(txtPassword, "Incorrect password");
                }
            } 
            
            
                
        }

        private void linkCreateAcc_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CreateForm create = new CreateForm();
            create.ShowDialog(this);
        }

        private void cbRememberMe_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRememberMe.Checked == true)
            {
                Settings.Default.Remember = true;
            }
            else
            {
                Settings.Default.Remember = false;
            }
            Settings.Default.Save();
        }
    }
}
