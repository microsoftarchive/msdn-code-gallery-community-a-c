using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
namespace WindowsFormsApplication1
{
    public partial class student_data : Form
    {
        public student_data()
        {
            InitializeComponent();
        }
        //Global Variable
        public OleDbConnection con = new OleDbConnection();
        
        private void student_data_Load(object sender, EventArgs e)
        {
           con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Software Engg Project\university.accdb;Persist Security Info=False";
           con.Open();
           button2.Enabled = false;
            //Connection with database
            //form load activities
                comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox3.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
                //Update
                textBox6.Enabled = false;
                checkBox1.Enabled = false;
                comboBox5.Enabled = false;
                button1.Enabled = false;
                //Search
                textBox7.Enabled = false;
                checkBox2.Enabled = false;
                comboBox6.Enabled = false;
                
                //Delete
                textBox8.Enabled = false;
                comboBox7.Enabled = false;
                button4.Enabled = false;
                checkBox3.Enabled = false;
        }
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {   
            //Update
            if (checkBox4.Checked == true)
            {
                textBox1.Enabled = false;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                //Add checkbox
                checkBox7.Checked = false;  
                textBox6.Enabled = true;
                checkBox1.Enabled = true;
                comboBox5.Enabled = false;
                button1.Enabled = true;
                //Search
                textBox7.Enabled = false;
                checkBox2.Enabled = false;
                comboBox6.Enabled = false;
                //Delete
                textBox8.Enabled = false;
                comboBox7.Enabled = false;
                button4.Enabled = false;
                checkBox3.Enabled = false;
                //Check boxes
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
            else
            {

                textBox1.Enabled = true;
                textBox6.Enabled = false;
                checkBox1.Enabled = false;
                comboBox5.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void checkBox4_CheckStateChanged(object sender, EventArgs e)
        {

        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            //Search
            if (checkBox5.Checked == true)
            {

                //Add checkbox
                checkBox7.Checked = false;  
                textBox7.Enabled = true;
                checkBox2.Enabled = true;
                comboBox6.Enabled = false;
                //Update
                textBox6.Enabled = false;
                checkBox1.Enabled = false;
                comboBox5.Enabled = false;
                button1.Enabled = false;
                //Delete  
                textBox8.Enabled = false;
                comboBox7.Enabled = false;
                button4.Enabled = false;
                checkBox3.Enabled = false;
                //Check boxes
                checkBox4.Checked = false;
                checkBox6.Checked = false;
            }
            else
            {
                textBox7.Enabled = false;
                checkBox2.Enabled = false;
                comboBox6.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            //Delete
            if (checkBox6.Checked == true)
            {
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
               

                //Add checkbox
                checkBox7.Checked = false;  
                textBox8.Enabled = true;
                comboBox7.Enabled = false;
                button4.Enabled = true;
                checkBox3.Enabled = true;
                //Update
                textBox6.Enabled = false;
                checkBox1.Enabled = false;
                comboBox5.Enabled = false;
                button1.Enabled = false;
                //Search
                textBox7.Enabled = false;
                checkBox2.Enabled = false;
                comboBox6.Enabled = false;
                //check boxes
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
            else
            {
                textBox8.Enabled = false;
                comboBox7.Enabled = false;
                button4.Enabled = false;
                checkBox3.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            if (checkBox1.Checked == true)
            {
                //Check box with database
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = con;
                command1.CommandText = "SELECT p.PersonId as personnum  FROM PERSON p, student s where p.PersonId = s.studentid";
                OleDbDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    comboBox5.Items.Add(reader["personnum"].ToString());
                }
                //Update Checkbox
                textBox6.Enabled = false;
                comboBox5.Enabled = true;
            }
            else
            {
                textBox6.Enabled = true;
                comboBox5.Enabled = false;    
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            if (checkBox2.Checked == true)
            {
                //Check box with database
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = con;
                command1.CommandText = "SELECT p.PersonId as personnum  FROM PERSON p, student s where p.PersonId = s.studentid";
                OleDbDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    comboBox6.Items.Add(reader["personnum"].ToString());
                }
                //Search Checkbox
                textBox7.Enabled = false;
                comboBox6.Enabled = true;
            }
            else
            {
                textBox7.Enabled = true;
                comboBox6.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            if (checkBox3.Checked == true)
            {
                //Check box with database
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = con;
                command1.CommandText = "SELECT p.PersonId as personnum  FROM PERSON p, student s where p.PersonId = s.studentid";
                OleDbDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    comboBox7.Items.Add(reader["personnum"].ToString());
                }
                //Delete Checkbox
                textBox8.Enabled = false;
                comboBox7.Enabled = true;
            }
            else
            {
                textBox8.Enabled = true;
                comboBox7.Enabled = false;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            bool flag = false;  
            string input = textBox1.Text;
            try
            {
                int id = int.Parse(input);
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = con;
                command1.CommandText = "SELECT PersonId FROM PERSON";
                OleDbDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    if (id.ToString() == reader["PersonId"].ToString())
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    label2.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    label2.ForeColor = System.Drawing.Color.Red;        
                }
            }
            catch
            {
                label2.ForeColor = System.Drawing.Color.Red;
            }
            
        }


        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand com1 = new OleDbCommand();
            OleDbCommand com2 = new OleDbCommand();
            OleDbCommand com3 = new OleDbCommand();
            OleDbCommand com4 = new OleDbCommand();
            OleDbCommand com5 = new OleDbCommand();

            com1.Connection = con;
            com2.Connection = con;
            com3.Connection = con;
            com4.Connection = con;
            com5.Connection = con;
            bool flag1 = false, flag2 = false;
            string studentId = textBox1.Text;
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            string address = textBox4.Text;
            string postalCode = textBox5.Text;

            if (studentId != "" && fname != "" && lname != "" && address != "" && postalCode != "" && comboBox1.SelectedItem != null && comboBox4.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                com4.CommandText = "Select courseid , coursetitle from course";
                OleDbDataReader courseRead = com4.ExecuteReader();
                while (courseRead.Read())
                {
                    if (comboBox2.SelectedItem.ToString() == courseRead["coursetitle"].ToString())
                    {
                        flag1 = true;
                        break;
                    }
                }
                com5.CommandText = "SELECT c.courseid as cID, d.deptid as stdDept, d.dname as depName FROM Course c, Department d where c.deptid = d.deptid";
                OleDbDataReader DeRead = com5.ExecuteReader();
                while (DeRead.Read())
                {
                    if (comboBox1.SelectedItem.ToString() == DeRead["depName"].ToString())
                    {
                        flag2 = true;
                        break;
                    }
                }
                if (flag1 && flag2)
                {
                    try
                    {
                        com1.CommandText = "Insert into person(personId,fname,lname,dob,postalcode,gender,address) values(" + int.Parse(studentId) + ",'" + fname + "','" + lname + "'," + dateTimePicker1.Value.ToString("mm-dd-yyyy") + "," + long.Parse(postalCode) + ",'" + comboBox4.SelectedItem.ToString() + "','" + address + "')";
                        com2.CommandText = "Insert into student(studentid,class,Deptid) values(" + int.Parse(studentId) + ",'" + comboBox3.SelectedItem.ToString() + "'," + int.Parse(DeRead["stdDept"].ToString()) + ")";
                        com3.CommandText = "Insert into Register(courseid, studentid) values(" + int.Parse(courseRead["courseid"].ToString()) + "," + int.Parse(studentId) + ")";

                        com1.ExecuteNonQuery();
                        com2.ExecuteNonQuery();
                        com3.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added");
                    }
                    catch(Exception es) 
                    {
                        MessageBox.Show(es.ToString());
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Values");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            string input = textBox1.Text;
            try
            {
                long id = long.Parse(input);
                label2.ForeColor = System.Drawing.Color.Green;
            }
            catch
            {
                textBox1.Focus();
                label2.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            string input = textBox2.Text;
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                    count++;
            }
            if (input.Length != 0)
            {
                if(count == input.Length)
                label6.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                textBox2.Focus();
                label6.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string input = textBox3.Text;
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                    count++;
            }
            if (input.Length != 0)
            {
                if (count == input.Length)
                {
                    label7.ForeColor = System.Drawing.Color.Green;
                }
            }
            else
            {
                textBox3.Focus();
                label7.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            string input = textBox5.Text;
            try
            {
                long id = long.Parse(input);
                label11.ForeColor = System.Drawing.Color.Green;
            }
            catch
            {
                textBox5.Focus();
                label11.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, s.class as stdclass, s.Deptid as stddept  FROM PERSON p, student s where p.PersonId = s.studentid";
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (textBox6.Text == reader["personnum"].ToString()) 
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                label13.ForeColor = System.Drawing.Color.Green;
                textBox1.Text = reader["personnum"].ToString();
                //Student Department
                OleDbCommand com2 = new OleDbCommand();
                com2.Connection = con;
                com2.CommandText = "SELECT  d.dname as deptname, s.deptid as stddept, s.class as stclass from department d, student s where s.deptid = d.deptid";
                OleDbDataReader readStd = com2.ExecuteReader();
                while (readStd.Read())
                {
                    if (reader["stdclass"].ToString() == readStd["stclass"].ToString())
                    {
                        comboBox1.Items.Add(readStd["deptname"].ToString());
                        comboBox3.Items.Add(readStd["stclass"].ToString());
                        break;
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                label13.ForeColor = System.Drawing.Color.Red;
            }
        }
        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, s.class as stdclass, s.Deptid as stddept  FROM PERSON p, student s where p.PersonId = s.studentid";
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (textBox7.Text == reader["personnum"].ToString())
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                label15.ForeColor = System.Drawing.Color.Green;
                textBox1.Text = reader["personnum"].ToString();
                //Student Department
                OleDbCommand com2 = new OleDbCommand();
                com2.Connection = con;
                com2.CommandText = "SELECT  d.dname as deptname, s.deptid as stddept, s.class as stclass from department d, student s where s.deptid = d.deptid";
                OleDbDataReader readStd = com2.ExecuteReader();
                while (readStd.Read())
                {
                    if (reader["stdclass"].ToString() == readStd["stclass"].ToString())
                    {
                        comboBox1.Items.Add(readStd["deptname"].ToString());
                        comboBox3.Items.Add(readStd["stclass"].ToString());
                        break;
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                label13.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            //Check box with database
            //Check box with database
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, s.class as stdclass, s.Deptid as stddept  FROM PERSON p, student s where p.PersonId = s.studentid";
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (textBox8.Text == reader["personnum"].ToString())
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                label17.ForeColor = System.Drawing.Color.Green;
                textBox1.Text = reader["personnum"].ToString();
                //Student Department
                OleDbCommand com2 = new OleDbCommand();
                com2.Connection = con;
                com2.CommandText = "SELECT  d.dname as deptname, s.deptid as stddept, s.class as stclass from department d, student s where s.deptid = d.deptid";
                OleDbDataReader readStd = com2.ExecuteReader();
                while (readStd.Read())
                {
                    if (reader["stdclass"].ToString() == readStd["stclass"].ToString())
                    {
                        comboBox1.Items.Add(readStd["deptname"].ToString());
                        comboBox3.Items.Add(readStd["stclass"].ToString());
                        break;
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                label13.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
              OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "SELECT c.deptid as coursedept, c.courseid as cID , d.dname as dename, d.deptid as deptnum,  c.coursetitle as coursename  FROM Course c, Department d where c.deptid = d.deptid";
                OleDbDataReader read = com.ExecuteReader();
                while (read.Read())
                {
                    if (comboBox1.SelectedItem.ToString() == read["dename"].ToString())
                    {
                        comboBox2.Items.Add(read["coursename"].ToString());
                    }
                }
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                com1.CommandText = "SELECT c.className as cName, d.deptid as dptid, d.dname as depname from class c, department d where d.deptid = c.deptid ";
                OleDbDataReader readclass = com1.ExecuteReader();
                while (readclass.Read())
                {
                    if(comboBox1.SelectedItem.ToString() == readclass["depname"].ToString())
                    {
                        comboBox3.Items.Add(readclass["cName"].ToString());
                        comboBox3.SelectedIndex = 0;
                        break;
                    }
                }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update combobox
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, s.class as stdclass, s.Deptid as stddept  FROM PERSON p, student s where p.PersonId = s.studentid";
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (comboBox5.SelectedItem.ToString() == reader["personnum"].ToString())
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                label13.ForeColor = System.Drawing.Color.Green;
                textBox1.Text = reader["personnum"].ToString();
                //Student Department
                OleDbCommand com2 = new OleDbCommand();
                com2.Connection = con;
                com2.CommandText = "SELECT  d.dname as deptname, s.deptid as stddept, s.class as stclass from department d, student s where s.deptid = d.deptid";
                OleDbDataReader readStd = com2.ExecuteReader();
                while (readStd.Read())
                {
                    if (reader["stdclass"].ToString() == readStd["stclass"].ToString())
                    {
                        comboBox1.Items.Add(readStd["deptname"].ToString());
                        comboBox3.Items.Add(readStd["stclass"].ToString());
                        break;
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                label13.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            //Add check box
            if (checkBox7.Checked == true)
            {
                comboBox1.Items.Clear();
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "Select dname from department";
                OleDbDataReader reDeptid = com.ExecuteReader();
                while (reDeptid.Read())
                {
                    comboBox1.Items.Add(reDeptid["dname"].ToString());
                }
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                OleDbCommand com2 = new OleDbCommand();
                com2.Connection = con;
                com2.CommandText = "SELECT DNAME FROM DEPARTMENT";
                OleDbDataReader dept = com2.ExecuteReader();
                while (dept.Read())
                {
                    comboBox1.Items.Add(dept["dname"].ToString());
                }
                comboBox4.Items.Add("Male");
                comboBox4.Items.Add("Female");
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }

            
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update combobox
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, s.class as stdclass, s.Deptid as stddept  FROM PERSON p, student s where p.PersonId = s.studentid";
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (comboBox6.SelectedItem.ToString() == reader["personnum"].ToString())
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                label13.ForeColor = System.Drawing.Color.Green;
                textBox1.Text = reader["personnum"].ToString();
                //Student Department
                OleDbCommand com2 = new OleDbCommand();
                com2.Connection = con;
                com2.CommandText = "SELECT  d.dname as deptname, s.deptid as stddept, s.class as stclass from department d, student s where s.deptid = d.deptid";
                OleDbDataReader readStd = com2.ExecuteReader();
                while (readStd.Read())
                {
                    if (reader["stdclass"].ToString() == readStd["stclass"].ToString())
                    {
                        comboBox1.Items.Add(readStd["deptname"].ToString());
                        comboBox3.Items.Add(readStd["stclass"].ToString());
                        break;
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                label13.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            if (textBox6.Text != "" || comboBox5.SelectedItem != null)
            {
                if (textBox6.Enabled == true && comboBox5.Enabled == false)
                {
                    try
                    {
                        com.CommandText = "Update Person set fname ='" + textBox2.Text + "', lname ='" + textBox3.Text + "', address ='" + textBox4.Text + "', postalcode = " + int.Parse(textBox5.Text) + " where personid =" + int.Parse(textBox1.Text) + "";
                        com.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated");
                    }
                    catch
                    {
                        MessageBox.Show("Can Not be Updated");
                    }
                }
                else
                {
                    try
                    {
                        com.CommandText = "Update Person set fname ='" + textBox2.Text + "', lname ='" + textBox3.Text + "', address ='" + textBox4.Text + "', postalcode = " + int.Parse(textBox5.Text) + " where personid =" + int.Parse(comboBox5.SelectedItem.ToString()) + "";
                        com.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated");
                    }
                    catch
                    {
                        MessageBox.Show("Can Not be Updated");
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Values");
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, s.class as stdclass, s.Deptid as stddept  FROM PERSON p, student s where p.PersonId = s.studentid";
            OleDbDataReader reader = command1.ExecuteReader();
            while (reader.Read())
            {
                if (comboBox7.SelectedItem.ToString() == reader["personnum"].ToString())
                {
                    flag = true;
                    break;
                }
            }
            if (flag)
            {
                label13.ForeColor = System.Drawing.Color.Green;
                textBox1.Text = reader["personnum"].ToString();
                //Student Department
                OleDbCommand com2 = new OleDbCommand();
                com2.Connection = con;
                com2.CommandText = "SELECT  d.dname as deptname, s.deptid as stddept, s.class as stclass from department d, student s where s.deptid = d.deptid";
                OleDbDataReader readStd = com2.ExecuteReader();
                while (readStd.Read())
                {
                    if (reader["stdclass"].ToString() == readStd["stclass"].ToString())
                    {
                        comboBox1.Items.Add(readStd["deptname"].ToString());
                        comboBox3.Items.Add(readStd["stclass"].ToString());
                        break;
                    }
                }
                comboBox1.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox1.Items.Clear();
                comboBox3.Items.Clear();
                comboBox4.Items.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                label13.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbCommand com1 = new OleDbCommand();
            OleDbCommand com2 = new OleDbCommand();
            OleDbCommand com3 = new OleDbCommand();
            com3.Connection = con;
            com2.Connection = con;
            com1.Connection = con;
            if (textBox8.Text != "" || comboBox7.SelectedItem != null)
            {
                if (textBox8.Enabled == true && comboBox7.Enabled == false)
                {
                    try
                    {
                        com3.CommandText = "Delete from Register where studentid =" + int.Parse(textBox8.Text) + "";
                        com1.CommandText = "Delete  from Student where studentid =" + int.Parse(textBox8.Text) + "";
                        com2.CommandText = "Delete  from Person where PersonId =" + int.Parse(textBox8.Text) + "";
                        com3.ExecuteNonQuery();
                        com1.ExecuteNonQuery();
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Successfully Deleted");
                    }
                    catch
                    {
                        MessageBox.Show("Can Not be Deleted");
                    }
                }
                else
                {
                    try
                    {
                        com3.CommandText = "Delete from Register where studentid =" + int.Parse(comboBox7.SelectedItem.ToString()) + "";
                        com1.CommandText = "Delete  from Student where studentid =" + int.Parse(comboBox7.SelectedItem.ToString()) + "";
                        com2.CommandText = "Delete  from Person where PersonId =" + int.Parse(comboBox7.SelectedItem.ToString()) + "";
                        com3.ExecuteNonQuery();
                        com1.ExecuteNonQuery();
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Successfully Deleted");
                    }
                    catch
                    {
                        MessageBox.Show("Can Not be Deleted");
                    }
                }
            }
            else
            {
                MessageBox.Show("Enter Value Please");
            }
        }

    }
}
