using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Domain;
using Session;
using System.Data.OleDb;

namespace Management
{
    public partial class Form1 : Form
    {
        Broker b = new Broker();
        OleDbCommand command;
        OleDbConnection connection;
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void entry_btn_Click(object sender, EventArgs e)
        {
            
            Inventory i = new Inventory();

            if ((item_name.Text == string.Empty) || (man_com.Text == string.Empty) || (type_box.Text == string.Empty) || (client_com.Text == string.Empty) || (ordr_id.Text == string.Empty))
            {
                MessageBox.Show("Empty Textbox Detected");

            }
            else
            {
                try
                {
                    i.Item = item_name.Text;
                    i.Model = model_box.Text;
                    i.Company = man_com.Text;
                    i.Type = type_box.Text;
                    i.Serial = serial_num.Text;
                    i.Order = ordr_id.Text;
                    i.ClientCom = client_com.Text;
                    i.DOrder = dateTimePicker1.Text;
                    i.DShip = dateTimePicker2.Text;
                    i.DMan = dateTimePicker3.Text;
                    i.Price = double.Parse(price_box.Text);
                    b.insert(i);
                    MessageBox.Show("Successfully Saved into Database!");
                }
                catch(Exception)
                {
                    MessageBox.Show("Price Can Be Numeric Input Only");
                }             
            }     

        }

        private void update_btn_Click(object sender, EventArgs e)
        {
            /* */
            try
            {
                if ((updtName.Text == string.Empty) || (updtCom.Text == string.Empty) || (updtModel.Text == string.Empty) || (updtStatus.Text == string.Empty) || (updtType.Text == string.Empty))
                {
                    MessageBox.Show("Empty Textbox Detected");

                }
                else
                {
                    Inventory oldInventory = new Inventory();
                    Inventory newInventory = new Inventory();
                    // Based on User's selection to make changes
                    oldInventory = combo_refrs.SelectedItem as Inventory;
                    //Selection is made now updating changes
                    newInventory.Item = updtName.Text;
                    newInventory.Company = updtCom.Text;
                    newInventory.Model = updtModel.Text;
                    newInventory.Type = updtType.Text;
                    newInventory.DShip = updtStatus.Text;
                    b.NewData(oldInventory, newInventory);
                    MessageBox.Show("Data Updated!");
                }
               
            }
            catch(Exception)
            {
                throw;
            }
            
        }

        private void Rfrs_btn_Click(object sender, EventArgs e)
        {
            
            combo_refrs.DataSource = b.edit();
        }

        private void dltsrc_btn_Click(object sender, EventArgs e)
        {
            Inventory i = new Inventory();
            i = combo_refrs.SelectedItem as Inventory;
            b.delete(i);
            MessageBox.Show("Data Deleted!");
        }


        private void dataGridCom_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void mant_view_box_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void combo_refrs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void refreshbtn_Click(object sender, EventArgs e)
        {

            connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\Users\mdjul\Desktop\Management\DataBase.accdb;Persist Security Info=False");
            command = connection.CreateCommand();
            connection.Open();
            command.CommandText = "SELECT * FROM InvetoryManagement";
            command.CommandType = CommandType.Text;

            OleDbDataAdapter da = new OleDbDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            inv_dg.DataSource = dt;
            MessageBox.Show("Inventory Data Synchronization Successful");
        }

        private void inv_dg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
    
        }

        private void date_src_btn_Click(object sender, EventArgs e)
        {
          
        }

        private void valid_box_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (valid_box.Text == string.Empty)
                {
                    MessageBox.Show("Write Item Type In The SearchBox");
                }
                else
                {
                    connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\Users\mdjul\Desktop\Management\DataBase.accdb;Persist Security Info=False");
                    command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT ItemName,ModelNum,ClientCom,MaitenDate FROM InvetoryManagement WHERE Type='" + valid_box.Text + "'";
                    command.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    mant_view_box.DataSource = dt;
                }

            }
            catch(Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void shw_btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (search_com.Text == string.Empty)
                {
                    MessageBox.Show("Write Company Name In The SearchBox");
                }
                else
                {
                    connection = new OleDbConnection(@"Provider=Microsoft.ACE.OLEDB.15.0;Data Source=C:\Users\mdjul\Desktop\Management\DataBase.accdb;Persist Security Info=False");
                    command = connection.CreateCommand();
                    connection.Open();
                    command.CommandText = "SELECT * FROM InvetoryManagement WHERE ClientCom='" + search_com.Text + "'";
                    command.CommandType = CommandType.Text;
                    OleDbDataAdapter da = new OleDbDataAdapter(command);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridCom.DataSource = dt;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                }
            }
        }

        private void item_name_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void updtName_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void search_com_TextChanged(object sender, EventArgs e)
        {

        }

        private void time_Click(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
