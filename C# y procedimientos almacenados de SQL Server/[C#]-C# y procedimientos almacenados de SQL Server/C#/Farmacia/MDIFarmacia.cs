using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Farmacia
{
    public partial class MDIFarmacia : Form
    {
        public MDIFarmacia()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Crear una nueva ventana hija
            WFClientes frm2 = new WFClientes();
            frm2.MdiParent = this;
            // Para mostrarlo maximizado:
            frm2.WindowState = FormWindowState.Normal;
            frm2.Show();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            // Cerrando la ventana principal se cierran todas
            this.Close();
            //Application.Exit()
        }

        private void productosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una nueva ventana hija
            WFProductos frm3 = new WFProductos();
            frm3.MdiParent = this;
            // Para mostrarlo maximizado:
            frm3.WindowState = FormWindowState.Normal;
            frm3.Show();
        }

        private void ventasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Crear una nueva ventana hija
            WFVentas frm4 = new WFVentas();
            frm4.MdiParent = this;
            // Para mostrarlo maximizado:
            frm4.WindowState = FormWindowState.Normal;
            frm4.Show();
        }
    }
}