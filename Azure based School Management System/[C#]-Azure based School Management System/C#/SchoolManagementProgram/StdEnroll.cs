using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;

namespace SchoolManagementProgram
{
    public partial class StdEnroll : Form
    {
        public StdEnroll()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            

            try
            {
                
                List<student> enroll = new List<student>();
                student std = new student();
                             
                string path = textBox1.Text;
                using (StreamReader s = new StreamReader(path))
                {
                    
                    string line;
                    
                    while ((line = s.ReadLine()) != null)
                    {
                        //Format of text file: First Name   Last Name   Age   Height   Weight   Gender   Address 
                       
                        button1.Text = "before";
                        string[] splits = line.Split(',');
                     
                        std.setFName(splits[0]);
                        std.setLName(splits[1]);
                        
                        std.setAge(Convert.ToInt32(splits[2]));
                        std.setHeight(Convert.ToDouble(splits[3]));

                        std.setWeight(Convert.ToDouble(splits[4]));
                        std.setGender(splits[5]);

                        std.setAddress(splits[6]);

                        enroll.Add(std);
                        line = s.ReadLine();
                    }

                    s.Close();
                }

               //enroll.OrderBy(x => x.getLName()); //sort by last name
               
                
                //after filling the list, print it
                for (int j = 0; j <= enroll.Count()-1; j++)
                {
                    std = enroll.ElementAt(j);
                    textBox2.Text = std.getFName() + " "+std.getLName() + " " + std.getAge() + " " + std.getHeight() + " " + std.getWeight() + " " + std.getGender() + " " + std.getAddress()+'\r'+'\n';
                   
                }
                button1.Text = "!!!!";

            }



            catch (Exception)
            {
               button1.Text = "Error!";

            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Connect to SQL DB assumed to be populated with student data
                
                //Retreive student data
                using (var conn = new SqlConnection("Server=tcp:SERVER_NAME.database.windows.net,1433;Database=NAME OF YOUR DB;User ID=USER_NAME@SERVER_nAME;Password=INSERT PASSWORD;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"))
                {
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"
                    SELECT * FROM Students,   
                    ORDER BY lastName;";
                    // we assume that the needed tables are created in the DB and that the info of the students is inserted there
                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBox2.AppendText("ID: {0} Name: {1} Order Count: {2}" + reader.GetInt32(0) + reader.GetString(1) + reader.GetInt32(2));
                        }
                    }
                }
            }


            catch (Exception)
            {

                textBox2.Text = "Error in retreiving data from SQL Database";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            Hide();
        }
    }


        }
    

