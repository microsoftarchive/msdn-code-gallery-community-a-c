using ADSearch.Forms;

namespace ADSearch.Forms
{
    partial class Explorer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Explorer));
            this.Panel1 = new System.Windows.Forms.Panel();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.spcActiveDirectory = new System.Windows.Forms.SplitContainer();
            this.tvwGroups = new System.Windows.Forms.TreeView();
            this.IltGroups = new System.Windows.Forms.ImageList(this.components);
            this.lvwAttributes = new System.Windows.Forms.ListView();
            this.Splitter1 = new System.Windows.Forms.Splitter();
            this.tslVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCopyright = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsFooter = new System.Windows.Forms.StatusStrip();
            this.tslReleaseDate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tltControlTips = new System.Windows.Forms.ToolTip(this.components);
            this.tsp2 = new System.Windows.Forms.ToolStripSeparator();
            this.tlbActiveDirectory = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.cboFindItems = new System.Windows.Forms.ToolStripComboBox();
            this.tsbFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbUserList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbFindDevice = new System.Windows.Forms.ToolStripButton();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.cboDomain = new System.Windows.Forms.ToolStripComboBox();
            this.Panel1.SuspendLayout();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spcActiveDirectory)).BeginInit();
            this.spcActiveDirectory.Panel1.SuspendLayout();
            this.spcActiveDirectory.Panel2.SuspendLayout();
            this.spcActiveDirectory.SuspendLayout();
            this.stsFooter.SuspendLayout();
            this.tlbActiveDirectory.SuspendLayout();
            this.SuspendLayout();
            // 
            // Panel1
            // 
            this.Panel1.Controls.Add(this.tlpMain);
            this.Panel1.Controls.Add(this.Splitter1);
            this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Panel1.Location = new System.Drawing.Point(0, 45);
            this.Panel1.Name = "Panel1";
            this.Panel1.Size = new System.Drawing.Size(784, 547);
            this.Panel1.TabIndex = 114;
            // 
            // tlpMain
            // 
            this.tlpMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.spcActiveDirectory, 1, 1);
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tlpMain.Size = new System.Drawing.Size(778, 541);
            this.tlpMain.TabIndex = 7;
            // 
            // spcActiveDirectory
            // 
            this.spcActiveDirectory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spcActiveDirectory.Location = new System.Drawing.Point(13, 13);
            this.spcActiveDirectory.Name = "spcActiveDirectory";
            // 
            // spcActiveDirectory.Panel1
            // 
            this.spcActiveDirectory.Panel1.Controls.Add(this.tvwGroups);
            // 
            // spcActiveDirectory.Panel2
            // 
            this.spcActiveDirectory.Panel2.Controls.Add(this.lvwAttributes);
            this.spcActiveDirectory.Size = new System.Drawing.Size(752, 515);
            this.spcActiveDirectory.SplitterDistance = 267;
            this.spcActiveDirectory.TabIndex = 8;
            // 
            // tvwGroups
            // 
            this.tvwGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwGroups.ImageIndex = 0;
            this.tvwGroups.ImageList = this.IltGroups;
            this.tvwGroups.Location = new System.Drawing.Point(0, 0);
            this.tvwGroups.Name = "tvwGroups";
            this.tvwGroups.SelectedImageIndex = 0;
            this.tvwGroups.Size = new System.Drawing.Size(267, 515);
            this.tvwGroups.TabIndex = 7;
            this.tvwGroups.BeforeCollapse += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwGroups_BeforeCollapse);
            this.tvwGroups.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvwGroups_BeforeExpand);
            this.tvwGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwGroups_AfterSelect);
            // 
            // IltGroups
            // 
            this.IltGroups.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IltGroups.ImageStream")));
            this.IltGroups.TransparentColor = System.Drawing.Color.Transparent;
            this.IltGroups.Images.SetKeyName(0, "database.png");
            this.IltGroups.Images.SetKeyName(1, "folder.png");
            this.IltGroups.Images.SetKeyName(2, "folder_add.png");
            this.IltGroups.Images.SetKeyName(3, "organizationalUnit.png");
            this.IltGroups.Images.SetKeyName(4, "organizationalUnit_add.png");
            this.IltGroups.Images.SetKeyName(5, "world.png");
            this.IltGroups.Images.SetKeyName(6, "monitor.png");
            this.IltGroups.Images.SetKeyName(7, "user.png");
            this.IltGroups.Images.SetKeyName(8, "group.png");
            this.IltGroups.Images.SetKeyName(9, "Help2.png");
            // 
            // lvwAttributes
            // 
            this.lvwAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwAttributes.FullRowSelect = true;
            this.lvwAttributes.GridLines = true;
            this.lvwAttributes.Location = new System.Drawing.Point(0, 0);
            this.lvwAttributes.MultiSelect = false;
            this.lvwAttributes.Name = "lvwAttributes";
            this.lvwAttributes.Size = new System.Drawing.Size(481, 515);
            this.lvwAttributes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwAttributes.TabIndex = 6;
            this.tltControlTips.SetToolTip(this.lvwAttributes, "Double-Click to view values from member | memberOf | sAMAccountName");
            this.lvwAttributes.UseCompatibleStateImageBehavior = false;
            this.lvwAttributes.View = System.Windows.Forms.View.Details;
            this.lvwAttributes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwAttributes_ColumnClick);
            this.lvwAttributes.DoubleClick += new System.EventHandler(this.lvwAttributes_DoubleClick);
            // 
            // Splitter1
            // 
            this.Splitter1.Location = new System.Drawing.Point(0, 0);
            this.Splitter1.Name = "Splitter1";
            this.Splitter1.Size = new System.Drawing.Size(3, 547);
            this.Splitter1.TabIndex = 5;
            this.Splitter1.TabStop = false;
            // 
            // tslVersion
            // 
            this.tslVersion.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslVersion.Name = "tslVersion";
            this.tslVersion.Size = new System.Drawing.Size(42, 17);
            this.tslVersion.Text = "Version";
            // 
            // tslCopyright
            // 
            this.tslCopyright.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslCopyright.Name = "tslCopyright";
            this.tslCopyright.Size = new System.Drawing.Size(363, 17);
            this.tslCopyright.Spring = true;
            this.tslCopyright.Text = "Copyright";
            this.tslCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // stsFooter
            // 
            this.stsFooter.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stsFooter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslCopyright,
            this.tslVersion,
            this.tslReleaseDate});
            this.stsFooter.Location = new System.Drawing.Point(0, 592);
            this.stsFooter.Name = "stsFooter";
            this.stsFooter.Size = new System.Drawing.Size(784, 22);
            this.stsFooter.TabIndex = 117;
            this.stsFooter.Text = "StatusStrip1";
            // 
            // tslReleaseDate
            // 
            this.tslReleaseDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tslReleaseDate.Name = "tslReleaseDate";
            this.tslReleaseDate.Size = new System.Drawing.Size(363, 17);
            this.tslReleaseDate.Spring = true;
            this.tslReleaseDate.Text = "Release Date";
            this.tslReleaseDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsp2
            // 
            this.tsp2.Name = "tsp2";
            this.tsp2.Size = new System.Drawing.Size(6, 45);
            // 
            // tlbActiveDirectory
            // 
            this.tlbActiveDirectory.AutoSize = false;
            this.tlbActiveDirectory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlbActiveDirectory.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tlbActiveDirectory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.cboFindItems,
            this.tsbFind,
            this.toolStripSeparator1,
            this.tsbSave,
            this.tsp2,
            this.tsbUserList,
            this.toolStripSeparator3,
            this.tsbFindDevice,
            this.tsbSettings,
            this.toolStripLabel1,
            this.cboDomain});
            this.tlbActiveDirectory.Location = new System.Drawing.Point(0, 0);
            this.tlbActiveDirectory.Name = "tlbActiveDirectory";
            this.tlbActiveDirectory.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.tlbActiveDirectory.Size = new System.Drawing.Size(784, 45);
            this.tlbActiveDirectory.TabIndex = 115;
            this.tlbActiveDirectory.Text = "tlbActiveDirectory";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(58, 42);
            this.toolStripLabel2.Text = "  Find Text";
            // 
            // cboFindItems
            // 
            this.cboFindItems.DropDownWidth = 200;
            this.cboFindItems.Name = "cboFindItems";
            this.cboFindItems.Size = new System.Drawing.Size(200, 45);
            this.cboFindItems.ToolTipText = "Search for user name ";
            this.cboFindItems.DropDownClosed += new System.EventHandler(this.cboFindItems_DropDownClosed);
            this.cboFindItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cboFindItems_KeyPress);
            // 
            // tsbFind
            // 
            this.tsbFind.Image = global::ADSearch.Properties.Resources.magnifier;
            this.tsbFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFind.Name = "tsbFind";
            this.tsbFind.Size = new System.Drawing.Size(55, 42);
            this.tsbFind.Text = "    &Find    ";
            this.tsbFind.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFind.ToolTipText = "Find  (Alt + F)";
            this.tsbFind.Click += new System.EventHandler(this.tsbFind_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // tsbSave
            // 
            this.tsbSave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbSave.Image = global::ADSearch.Properties.Resources.disk;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(53, 42);
            this.tsbSave.Text = "   &Save   ";
            this.tsbSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSave.ToolTipText = "Save file to desktop (Alt + S)";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbUserList
            // 
            this.tsbUserList.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbUserList.Image = global::ADSearch.Properties.Resources.user;
            this.tsbUserList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUserList.Name = "tsbUserList";
            this.tsbUserList.Size = new System.Drawing.Size(58, 42);
            this.tsbUserList.Text = " User List ";
            this.tsbUserList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbUserList.ToolTipText = "Show all users";
            this.tsbUserList.Click += new System.EventHandler(this.tsbUserList_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 45);
            // 
            // tsbFindDevice
            // 
            this.tsbFindDevice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbFindDevice.Image = global::ADSearch.Properties.Resources.server;
            this.tsbFindDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbFindDevice.Name = "tsbFindDevice";
            this.tsbFindDevice.Size = new System.Drawing.Size(52, 42);
            this.tsbFindDevice.Text = "  &Device ";
            this.tsbFindDevice.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbFindDevice.ToolTipText = "Find Device (Alt + D) cmd.exe nbtstat";
            this.tsbFindDevice.Visible = false;
            this.tsbFindDevice.Click += new System.EventHandler(this.tsbFindDevice_Click);
            // 
            // tsbSettings
            // 
            this.tsbSettings.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsbSettings.Image = global::ADSearch.Properties.Resources.cog;
            this.tsbSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(50, 42);
            this.tsbSettings.Text = "Settings";
            this.tsbSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(42, 42);
            this.toolStripLabel1.Text = "Domain";
            // 
            // cboDomain
            // 
            this.cboDomain.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDomain.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cboDomain.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDomain.Items.AddRange(new object[] {
            "DOMAIN1",
            "DOMAIN2"});
            this.cboDomain.Name = "cboDomain";
            this.cboDomain.Size = new System.Drawing.Size(121, 45);
            this.cboDomain.DropDownClosed += new System.EventHandler(this.cboDomain_DropDownClosed);
            // 
            // Explorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 614);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.stsFooter);
            this.Controls.Add(this.tlbActiveDirectory);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 650);
            this.Name = "Explorer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Panel1.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.spcActiveDirectory.Panel1.ResumeLayout(false);
            this.spcActiveDirectory.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spcActiveDirectory)).EndInit();
            this.spcActiveDirectory.ResumeLayout(false);
            this.stsFooter.ResumeLayout(false);
            this.stsFooter.PerformLayout();
            this.tlbActiveDirectory.ResumeLayout(false);
            this.tlbActiveDirectory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Panel Panel1;
        internal System.Windows.Forms.TableLayoutPanel tlpMain;
        internal System.Windows.Forms.SplitContainer spcActiveDirectory;
        internal System.Windows.Forms.TreeView tvwGroups;
        internal System.Windows.Forms.ImageList IltGroups;
        internal System.Windows.Forms.ListView lvwAttributes;
        internal System.Windows.Forms.ToolTip tltControlTips;
        internal System.Windows.Forms.Splitter Splitter1;
        internal System.Windows.Forms.ToolStripButton tsbUserList;
        internal System.Windows.Forms.ToolStripButton tsbFindDevice;
        internal System.Windows.Forms.ToolStripStatusLabel tslVersion;
        internal System.Windows.Forms.ToolStripStatusLabel tslCopyright;
        internal System.Windows.Forms.StatusStrip stsFooter;
        internal System.Windows.Forms.ToolStripStatusLabel tslReleaseDate;
        internal System.Windows.Forms.ToolStripSeparator tsp2;
        internal System.Windows.Forms.ToolStripButton tsbSave;
        internal System.Windows.Forms.ToolStrip tlbActiveDirectory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ToolStripComboBox cboDomain;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox cboFindItems;
        private System.Windows.Forms.ToolStripButton tsbFind;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

