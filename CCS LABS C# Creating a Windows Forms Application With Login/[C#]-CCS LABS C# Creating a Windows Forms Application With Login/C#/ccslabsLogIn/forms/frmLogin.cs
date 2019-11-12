using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using System.Data.SqlClient;

namespace ccslabsLogIn.forms
    {
    public partial class frmLogin : Form
        {
        #region "Properties"

        private bool _Authenticated = false;

        public bool Authenticated
            {
            get { return _Authenticated; }
            set { _Authenticated = value; }
            }
        private string _Username = "";

        public string Username
            {
            get { return _Username; }
            set { _Username = value; }
            }

        #endregion

        public frmLogin()
            {
            InitializeComponent();
            }

        // exit the program if they do not want to login
        private void btnCancel_Click( object sender, EventArgs e )
            {
            Application.Exit();
            }

        // check that username and password are not empty
        // lookup username in database and compare passwords - if ok continue
        // if not ok, retry 2 more times then exit
        private void btnLogin_Click( object sender, EventArgs e )
            {
            Login();
            }

        private void Login()
            {

            if ( tbPassword.Text.Length > 0 && tbUsername.Text.Length > 0 )
                {
                if ( UserAuthenticated( tbUsername.Text, tbPassword.Text ) )
                    {
                    Authenticated = true;
                    this.Close(); // close this form - do not exit the application
                    }
                else
                    {
                    Authenticated = false;
                    MessageBox.Show( "Username or Password not recognised" );

                    }
                }
            else // password or username is empty
                {
                Authenticated = false;
                MessageBox.Show( "You need to enter both a username and a password to continue" );
                }

            }

        // Does the user exist?
        // if so - is the password correct?
        private bool UserAuthenticated( string p, string p_2 )
            {
            try
                {
                int result = (int) usersTableAdapter.GetUserIDByUsernameAndPassword( p, p_2 );
                Authenticated = true;
                if ( result > 0 ) return true;
                }
            catch ( Exception ) // FIXED: Added Exception catching  which defaults to Not Authenticated
                {
                Authenticated = false;
                return false;
                }
            Authenticated = false;
            return false;
            }

        // You do not need this
        private void usersBindingNavigatorSaveItem_Click( object sender, EventArgs e )
            {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll( this.applicationDataSet );

            }

        private void frmLogin_Load( object sender, EventArgs e )
            {
            // TODO: This line of code loads data into the 'applicationDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill( this.applicationDataSet.Users ); // you do not need this

            }

        // register the user - get Username, password x 2
        // Add user to database if passwords match
        private void llRegister_LinkClicked( object sender, LinkLabelLinkClickedEventArgs e )
            {
            frmRegister reg = new frmRegister();
            reg.ShowDialog();
            if ( reg.Registered )
                {
                Authenticated = true;
                this.Close();
                }
            else
                {
                Authenticated = true;
                this.Close();
                }
            }


        }
    }
