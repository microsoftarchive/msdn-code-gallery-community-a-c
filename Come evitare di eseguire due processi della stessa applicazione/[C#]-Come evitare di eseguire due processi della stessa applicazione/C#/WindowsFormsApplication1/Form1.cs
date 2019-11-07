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
    public partial class Form1 : Form
    {
        List<ClassAccounts> list = new List<ClassAccounts>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassAccounts ca = new ClassAccounts { Name = "My Name", Notes = "Custom Notes" };
            list.Add(ca);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = list;
        }
    }

     public partial class ClassAccounts
    {
         public string Name {get;set;}
         public string Notes {get;set;}
    }
}
