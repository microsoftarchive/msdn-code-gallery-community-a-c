namespace AdWksSalesWinDataBind
{
    partial class FormSalesOrders
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.buttonGetOrder = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonAddSalesOrder = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonSaveChanges = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonDeleteDetail = new System.Windows.Forms.Button();
            this.dataGridViewSOHeader = new System.Windows.Forms.DataGridView();
            this.bindingSourceOrders = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceOrderDetails = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewOrderDetails = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSOHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOrderDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Location = new System.Drawing.Point(89, 14);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(100, 20);
            this.txtOrderNumber.TabIndex = 0;
            this.txtOrderNumber.Text = "Enter sales order #";
            this.txtOrderNumber.TextChanged += new System.EventHandler(this.txtOrderNumber_TextChanged);
            this.txtOrderNumber.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtOrderNumber_PreviewKeyDown);
            // 
            // buttonGetOrder
            // 
            this.buttonGetOrder.Enabled = false;
            this.buttonGetOrder.Location = new System.Drawing.Point(195, 14);
            this.buttonGetOrder.Name = "buttonGetOrder";
            this.buttonGetOrder.Size = new System.Drawing.Size(99, 20);
            this.buttonGetOrder.TabIndex = 1;
            this.buttonGetOrder.Text = "Get Sales Order";
            this.buttonGetOrder.UseVisualStyleBackColor = true;
            this.buttonGetOrder.Click += new System.EventHandler(this.buttonGetOrder_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Sales Order";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(97, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Sales Order Details";
            // 
            // buttonAddSalesOrder
            // 
            this.buttonAddSalesOrder.Enabled = false;
            this.buttonAddSalesOrder.Location = new System.Drawing.Point(547, 39);
            this.buttonAddSalesOrder.Name = "buttonAddSalesOrder";
            this.buttonAddSalesOrder.Size = new System.Drawing.Size(120, 20);
            this.buttonAddSalesOrder.TabIndex = 8;
            this.buttonAddSalesOrder.Text = "Add Detail to Order";
            this.buttonAddSalesOrder.UseVisualStyleBackColor = true;
            this.buttonAddSalesOrder.Click += new System.EventHandler(this.buttonAddSalesOrder_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(692, 562);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(101, 20);
            this.buttonClose.TabIndex = 9;
            this.buttonClose.Text = "Close Form";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonSaveChanges
            // 
            this.buttonSaveChanges.Location = new System.Drawing.Point(585, 562);
            this.buttonSaveChanges.Name = "buttonSaveChanges";
            this.buttonSaveChanges.Size = new System.Drawing.Size(101, 20);
            this.buttonSaveChanges.TabIndex = 10;
            this.buttonSaveChanges.Text = "Save Changes";
            this.buttonSaveChanges.UseVisualStyleBackColor = true;
            this.buttonSaveChanges.Click += new System.EventHandler(this.buttonSaveChanges_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Order Number:";
            // 
            // buttonDeleteDetail
            // 
            this.buttonDeleteDetail.Enabled = false;
            this.buttonDeleteDetail.Location = new System.Drawing.Point(673, 39);
            this.buttonDeleteDetail.Name = "buttonDeleteDetail";
            this.buttonDeleteDetail.Size = new System.Drawing.Size(121, 20);
            this.buttonDeleteDetail.TabIndex = 12;
            this.buttonDeleteDetail.Text = "Delete Selected Item";
            this.buttonDeleteDetail.UseVisualStyleBackColor = true;
            this.buttonDeleteDetail.Click += new System.EventHandler(this.buttonDeleteDetail_Click);
            // 
            // dataGridViewSOHeader
            // 
            this.dataGridViewSOHeader.AllowUserToAddRows = false;
            this.dataGridViewSOHeader.AllowUserToDeleteRows = false;
            this.dataGridViewSOHeader.AutoGenerateColumns = false;
            this.dataGridViewSOHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSOHeader.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20,
            this.dataGridViewTextBoxColumn21});
            this.dataGridViewSOHeader.DataSource = this.bindingSourceOrders;
            this.dataGridViewSOHeader.Location = new System.Drawing.Point(15, 71);
            this.dataGridViewSOHeader.Name = "dataGridViewSOHeader";
            this.dataGridViewSOHeader.Size = new System.Drawing.Size(771, 55);
            this.dataGridViewSOHeader.TabIndex = 12;
            // 
            // bindingSourceOrders
            // 
            this.bindingSourceOrders.DataSource = typeof(AdWksSalesWinDataBind.SalesOrderHeader);
            // 
            // bindingSourceOrderDetails
            // 
            this.bindingSourceOrderDetails.DataMember = "SalesOrderDetail";
            this.bindingSourceOrderDetails.DataSource = this.bindingSourceOrders;
            // 
            // dataGridViewOrderDetails
            // 
            this.dataGridViewOrderDetails.AllowUserToAddRows = false;
            this.dataGridViewOrderDetails.AllowUserToDeleteRows = false;
            this.dataGridViewOrderDetails.AutoGenerateColumns = false;
            this.dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrderDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn26});
            this.dataGridViewOrderDetails.DataSource = this.bindingSourceOrderDetails;
            this.dataGridViewOrderDetails.Location = new System.Drawing.Point(15, 158);
            this.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails";
            this.dataGridViewOrderDetails.Size = new System.Drawing.Size(778, 398);
            this.dataGridViewOrderDetails.TabIndex = 12;
            this.dataGridViewOrderDetails.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridViewOrderDetails_DataError);
            this.dataGridViewOrderDetails.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewOrderDetails_RowHeaderMouseClick);
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "ProductID";
            this.dataGridViewTextBoxColumn28.HeaderText = "Product ID";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "OrderQty";
            this.dataGridViewTextBoxColumn27.HeaderText = "Quantity";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "UnitPrice";
            dataGridViewCellStyle5.Format = "C2";
            dataGridViewCellStyle5.NullValue = null;
            this.dataGridViewTextBoxColumn30.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewTextBoxColumn30.HeaderText = "Price Each";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "UnitPriceDiscount";
            dataGridViewCellStyle6.Format = "N2";
            dataGridViewCellStyle6.NullValue = null;
            this.dataGridViewTextBoxColumn31.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewTextBoxColumn31.HeaderText = "Discount Each";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "LineTotal";
            dataGridViewCellStyle7.Format = "C2";
            dataGridViewCellStyle7.NullValue = null;
            this.dataGridViewTextBoxColumn32.DefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewTextBoxColumn32.HeaderText = "Line Total";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "CarrierTrackingNumber";
            this.dataGridViewTextBoxColumn26.HeaderText = "Tracking #";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "OrderDate";
            this.dataGridViewTextBoxColumn3.HeaderText = "Order Date";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DueDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Due Date";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ShipDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "Ship Date";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Status";
            this.dataGridViewTextBoxColumn6.HeaderText = "Status";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "PurchaseOrderNumber";
            this.dataGridViewTextBoxColumn8.HeaderText = "PO Number";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "AccountNumber";
            this.dataGridViewTextBoxColumn9.HeaderText = "Account";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "SubTotal";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.dataGridViewTextBoxColumn17.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewTextBoxColumn17.HeaderText = "Sub Total";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            this.dataGridViewTextBoxColumn17.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "TaxAmt";
            dataGridViewCellStyle2.Format = "C2";
            this.dataGridViewTextBoxColumn18.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn18.HeaderText = "Tax ";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            this.dataGridViewTextBoxColumn18.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Freight";
            dataGridViewCellStyle3.Format = "C2";
            this.dataGridViewTextBoxColumn19.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn19.HeaderText = "Freight";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            this.dataGridViewTextBoxColumn19.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "TotalDue";
            dataGridViewCellStyle4.Format = "C2";
            this.dataGridViewTextBoxColumn20.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn20.HeaderText = "Order Total";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn21.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            // 
            // FormSalesOrders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 594);
            this.Controls.Add(this.dataGridViewOrderDetails);
            this.Controls.Add(this.dataGridViewSOHeader);
            this.Controls.Add(this.buttonDeleteDetail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonSaveChanges);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAddSalesOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonGetOrder);
            this.Controls.Add(this.txtOrderNumber);
            this.Name = "FormSalesOrders";
            this.Text = "Adventureworks Sales Orders";
            this.Enter += new System.EventHandler(this.buttonGetOrder_Click);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSOHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceOrderDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrderDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Button buttonGetOrder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonAddSalesOrder;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonSaveChanges;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonDeleteDetail;
        private System.Windows.Forms.BindingSource bindingSourceOrders;
        private System.Windows.Forms.DataGridView dataGridViewSOHeader;
        private System.Windows.Forms.BindingSource bindingSourceOrderDetails;
        private System.Windows.Forms.DataGridView dataGridViewOrderDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
    }
}

