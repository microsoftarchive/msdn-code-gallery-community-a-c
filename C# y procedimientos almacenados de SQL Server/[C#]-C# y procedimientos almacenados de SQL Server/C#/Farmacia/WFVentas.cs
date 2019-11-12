using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Farmacia
{
    public partial class WFVentas : Form
    {
        public WFVentas()
        {
            InitializeComponent();
        }
        private void WFVentas_Load(object sender, EventArgs e)
        {
            CargarClientes();
            CargarProductos();
            CargarVentas();
        }
        private void CargarVentas()
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("VerVistaVentas", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cnn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
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
        private void CargarClientes()
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("Vercliente", cnn);
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
                dataGridView3.DataSource = ds.Tables[0];
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
        private void CargarLog(string texto)
        {
            string fileString = "c:\\log.log";
            TextWriter tw = new StreamWriter(fileString);
            tw.WriteLine(DateTime.Now + " " + texto);
            tw.Close();
        }
        private void dataGridView2_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //this.textBox10.Text = "0";
                this.textBox3.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.textBox5.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();

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
        private void dataGridView3_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //this.textBox10.Text = "0";
                this.textBox7.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.textBox8.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.textBox9.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
                //this.textBox4.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
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
            CargarClientes();            
        }
        private void button1_Click(object sender, EventArgs e)
        {            
            CargarProductos();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton1.Checked)
                {
                    this.BuscarPorId(this.textBox1.Text);
                }
                else if (radioButton6.Checked)
                {
                    this.BuscarPorProducto(this.textBox1.Text);
                }
                else if (radioButton7.Checked)
                {
                    this.BuscarPorPrecio(this.textBox1.Text);
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
                dataGridView3.DataSource = ds.Tables[0];
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
                dataGridView3.DataSource = ds.Tables[0];
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
                dataGridView3.DataSource = ds.Tables[0];
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
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton2.Checked)
                {
                    this.BuscarPorNombre(this.textBox6.Text);
                }
                else if (radioButton3.Checked)
                {
                    this.BuscarPorApellido(this.textBox6.Text);
                }
                else if (radioButton4.Checked)
                {
                    this.BuscarPorDireccion(this.textBox6.Text);
                }
                else if (radioButton5.Checked)
                {
                    this.BuscarPorEmail(this.textBox6.Text);
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
        private void BuscarPorNombre(string nombre)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarClientePorNombre", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombres", SqlDbType.Char, 50);
                cmd.Parameters["@nombres"].Value = nombre;
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
        private void BuscarPorApellido(string apellido)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarClienteApellidos", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@apellidos", SqlDbType.Char, 50);
                cmd.Parameters["@apellidos"].Value = apellido;
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
        private void BuscarPorDireccion(string direccion)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarClienteDireccion", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@direccion", SqlDbType.Char, 50);
                cmd.Parameters["@direccion"].Value = direccion;
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
        private void BuscarPorEmail(string email)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarClienteEmail", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@email", SqlDbType.Char, 50);
                cmd.Parameters["@email"].Value = email;
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
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.textBox10.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                this.textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                this.textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                this.textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

                this.textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                this.textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                this.textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
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
        private void button10_Click(object sender, EventArgs e)
        {
            try
            {

                if (radioButton8.Checked)
                {
                    this.BuscarPorNombreVenta(this.textBox2.Text);
                }
                else if (radioButton9.Checked)
                {
                    this.BuscarPorApellidoVenta(this.textBox2.Text);
                }
                else if (radioButton10.Checked)
                {
                    this.BuscarPorProductoVenta(this.textBox2.Text);
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
        private void BuscarPorNombreVenta(string nombre)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarVentaNombreCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombres", SqlDbType.Char, 50);
                cmd.Parameters["@nombres"].Value = nombre;
                cnn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
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
        private void BuscarPorApellidoVenta(string apellido)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarVentaApellidoCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@apellidos", SqlDbType.Char, 50);
                cmd.Parameters["@apellidos"].Value = apellido;
                cnn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
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
        private void BuscarPorProductoVenta(string producto)
        {
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BuscarVentaPorProductoCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@producto ", SqlDbType.Char, 50);
                cmd.Parameters["@producto "].Value = producto;
                cnn.Open();
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
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
        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox10.Text;
                if(id.Equals("0")){
                    string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                    SqlConnection cnn = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand("InsertarVenta", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@idproducto", SqlDbType.Int);
                    cmd.Parameters.Add("@idcliente", SqlDbType.Int);
                    cmd.Parameters.Add("@precio", SqlDbType.Money);                    
                    cmd.Parameters["@idproducto"].Value = Convert.ToInt32(this.textBox7.Text);
                    cmd.Parameters["@idcliente"].Value = Convert.ToInt32(this.textBox3.Text);
                    cmd.Parameters["@precio"].Value = textBox9.Text;                                   
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron insertados correctamente");
                    cnn.Close();
                    this.button8.Visible = true;
                    this.button3.Visible = false;
                    CargarVentas();       
                }
                else{
                    MessageBox.Show("Los datos deben ser actualizados y no insertados como nuevos");
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
        private void button9_Click(object sender, EventArgs e)
        {
            CargarVentas();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox10.Text;
                if (id.Equals("0"))
                {
                    MessageBox.Show("Los datos deben ser insertados como nuevos y no actualizados"); 
                }
                else
                {
                    string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                    SqlConnection cnn = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand("ActualizarVenta", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int);
                    cmd.Parameters.Add("@idproducto", SqlDbType.Int);
                    cmd.Parameters.Add("@idcliente", SqlDbType.Int);
                    cmd.Parameters.Add("@precio", SqlDbType.Money);
                    cmd.Parameters["@id"].Value = Convert.ToInt32(this.textBox10.Text);
                    cmd.Parameters["@idproducto"].Value = Convert.ToInt32(this.textBox7.Text);
                    cmd.Parameters["@idcliente"].Value = Convert.ToInt32(this.textBox3.Text);
                    cmd.Parameters["@precio"].Value = textBox9.Text;
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron actualizados correctamente");
                    cnn.Close();
                    this.button3.Visible = true;
                    this.button8.Visible = false;
                    CargarVentas();                   
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

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.textBox10.Text = "0";               
                this.textBox3.Text = "";
                this.textBox4.Text = "";
                this.textBox5.Text = "";
                this.textBox7.Text = "";
                this.textBox8.Text = "";
                this.textBox9.Text = "";
                this.button3.Visible = true;
                this.button8.Visible = false;
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox10.Text;
                if (id.Equals("0"))
                {
                    MessageBox.Show("el id no existe");
                }
                else
                {
                    string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                    SqlConnection cnn = new SqlConnection(ConnectionString);
                    SqlCommand cmd = new SqlCommand("BorrarVenta", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@id", SqlDbType.Int);                    
                    cmd.Parameters["@id"].Value = Convert.ToInt32(this.textBox10.Text);                    
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Los datos fueron eliminados correctamente");
                    cnn.Close();
                    this.button3.Visible = true;
                    this.button8.Visible = false;
                    CargarVentas();      
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
    }

}
