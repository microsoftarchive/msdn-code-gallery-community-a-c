namespace AdWksSalesWinDataBind
{
    partial class FormAddSalesOrderDetail
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
            System.Windows.Forms.Label unitPriceDiscountLabel;
            System.Windows.Forms.Label orderQtyLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonAddNewDetail = new System.Windows.Forms.Button();
            this.buttonCancelOrder = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.productsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewProducts = new System.Windows.Forms.DataGridView();
            this.salesOrderDetailBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.unitPriceDiscountTextBox = new System.Windows.Forms.TextBox();
            this.orderQtyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            unitPriceDiscountLabel = new System.Windows.Forms.Label();
            orderQtyLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesOrderDetailBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // unitPriceDiscountLabel
            // 
            unitPriceDiscountLabel.AutoSize = true;
            unitPriceDiscountLabel.Location = new System.Drawing.Point(138, 255);
            unitPriceDiscountLabel.Name = "unitPriceDiscountLabel";
            unitPriceDiscountLabel.Size = new System.Drawing.Size(85, 13);
            unitPriceDiscountLabel.TabIndex = 8;
            unitPriceDiscountLabel.Text = "Discount Factor:";
            // 
            // orderQtyLabel
            // 
            orderQtyLabel.AutoSize = true;
            orderQtyLabel.Location = new System.Drawing.Point(15, 255);
            orderQtyLabel.Name = "orderQtyLabel";
            orderQtyLabel.Size = new System.Drawing.Size(49, 13);
            orderQtyLabel.TabIndex = 9;
            orderQtyLabel.Text = "Quantity:";
            // 
            // buttonAddNewDetail
            // 
            this.buttonAddNewDetail.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonAddNewDetail.Enabled = false;
            this.buttonAddNewDetail.Location = new System.Drawing.Point(536, 252);
            this.buttonAddNewDetail.Name = "buttonAddNewDetail";
            this.buttonAddNewDetail.Size = new System.Drawing.Size(75, 21);
            this.buttonAddNewDetail.TabIndex = 3;
            this.buttonAddNewDetail.Text = "Add Detail";
            this.buttonAddNewDetail.UseVisualStyleBackColor = true;
            this.buttonAddNewDetail.Click += new System.EventHandler(this.buttonAcceptNewOrder_Click);
            // 
            // buttonCancelOrder
            // 
            this.buttonCancelOrder.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancelOrder.Location = new System.Drawing.Point(455, 253);
            this.buttonCancelOrder.Name = "buttonCancelOrder";
            this.buttonCancelOrder.Size = new System.Drawing.Size(75, 21);
            this.buttonCancelOrder.TabIndex = 4;
            this.buttonCancelOrder.Text = "Cancel";
            this.buttonCancelOrder.UseVisualStyleBackColor = true;
            this.buttonCancelOrder.Click += new System.EventHandler(this.buttonCancelOrder_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Product:";
            // 
            // productsBindingSource
            // 
            this.productsBindingSource.DataSource = typeof(AdWksSalesWinDataBind.Product);
            // 
            // dataGridViewProducts
            // 
            this.dataGridViewProducts.AllowUserToAddRows = false;
            this.dataGridViewProducts.AllowUserToDeleteRows = false;
            this.dataGridViewProducts.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn12});
            this.dataGridViewProducts.DataSource = this.productsBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewProducts.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewProducts.Location = new System.Drawing.Point(15, 24);
            this.dataGridViewProducts.Name = "dataGridViewProducts";
            this.dataGridViewProducts.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewProducts.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewProducts.Size = new System.Drawing.Size(596, 222);
            this.dataGridViewProducts.TabIndex = 0;
            this.dataGridViewProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewProducts_CellClick);
            // 
            // salesOrderDetailBindingSource
            // 
            this.salesOrderDetailBindingSource.DataSource = typeof(AdWksSalesWinDataBind.SalesOrderDetail);
            // 
            // unitPriceDiscountTextBox
            // 
            this.unitPriceDiscountTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salesOrderDetailBindingSource, "UnitPriceDiscount", true, System.Windows.Forms.DataSourceUpdateMode.OnValidation, null, "N2"));
            this.unitPriceDiscountTextBox.Location = new System.Drawing.Point(226, 252);
            this.unitPriceDiscountTextBox.Name = "unitPriceDiscountTextBox";
            this.unitPriceDiscountTextBox.Size = new System.Drawing.Size(47, 20);
            this.unitPriceDiscountTextBox.TabIndex = 2;
            // 
            // orderQtyTextBox
            // 
            this.orderQtyTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.salesOrderDetailBindingSource, "OrderQty", true));
            this.orderQtyTextBox.Location = new System.Drawing.Point(70, 252);
            this.orderQtyTextBox.Name = "orderQtyTextBox";
            this.orderQtyTextBox.Size = new System.Drawing.Size(53, 20);
            this.orderQtyTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(279, 255);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "(must be between 0.0 and 1.0)";
            // 
            // ProductID
            // 
            this.ProductID.DataPropertyName = "ProductID";
            this.ProductID.HeaderText = "Product ID";
            this.ProductID.Name = "ProductID";
            this.ProductID.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Name";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "ProductNumber";
            this.dataGridViewTextBoxColumn3.HeaderText = "ProductNumber";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Color";
            this.dataGridViewTextBoxColumn4.HeaderText = "Color";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "StandardCost";
            dataGridViewCellStyle2.Format = "C2";
            this.dataGridViewTextBoxColumn7.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn7.HeaderText = "StandardCost";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "ListPrice";
            dataGridViewCellStyle3.Format = "C2";
            this.dataGridViewTextBoxColumn8.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn8.HeaderText = "ListPrice";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Size";
            this.dataGridViewTextBoxColumn9.HeaderText = "Size";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "Weight";
            this.dataGridViewTextBoxColumn12.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // FormAddSalesOrderDetail
            // 
            this.AcceptButton = this.buttonAddNewDetail;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancelOrder;
            this.ClientSize = new System.Drawing.Size(631, 295);
            this.Controls.Add(this.label2);
            this.Controls.Add(orderQtyLabel);
            this.Controls.Add(this.orderQtyTextBox);
            this.Controls.Add(unitPriceDiscountLabel);
            this.Controls.Add(this.unitPriceDiscountTextBox);
            this.Controls.Add(this.dataGridViewProducts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancelOrder);
            this.Controls.Add(this.buttonAddNewDetail);
            this.Name = "FormAddSalesOrderDetail";
            this.Text = "Add SalesOrderDetail";
            this.Load += new System.EventHandler(this.formAddSalesOrderDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.productsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salesOrderDetailBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonAddNewDetail;
        private System.Windows.Forms.Button buttonCancelOrder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource productsBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewProducts;
        private System.Windows.Forms.BindingSource salesOrderDetailBindingSource;
        private System.Windows.Forms.TextBox unitPriceDiscountTextBox;
        private System.Windows.Forms.TextBox orderQtyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
    }
}