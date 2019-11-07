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
    public partial class WFClientes : Form
    {
        private BindingSource bindingSource1 = new BindingSource();
        private SqlDataAdapter dataAdapter = new SqlDataAdapter();
        public WFClientes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox3.Text = "";
                    this.textBox4.Text = "";
                    this.textBox5.Text = "";
                    this.button4.Visible = true;
                    this.button1.Visible = false;
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
                //string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("ActualizarCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int);
                cmd.Parameters.Add("@nombres", SqlDbType.Char, 50);
                cmd.Parameters.Add("@apellidos", SqlDbType.Char, 50);
                cmd.Parameters.Add("@direccion", SqlDbType.Char, 50);
                cmd.Parameters.Add("@email", SqlDbType.Char, 100);
                cmd.Parameters["@id"].Value = Convert.ToInt32(this.textBox1.Text);
                cmd.Parameters["@nombres"].Value = textBox2.Text;
                cmd.Parameters["@apellidos"].Value = textBox3.Text;
                cmd.Parameters["@direccion"].Value = textBox4.Text;
                cmd.Parameters["@email"].Value = textBox5.Text;
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actulizados correctamente");
                cnn.Close();
                this.button4.Visible = false;
                this.button1.Visible = true;
                CargarClientes();
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
        private string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
        
        private void CargarClientes()
        {
            try
            {
                //string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("Vercliente", cnn);
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
        private void WFClientes_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }        
        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            
                try
                {
                    this.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    this.textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    this.textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    this.textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                    this.textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                    
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
        private void CargarLog(string texto)
        {
            string fileString = "c:\\log.log";
            TextWriter tw = new StreamWriter(fileString);
            tw.WriteLine(DateTime.Now + " " + texto);
            tw.Close();
        }
        private void button4_Click(object sender, EventArgs e)
        {         
            try
            {
                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("InsertarCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombres", SqlDbType.Char, 50);
                cmd.Parameters.Add("@apellidos", SqlDbType.Char, 50);
                cmd.Parameters.Add("@direccion", SqlDbType.Char, 50);
                cmd.Parameters.Add("@email", SqlDbType.Char, 100);
                cmd.Parameters["@nombres"].Value = textBox2.Text;
                cmd.Parameters["@apellidos"].Value = textBox3.Text;
                cmd.Parameters["@direccion"].Value = textBox4.Text;
                cmd.Parameters["@email"].Value = textBox5.Text;
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron insertados correctamente");
                cnn.Close();
                this.button4.Visible = false;
                this.button1.Visible = true;
                CargarClientes();
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


                string ConnectionString = ConfigurationManager.ConnectionStrings["connectionStringName"].ToString();
                SqlConnection cnn = new SqlConnection(ConnectionString);
                SqlCommand cmd = new SqlCommand("BorrarCliente", cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int);                
                cmd.Parameters["@id"].Value = Convert.ToInt32(this.textBox1.Text);                
                cnn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Los datos fueron actulizados correctamente");
                cnn.Close();
                this.button4.Visible = false;
                this.button1.Visible = true;
                CargarClientes();
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
                                     
                if (radioButton2.Checked) {
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

        private void button6_Click(object sender, EventArgs e)
        {
            CargarClientes();
            //BuscarPorNombre();
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
                cmd.Parameters["@nombres"].Value =nombre;                 
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
    }
}
