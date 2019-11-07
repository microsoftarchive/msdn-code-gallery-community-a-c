using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ConcreteLibrary;
using MainForm.Extensions;

namespace MainApplication
{
    public partial class frmCustomers : Form
    {
        public frmCustomers()
        {
            InitializeComponent();
        }

        private List<Customer> _customers;
        public frmCustomers(List<Customer> pCustomers)
        {
            InitializeComponent();
            _customers = pCustomers;
            Shown += FrmCustomers_Shown;           
        }
        private void FrmCustomers_Shown(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _customers;
            dataGridView1.ExpandColumns();
        }
    }
}
