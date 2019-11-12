using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Configuration;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string MyConString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString(); 
            MySqlConnection connection = new MySqlConnection(MyConString); 
            MySqlCommand command = connection.CreateCommand(); 
            MySqlDataReader Reader; command.CommandText = "select nombre from empleados"; 
            connection.Open(); 
            Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                   comboBox1.Items.Add(Reader["nombre"].ToString());
            }
        }
    }
}
