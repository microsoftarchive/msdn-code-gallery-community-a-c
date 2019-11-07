namespace SHANUControlChart_DEMO
{
    partial class SHANUControlChartDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SHANUControlChartDemo));
            this.Label1 = new System.Windows.Forms.Label();
            this.btnRealTime = new System.Windows.Forms.Button();
            this.GroupBox1 = new System.Windows.Forms.GroupBox();
            this.txtusl = new System.Windows.Forms.TextBox();
            this.btnDisplay = new System.Windows.Forms.Button();
            this.txtData = new System.Windows.Forms.TextBox();
            this.txtLSL = new System.Windows.Forms.TextBox();
            this.txtNominal = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.shanuControlChart = new SHANUControlChart_CNT.SHANUControlChart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.GroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.Color.Transparent;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.Color.Maroon;
            this.Label1.Location = new System.Drawing.Point(8, 392);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(296, 136);
            this.Label1.TabIndex = 114;
            this.Label1.Text = resources.GetString("Label1.Text");
            // 
            // btnRealTime
            // 
            this.btnRealTime.BackColor = System.Drawing.Color.AliceBlue;
            this.btnRealTime.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRealTime.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnRealTime.Location = new System.Drawing.Point(24, 304);
            this.btnRealTime.Name = "btnRealTime";
            this.btnRealTime.Size = new System.Drawing.Size(248, 72);
            this.btnRealTime.TabIndex = 113;
            this.btnRealTime.Text = "Real Time Data ON";
            this.btnRealTime.UseVisualStyleBackColor = false;
            this.btnRealTime.Click += new System.EventHandler(this.btnRealTime_Click);
            // 
            // GroupBox1
            // 
            this.GroupBox1.Controls.Add(this.txtusl);
            this.GroupBox1.Controls.Add(this.btnDisplay);
            this.GroupBox1.Controls.Add(this.txtData);
            this.GroupBox1.Controls.Add(this.txtLSL);
            this.GroupBox1.Controls.Add(this.txtNominal);
            this.GroupBox1.Controls.Add(this.Label3);
            this.GroupBox1.Controls.Add(this.Label4);
            this.GroupBox1.Controls.Add(this.Label5);
            this.GroupBox1.Controls.Add(this.Label6);
            this.GroupBox1.ForeColor = System.Drawing.Color.Yellow;
            this.GroupBox1.Location = new System.Drawing.Point(8, 8);
            this.GroupBox1.Name = "GroupBox1";
            this.GroupBox1.Size = new System.Drawing.Size(296, 280);
            this.GroupBox1.TabIndex = 112;
            this.GroupBox1.TabStop = false;
            this.GroupBox1.Text = "Enter the values";
            // 
            // txtusl
            // 
            this.txtusl.BackColor = System.Drawing.Color.White;
            this.txtusl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtusl.Location = new System.Drawing.Point(128, 32);
            this.txtusl.MaxLength = 6;
            this.txtusl.Name = "txtusl";
            this.txtusl.Size = new System.Drawing.Size(120, 21);
            this.txtusl.TabIndex = 113;
            this.txtusl.Text = "10.000";
            this.txtusl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtusl_KeyPress);
            // 
            // btnDisplay
            // 
            this.btnDisplay.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnDisplay.Font = new System.Drawing.Font("굴림", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDisplay.ForeColor = System.Drawing.Color.DimGray;
            this.btnDisplay.Location = new System.Drawing.Point(8, 192);
            this.btnDisplay.Name = "btnDisplay";
            this.btnDisplay.Size = new System.Drawing.Size(248, 72);
            this.btnDisplay.TabIndex = 112;
            this.btnDisplay.Text = "Manual Data Check";
            this.btnDisplay.UseVisualStyleBackColor = false;
            this.btnDisplay.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // txtData
            // 
            this.txtData.BackColor = System.Drawing.Color.White;
            this.txtData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtData.Location = new System.Drawing.Point(128, 152);
            this.txtData.MaxLength = 6;
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(120, 21);
            this.txtData.TabIndex = 111;
            this.txtData.Text = "3.500";
            this.txtData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtData_KeyPress);
            // 
            // txtLSL
            // 
            this.txtLSL.BackColor = System.Drawing.Color.White;
            this.txtLSL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLSL.Location = new System.Drawing.Point(128, 73);
            this.txtLSL.MaxLength = 6;
            this.txtLSL.Name = "txtLSL";
            this.txtLSL.Size = new System.Drawing.Size(120, 21);
            this.txtLSL.TabIndex = 109;
            this.txtLSL.Text = "1.000";
            this.txtLSL.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLSL_KeyPress);
            // 
            // txtNominal
            // 
            this.txtNominal.BackColor = System.Drawing.Color.White;
            this.txtNominal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNominal.Location = new System.Drawing.Point(128, 112);
            this.txtNominal.MaxLength = 6;
            this.txtNominal.Name = "txtNominal";
            this.txtNominal.Size = new System.Drawing.Size(120, 21);
            this.txtNominal.TabIndex = 110;
            this.txtNominal.Text = "5.000";
            this.txtNominal.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNominal_KeyPress);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Transparent;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Label3.Location = new System.Drawing.Point(8, 141);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(61, 25);
            this.Label3.TabIndex = 107;
            this.Label3.Text = "Data";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Transparent;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.Color.AliceBlue;
            this.Label4.Location = new System.Drawing.Point(8, 105);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(97, 25);
            this.Label4.TabIndex = 106;
            this.Label4.Text = "Nominal";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Transparent;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.Color.AliceBlue;
            this.Label5.Location = new System.Drawing.Point(8, 32);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(56, 25);
            this.Label5.TabIndex = 105;
            this.Label5.Text = "USL";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Transparent;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.Color.AliceBlue;
            this.Label6.Location = new System.Drawing.Point(8, 70);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(53, 25);
            this.Label6.TabIndex = 104;
            this.Label6.Text = "LSL";
            // 
            // shanuControlChart
            // 
            this.shanuControlChart.BackColor = System.Drawing.Color.CornflowerBlue;
            this.shanuControlChart.Location = new System.Drawing.Point(320, 16);
            this.shanuControlChart.LSLData = "1.000";
            this.shanuControlChart.MasterData = "3.500";
            this.shanuControlChart.Name = "shanuControlChart";
            this.shanuControlChart.NominalData = "5.000";
            this.shanuControlChart.Size = new System.Drawing.Size(512, 488);
            this.shanuControlChart.TabIndex = 115;
            this.shanuControlChart.USLData = "10.000";
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SHANUControlChartDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(847, 545);
            this.Controls.Add(this.shanuControlChart);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.btnRealTime);
            this.Controls.Add(this.GroupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SHANUControlChartDemo";
            this.Text = "S H A N U  -  USL/LSL Control Limit Demo";
            this.Load += new System.EventHandler(this.SHANUControlChartDemo_Load);
            this.GroupBox1.ResumeLayout(false);
            this.GroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnRealTime;
        internal System.Windows.Forms.GroupBox GroupBox1;
        private System.Windows.Forms.Button btnDisplay;
        internal System.Windows.Forms.TextBox txtData;
        internal System.Windows.Forms.TextBox txtLSL;
        internal System.Windows.Forms.TextBox txtNominal;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label6;
        private SHANUControlChart_CNT.SHANUControlChart shanuControlChart;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.TextBox txtusl;
    }
}