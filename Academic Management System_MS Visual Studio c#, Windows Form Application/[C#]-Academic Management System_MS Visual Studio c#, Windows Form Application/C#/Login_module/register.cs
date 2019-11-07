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
    public partial class register : Form
    {
        public register()
        {
            InitializeComponent();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox1.Enabled = true;
            }
            else
            {
                textBox1.Enabled = false;
            }
        }
        public OleDbConnection con = new OleDbConnection();
        private void register_Load(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            textBox1.Enabled = false;
            con.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=E:\Software Engg Project\university.accdb;Persist Security Info=False";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.Connection = con;
            OleDbCommand com2 = new OleDbCommand();
            com2.Connection = con;
            com.CommandText = "Select p.personid as stdid, p.fname as stdName, p.lname as stdLastName from person p, register r where p.personid = r.studentid";
            dataGridView1.Columns.Add("personid", "Student Id");
            dataGridView1.Columns.Add("fname", "First Name");
            dataGridView1.Columns.Add("lname", "Last Name");
            dataGridView1.Columns.Add("Dump", "Register");
            dataGridView1.Columns.Add("Coursetitle", "Course");
            com2.CommandText = "Select c.coursetitle as cName, r.studentid as stID from course c, register r where r.courseid = c.courseid";
            OleDbDataReader cRead = com2.ExecuteReader();
            OleDbDataReader stdRead = com.ExecuteReader();
            while (stdRead.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = stdRead["stdid"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = stdRead["stdName"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = stdRead["stdLastName"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = "Is Registered for";
           
                  while (cRead.Read())
                    {
                    if (cRead["stID"].ToString() == stdRead["stdid"].ToString())
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = cRead["cName"].ToString();
                        break;
                    }
                }
            } 
                }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            OleDbCommand com1 = new OleDbCommand();
            com1.Connection = con;
            com1.CommandText = "Select p.personid as stdid, p.fname as stdName, p.lname as stdLastName from person p, register r where p.personid = r.studentid and p.fname like'"+textBox1.Text+"%'";
           
            OleDbCommand com2 = new OleDbCommand();
            com2.Connection = con;
            com2.CommandText = "Select c.coursetitle as cName, r.studentid as stID from course c, register r where r.courseid = c.courseid";
            OleDbDataReader cRead = com2.ExecuteReader();
            OleDbDataReader stdRead = com1.ExecuteReader();
            while (stdRead.Read())
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0].Value = stdRead["stdid"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1].Value = stdRead["stdName"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Value = stdRead["stdLastName"].ToString();
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Value = "Is Registered for";

                while (cRead.Read())
                {
                    if (cRead["stID"].ToString() == stdRead["stdid"].ToString())
                    {
                        dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Value = cRead["cName"].ToString();
                        break;
                    }
                }
            } 
        }
        }
    
}
