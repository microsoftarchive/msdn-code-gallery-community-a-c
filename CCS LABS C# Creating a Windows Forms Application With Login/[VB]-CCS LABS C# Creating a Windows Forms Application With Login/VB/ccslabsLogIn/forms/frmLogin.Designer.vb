Namespace ccslabsLogIn.forms
	Partial Public Class frmLogin
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.label1 = New System.Windows.Forms.Label()
			Me.tbUsername = New System.Windows.Forms.TextBox()
			Me.tbPassword = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.llRegister = New System.Windows.Forms.LinkLabel()
			Me.btnLogin = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.applicationDataSet_Renamed = New ccslabsLogIn.ApplicationDataSet()
			Me.usersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.usersTableAdapter = New ccslabsLogIn.ApplicationDataSetTableAdapters.UsersTableAdapter()
			Me.tableAdapterManager = New ccslabsLogIn.ApplicationDataSetTableAdapters.TableAdapterManager()
			DirectCast(Me.applicationDataSet_Renamed, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.usersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(13, 13)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(55, 13)
			Me.label1.TabIndex = 0
			Me.label1.Text = "Username"
			' 
			' tbUsername
			' 
			Me.tbUsername.Location = New System.Drawing.Point(16, 30)
			Me.tbUsername.Name = "tbUsername"
			Me.tbUsername.Size = New System.Drawing.Size(311, 20)
			Me.tbUsername.TabIndex = 1
			' 
			' tbPassword
			' 
			Me.tbPassword.Location = New System.Drawing.Point(15, 70)
			Me.tbPassword.Name = "tbPassword"
			Me.tbPassword.PasswordChar = "*"c
			Me.tbPassword.Size = New System.Drawing.Size(311, 20)
			Me.tbPassword.TabIndex = 3
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(12, 53)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(53, 13)
			Me.label2.TabIndex = 2
			Me.label2.Text = "Password"
			' 
			' llRegister
			' 
			Me.llRegister.AutoSize = True
			Me.llRegister.Location = New System.Drawing.Point(15, 107)
			Me.llRegister.Name = "llRegister"
			Me.llRegister.Size = New System.Drawing.Size(46, 13)
			Me.llRegister.TabIndex = 4
			Me.llRegister.TabStop = True
			Me.llRegister.Text = "Register"
'			Me.llRegister.LinkClicked += New System.Windows.Forms.LinkLabelLinkClickedEventHandler(Me.llRegister_LinkClicked)
			' 
			' btnLogin
			' 
			Me.btnLogin.Location = New System.Drawing.Point(252, 107)
			Me.btnLogin.Name = "btnLogin"
			Me.btnLogin.Size = New System.Drawing.Size(75, 23)
			Me.btnLogin.TabIndex = 5
			Me.btnLogin.Text = "Login"
			Me.btnLogin.UseVisualStyleBackColor = True
'			Me.btnLogin.Click += New System.EventHandler(Me.btnLogin_Click)
			' 
			' btnCancel
			' 
			Me.btnCancel.Location = New System.Drawing.Point(171, 107)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 6
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' applicationDataSet
			' 
			Me.applicationDataSet_Renamed.DataSetName = "ApplicationDataSet"
			Me.applicationDataSet_Renamed.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
			' 
			' usersBindingSource
			' 
			Me.usersBindingSource.DataMember = "Users"
			Me.usersBindingSource.DataSource = Me.applicationDataSet_Renamed
			' 
			' usersTableAdapter
			' 
			Me.usersTableAdapter.ClearBeforeFill = True
			' 
			' tableAdapterManager
			' 
			Me.tableAdapterManager.BackupDataSetBeforeUpdate = False
			Me.tableAdapterManager.UpdateOrder = ccslabsLogIn.ApplicationDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
			Me.tableAdapterManager.UsersTableAdapter = Me.usersTableAdapter
			' 
			' frmLogin
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(351, 144)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.btnLogin)
			Me.Controls.Add(Me.llRegister)
			Me.Controls.Add(Me.tbPassword)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.tbUsername)
			Me.Controls.Add(Me.label1)
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
			Me.Name = "frmLogin"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
			Me.Text = "Login"
'			Me.Load += New System.EventHandler(Me.frmLogin_Load)
			DirectCast(Me.applicationDataSet_Renamed, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.usersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private label1 As System.Windows.Forms.Label
		Private tbUsername As System.Windows.Forms.TextBox
		Private tbPassword As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private WithEvents llRegister As System.Windows.Forms.LinkLabel
		Private WithEvents btnLogin As System.Windows.Forms.Button
		Private WithEvents btnCancel As System.Windows.Forms.Button
'INSTANT VB NOTE: The variable applicationDataSet was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Private applicationDataSet_Renamed As ApplicationDataSet
		Private usersBindingSource As System.Windows.Forms.BindingSource
		Private usersTableAdapter As ApplicationDataSetTableAdapters.UsersTableAdapter
		Private tableAdapterManager As ApplicationDataSetTableAdapters.TableAdapterManager
	End Class
End Namespace