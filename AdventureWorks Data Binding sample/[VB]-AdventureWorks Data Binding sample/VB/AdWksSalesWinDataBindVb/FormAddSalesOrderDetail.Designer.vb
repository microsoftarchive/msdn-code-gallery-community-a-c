<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAddSalesOrderDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim unitPriceDiscountLabel As System.Windows.Forms.Label
        Dim orderQtyLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.productsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.salesOrderDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.orderQtyTextBox = New System.Windows.Forms.TextBox
        Me.unitPriceDiscountTextBox = New System.Windows.Forms.TextBox
        Me.label2 = New System.Windows.Forms.Label
        Me.label1 = New System.Windows.Forms.Label
        Me.buttonCancelOrder = New System.Windows.Forms.Button
        Me.buttonAddNewDetail = New System.Windows.Forms.Button
        Me.dataGridViewProducts = New System.Windows.Forms.DataGridView
        Me.ProductID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn
        unitPriceDiscountLabel = New System.Windows.Forms.Label
        orderQtyLabel = New System.Windows.Forms.Label
        CType(Me.productsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.salesOrderDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridViewProducts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'unitPriceDiscountLabel
        '
        unitPriceDiscountLabel.AutoSize = True
        unitPriceDiscountLabel.Location = New System.Drawing.Point(135, 259)
        unitPriceDiscountLabel.Name = "unitPriceDiscountLabel"
        unitPriceDiscountLabel.Size = New System.Drawing.Size(85, 13)
        unitPriceDiscountLabel.TabIndex = 17
        unitPriceDiscountLabel.Text = "Discount Factor:"
        '
        'orderQtyLabel
        '
        orderQtyLabel.AutoSize = True
        orderQtyLabel.Location = New System.Drawing.Point(12, 259)
        orderQtyLabel.Name = "orderQtyLabel"
        orderQtyLabel.Size = New System.Drawing.Size(49, 13)
        orderQtyLabel.TabIndex = 18
        orderQtyLabel.Text = "Quantity:"
        '
        'productsBindingSource
        '
        Me.productsBindingSource.DataSource = GetType(AdWksSalesWinDataBindVb.Product)
        '
        'salesOrderDetailBindingSource
        '
        Me.salesOrderDetailBindingSource.DataSource = GetType(AdWksSalesWinDataBindVb.SalesOrderDetail)
        '
        'orderQtyTextBox
        '
        Me.orderQtyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.salesOrderDetailBindingSource, "OrderQty", True))
        Me.orderQtyTextBox.Location = New System.Drawing.Point(67, 256)
        Me.orderQtyTextBox.Name = "orderQtyTextBox"
        Me.orderQtyTextBox.Size = New System.Drawing.Size(53, 20)
        Me.orderQtyTextBox.TabIndex = 12
        '
        'unitPriceDiscountTextBox
        '
        Me.unitPriceDiscountTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.salesOrderDetailBindingSource, "UnitPriceDiscount", True, DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.unitPriceDiscountTextBox.Location = New System.Drawing.Point(223, 256)
        Me.unitPriceDiscountTextBox.Name = "unitPriceDiscountTextBox"
        Me.unitPriceDiscountTextBox.Size = New System.Drawing.Size(47, 20)
        Me.unitPriceDiscountTextBox.TabIndex = 13
        '
        'label2
        '
        Me.label2.AutoSize = True
        Me.label2.Location = New System.Drawing.Point(276, 259)
        Me.label2.Name = "label2"
        Me.label2.Size = New System.Drawing.Size(151, 13)
        Me.label2.TabIndex = 19
        Me.label2.Text = "(must be between 0.0 and 1.0)"
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(9, 12)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(80, 13)
        Me.label1.TabIndex = 14
        Me.label1.Text = "Select Product:"
        '
        'buttonCancelOrder
        '
        Me.buttonCancelOrder.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancelOrder.Location = New System.Drawing.Point(452, 257)
        Me.buttonCancelOrder.Name = "buttonCancelOrder"
        Me.buttonCancelOrder.Size = New System.Drawing.Size(75, 21)
        Me.buttonCancelOrder.TabIndex = 16
        Me.buttonCancelOrder.Text = "Cancel"
        Me.buttonCancelOrder.UseVisualStyleBackColor = True
        '
        'buttonAddNewDetail
        '
        Me.buttonAddNewDetail.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.buttonAddNewDetail.Enabled = False
        Me.buttonAddNewDetail.Location = New System.Drawing.Point(533, 256)
        Me.buttonAddNewDetail.Name = "buttonAddNewDetail"
        Me.buttonAddNewDetail.Size = New System.Drawing.Size(75, 21)
        Me.buttonAddNewDetail.TabIndex = 15
        Me.buttonAddNewDetail.Text = "Add Detail"
        Me.buttonAddNewDetail.UseVisualStyleBackColor = True
        '
        'dataGridViewProducts
        '
        Me.dataGridViewProducts.AllowUserToAddRows = False
        Me.dataGridViewProducts.AllowUserToDeleteRows = False
        Me.dataGridViewProducts.AutoGenerateColumns = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridViewProducts.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dataGridViewProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewProducts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ProductID, Me.dataGridViewTextBoxColumn2, Me.dataGridViewTextBoxColumn3, Me.dataGridViewTextBoxColumn4, Me.dataGridViewTextBoxColumn7, Me.dataGridViewTextBoxColumn8, Me.dataGridViewTextBoxColumn9, Me.dataGridViewTextBoxColumn12})
        Me.dataGridViewProducts.DataSource = Me.productsBindingSource
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dataGridViewProducts.DefaultCellStyle = DataGridViewCellStyle4
        Me.dataGridViewProducts.Location = New System.Drawing.Point(12, 28)
        Me.dataGridViewProducts.Name = "dataGridViewProducts"
        Me.dataGridViewProducts.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dataGridViewProducts.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dataGridViewProducts.Size = New System.Drawing.Size(596, 222)
        Me.dataGridViewProducts.TabIndex = 20
        '
        'ProductID
        '
        Me.ProductID.DataPropertyName = "ProductID"
        Me.ProductID.HeaderText = "Product ID"
        Me.ProductID.Name = "ProductID"
        Me.ProductID.ReadOnly = True
        '
        'dataGridViewTextBoxColumn2
        '
        Me.dataGridViewTextBoxColumn2.DataPropertyName = "Name"
        Me.dataGridViewTextBoxColumn2.HeaderText = "Name"
        Me.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2"
        Me.dataGridViewTextBoxColumn2.ReadOnly = True
        '
        'dataGridViewTextBoxColumn3
        '
        Me.dataGridViewTextBoxColumn3.DataPropertyName = "ProductNumber"
        Me.dataGridViewTextBoxColumn3.HeaderText = "ProductNumber"
        Me.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3"
        Me.dataGridViewTextBoxColumn3.ReadOnly = True
        '
        'dataGridViewTextBoxColumn4
        '
        Me.dataGridViewTextBoxColumn4.DataPropertyName = "Color"
        Me.dataGridViewTextBoxColumn4.HeaderText = "Color"
        Me.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4"
        Me.dataGridViewTextBoxColumn4.ReadOnly = True
        '
        'dataGridViewTextBoxColumn7
        '
        Me.dataGridViewTextBoxColumn7.DataPropertyName = "StandardCost"
        DataGridViewCellStyle2.Format = "C2"
        Me.dataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle2
        Me.dataGridViewTextBoxColumn7.HeaderText = "StandardCost"
        Me.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7"
        Me.dataGridViewTextBoxColumn7.ReadOnly = True
        '
        'dataGridViewTextBoxColumn8
        '
        Me.dataGridViewTextBoxColumn8.DataPropertyName = "ListPrice"
        DataGridViewCellStyle3.Format = "C2"
        Me.dataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle3
        Me.dataGridViewTextBoxColumn8.HeaderText = "ListPrice"
        Me.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8"
        Me.dataGridViewTextBoxColumn8.ReadOnly = True
        '
        'dataGridViewTextBoxColumn9
        '
        Me.dataGridViewTextBoxColumn9.DataPropertyName = "Size"
        Me.dataGridViewTextBoxColumn9.HeaderText = "Size"
        Me.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9"
        Me.dataGridViewTextBoxColumn9.ReadOnly = True
        '
        'dataGridViewTextBoxColumn12
        '
        Me.dataGridViewTextBoxColumn12.DataPropertyName = "Weight"
        Me.dataGridViewTextBoxColumn12.HeaderText = "Weight"
        Me.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12"
        Me.dataGridViewTextBoxColumn12.ReadOnly = True
        '
        'FormAddSalesOrderDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 289)
        Me.Controls.Add(Me.dataGridViewProducts)
        Me.Controls.Add(unitPriceDiscountLabel)
        Me.Controls.Add(Me.orderQtyTextBox)
        Me.Controls.Add(Me.unitPriceDiscountTextBox)
        Me.Controls.Add(Me.label2)
        Me.Controls.Add(orderQtyLabel)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.buttonCancelOrder)
        Me.Controls.Add(Me.buttonAddNewDetail)
        Me.Name = "FormAddSalesOrderDetail"
        Me.Text = "Add SalesOrderDetail"
        CType(Me.productsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.salesOrderDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridViewProducts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents productsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents salesOrderDetailBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents orderQtyTextBox As System.Windows.Forms.TextBox
    Private WithEvents unitPriceDiscountTextBox As System.Windows.Forms.TextBox
    Private WithEvents label2 As System.Windows.Forms.Label
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents buttonCancelOrder As System.Windows.Forms.Button
    Private WithEvents buttonAddNewDetail As System.Windows.Forms.Button
    Private WithEvents dataGridViewProducts As System.Windows.Forms.DataGridView
    Private WithEvents ProductID As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
