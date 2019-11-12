using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace SchoolManagementProgram
{
    public partial class Academic : Form
    {
        public Academic()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // Connect to SQL DB assumed to be populated with student data
               
                //Retreive student data
                using (var conn = new SqlConnection("Server=tcp:SERVER NAME.database.windows.net,1433;Database=DB_NAME;User ID=USER_NAME@SERVER_NAME;Password=INSERT PASSWORD;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                    SELECT * FROM Students,   
                    ORDER BY lastName;";
                    // we assume that the needed tables are created in the DB and that the academic info of the students is inserted there
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox1.AppendText("ID: {0} Name: {1} Order Count: {2}" + reader.GetInt32(0) + reader.GetString(1) + reader.GetInt32(2));
                        }
                    }
                }
            }


            catch (Exception)
            {

                textBox1.Text = "Error in retreiving data from SQL Database";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            Hide();
        }
    }
    }

