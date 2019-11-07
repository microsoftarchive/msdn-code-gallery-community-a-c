
using DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Access to database operations
        /// </summary>
        /// <remarks></remarks>
        private Operations DataOpts = new Operations();

        /// <summary>
        /// Used for the data source for the DataGridView
        /// </summary>
        /// <remarks></remarks>
        private BindingSource bsCustmers = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bsCustmers.DataSource = DataOpts.LoadCustomers();
            DataGridView1.DataSource = bsCustmers;
        }

        private void cmdAddRows_Click(object sender, EventArgs e)
        {
            bool SeconaryTry = false;
            List<Customer> Customers = new List<Customer>() {
			new Customer {CompanyName = "BDF Inc.", ContactName = "Anne", ContactTitle = "Owner"},
			new Customer {CompanyName = "Bill's shoes", ContactName = "Bill", ContactTitle = "Owner"},
			new Customer {CompanyName = "Salem Fishing Corp", ContactName = "Debbie", ContactTitle = "Sales"}
		};

            int NewIdentifier = 0;
            DataTable dt = (DataTable)bsCustmers.DataSource;
            foreach (var Customer in Customers)
            {
                //
                // See if the row already exists
                //
                if (bsCustmers.Find("CompanyName", Customer.CompanyName) == -1)
                {
                    if (DataOpts.AddNewRow(Customer, ref NewIdentifier))
                    {
                        dt.Rows.Add(new object[] { NewIdentifier, Customer.CompanyName, Customer.ContactName, Customer.ContactTitle });
                    }
                }
                else
                {
                    SeconaryTry = true;
                    break;
                }
            }

            if (SeconaryTry)
            {
                MessageBox.Show("This was designed to work once :-)");
            }
        }

        private void cmdView_Click(object sender, EventArgs e)
        {
            DataOpts.ViewDatabase();
        }
    }
}