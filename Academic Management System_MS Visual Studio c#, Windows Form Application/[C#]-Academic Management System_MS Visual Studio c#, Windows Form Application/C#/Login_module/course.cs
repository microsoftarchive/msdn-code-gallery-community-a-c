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
    public partial class course : Form
    {
        public course()
        {
            InitializeComponent();
        }
        public OleDbConnection con = new OleDbConnection();


        private void course_Load(object sender, EventArgs e)
        {

            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Software Engg Project\university.accdb;Persist Security Info=False";
            con.Open();

            button2.Enabled = false;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
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
                textBox6.Enabled = false;
                checkBox1.Enabled = false;
                comboBox5.Enabled = false;
                button1.Enabled = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
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
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                textBox3.Enabled = false;


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
                //Update Checkbox
                textBox6.Enabled = false;
                comboBox5.Enabled = true;
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "Select courseid from course";
                OleDbDataReader Cread = com.ExecuteReader();
                while (Cread.Read())
                {
                    comboBox5.Items.Add(Cread["courseid"].ToString());
                }
            }
            else
            {
                textBox6.Enabled = true;
                comboBox5.Enabled = false;
            }

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                //Check box with database
                textBox7.Enabled = false;
                comboBox6.Enabled = true;
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "Select courseid from course";
                OleDbDataReader Cread = com.ExecuteReader();
                while (Cread.Read())
                {
                    comboBox6.Items.Add(Cread["courseid"].ToString());
                }
            }
            else
            {
                textBox7.Enabled = true;
                comboBox6.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                //Check box with database
                //Delete Checkbox
                textBox8.Enabled = false;
                comboBox7.Enabled = true;
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "Select courseid from course";
                OleDbDataReader Cread = com.ExecuteReader();
                while (Cread.Read())
                {
                    comboBox7.Items.Add(Cread["courseid"].ToString());
                }
            }
            else
            {
                textBox8.Enabled = true;
                comboBox7.Enabled = false;
            }
        }

        private void label2_Leave(object sender, EventArgs e)
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
                if (char.IsLetter(input[i]) || input[i] == ' ')
                    count++;
            }
            if (count == input.Length)
            {
                label4.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                textBox2.Focus();
                label4.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            string input = textBox3.Text;
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]) || input[i] == ' ')
                    count++;
            }
            if (count == input.Length)
            {
                label3.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                textBox3.Focus();
                label3.ForeColor = System.Drawing.Color.Red;
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

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            if (textBox6.Text != "")
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                com1.CommandText = "Select deptid, dname from department";
                OleDbDataReader Dread = com1.ExecuteReader();
                com.CommandText = "select c.courseid as cid, c.coursetitle as cName, c.coursedesc as cDesc, c.deptid as cDeptid from course c, department d where  d.deptid = c.deptid";
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (textBox6.Text == fread["cid"].ToString())
                    {
                        textBox1.Text = fread["cid"].ToString();
                        textBox2.Text = fread["cName"].ToString();
                        textBox3.Text = fread["Cdesc"].ToString();
                        while (Dread.Read())
                        {
                            if (fread["cDeptid"].ToString() == Dread["deptid"].ToString())
                            {
                                comboBox1.Items.Add(Dread["dname"].ToString());
                                comboBox1.SelectedIndex = 0;
                                break;
                            }
                        }

                        label13.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                    else
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedItem = null;
                        label13.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox1.Items.Clear();
            if (textBox7.Text != "")
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                com1.CommandText = "Select deptid, dname from department";
                OleDbDataReader Dread = com1.ExecuteReader();
                com.CommandText = "select c.courseid as cid, c.coursetitle as cName, c.coursedesc as cDesc, c.deptid as cDeptid from course c, department d where  d.deptid = c.deptid";
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (textBox7.Text == fread["cid"].ToString())
                    {
                        textBox1.Text = fread["cid"].ToString();
                        textBox2.Text = fread["cName"].ToString();
                        textBox3.Text = fread["Cdesc"].ToString();
                        while (Dread.Read())
                        {
                            if (fread["cDeptid"].ToString() == Dread["deptid"].ToString())
                            {
                                comboBox1.Items.Add(Dread["dname"].ToString());
                                comboBox1.SelectedIndex = 0;
                                break;
                            }
                        }

                        label15.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                    else
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedItem = null;
                        label15.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;

            textBox2.Enabled = false;
            textBox3.Enabled = false;
            comboBox1.Items.Clear();
            if (textBox8.Text != "")
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                com1.CommandText = "Select deptid, dname from department";
                OleDbDataReader Dread = com1.ExecuteReader();
                com.CommandText = "select c.courseid as cid, c.coursetitle as cName, c.coursedesc as cDesc, c.deptid as cDeptid from course c, department d where  d.deptid = c.deptid";
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (textBox8.Text == fread["cid"].ToString())
                    {
                        textBox1.Text = fread["cid"].ToString();
                        textBox2.Text = fread["cName"].ToString();
                        textBox3.Text = fread["Cdesc"].ToString();
                        while (Dread.Read())
                        {
                            if (fread["cDeptid"].ToString() == Dread["deptid"].ToString())
                            {
                                comboBox1.Items.Add(Dread["dname"].ToString());
                                comboBox1.SelectedIndex = 0;
                                break;
                            }
                        }

                        label17.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                    else
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedItem = null;
                        label17.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox7.Checked == true)
            {
                comboBox1.Items.Clear();
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "Select dname from department ";
                OleDbDataReader cRead = com.ExecuteReader();
                while (cRead.Read())
                {
                    comboBox1.Items.Add(cRead["dname"].ToString());
                }
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
                comboBox1.Items.Clear();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            bool flag = false;
            com.CommandText = "Select courseid from course";
            OleDbDataReader cRead = com.ExecuteReader();
            while (cRead.Read())
            {
                if (textBox1.Text == cRead["courseid"].ToString())
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

        private void button2_Click(object sender, EventArgs e)
        {
            bool flag = false;
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && comboBox1.SelectedItem != null)
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "Select deptid,dname from department";
                OleDbDataReader cRead = com.ExecuteReader();
                while (cRead.Read())
                {
                    if (comboBox1.SelectedItem.ToString() == cRead["dname"].ToString())
                    {
                        flag = true;
                        break;
                    }
                }
                if (flag)
                {
                    OleDbCommand com1 = new OleDbCommand();
                    com1.Connection = con;
                    try
                    {
                        com1.CommandText = "Insert into Course(courseid,deptid,coursetitle,coursedesc) values(" + int.Parse(textBox1.Text) + "," + int.Parse(cRead["deptid"].ToString()) + ",'" + textBox2.Text + "','" + textBox3.Text + "')";
                        com1.ExecuteNonQuery();
                        MessageBox.Show("Successfully Added");
                    }
                    catch
                    {
                        MessageBox.Show("Can not be added");
                    }
                }

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            if (comboBox5.SelectedItem != null)
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                com1.CommandText = "Select deptid, dname from department";
                OleDbDataReader Dread = com1.ExecuteReader();
                com.CommandText = "select c.courseid as cid, c.coursetitle as cName, c.coursedesc as cDesc, c.deptid as cDeptid from course c, department d where  d.deptid = c.deptid";
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (comboBox5.SelectedItem.ToString() == fread["cid"].ToString())
                    {
                        textBox1.Text = fread["cid"].ToString();
                        textBox2.Text = fread["cName"].ToString();
                        textBox3.Text = fread["Cdesc"].ToString();
                        while (Dread.Read())
                        {
                            if (fread["cDeptid"].ToString() == Dread["deptid"].ToString())
                            {
                                comboBox1.Items.Add(Dread["dname"].ToString());
                                comboBox1.SelectedIndex = 0;
                                break;
                            }
                        }

                        label13.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                    else
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedItem = null;
                        label13.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            if (comboBox6.SelectedItem != null)
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                com1.CommandText = "Select deptid, dname from department";
                OleDbDataReader Dread = com1.ExecuteReader();
                com.CommandText = "select c.courseid as cid, c.coursetitle as cName, c.coursedesc as cDesc, c.deptid as cDeptid from course c, department d where  d.deptid = c.deptid";
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (comboBox6.SelectedItem.ToString() == fread["cid"].ToString())
                    {
                        textBox1.Text = fread["cid"].ToString();
                        textBox2.Text = fread["cName"].ToString();
                        textBox3.Text = fread["Cdesc"].ToString();
                        while (Dread.Read())
                        {
                            if (fread["cDeptid"].ToString() == Dread["deptid"].ToString())
                            {
                                comboBox1.Items.Add(Dread["dname"].ToString());
                                comboBox1.SelectedIndex = 0;
                                break;
                            }
                        }

                        label15.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                    else
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedItem = null;
                        label15.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            if (comboBox7.SelectedItem != null)
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                com1.CommandText = "Select deptid, dname from department";
                OleDbDataReader Dread = com1.ExecuteReader();
                com.CommandText = "select c.courseid as cid, c.coursetitle as cName, c.coursedesc as cDesc, c.deptid as cDeptid from course c, department d where  d.deptid = c.deptid";
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (comboBox7.SelectedItem.ToString() == fread["cid"].ToString())
                    {
                        textBox1.Text = fread["cid"].ToString();
                        textBox2.Text = fread["cName"].ToString();
                        textBox3.Text = fread["Cdesc"].ToString();
                        while (Dread.Read())
                        {
                            if (fread["cDeptid"].ToString() == Dread["deptid"].ToString())
                            {
                                comboBox1.Items.Add(Dread["dname"].ToString());
                                comboBox1.SelectedIndex = 0;
                                break;
                            }
                        }

                        label17.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                    else
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.SelectedItem = null;
                        label17.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                if (textBox6.Enabled == true && comboBox5.Enabled == false)
                {
                    OleDbCommand com = new OleDbCommand();
                    com.Connection = con;
                    try
                    {
                        com.CommandText = "Update course set coursetitle ='" + textBox2.Text + "', coursedesc = '" + textBox3.Text + "' where courseid =" + int.Parse(textBox1.Text) + "";
                        com.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated");
                    }
                    catch
                    {
                        MessageBox.Show("Can not be updated");
                    }
                }
                else
                {
                    OleDbCommand com = new OleDbCommand();
                    com.Connection = con;
                    try
                    {
                        com.CommandText = "Update course set coursetitle ='" + textBox2.Text + "', coursedesc = '" + textBox3.Text + "' where courseid =" + int.Parse(comboBox5.SelectedItem.ToString()) + "";
                        com.ExecuteNonQuery();
                        MessageBox.Show("Successfully Updated");
                    }
                    catch
                    {
                        MessageBox.Show("Can not be updated");
                    }

                }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox8.Enabled == true && comboBox7.Enabled == false)
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                try
                {
                    com.CommandText = "Delete from course where courseid =" + int.Parse(textBox8.Text) + "";
                    com.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted");
                }
                catch
                {
                    MessageBox.Show("Can not be Deleted");
                }
            }
            else
            {
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                try
                {
                    com.CommandText = "Delete from course where courseid =" + int.Parse(comboBox7.SelectedItem.ToString()) + "";
                    com.ExecuteNonQuery();
                    MessageBox.Show("Successfully Deleted");
                }
                catch
                {
                    MessageBox.Show("Can not be Deleted");
                }
            }
        }
    }
}
