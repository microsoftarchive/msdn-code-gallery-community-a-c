using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ccslabsLogIn.forms
    {
    public partial class frmRegister : Form
        {

        #region "Properties"

        private bool _Registered = false;

        public bool Registered
            {
            get { return _Registered; }
            set { _Registered = value; }
            }
        private string _Username = "";

        public string Username
            {
            get { return _Username; }
            set { _Username = value; }
            }

        #endregion

        public frmRegister()
            {
            InitializeComponent();
            }

        private void btnCancel_Click( object sender, EventArgs e )
            {
            Registered = false; // tell calling form the user DID NOT register
            this.Close(); // close the form
            }

        // register the dude.
        private void btnRegister_Click( object sender, EventArgs e )
            {
            RegisterUser();
            }

        // Register the User
        private void RegisterUser()
            {
            if ( tbUsername.Text.Length > 0 ) // You may want longer than 1 char minimum for usernames
                {
                if ( tbPassword.Text != tbRepeatPassword.Text ) { MessageBox.Show( "Passwords do not match" ); RegisterUser(); } // passwords do not match retry
                // ok passwords do match are they empty?
                if ( tbPassword.Text.Length == 0 ) { MessageBox.Show( "Passwords can not be empty" ); RegisterUser(); } // empty passwords try again!
                // Ok username and passwords are valid.
                // register the user !
                usersTableAdapter.Insert( tbUsername.Text, tbPassword.Text );
                Registered = true;
                this.Close();
                }
            else // Fixed: Forgot the else clause !
                {
                MessageBox.Show( "Username can not be empty" );
                RegisterUser();
                }
            }

        private void usersBindingNavigatorSaveItem_Click( object sender, EventArgs e )
            {
            this.Validate();
            this.usersBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll( this.applicationDataSet );

            }

        private void frmRegister_Load( object sender, EventArgs e )
            {
            // TODO: This line of code loads data into the 'applicationDataSet.Users' table. You can move, or remove it, as needed.
            this.usersTableAdapter.Fill( this.applicationDataSet.Users );

            }
        }
    }
