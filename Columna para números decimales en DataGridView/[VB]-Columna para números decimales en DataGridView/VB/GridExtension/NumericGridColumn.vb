Imports System.ComponentModel
Imports System.Globalization
Imports System.Windows.Forms

Public Class NumericGridColumn
    Inherits DataGridViewColumn

    Private _numberFormat As NumberFormatInfo
    Private _decimalSeparator As String
    Private _decimalDigits As Integer

    Public Sub New()
        MyBase.New(New NumericGridCell())
    End Sub

    Public Overrides Property CellTemplate As DataGridViewCell
        Get
            Return MyBase.CellTemplate
        End Get
        Set(value As DataGridViewCell)
            If value IsNot Nothing AndAlso
                Not value.GetType().IsAssignableFrom(GetType(NumericGridCell)) Then
                Throw New InvalidCastException("Debe especificar una instancia de NumericGridCell")
            End If
            MyBase.CellTemplate = value
        End Set
    End Property

    <Category("Appearance")>
    Public Property DecimalSeparator As String
        Get
            If String.IsNullOrEmpty(_decimalSeparator) Then
                Return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalSeparator
            Else
                Return _decimalSeparator
            End If
        End Get
        Set(ByVal value As String)
            If value.Length <> 1 Then
                Throw New ArgumentException("El separador decimal debe ser un único caracter")
            End If
            _decimalSeparator = value
        End Set
    End Property

    <Category("Appearance")>
    Public Property DecimalDigits As Integer
        Get
            If _decimalDigits < 0 Then
                Return CultureInfo.CurrentUICulture.NumberFormat.NumberDecimalDigits
            Else
                Return _decimalDigits
            End If
        End Get
        Set(ByVal value As Integer)
            _decimalDigits = value
        End Set
    End Property

    Friend ReadOnly Property NumberFormat As NumberFormatInfo
        Get
            If _numberFormat Is Nothing Then _numberFormat = New NumberFormatInfo()
            _numberFormat.NumberDecimalSeparator = DecimalSeparator
            _numberFormat.NumberDecimalDigits = DecimalDigits
            Return _numberFormat
        End Get
    End Property

    Public Overrides Function Clone() As Object
        Dim newColumn As NumericGridColumn = MyBase.Clone()
        newColumn.DecimalSeparator = DecimalSeparator
        newColumn.DecimalDigits = DecimalDigits
        Return newColumn
    End Function

End Class

Public Class NumericGridCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        MyBase.New()
    End Sub

    Private ReadOnly Property NumberFormat As NumberFormatInfo
        Get
            Return CType(OwningColumn, NumericGridColumn).NumberFormat
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType As Type
        Get
            Return GetType(Decimal?)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue As Object
        Get
            Dim defaultValue As Object = MyBase.DefaultNewRowValue
            If TypeOf defaultValue Is Decimal Then
                Return defaultValue
            Else
                Return Nothing
            End If
        End Get
    End Property

    Public Overrides Sub InitializeEditingControl(rowIndex As Integer, initialFormattedValue As Object, dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As Control = DataGridView.EditingControl
        AddHandler ctl.KeyPress, AddressOf NumericCell_KeyPress
    End Sub

    Private Sub NumericCell_KeyPress(sender As Object, e As KeyPressEventArgs)
        Dim currentCell As DataGridViewCell =
            CType(sender, IDataGridViewEditingControl).EditingControlDataGridView.CurrentCell
        If Not TypeOf currentCell Is NumericGridCell Then Return

        Dim ctl As DataGridViewTextBoxEditingControl = CType(sender, DataGridViewTextBoxEditingControl)
        If Char.IsDigit(e.KeyChar) Then
            Dim separatorPosition As Integer = ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator)
            If separatorPosition >= 0 AndAlso ctl.SelectionStart > separatorPosition Then
                Dim currentDecimals = ctl.Text.Length - separatorPosition _
                    - NumberFormat.NumberDecimalSeparator.Length - ctl.SelectionLength
                If currentDecimals >= NumberFormat.NumberDecimalDigits Then
                    e.Handled = True
                End If
            End If
        ElseIf e.KeyChar.ToString().Equals(NumberFormat.NumberDecimalSeparator) Then
            e.Handled = ctl.Text.IndexOf(NumberFormat.NumberDecimalSeparator) >= 0
        Else
            e.Handled = Not Char.IsControl(e.KeyChar)
        End If
    End Sub

    Public Overrides Function GetInheritedStyle(inheritedCellStyle As DataGridViewCellStyle, rowIndex As Integer, includeColors As Boolean) As DataGridViewCellStyle
        Dim style As DataGridViewCellStyle = MyBase.GetInheritedStyle(inheritedCellStyle, rowIndex, includeColors)
        style.FormatProvider = NumberFormat
        Return style
    End Function

    Protected Overrides Function GetFormattedValue(value As Object, rowIndex As Integer, ByRef cellStyle As DataGridViewCellStyle, valueTypeConverter As TypeConverter, formattedValueTypeConverter As TypeConverter, context As DataGridViewDataErrorContexts) As Object
        If value Is Nothing Then
            Return Nothing
        Else
            Return CType(value, Decimal).ToString(cellStyle.FormatProvider)
        End If
    End Function

End Class
