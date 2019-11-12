using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace Farmacia
{
    public partial class WFProductos : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public WFProductos()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                this.textBox4.Text = "";                
                this.button8.Visible = true;
                this.button5.Visible = false;
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }
        private void CargarLog(string texto)
        {
            string fileString = "c:\\log.log";
            TextWriter tw = new StreamWriter(fileString);
            tw.WriteLine(DateTime.Now + " " + texto);
            tw.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {            
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("InsertarProducto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@producto", SqlDbType.Char, 50);
                cmd.Parameters.Add("@droga", SqlDbType.Char, 50);
                cmd.Parameters.Add("@precio", SqlDbType.Money, 50);
               
                cmd.Parameters["@producto"].Value = textBox2.Text;
                cmd.Parameters["@droga"].Value = textBox3.Text;
                cmd.Parameters["@precio"].Value = textBox4.Text;
                
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron insertados correctamente");
                cnn.Close();
                this.button8.Visible = false;
                this.button5.Visible = true;
                CargarProductos();
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }

        private void WFProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();
        }
        private void CargarProductos()
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("VerProducto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                cnn.Close();
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.textBox1.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.textBox2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
                //this.textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString();

            }
            //error de conexion a la base de datows  
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BorrarProducto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = Convert.ToInt32(this.textBox1.Text);
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actulizados correctamente");
                cnn.Close();
                this.button8.Visible = false;
                this.button5.Visible = true;
                CargarProductos();
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("ActulizarProducto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@producto", SqlDbType.Char, 50);
                cmd.Parameters.Add("@droga", SqlDbType.Char, 50);
                cmd.Parameters.Add("@precio", SqlDbType.Money, 50);
                
                cmd.Parameters["@id"].Value = Convert.ToInt32(this.textBox1.Text);
                cmd.Parameters["@producto"].Value = textBox2.Text;
                cmd.Parameters["@droga"].Value = textBox3.Text;
                cmd.Parameters["@precio"].Value = textBox4.Text;
                
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actulizados correctamente");
                cnn.Close();
                this.button8.Visible = false;
                this.button5.Visible = true;
                CargarProductos();
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton2.Checked)
                {
                    this.BuscarPorId(this.textBox6.Text);
                }
                else if (radioButton3.Checked)
                {
                    this.BuscarPorProducto(this.textBox6.Text);
                }
                else if (radioButton4.Checked)
                {
                    this.BuscarPorPrecio(this.textBox6.Text);
                }                
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }
        private void BuscarPorId(string id)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarProductoId", cnn);
                cmd.CommandType = CommandType.StoredProcedure;                
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters["@id"].Value = Convert.ToInt32(id);                
                cnn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                cnn.Close();
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }
        private void BuscarPorProducto(string producto)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarProductoPorProducto", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@producto ", SqlDbType.Char, 50);
                cmd.Parameters["@producto "].Value = producto;
                cnn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                cnn.Close();
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }
        private void BuscarPorPrecio(string precio)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarProductoPrecio", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@precio", SqlDbType.Money, 50);
                cmd.Parameters["@precio"].Value = precio;
                cnn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView2.DataSource = ds.Tables[0];
                cnn.Close();
            }
            catch (System.InvalidOperationException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n"

                            );
                this.CargarLog(ex.ToString());
            }
            //error de sentencia sql que no sea la correta
            catch (SqlException ex)
            {
                MessageBox.Show("Please open a new connection" + "\n"
                            + "TargetSite: " + ex.TargetSite + "\n" +
                            "Source: " + ex.Source + "\n" +
                            "ErrorCode: " + ex.ErrorCode + "\n" +
                            "Server: " + ex.Server + "\n" +
                            "State: " + ex.State + "\n" +
                            "Number: " + ex.Number + "\n" +
                            "Message: " + ex.Message);
                this.CargarLog(ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                this.CargarLog(ex.ToString());
            }
        }
    }
}
