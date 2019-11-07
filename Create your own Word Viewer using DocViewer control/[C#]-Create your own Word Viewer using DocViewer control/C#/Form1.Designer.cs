namespace Open
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            Spire.Doc.ToPdfParameterList toPdfParameterList5 = new Spire.Doc.ToPdfParameterList();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.docDocumentViewer1 = new Spire.DocViewer.Forms.DocDocumentViewer();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpen,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(676, 54);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnOpen
            // 
            this.btnOpen.Image = global::Open.Properties.Resources.Open;
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(40, 51);
            this.btnOpen.Text = "Open";
            this.btnOpen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnOpen.ToolTipText = "Open a document";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Open.Properties.Resources.Close;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(40, 51);
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnClose.ToolTipText = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // docDocumentViewer1
            // 
            this.docDocumentViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.docDocumentViewer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.docDocumentViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.docDocumentViewer1.EnableHandTools = false;
            this.docDocumentViewer1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.docDocumentViewer1.Location = new System.Drawing.Point(0, 54);
            this.docDocumentViewer1.Name = "docDocumentViewer1";
            this.docDocumentViewer1.Size = new System.Drawing.Size(676, 195);
            this.docDocumentViewer1.TabIndex = 1;
            this.docDocumentViewer1.Text = "docDocumentViewer1";
            toPdfParameterList5.AutoFitTableLayout = false;
            toPdfParameterList5.CreateWordBookmarks = false;
            toPdfParameterList5.EmbeddedFontNameList = ((System.Collections.Generic.List<string>)(resources.GetObject("toPdfParameterList5.EmbeddedFontNameList")));
            toPdfParameterList5.IsAtLast = false;
            toPdfParameterList5.IsEmbeddedAllFonts = false;
            toPdfParameterList5.IsHidden = false;
            toPdfParameterList5.PdfConformanceLevel = Spire.Pdf.PdfConformanceLevel.None;
            toPdfParameterList5.PrivateFontPaths = ((System.Collections.Generic.List<string>)(resources.GetObject("toPdfParameterList5.PrivateFontPaths")));
            this.docDocumentViewer1.ToPdfParameterList = toPdfParameterList5;
            this.docDocumentViewer1.ZoomMode = Spire.DocViewer.Forms.ZoomMode.Default;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 249);
            this.Controls.Add(this.docDocumentViewer1);
            this.Controls.Add(this.toolStrip1);
            this.ForeColor = System.Drawing.SystemColors.Highlight;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Your Own Word Viewer";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private Spire.DocViewer.Forms.DocDocumentViewer docDocumentViewer1;
        private System.Windows.Forms.ToolStripButton btnOpen;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

