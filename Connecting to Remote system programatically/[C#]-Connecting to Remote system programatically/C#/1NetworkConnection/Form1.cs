using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace _1NetworkConnection
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NetworkCredential objnetCred = GetNetorkCredential();

            string localName=string.Empty; //specify local name of the drive
            string networkName= string.Empty; //Specify remote network name, eg:\\190.x.x.x\Test
            try
            {
                using (NetworkConnection nc = new NetworkConnection(localName, networkName, objnetCred))
                {
                    
                }
            }
            catch (Exception exMsg)
            {
                MessageBox.Show(exMsg.ToString());
            }

        }

        public NetworkCredential GetNetorkCredential()
        {
            NetworkCredential objNetworkCred = new NetworkCredential(@"domainname\username", "password", "domainname");            
            return objNetworkCred;
        }
    }
}
