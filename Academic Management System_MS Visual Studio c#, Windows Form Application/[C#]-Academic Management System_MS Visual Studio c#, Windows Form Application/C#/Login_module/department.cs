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
    public partial class department : Form
    {
        public department()
        {
            InitializeComponent();
        }
        public OleDbConnection con = new OleDbConnection();
        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void department_Load(object sender, EventArgs e)
        {
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Software Engg Project\university.accdb;Persist Security Info=False";
            con.Open();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox5.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox6.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox7.DropDownStyle = ComboBoxStyle.DropDownList;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            button2.Enabled = false;
            //Update
            textBox9.Enabled = false;
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
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                //Add checkbox
                checkBox7.Checked = false;
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
                textBox9.Enabled = true;
                //Check boxes
                checkBox5.Checked = false;
                checkBox6.Checked = false;
            }
            else
            {
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
                textBox9.Enabled = false;
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

                textBox9.Enabled = false;

                //Add checkbox
                checkBox7.Checked = false;
                textBox8.Enabled = true;
                comboBox7.Enabled = false;
                button4.Enabled = true;
                checkBox3.Enabled = true;
                //Update
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
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select deptid from department";
                OleDbDataReader dread = com.ExecuteReader();
                while (dread.Read())
                {
                    comboBox5.Items.Add(dread["deptid"].ToString());
                }
                textBox9.Enabled = false;
                //Update Checkbox
                comboBox5.Enabled = true;
            }
            else
            {
                textBox9.Enabled = true;
                comboBox5.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            if (checkBox2.Checked == true)
            {
                //Check box with database
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select deptid from department";
                OleDbDataReader dread = com.ExecuteReader();
                while (dread.Read())
                {
                    comboBox6.Items.Add(dread["deptid"].ToString());
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
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select deptid from department";
                OleDbDataReader dread = com.ExecuteReader();
                while (dread.Read())
                {
                    comboBox7.Items.Add(dread["deptid"].ToString());
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
            if (count == input.Length)
            {
                label3.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                textBox2.Focus();
                label3.ForeColor = System.Drawing.Color.Red;
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
            if (count == input.Length)
            {
                label4.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                textBox3.Focus();
                label4.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            //Check box with database
            textBox1.Enabled = false;
            comboBox1.Items.Clear();
            if (textBox9.Text != "")
            {
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select f.facultyid as fid, d.deptid as dept, d.dname as dename, d.location as dloc  from department d, faculty f where d.facultyid = f.facultyid";
                com1.CommandText = "Select c.className as cName, c.deptid as classDept from class c, department d where c.deptid = d.deptid";
                OleDbDataReader Cread = com1.ExecuteReader();
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (textBox9.Text == fread["dept"].ToString())
                    {
                        comboBox1.Items.Add(fread["fid"].ToString());
                        textBox1.Text = fread["dept"].ToString();
                        textBox2.Text = fread["dename"].ToString();
                        textBox3.Text = fread["dloc"].ToString();
                        comboBox1.SelectedIndex = 0;
                        while (Cread.Read())
                        {
                            if (fread["dept"].ToString() == Cread["classDept"].ToString())
                            { 
                                textBox4.Text = Cread["cName"].ToString();
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
                        comboBox1.Items.Clear();
                        textBox5.Text = "";
                        textBox6.Text = "";
                        textBox4.Text = "";
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
            textBox4.Enabled = false;
            comboBox1.Items.Clear();
            if (textBox7.Text != "")
            {
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
            
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select f.facultyid as fid, d.deptid as dept, d.dname as dename, d.location as dloc  from department d, faculty f where d.facultyid = f.facultyid";
                com1.CommandText = "Select c.className as cName, c.deptid as classDept from class c, department d where c.deptid = d.deptid";
                OleDbDataReader Cread = com1.ExecuteReader();
            
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (textBox7.Text == fread["dept"].ToString())
                    {
                        comboBox1.Items.Add(fread["fid"].ToString());
                        textBox1.Text = fread["dept"].ToString();
                        textBox2.Text = fread["dename"].ToString();
                        textBox3.Text = fread["dloc"].ToString();
                        while (Cread.Read())
                        {
                            if (fread["dept"].ToString() == Cread["classDept"].ToString())
                            {
                                textBox4.Text = Cread["cName"].ToString();
                                break;
                            }
                        }
                        comboBox1.SelectedIndex = 0;
                        label13.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                    else
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.Items.Clear();
                        textBox5.Text = "";
                        textBox6.Text = "";

                        textBox4.Text = "";
                        label13.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;

            textBox4.Enabled = false;
            comboBox1.Items.Clear();
            if (textBox8.Text != "")
            {
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
            
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select f.facultyid as fid, d.deptid as dept, d.dname as dename, d.location as dloc  from department d, faculty f where d.facultyid = f.facultyid";
                com1.CommandText = "Select c.className as cName, c.deptid as classDept from class c, department d where c.deptid = d.deptid";
                OleDbDataReader Cread = com1.ExecuteReader();
            
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    if (textBox8.Text == fread["dept"].ToString())
                    {
                        comboBox1.Items.Add(fread["fid"].ToString());
                        textBox1.Text = fread["dept"].ToString();
                        textBox2.Text = fread["dename"].ToString();
                        textBox3.Text = fread["dloc"].ToString();
                        while (Cread.Read())
                        {
                            if (fread["dept"].ToString() == Cread["classDept"].ToString())
                            {
                                textBox4.Text = Cread["cName"].ToString();
                                break;
                            }
                        }
                        comboBox1.SelectedIndex = 0;
                        label13.ForeColor = System.Drawing.Color.Green;
                        break;
                    }
                    else
                    {

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        comboBox1.Items.Clear();
                        textBox5.Text = "";
                        textBox6.Text = "";

                        textBox4.Text = "";
                        label13.ForeColor = System.Drawing.Color.Red;
                    }
                }
            }
        }

        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (checkBox7.Checked == true)
            {
                textBox4.Enabled = true;
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "select facultyid from faculty where facultyid NOT IN (select facultyid from department) ";
                OleDbDataReader fread = com.ExecuteReader();
                while (fread.Read())
                {
                    comboBox1.Items.Add(fread["facultyid"].ToString());
                }
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
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
                command1.CommandText = "SELECT deptid FROM Department";
                OleDbDataReader reader = command1.ExecuteReader();
                while (reader.Read())
                {
                    if (id.ToString() == reader["deptid"].ToString())
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            com.CommandText = "Select  f.facultyid as fId, p.fname as pfname, p.lname as plname from faculty f, person p where f.facultyid = p.personid";
            OleDbDataReader fread = com.ExecuteReader();
            while (fread.Read())
            {
                if (fread["fId"].ToString() == comboBox1.SelectedItem.ToString())
                {
                    textBox5.Text = fread["pfname"].ToString();
                    textBox6.Text = fread["plname"].ToString();
                    break;
                }
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            textBox1.Enabled = false;
            
            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = con;
            
            com.CommandText = "select f.facultyid as fid, d.deptid as dept, d.dname as dename, d.location as dloc  from department d, faculty f where d.facultyid = f.facultyid";
            com1.CommandText = "Select c.className as cName, c.deptid as classDept from class c, department d where c.deptid = d.deptid";
            OleDbDataReader Cread = com1.ExecuteReader();
            OleDbDataReader fread = com.ExecuteReader();
            while (fread.Read())
            {
                if (comboBox5.SelectedItem.ToString() == fread["dept"].ToString())
                {
                    comboBox1.Items.Add(fread["fid"].ToString());
                    textBox1.Text = fread["dept"].ToString();
                    textBox2.Text = fread["dename"].ToString();
                    while (Cread.Read())
                    {
                        if (fread["dept"].ToString() == Cread["classDept"].ToString())
                        {
                            textBox4.Text = Cread["cName"].ToString();
                            break;
                        }
                    }
                    textBox3.Text = fread["dloc"].ToString();
                    break;
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = con;
            
            com.CommandText = "select f.facultyid as fid, d.deptid as dept, d.dname as dename, d.location as dloc  from department d, faculty f where d.facultyid = f.facultyid";
            com1.CommandText = "Select c.className as cName, c.deptid as classDept from class c, department d where c.deptid = d.deptid";
            OleDbDataReader Cread = com1.ExecuteReader();
            
            OleDbDataReader fread = com.ExecuteReader();
            while (fread.Read())
            {
                if (comboBox6.SelectedItem.ToString() == fread["dept"].ToString())
                {
                    comboBox1.Items.Add(fread["fid"].ToString());
                    textBox1.Text = fread["dept"].ToString();
                    textBox2.Text = fread["dename"].ToString();
                    textBox3.Text = fread["dloc"].ToString();
                    while (Cread.Read())
                    {
                        if (fread["dept"].ToString() == Cread["classDept"].ToString())
                        {
                            textBox4.Text = Cread["cName"].ToString();
                            break;
                        }
                    }
                    break;
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            textBox1.Enabled = false;
            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = con;
            
            com.CommandText = "select f.facultyid as fid, d.deptid as dept, d.dname as dename, d.location as dloc  from department d, faculty f where d.facultyid = f.facultyid";
            com1.CommandText = "Select c.className as cName, c.deptid as classDept from class c, department d where c.deptid = d.deptid";
            OleDbDataReader Cread = com1.ExecuteReader();
            
            OleDbDataReader fread = com.ExecuteReader();
            while (fread.Read())
            {
                if (comboBox7.SelectedItem.ToString() == fread["dept"].ToString())
                {
                    comboBox1.Items.Add(fread["fid"].ToString());
                    textBox1.Text = fread["dept"].ToString();
                    textBox2.Text = fread["dename"].ToString();
                    textBox3.Text = fread["dloc"].ToString();
                    while (Cread.Read())
                    {
                        if (fread["dept"].ToString() == Cread["classDept"].ToString())
                        {
                            textBox4.Text = Cread["cName"].ToString();
                            break;
                        }
                    }
                    break;
                }
            }
            comboBox1.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            string dname = textBox2.Text;
            string dloc = textBox3.Text;
            string className = textBox4.Text;
            object facultyId = comboBox1.SelectedItem;
            if (id != "" && dname != "" && dloc != "" && facultyId != null && className !="")
            {
                OleDbCommand com1 = new OleDbCommand();
                com1.Connection = con;
                OleDbCommand com = new OleDbCommand();
                com.Connection = con;
                com.CommandText = "Insert into Department(deptid, dname, location, facultyid) values("+int.Parse(id)+",'"+dname+"','"+dloc+"',"+int.Parse(facultyId.ToString())+")";
                com1.CommandText = "Insert into class(className,deptid) values('"+className+"',"+int.Parse(id)+")";
                com.ExecuteNonQuery();
                com1.ExecuteNonQuery();
                MessageBox.Show("Successfully Added");
            }
            else
            {
                MessageBox.Show("Enter Values");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    OleDbCommand com1 = new OleDbCommand();
                    com1.Connection = con;
                    OleDbCommand com = new OleDbCommand();
                    com.Connection = con;
                    com1.CommandText = "Update class set className = '"+textBox4.Text+"' where deptid =" + int.Parse(textBox1.Text) + "";
                    com.CommandText = "Update department set dname = '" + textBox2.Text + "', location ='" + textBox3.Text + "' where deptid =" + int.Parse(textBox1.Text) + "";
                    com.ExecuteNonQuery();
                    com1.ExecuteNonQuery();
                    MessageBox.Show("Successfully Updated");
                }
            }
            catch
            {
                MessageBox.Show("Can not be updated");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = con;
            OleDbCommand com2 = new OleDbCommand();
            com2.Connection = con;
            OleDbCommand com3 = new OleDbCommand();
            com3.Connection = con;
            OleDbCommand com4 = new OleDbCommand();
            com4.Connection = con;
            OleDbCommand com5 = new OleDbCommand();
            com5.Connection = con;
            OleDbCommand com6 = new OleDbCommand();
            com6.Connection = con;
            bool flag = false;
            if (textBox8.Enabled == true && comboBox7.Enabled == false)
            {
                try
                {
                    OleDbCommand com = new OleDbCommand();
                    com.Connection = con;
                    com2.CommandText = "Delete from course where deptid = "+int.Parse(textBox1.Text)+"";
                    com1.CommandText = "Delete from Student where deptid =" +int.Parse(textBox1.Text)+"";
                    com5.CommandText = "Delete from class where deptid =" + int.Parse(textBox1.Text) + "";
                    com.CommandText = "Delete from department where deptid = " + int.Parse(textBox1.Text) + "";
                    com5.ExecuteNonQuery();
                    com2.ExecuteNonQuery();
                    com1.ExecuteNonQuery();
                    com.ExecuteNonQuery();
                    flag = true;
                }
                catch
                {
                    flag = false;
                }
                if (flag)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox4.Text = "";
                    comboBox1.Items.Clear(); 
                    MessageBox.Show("Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("Can not be Deleted");
                }
            }
            else
            {
                try
                {
                    OleDbCommand com = new OleDbCommand();
                    com.Connection = con;
                    com4.CommandText = "Delete from course where deptid = " + int.Parse(comboBox7.SelectedItem.ToString()) + "";
                    com3.CommandText = "Delete from Student where deptid =" + int.Parse(comboBox7.SelectedItem.ToString()) + "";
                    com6.CommandText = "Delete from class where deptid =" + int.Parse(comboBox7.SelectedItem.ToString()) + "";
                    com.CommandText = "Delete from department where deptid = " + int.Parse(comboBox7.SelectedItem.ToString()) + "";
                    com6.ExecuteNonQuery();
                    com4.ExecuteNonQuery();
                    com3.ExecuteNonQuery();
                    com.ExecuteNonQuery();
                    flag = true;
                }
                catch
                {
                    flag = false;
                }
                if (flag)
                {
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
                    textBox4.Text = "";
                    comboBox1.Items.Clear();
                    MessageBox.Show("Successfully Deleted");
                }
                else
                {
                    MessageBox.Show("Can not be Deleted");
                }
            }
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            string input = textBox4.Text;
            int count = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsLetter(input[i]))
                    count++;
            }
            if (count == input.Length)
            {
                label9.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                textBox4.Focus();
                label9.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
