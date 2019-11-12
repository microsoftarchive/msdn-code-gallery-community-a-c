Namespace ccslabsLogIn.forms
	Partial Public Class frmRegister
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
			Me.tbPassword = New System.Windows.Forms.TextBox()
			Me.label2 = New System.Windows.Forms.Label()
			Me.tbUsername = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.tbRepeatPassword = New System.Windows.Forms.TextBox()
			Me.label3 = New System.Windows.Forms.Label()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.btnRegister = New System.Windows.Forms.Button()
			Me.applicationDataSet_Renamed = New ccslabsLogIn.ApplicationDataSet()
			Me.usersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
			Me.usersTableAdapter = New ccslabsLogIn.ApplicationDataSetTableAdapters.UsersTableAdapter()
			Me.tableAdapterManager = New ccslabsLogIn.ApplicationDataSetTableAdapters.TableAdapterManager()
			DirectCast(Me.applicationDataSet_Renamed, System.ComponentModel.ISupportInitialize).BeginInit()
			DirectCast(Me.usersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' tbPassword
			' 
			Me.tbPassword.Location = New System.Drawing.Point(14, 66)
			Me.tbPassword.Name = "tbPassword"
			Me.tbPassword.PasswordChar = "*"c
			Me.tbPassword.Size = New System.Drawing.Size(311, 20)
			Me.tbPassword.TabIndex = 7
			' 
			' label2
			' 
			Me.label2.AutoSize = True
			Me.label2.Location = New System.Drawing.Point(11, 49)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(53, 13)
			Me.label2.TabIndex = 6
			Me.label2.Text = "Password"
			' 
			' tbUsername
			' 
			Me.tbUsername.Location = New System.Drawing.Point(15, 26)
			Me.tbUsername.Name = "tbUsername"
			Me.tbUsername.Size = New System.Drawing.Size(311, 20)
			Me.tbUsername.TabIndex = 5
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 9)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(55, 13)
			Me.label1.TabIndex = 4
			Me.label1.Text = "Username"
			' 
			' tbRepeatPassword
			' 
			Me.tbRepeatPassword.Location = New System.Drawing.Point(17, 106)
			Me.tbRepeatPassword.Name = "tbRepeatPassword"
			Me.tbRepeatPassword.PasswordChar = "*"c
			Me.tbRepeatPassword.Size = New System.Drawing.Size(311, 20)
			Me.tbRepeatPassword.TabIndex = 9
			' 
			' label3
			' 
			Me.label3.AutoSize = True
			Me.label3.Location = New System.Drawing.Point(14, 89)
			Me.label3.Name = "label3"
			Me.label3.Size = New System.Drawing.Size(91, 13)
			Me.label3.TabIndex = 8
			Me.label3.Text = "Repeat Password"
			' 
			' btnCancel
			' 
			Me.btnCancel.Location = New System.Drawing.Point(12, 132)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(75, 23)
			Me.btnCancel.TabIndex = 10
			Me.btnCancel.Text = "Cancel"
			Me.btnCancel.UseVisualStyleBackColor = True
'			Me.btnCancel.Click += New System.EventHandler(Me.btnCancel_Click)
			' 
			' btnRegister
			' 
			Me.btnRegister.Location = New System.Drawing.Point(251, 132)
			Me.btnRegister.Name = "btnRegister"
			Me.btnRegister.Size = New System.Drawing.Size(75, 23)
			Me.btnRegister.TabIndex = 11
			Me.btnRegister.Text = "Register"
			Me.btnRegister.UseVisualStyleBackColor = True
'			Me.btnRegister.Click += New System.EventHandler(Me.btnRegister_Click)
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
			' frmRegister
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(349, 163)
			Me.Controls.Add(Me.btnRegister)
			Me.Controls.Add(Me.btnCancel)
			Me.Controls.Add(Me.tbRepeatPassword)
			Me.Controls.Add(Me.label3)
			Me.Controls.Add(Me.tbPassword)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.tbUsername)
			Me.Controls.Add(Me.label1)
			Me.Name = "frmRegister"
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "frmRegister"
'			Me.Load += New System.EventHandler(Me.frmRegister_Load)
			DirectCast(Me.applicationDataSet_Renamed, System.ComponentModel.ISupportInitialize).EndInit()
			DirectCast(Me.usersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private tbPassword As System.Windows.Forms.TextBox
		Private label2 As System.Windows.Forms.Label
		Private tbUsername As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private tbRepeatPassword As System.Windows.Forms.TextBox
		Private label3 As System.Windows.Forms.Label
		Private WithEvents btnCancel As System.Windows.Forms.Button
		Private WithEvents btnRegister As System.Windows.Forms.Button
'INSTANT VB NOTE: The variable applicationDataSet was renamed since it may cause conflicts with calls to static members of the user-defined type with this name:
		Private applicationDataSet_Renamed As ApplicationDataSet
		Private usersBindingSource As System.Windows.Forms.BindingSource
		Private usersTableAdapter As ApplicationDataSetTableAdapters.UsersTableAdapter
		Private tableAdapterManager As ApplicationDataSetTableAdapters.TableAdapterManager
	End Class
End Namespace