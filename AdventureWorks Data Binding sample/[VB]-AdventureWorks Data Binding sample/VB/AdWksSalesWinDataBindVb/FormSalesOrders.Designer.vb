<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesOrders
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtOrderNumber = New System.Windows.Forms.TextBox
        Me.bindingSourceOrders = New System.Windows.Forms.BindingSource(Me.components)
        Me.bindingSourceOrderDetails = New System.Windows.Forms.BindingSource(Me.components)
        Me.dataGridViewOrderDetails = New System.Windows.Forms.DataGridView
        Me.dataGridViewTextBoxColumn28 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn27 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn30 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn31 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn32 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewTextBoxColumn26 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dataGridViewSOHeader = New System.Windows.Forms.DataGridView
        Me.buttonDeleteDetail = New System.Windows.Forms.Button
        Me.label1 = New System.Windows.Forms.Label
        Me.buttonSaveChanges = New System.Windows.Forms.Button
        Me.buttonClose = New System.Windows.Forms.Button
        Me.buttonAddSalesOrder = New System.Windows.Forms.Button
        Me.label4 = New System.Windows.Forms.Label
        Me.label3 = New System.Windows.Forms.Label
        Me.buttonGetOrder = New System.Windows.Forms.Button
        Me.SalesOrderIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RevisionNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OrderDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DueDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.StatusDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.OnlineOrderFlagDataGridViewCheckBoxColumn = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.SalesOrderNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AccountNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CustomerIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesPersonIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TerritoryIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ShipMethodIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditCardIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CreditCardApprovalCodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CurrencyRateIDDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SubTotalDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TaxAmtDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FreightDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotalDueDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.CommentDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.RowguidDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ModifiedDateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AddressDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Address1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ContactDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.SalesOrderDetailDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.bindingSourceOrders, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.bindingSourceOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridViewOrderDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dataGridViewSOHeader, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtOrderNumber
        '
        Me.txtOrderNumber.Location = New System.Drawing.Point(91, 23)
        Me.txtOrderNumber.Name = "txtOrderNumber"
        Me.txtOrderNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtOrderNumber.TabIndex = 13
        Me.txtOrderNumber.Text = "Enter sales order #"
        '
        'bindingSourceOrders
        '
        Me.bindingSourceOrders.DataSource = GetType(AdWksSalesWinDataBindVb.SalesOrderHeader)
        '
        'bindingSourceOrderDetails
        '
        Me.bindingSourceOrderDetails.DataMember = "SalesOrderDetail"
        Me.bindingSourceOrderDetails.DataSource = Me.bindingSourceOrders
        '
        'dataGridViewOrderDetails
        '
        Me.dataGridViewOrderDetails.AllowUserToAddRows = False
        Me.dataGridViewOrderDetails.AllowUserToDeleteRows = False
        Me.dataGridViewOrderDetails.AutoGenerateColumns = False
        Me.dataGridViewOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewOrderDetails.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dataGridViewTextBoxColumn28, Me.dataGridViewTextBoxColumn27, Me.dataGridViewTextBoxColumn30, Me.dataGridViewTextBoxColumn31, Me.dataGridViewTextBoxColumn32, Me.dataGridViewTextBoxColumn26})
        Me.dataGridViewOrderDetails.DataSource = Me.bindingSourceOrderDetails
        Me.dataGridViewOrderDetails.Location = New System.Drawing.Point(17, 167)
        Me.dataGridViewOrderDetails.Name = "dataGridViewOrderDetails"
        Me.dataGridViewOrderDetails.Size = New System.Drawing.Size(778, 398)
        Me.dataGridViewOrderDetails.TabIndex = 21
        '
        'dataGridViewTextBoxColumn28
        '
        Me.dataGridViewTextBoxColumn28.DataPropertyName = "ProductID"
        Me.dataGridViewTextBoxColumn28.HeaderText = "Product ID"
        Me.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28"
        Me.dataGridViewTextBoxColumn28.ReadOnly = True
        '
        'dataGridViewTextBoxColumn27
        '
        Me.dataGridViewTextBoxColumn27.DataPropertyName = "OrderQty"
        Me.dataGridViewTextBoxColumn27.HeaderText = "Quantity"
        Me.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27"
        '
        'dataGridViewTextBoxColumn30
        '
        Me.dataGridViewTextBoxColumn30.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle4.Format = "C2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.dataGridViewTextBoxColumn30.DefaultCellStyle = DataGridViewCellStyle4
        Me.dataGridViewTextBoxColumn30.HeaderText = "Price Each"
        Me.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30"
        Me.dataGridViewTextBoxColumn30.ReadOnly = True
        '
        'dataGridViewTextBoxColumn31
        '
        Me.dataGridViewTextBoxColumn31.DataPropertyName = "UnitPriceDiscount"
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.dataGridViewTextBoxColumn31.DefaultCellStyle = DataGridViewCellStyle5
        Me.dataGridViewTextBoxColumn31.HeaderText = "Discount Each"
        Me.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31"
        '
        'dataGridViewTextBoxColumn32
        '
        Me.dataGridViewTextBoxColumn32.DataPropertyName = "LineTotal"
        DataGridViewCellStyle6.Format = "C2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.dataGridViewTextBoxColumn32.DefaultCellStyle = DataGridViewCellStyle6
        Me.dataGridViewTextBoxColumn32.HeaderText = "Line Total"
        Me.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32"
        Me.dataGridViewTextBoxColumn32.ReadOnly = True
        '
        'dataGridViewTextBoxColumn26
        '
        Me.dataGridViewTextBoxColumn26.DataPropertyName = "CarrierTrackingNumber"
        Me.dataGridViewTextBoxColumn26.HeaderText = "Tracking #"
        Me.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26"
        '
        'dataGridViewSOHeader
        '
        Me.dataGridViewSOHeader.AllowUserToAddRows = False
        Me.dataGridViewSOHeader.AllowUserToDeleteRows = False
        Me.dataGridViewSOHeader.AutoGenerateColumns = False
        Me.dataGridViewSOHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataGridViewSOHeader.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SalesOrderIDDataGridViewTextBoxColumn, Me.RevisionNumberDataGridViewTextBoxColumn, Me.OrderDateDataGridViewTextBoxColumn, Me.DueDateDataGridViewTextBoxColumn, Me.ShipDateDataGridViewTextBoxColumn, Me.StatusDataGridViewTextBoxColumn, Me.OnlineOrderFlagDataGridViewCheckBoxColumn, Me.SalesOrderNumberDataGridViewTextBoxColumn, Me.PurchaseOrderNumberDataGridViewTextBoxColumn, Me.AccountNumberDataGridViewTextBoxColumn, Me.CustomerIDDataGridViewTextBoxColumn, Me.SalesPersonIDDataGridViewTextBoxColumn, Me.TerritoryIDDataGridViewTextBoxColumn, Me.ShipMethodIDDataGridViewTextBoxColumn, Me.CreditCardIDDataGridViewTextBoxColumn, Me.CreditCardApprovalCodeDataGridViewTextBoxColumn, Me.CurrencyRateIDDataGridViewTextBoxColumn, Me.SubTotalDataGridViewTextBoxColumn, Me.TaxAmtDataGridViewTextBoxColumn, Me.FreightDataGridViewTextBoxColumn, Me.TotalDueDataGridViewTextBoxColumn, Me.CommentDataGridViewTextBoxColumn, Me.RowguidDataGridViewTextBoxColumn, Me.ModifiedDateDataGridViewTextBoxColumn, Me.AddressDataGridViewTextBoxColumn, Me.Address1DataGridViewTextBoxColumn, Me.ContactDataGridViewTextBoxColumn, Me.SalesOrderDetailDataGridViewTextBoxColumn})
        Me.dataGridViewSOHeader.DataSource = Me.bindingSourceOrders
        Me.dataGridViewSOHeader.Location = New System.Drawing.Point(17, 80)
        Me.dataGridViewSOHeader.Name = "dataGridViewSOHeader"
        Me.dataGridViewSOHeader.Size = New System.Drawing.Size(771, 55)
        Me.dataGridViewSOHeader.TabIndex = 22
        '
        'buttonDeleteDetail
        '
        Me.buttonDeleteDetail.Enabled = False
        Me.buttonDeleteDetail.Location = New System.Drawing.Point(675, 48)
        Me.buttonDeleteDetail.Name = "buttonDeleteDetail"
        Me.buttonDeleteDetail.Size = New System.Drawing.Size(121, 20)
        Me.buttonDeleteDetail.TabIndex = 23
        Me.buttonDeleteDetail.Text = "Delete Selected Item"
        Me.buttonDeleteDetail.UseVisualStyleBackColor = True
        '
        'label1
        '
        Me.label1.AutoSize = True
        Me.label1.Location = New System.Drawing.Point(14, 26)
        Me.label1.Name = "label1"
        Me.label1.Size = New System.Drawing.Size(76, 13)
        Me.label1.TabIndex = 20
        Me.label1.Text = "Order Number:"
        '
        'buttonSaveChanges
        '
        Me.buttonSaveChanges.Location = New System.Drawing.Point(587, 571)
        Me.buttonSaveChanges.Name = "buttonSaveChanges"
        Me.buttonSaveChanges.Size = New System.Drawing.Size(101, 20)
        Me.buttonSaveChanges.TabIndex = 19
        Me.buttonSaveChanges.Text = "Save Changes"
        Me.buttonSaveChanges.UseVisualStyleBackColor = True
        '
        'buttonClose
        '
        Me.buttonClose.Location = New System.Drawing.Point(694, 571)
        Me.buttonClose.Name = "buttonClose"
        Me.buttonClose.Size = New System.Drawing.Size(101, 20)
        Me.buttonClose.TabIndex = 18
        Me.buttonClose.Text = "Close Form"
        Me.buttonClose.UseVisualStyleBackColor = True
        '
        'buttonAddSalesOrder
        '
        Me.buttonAddSalesOrder.Enabled = False
        Me.buttonAddSalesOrder.Location = New System.Drawing.Point(549, 48)
        Me.buttonAddSalesOrder.Name = "buttonAddSalesOrder"
        Me.buttonAddSalesOrder.Size = New System.Drawing.Size(120, 20)
        Me.buttonAddSalesOrder.TabIndex = 17
        Me.buttonAddSalesOrder.Text = "Add Detail to Order"
        Me.buttonAddSalesOrder.UseVisualStyleBackColor = True
        '
        'label4
        '
        Me.label4.AutoSize = True
        Me.label4.Location = New System.Drawing.Point(14, 151)
        Me.label4.Name = "label4"
        Me.label4.Size = New System.Drawing.Size(97, 13)
        Me.label4.TabIndex = 16
        Me.label4.Text = "Sales Order Details"
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(14, 64)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(62, 13)
        Me.label3.TabIndex = 15
        Me.label3.Text = "Sales Order"
        '
        'buttonGetOrder
        '
        Me.buttonGetOrder.Enabled = False
        Me.buttonGetOrder.Location = New System.Drawing.Point(197, 23)
        Me.buttonGetOrder.Name = "buttonGetOrder"
        Me.buttonGetOrder.Size = New System.Drawing.Size(99, 20)
        Me.buttonGetOrder.TabIndex = 14
        Me.buttonGetOrder.Text = "Get Sales Order"
        Me.buttonGetOrder.UseVisualStyleBackColor = True
        '
        'SalesOrderIDDataGridViewTextBoxColumn
        '
        Me.SalesOrderIDDataGridViewTextBoxColumn.DataPropertyName = "SalesOrderID"
        Me.SalesOrderIDDataGridViewTextBoxColumn.HeaderText = "SalesOrderID"
        Me.SalesOrderIDDataGridViewTextBoxColumn.Name = "SalesOrderIDDataGridViewTextBoxColumn"
        '
        'RevisionNumberDataGridViewTextBoxColumn
        '
        Me.RevisionNumberDataGridViewTextBoxColumn.DataPropertyName = "RevisionNumber"
        Me.RevisionNumberDataGridViewTextBoxColumn.HeaderText = "RevisionNumber"
        Me.RevisionNumberDataGridViewTextBoxColumn.Name = "RevisionNumberDataGridViewTextBoxColumn"
        '
        'OrderDateDataGridViewTextBoxColumn
        '
        Me.OrderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate"
        Me.OrderDateDataGridViewTextBoxColumn.HeaderText = "OrderDate"
        Me.OrderDateDataGridViewTextBoxColumn.Name = "OrderDateDataGridViewTextBoxColumn"
        '
        'DueDateDataGridViewTextBoxColumn
        '
        Me.DueDateDataGridViewTextBoxColumn.DataPropertyName = "DueDate"
        Me.DueDateDataGridViewTextBoxColumn.HeaderText = "DueDate"
        Me.DueDateDataGridViewTextBoxColumn.Name = "DueDateDataGridViewTextBoxColumn"
        '
        'ShipDateDataGridViewTextBoxColumn
        '
        Me.ShipDateDataGridViewTextBoxColumn.DataPropertyName = "ShipDate"
        Me.ShipDateDataGridViewTextBoxColumn.HeaderText = "ShipDate"
        Me.ShipDateDataGridViewTextBoxColumn.Name = "ShipDateDataGridViewTextBoxColumn"
        '
        'StatusDataGridViewTextBoxColumn
        '
        Me.StatusDataGridViewTextBoxColumn.DataPropertyName = "Status"
        Me.StatusDataGridViewTextBoxColumn.HeaderText = "Status"
        Me.StatusDataGridViewTextBoxColumn.Name = "StatusDataGridViewTextBoxColumn"
        '
        'OnlineOrderFlagDataGridViewCheckBoxColumn
        '
        Me.OnlineOrderFlagDataGridViewCheckBoxColumn.DataPropertyName = "OnlineOrderFlag"
        Me.OnlineOrderFlagDataGridViewCheckBoxColumn.HeaderText = "OnlineOrderFlag"
        Me.OnlineOrderFlagDataGridViewCheckBoxColumn.Name = "OnlineOrderFlagDataGridViewCheckBoxColumn"
        '
        'SalesOrderNumberDataGridViewTextBoxColumn
        '
        Me.SalesOrderNumberDataGridViewTextBoxColumn.DataPropertyName = "SalesOrderNumber"
        Me.SalesOrderNumberDataGridViewTextBoxColumn.HeaderText = "SalesOrderNumber"
        Me.SalesOrderNumberDataGridViewTextBoxColumn.Name = "SalesOrderNumberDataGridViewTextBoxColumn"
        '
        'PurchaseOrderNumberDataGridViewTextBoxColumn
        '
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn.DataPropertyName = "PurchaseOrderNumber"
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn.HeaderText = "PurchaseOrderNumber"
        Me.PurchaseOrderNumberDataGridViewTextBoxColumn.Name = "PurchaseOrderNumberDataGridViewTextBoxColumn"
        '
        'AccountNumberDataGridViewTextBoxColumn
        '
        Me.AccountNumberDataGridViewTextBoxColumn.DataPropertyName = "AccountNumber"
        Me.AccountNumberDataGridViewTextBoxColumn.HeaderText = "AccountNumber"
        Me.AccountNumberDataGridViewTextBoxColumn.Name = "AccountNumberDataGridViewTextBoxColumn"
        '
        'CustomerIDDataGridViewTextBoxColumn
        '
        Me.CustomerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID"
        Me.CustomerIDDataGridViewTextBoxColumn.Name = "CustomerIDDataGridViewTextBoxColumn"
        '
        'SalesPersonIDDataGridViewTextBoxColumn
        '
        Me.SalesPersonIDDataGridViewTextBoxColumn.DataPropertyName = "SalesPersonID"
        Me.SalesPersonIDDataGridViewTextBoxColumn.HeaderText = "SalesPersonID"
        Me.SalesPersonIDDataGridViewTextBoxColumn.Name = "SalesPersonIDDataGridViewTextBoxColumn"
        '
        'TerritoryIDDataGridViewTextBoxColumn
        '
        Me.TerritoryIDDataGridViewTextBoxColumn.DataPropertyName = "TerritoryID"
        Me.TerritoryIDDataGridViewTextBoxColumn.HeaderText = "TerritoryID"
        Me.TerritoryIDDataGridViewTextBoxColumn.Name = "TerritoryIDDataGridViewTextBoxColumn"
        '
        'ShipMethodIDDataGridViewTextBoxColumn
        '
        Me.ShipMethodIDDataGridViewTextBoxColumn.DataPropertyName = "ShipMethodID"
        Me.ShipMethodIDDataGridViewTextBoxColumn.HeaderText = "ShipMethodID"
        Me.ShipMethodIDDataGridViewTextBoxColumn.Name = "ShipMethodIDDataGridViewTextBoxColumn"
        '
        'CreditCardIDDataGridViewTextBoxColumn
        '
        Me.CreditCardIDDataGridViewTextBoxColumn.DataPropertyName = "CreditCardID"
        Me.CreditCardIDDataGridViewTextBoxColumn.HeaderText = "CreditCardID"
        Me.CreditCardIDDataGridViewTextBoxColumn.Name = "CreditCardIDDataGridViewTextBoxColumn"
        '
        'CreditCardApprovalCodeDataGridViewTextBoxColumn
        '
        Me.CreditCardApprovalCodeDataGridViewTextBoxColumn.DataPropertyName = "CreditCardApprovalCode"
        Me.CreditCardApprovalCodeDataGridViewTextBoxColumn.HeaderText = "CreditCardApprovalCode"
        Me.CreditCardApprovalCodeDataGridViewTextBoxColumn.Name = "CreditCardApprovalCodeDataGridViewTextBoxColumn"
        '
        'CurrencyRateIDDataGridViewTextBoxColumn
        '
        Me.CurrencyRateIDDataGridViewTextBoxColumn.DataPropertyName = "CurrencyRateID"
        Me.CurrencyRateIDDataGridViewTextBoxColumn.HeaderText = "CurrencyRateID"
        Me.CurrencyRateIDDataGridViewTextBoxColumn.Name = "CurrencyRateIDDataGridViewTextBoxColumn"
        '
        'SubTotalDataGridViewTextBoxColumn
        '
        Me.SubTotalDataGridViewTextBoxColumn.DataPropertyName = "SubTotal"
        Me.SubTotalDataGridViewTextBoxColumn.HeaderText = "SubTotal"
        Me.SubTotalDataGridViewTextBoxColumn.Name = "SubTotalDataGridViewTextBoxColumn"
        '
        'TaxAmtDataGridViewTextBoxColumn
        '
        Me.TaxAmtDataGridViewTextBoxColumn.DataPropertyName = "TaxAmt"
        Me.TaxAmtDataGridViewTextBoxColumn.HeaderText = "TaxAmt"
        Me.TaxAmtDataGridViewTextBoxColumn.Name = "TaxAmtDataGridViewTextBoxColumn"
        '
        'FreightDataGridViewTextBoxColumn
        '
        Me.FreightDataGridViewTextBoxColumn.DataPropertyName = "Freight"
        Me.FreightDataGridViewTextBoxColumn.HeaderText = "Freight"
        Me.FreightDataGridViewTextBoxColumn.Name = "FreightDataGridViewTextBoxColumn"
        '
        'TotalDueDataGridViewTextBoxColumn
        '
        Me.TotalDueDataGridViewTextBoxColumn.DataPropertyName = "TotalDue"
        Me.TotalDueDataGridViewTextBoxColumn.HeaderText = "TotalDue"
        Me.TotalDueDataGridViewTextBoxColumn.Name = "TotalDueDataGridViewTextBoxColumn"
        '
        'CommentDataGridViewTextBoxColumn
        '
        Me.CommentDataGridViewTextBoxColumn.DataPropertyName = "Comment"
        Me.CommentDataGridViewTextBoxColumn.HeaderText = "Comment"
        Me.CommentDataGridViewTextBoxColumn.Name = "CommentDataGridViewTextBoxColumn"
        '
        'RowguidDataGridViewTextBoxColumn
        '
        Me.RowguidDataGridViewTextBoxColumn.DataPropertyName = "rowguid"
        Me.RowguidDataGridViewTextBoxColumn.HeaderText = "rowguid"
        Me.RowguidDataGridViewTextBoxColumn.Name = "RowguidDataGridViewTextBoxColumn"
        '
        'ModifiedDateDataGridViewTextBoxColumn
        '
        Me.ModifiedDateDataGridViewTextBoxColumn.DataPropertyName = "ModifiedDate"
        Me.ModifiedDateDataGridViewTextBoxColumn.HeaderText = "ModifiedDate"
        Me.ModifiedDateDataGridViewTextBoxColumn.Name = "ModifiedDateDataGridViewTextBoxColumn"
        '
        'AddressDataGridViewTextBoxColumn
        '
        Me.AddressDataGridViewTextBoxColumn.DataPropertyName = "Address"
        Me.AddressDataGridViewTextBoxColumn.HeaderText = "Address"
        Me.AddressDataGridViewTextBoxColumn.Name = "AddressDataGridViewTextBoxColumn"
        '
        'Address1DataGridViewTextBoxColumn
        '
        Me.Address1DataGridViewTextBoxColumn.DataPropertyName = "Address1"
        Me.Address1DataGridViewTextBoxColumn.HeaderText = "Address1"
        Me.Address1DataGridViewTextBoxColumn.Name = "Address1DataGridViewTextBoxColumn"
        '
        'ContactDataGridViewTextBoxColumn
        '
        Me.ContactDataGridViewTextBoxColumn.DataPropertyName = "Contact"
        Me.ContactDataGridViewTextBoxColumn.HeaderText = "Contact"
        Me.ContactDataGridViewTextBoxColumn.Name = "ContactDataGridViewTextBoxColumn"
        '
        'SalesOrderDetailDataGridViewTextBoxColumn
        '
        Me.SalesOrderDetailDataGridViewTextBoxColumn.DataPropertyName = "SalesOrderDetail"
        Me.SalesOrderDetailDataGridViewTextBoxColumn.HeaderText = "SalesOrderDetail"
        Me.SalesOrderDetailDataGridViewTextBoxColumn.Name = "SalesOrderDetailDataGridViewTextBoxColumn"
        '
        'FormSalesOrders
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(810, 614)
        Me.Controls.Add(Me.txtOrderNumber)
        Me.Controls.Add(Me.dataGridViewOrderDetails)
        Me.Controls.Add(Me.dataGridViewSOHeader)
        Me.Controls.Add(Me.buttonDeleteDetail)
        Me.Controls.Add(Me.label1)
        Me.Controls.Add(Me.buttonSaveChanges)
        Me.Controls.Add(Me.buttonClose)
        Me.Controls.Add(Me.buttonAddSalesOrder)
        Me.Controls.Add(Me.label4)
        Me.Controls.Add(Me.label3)
        Me.Controls.Add(Me.buttonGetOrder)
        Me.Name = "FormSalesOrders"
        Me.Text = "Adventureworks Sales Orders"
        CType(Me.bindingSourceOrders, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.bindingSourceOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridViewOrderDetails, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dataGridViewSOHeader, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents txtOrderNumber As System.Windows.Forms.TextBox
    Private WithEvents bindingSourceOrders As System.Windows.Forms.BindingSource
    Private WithEvents bindingSourceOrderDetails As System.Windows.Forms.BindingSource
    Private WithEvents dataGridViewOrderDetails As System.Windows.Forms.DataGridView
    Private WithEvents dataGridViewTextBoxColumn28 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn27 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn30 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn31 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn32 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewTextBoxColumn26 As System.Windows.Forms.DataGridViewTextBoxColumn
    Private WithEvents dataGridViewSOHeader As System.Windows.Forms.DataGridView
    Private WithEvents buttonDeleteDetail As System.Windows.Forms.Button
    Private WithEvents label1 As System.Windows.Forms.Label
    Private WithEvents buttonSaveChanges As System.Windows.Forms.Button
    Private WithEvents buttonClose As System.Windows.Forms.Button
    Private WithEvents buttonAddSalesOrder As System.Windows.Forms.Button
    Private WithEvents label4 As System.Windows.Forms.Label
    Private WithEvents label3 As System.Windows.Forms.Label
    Private WithEvents buttonGetOrder As System.Windows.Forms.Button
    Friend WithEvents SalesOrderIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RevisionNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OrderDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DueDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StatusDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OnlineOrderFlagDataGridViewCheckBoxColumn As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents SalesOrderNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PurchaseOrderNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccountNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CustomerIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesPersonIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TerritoryIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShipMethodIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditCardIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditCardApprovalCodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CurrencyRateIDDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SubTotalDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TaxAmtDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FreightDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TotalDueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CommentDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RowguidDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ModifiedDateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Address1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContactDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SalesOrderDetailDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
