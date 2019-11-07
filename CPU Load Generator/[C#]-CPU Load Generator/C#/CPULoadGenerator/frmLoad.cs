using LoadGenerator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CPULoadGenerator
{
    public partial class frmLoad : Form
    {
        LoadManager manager;
        int processorCount = Environment.ProcessorCount;

        public frmLoad()
        {
            InitializeComponent();
        }

        private void frmLoad_Load(object sender, EventArgs e)
        {
            Label[] lblCPU = new Label[processorCount];
            TrackBar[] tBar = new TrackBar[processorCount];

            GroupBox[] grpCPU = new GroupBox[processorCount];
            for (int i = 0; i < processorCount; i++)
            {
                int yOffset = 17;
                grpCPU[i] = new GroupBox();
                grpCPU[i].Text = "CPU" + i.ToString();
                grpCPU[i].Size = new Size(350, 50);
                grpCPU[i].Location = new Point(20, i * 60);

                RadioButton rbtnMin = new RadioButton();
                RadioButton rbtnMed = new RadioButton();
                RadioButton rbtnMax = new RadioButton();

                grpCPU[i].Controls.Add(rbtnMin);
                grpCPU[i].Controls.Add(rbtnMed);
                grpCPU[i].Controls.Add(rbtnMax);

                rbtnMin.Text = "Minimum";
                rbtnMin.AutoSize = true;
                rbtnMin.Location = new Point(40, yOffset);
                rbtnMin.Checked = true;
                rbtnMin.Click += rbt_Click;
                rbtnMin.Tag = i.ToString() + ",0";

                rbtnMed.Text = "Medium";
                rbtnMed.AutoSize = true;
                rbtnMed.Location = new Point(130, yOffset);
                rbtnMed.Click += rbt_Click;
                rbtnMed.Tag = i.ToString() + ",50";

                rbtnMax.Text = "Maximum";
                rbtnMax.AutoSize = true;
                rbtnMax.Location = new Point(220, yOffset);
                rbtnMax.Click += rbt_Click;
                rbtnMax.Tag = i.ToString() + ",100";

                pnlCPU.Controls.Add(grpCPU[i]);

            }

            manager = new LoadManager();
        }

        void rbt_Click(object sender, EventArgs e)
        {
            RadioButton chkBox = sender as RadioButton;
            if (chkBox != null)
            {
                string data = chkBox.Tag.ToString();
                string[] input = data.Split(new char[] { ',' });
                manager.SetLoad(int.Parse(input[0]),int.Parse(input[1]));
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLoad_FormClosing(object sender, FormClosingEventArgs e)
        {
            manager.Dispose();
        }
    }
}
