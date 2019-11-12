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
    public partial class faculty : Form
    {
        public faculty()
        {
            InitializeComponent();
        }
        //Global Variable
        public OleDbConnection con = new OleDbConnection();
        
        private void faculty_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Software Engg Project\university.accdb;Persist Security Info=False";
            con.Open();
            button2.Enabled = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            
            comboBox4.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            //Update
            textBox6.Enabled = false;
            checkBox1.Enabled = false;
            comboBox5.Enabled = false;
            button1.Enabled = false;
            //Search
            textBox7.Enabled = false;
            checkBox2.Enabled = false;
            comboBox6.Enabled = false;
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
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
                //Check boxes
                checkBox5.Checked = false;
            }
            else
            {
                textBox6.Enabled = false;
                checkBox1.Enabled = false;
                comboBox5.Enabled = false;
                button1.Enabled = false;
            }
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
                checkBox4.Checked = false;
            }
            else
            {

                textBox7.Enabled = false;
                checkBox2.Enabled = false;
                comboBox6.Enabled = false;
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
                command1.CommandText = "SELECT p.PersonId as personnum  FROM PERSON p, faculty f where p.PersonId = f.facultyid";
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
                command1.CommandText = "SELECT p.PersonId as personnum  FROM PERSON p, faculty f where p.PersonId = f.facultyid";
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

        private void button2_Click(object sender, EventArgs e)
        {
            string fId = textBox1.Text;
            string fname = textBox2.Text;
            string lname = textBox3.Text;
            string address = textBox4.Text;
            string postalCode = textBox5.Text;
            string fcon = textBox9.Text;
            string fsal = textBox10.Text;
            if (fId != "" && fname != "" && lname != "" && address != "" && postalCode != "" && fcon != "" && fsal != "" && comboBox4.SelectedItem != null && dateTimePicker1.Value != null && comboBox1.SelectedItem != null)
            {
                OleDbCommand com1 = new OleDbCommand();
                OleDbCommand com2 = new OleDbCommand();
                com1.Connection = con;
                com2.Connection = con;
                try
                {
                    com1.CommandText = "Insert into person(personId,fname,lname,dob,postalcode,gender,address) values(" + fId + ",'" + fname + "','" + lname + "'," + dateTimePicker1.Value.ToString("mm-dd-yyyy") + "," + postalCode + ",'" + comboBox4.SelectedItem.ToString() + "','" + address + "')";
                    com2.CommandText = "Insert into faculty(facultyid, office, salary, contactNo) values(" + fId + ",'" + comboBox1.SelectedItem.ToString() + "'," + long.Parse(textBox10.Text) + "," + long.Parse(textBox9.Text) + ")";
                    com1.ExecuteNonQuery();
                    com2.ExecuteNonQuery();
                    MessageBox.Show("Successfully Added");
                }
                catch
                {
                    MessageBox.Show("Can not be added");
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
            if (input.Length > 3)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]) || input[i] == ' ')
                        count++;
                }
                if (count == input.Length)
                {
                    label6.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    textBox2.Focus();
                    label6.ForeColor = System.Drawing.Color.Red;
                }
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
            if (input.Length > 3)
            {
                for (int i = 0; i < input.Length; i++)
                {
                    if (char.IsLetter(input[i]) || input[i] == ' ')
                        count++;
                }
                if (count == input.Length)
                {
                    label7.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    textBox3.Focus();
                    label7.ForeColor = System.Drawing.Color.Red;
                }
            }

            else
            {
                textBox3.Focus();
                label7.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void textBox9_Leave(object sender, EventArgs e)
        {
            string input = textBox9.Text;
            try
            {
                long id = long.Parse(input);
                label5.ForeColor = System.Drawing.Color.Green;
            }
            catch
            {
                textBox9.Focus();
                label5.ForeColor = System.Drawing.Color.Red;
            }
        
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, f.salary as fSal, f.contactNo as fCon, f.office as foffice  FROM PERSON p, Faculty f where p.PersonId = f.facultyid";
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
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox1.Items.Add(reader["foffice"].ToString());
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                comboBox1.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);
                textBox9.Text = reader["fCon"].ToString();
                textBox10.Text = reader["fSal"].ToString(); 

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox4.Items.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
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
            textBox9.Enabled = false;
            textBox10.Enabled = false;
  
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, f.salary as fSal, f.contactNo as fCon, f.office as foffice  FROM PERSON p, Faculty f where p.PersonId = f.facultyid";
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
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox1.Items.Add(reader["foffice"].ToString());
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                comboBox1.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);
                textBox9.Text = reader["fCon"].ToString();
                textBox10.Text = reader["fSal"].ToString();

            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                comboBox4.Items.Clear();
                textBox4.Text = "";
                textBox5.Text = "";
                textBox10.Text = "";
                textBox9.Text = "";
                dateTimePicker1.Value = DateTime.Now;
                label15.ForeColor = System.Drawing.Color.Red;
            }
        }

       

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked)
            {
                comboBox1.Items.Clear();
                button2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                textBox5.Enabled = true;
                textBox10.Enabled = true;
                textBox9.Enabled = true;
                comboBox4.Items.Clear();
                comboBox4.Items.Add("Male");
                comboBox4.Items.Add("Female");
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select dname from department";

                OleDbDataReader Fread = com.ExecuteReader();
                while (Fread.Read())
                {
                    comboBox1.Items.Add(Fread["dname"].ToString());
                }
                checkBox4.Checked = false;
                checkBox5.Checked = false;
            }
            else
            {
                comboBox1.Items.Clear();
                button2.Enabled = false;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Focus();
                label10.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                label10.ForeColor = System.Drawing.Color.Green;
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            textBox9.Enabled = true;
            textBox10.Enabled = true;

            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, f.salary as fSal, f.contactNo as fCon, f.office as foffice  FROM PERSON p, Faculty f where p.PersonId = f.facultyid";
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
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                comboBox1.Items.Add(reader["foffice"].ToString());
                comboBox1.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);
                textBox9.Text = reader["fCon"].ToString();
                textBox10.Text = reader["fSal"].ToString();

            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox9.Enabled = false;
            textBox10.Enabled = false;

            //Check box with database
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            comboBox4.Items.Clear();
            bool flag = false;
            OleDbCommand command1 = new OleDbCommand();
            command1.Connection = con;
            command1.CommandText = "SELECT p.PersonId as personnum, p.fname as perfname, p.lname as perlname, p.gender as pergen, p.dob as perdob, p.postalcode as perpost, p.address as peradd, f.salary as fSal, f.contactNo as fCon, f.office as foffice  FROM PERSON p, Faculty f where p.PersonId = f.facultyid";
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
                label15.ForeColor = System.Drawing.Color.Green;
                textBox1.Text = reader["personnum"].ToString();
                textBox2.Text = reader["perfname"].ToString();
                textBox3.Text = reader["perlname"].ToString();
                comboBox4.Items.Add(reader["pergen"].ToString());
                comboBox4.SelectedIndex = 0;
                comboBox1.Items.Add(reader["foffice"].ToString());
                comboBox1.SelectedIndex = 0;
                textBox5.Text = reader["perpost"].ToString();
                textBox4.Text = reader["peradd"].ToString();
                dateTimePicker1.Value = Convert.ToDateTime(reader["perdob"]);
                textBox9.Text = reader["fCon"].ToString();
                textBox10.Text = reader["fSal"].ToString();

            }
        
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
                OleDbCommand com1 = new OleDbCommand();
                OleDbCommand com2 = new OleDbCommand();
                com1.Connection = con;
                com2.Connection = con;
                if (textBox6.Text != "" || comboBox5.SelectedItem != null)
                {
                    try
                    {
                        com1.CommandText = "Update Person set fname ='" + textBox2.Text + "', lname ='" + textBox3.Text + "', address ='" + textBox4.Text + "', postalcode = " + int.Parse(textBox5.Text) + " where personid =" + int.Parse(textBox1.Text) + "";
                        com2.CommandText = "Update Faculty set salary = " + long.Parse(textBox10.Text) + ", contactNo = " + long.Parse(textBox9.Text) + " where facultyid =" + int.Parse(textBox1.Text) + "";
                        com1.ExecuteNonQuery();
                        com2.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated");
                    }
                    catch
                    {
                        MessageBox.Show("Can not be updated");
                    }
                }
                else
                {
                    MessageBox.Show("Enter Values");
                }
            
        }


    }
}
