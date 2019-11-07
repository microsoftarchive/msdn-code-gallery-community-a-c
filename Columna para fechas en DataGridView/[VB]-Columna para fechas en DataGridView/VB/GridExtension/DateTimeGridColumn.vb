Imports System.Windows.Forms
Imports System.Globalization

Public Class DateTimeGridColumn
    Inherits DataGridViewColumn

    Public Sub New()
        MyBase.New(New DateTimeCell())
    End Sub

    Public Overrides Property CellTemplate As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(value As DataGridViewCell)
            If value IsNot Nothing AndAlso _
                Not value.GetType().IsAssignableFrom(GetType(DateTimeCell)) Then
                Throw New InvalidCastException("Debe especificar una instancia de DateTimeCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property
End Class

Public Class DateTimeCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        MyBase.New()
    End Sub

    Public Overrides ReadOnly Property EditType As Type
        Get
            Return GetType(DateTimeEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType As Type
        Get
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue As Object
        Get
            Dim defaultValue As Object = MyBase.DefaultNewRowValue
            If TypeOf defaultValue Is DateTime Then
                Return defaultValue
            Else
                Return DateTime.Now
            End If
        End Get
    End Property

    Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, _
                                                  dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As DateTimeEditingControl = CType(DataGridView.EditingControl, DateTimeEditingControl)
        Try
            If Me.Value = Nothing Then
                ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
            Else
                ctl.Value = CType(Me.Value, DateTime)
            End If
        Catch ex As Exception
            ctl.Value = CType(Me.DefaultNewRowValue, DateTime)
        End Try

        If dataGridViewCellStyle.Format.Length = 1 Then
            Dim patterns As String() = DateTimeFormatInfo.CurrentInfo.GetAllDateTimePatterns( _
                dataGridViewCellStyle.Format.ToCharArray()(0))
            If patterns.Length > 0 Then
                ctl.CustomFormat = patterns(0).ToString()
            Else
                ctl.CustomFormat = dataGridViewCellStyle.Format
            End If
        Else
            ctl.CustomFormat = dataGridViewCellStyle.Format
        End If
    End Sub

End Class

Class DateTimeEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private grid As DataGridView
    Private valChanged As Boolean

    Public Sub New()
        Me.Format = DateTimePickerFormat.Custom
    End Sub

    Protected Overrides Sub OnValueChanged(eventargs As EventArgs)
        MyBase.OnValueChanged(eventargs)
        SendToGridValueChanged()
    End Sub

    Private Sub SendToGridValueChanged()
        valChanged = True
        If grid IsNot Nothing Then
            grid.NotifyCurrentCellDirty(True)
        End If
    End Sub

#Region "Miembros de IDataGridViewEditingControl"

    Public Sub ApplyCellStyleToEditingControl(dataGridViewCellStyle As DataGridViewCellStyle) _
        Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor
    End Sub

    Public Property EditingControlDataGridView As DataGridView _
        Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return grid
        End Get
        Set(value As DataGridView)
            grid = value
        End Set
    End Property

    Public Property EditingControlFormattedValue As Object _
        Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Value.ToString(Me.CustomFormat)
        End Get
        Set(value As Object)
            Try
                Me.Value = DateTime.Parse(CType(value, String))
            Catch ex As Exception
                Me.Value = DateTime.Now
            End Try
            SendToGridValueChanged()
        End Set
    End Property

    Public Property EditingControlRowIndex As Integer _
        Implements IDataGridViewEditingControl.EditingControlRowIndex

    Public Property EditingControlValueChanged As Boolean _
        Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valChanged
        End Get
        Set(value As Boolean)
            valChanged = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(keyData As Keys, dataGridViewWantsInputKey As Boolean) As Boolean _
        Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case keyData And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, _
                Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select
    End Function

    Public ReadOnly Property EditingPanelCursor As Cursor _
        Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Public Function GetEditingControlFormattedValue(context As DataGridViewDataErrorContexts) As Object _
        Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return EditingControlFormattedValue
    End Function

    Public Sub PrepareEditingControlForEdit(selectAll As Boolean) _
        Implements IDataGridViewEditingControl.PrepareEditingControlForEdit

    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange As Boolean _
        Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

#End Region

End Class