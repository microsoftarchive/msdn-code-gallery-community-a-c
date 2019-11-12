using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Conways_Game_of_Life_cs
{
    public partial class Form1 : Form
    {


        private Animation animation;

        public Form1()
        {
            // This call is required by the designer.
            InitializeComponent();

            FormClosing += Form1_FormClosing;
            Shown += Form1_Shown;
            

            // Add any initialization after the InitializeComponent() call.

            frmProgress progress = new frmProgress(200, "Loading...");
            progress.Show();

            exDGV1.SuspendLayout();
            for (int x = 0; x <= 99; x++)
            {
                exDGV1.Columns.Add("", "");
                exDGV1.Columns[x].Width = 4;
                progress.performStep();
            }

            exDGV1.Rows.Add(100);

            for (int x = 0; x <= 99; x++)
            {
                exDGV1.Rows[x].Height = 4;
                progress.performStep();
            }
            exDGV1.ResumeLayout();

            animation = new Animation(exDGV1);

        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            ComboBox1.SelectedIndex = 0;
            exDGV1.CurrentCell = null;
            exDGV1.ShowCellToolTips = false;
        }        

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            animation.cancelled = true;
        }

        private void ComboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            animation.setSeed(ComboBox1.SelectedIndex);
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            Thread backgroundThread = new Thread(new ParameterizedThreadStart(animation.animate));
            backgroundThread.Start(ComboBox1.SelectedIndex);
        }
    }
}
