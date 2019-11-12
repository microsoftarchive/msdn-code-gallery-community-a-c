Imports System.ComponentModel
Imports System.Collections.ObjectModel
Imports System.Runtime.InteropServices

Public Class CheckedCombobox
    Inherits ComboBox

    Public Event ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs)

    Dim n As nWindow = Nothing


    Public Overrides Property Text() As String
        Get
            Return String.Join(", ", Me._checkedItems.ToArray)
        End Get
        Set(ByVal value As String)

        End Set
    End Property

    Public Sub clearAllChecks()
        _isCheckedItem.Clear()
        _isCheckedItem.AddRange(Enumerable.Repeat(False, MyBase.Items.Count).ToArray())
        _checkedItems.Clear()
        _checkedIndices.Clear()
        MyBase.Refresh()
    End Sub

    Public Sub setCheckRange(ByVal which As IEnumerable(Of Integer), ByVal value As Boolean)
        For x As Integer = 0 To which.Count - 1
            _isCheckedItem(which(x)) = value
            If _checkedIndices.Contains(which(x)) Then
                If Not value Then
                    _checkedIndices.Remove(which(x))
                    _checkedItems.Remove(_items(which(x)))
                End If
            Else
                _checkedIndices.Add(which(x))
                _checkedItems.Add(_items(which(x)))
            End If
        Next
        MyBase.Refresh()
        MyBase.SelectedIndex = MyBase.SelectedIndex
    End Sub

    <Browsable(False)> _
    Public Overloads ReadOnly Property Items() As ComboBox.ObjectCollection
        Get
            Return MyBase.Items
        End Get
    End Property

    Private _items As New ObservableCollection(Of String)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property CheckedComboboxItems() As ObservableCollection(Of String)
        Get
            Return _items
        End Get
    End Property

    Private _isCheckedItem As New List(Of Boolean)
    Private ReadOnly Property isCheckedItem() As List(Of Boolean)
        Get
            Return _isCheckedItem
        End Get
    End Property

    Private _checkedItems As New List(Of String)
    Public ReadOnly Property checkedItems() As List(Of String)
        Get
            Return _checkedItems
        End Get
    End Property

    Private _checkedIndices As New List(Of Integer)
    Public ReadOnly Property checkedIndices() As List(Of Integer)
        Get
            Return _checkedIndices
        End Get
    End Property

    Public Sub New()
        Me.DrawMode = Windows.Forms.DrawMode.OwnerDrawVariable
        AddHandler CheckedComboboxItems.CollectionChanged, AddressOf itemsChanged
    End Sub

    Private Sub itemsChanged(ByVal sender As Object, ByVal e As System.Collections.Specialized.NotifyCollectionChangedEventArgs)
        If e.Action = Specialized.NotifyCollectionChangedAction.Add Then
            If e.NewStartingIndex = isCheckedItem.Count Then
                isCheckedItem.Add(False)
                MyBase.Items.Add(e.NewItems(0))
            Else
                isCheckedItem.Insert(e.NewStartingIndex, False)
                MyBase.Items.Insert(e.NewStartingIndex, e.NewItems(0))
            End If
        ElseIf e.Action = Specialized.NotifyCollectionChangedAction.Remove Then
            isCheckedItem.RemoveAt(e.OldStartingIndex)
            MyBase.Items.RemoveAt(e.OldStartingIndex)
        ElseIf e.Action = Specialized.NotifyCollectionChangedAction.Move Then
            Dim tempBoolean As Boolean = isCheckedItem(e.OldStartingIndex)
            Dim tempList As New List(Of Boolean)(isCheckedItem)
            Dim tempItem As Object = MyBase.Items(e.OldStartingIndex)
            tempList.RemoveAt(e.OldStartingIndex)
            MyBase.Items.RemoveAt(e.OldStartingIndex)
            tempList.Insert(e.NewStartingIndex, tempBoolean)
            MyBase.Items.Insert(e.NewStartingIndex, tempItem)
            _isCheckedItem = tempList
        End If
        Me.Invalidate()
    End Sub

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        Dim items() As String = MyBase.Items.Cast(Of String).ToArray
        If Not items.SequenceEqual(Me.CheckedComboboxItems) Then
            MyBase.Items.Clear()
            MyBase.Items.AddRange(Me.CheckedComboboxItems.ToArray)
        End If
        isCheckedItem.AddRange(Enumerable.Repeat(False, MyBase.Items.Count))
        MyBase.SelectedIndex = 0
    End Sub

    Protected Overrides Sub OnDrawItem(ByVal e As System.Windows.Forms.DrawItemEventArgs)
        If e.Index = -1 Then Return
        Dim itemText As String = MyBase.GetItemText(MyBase.Items(e.Index))
        e.DrawBackground()
        Dim p As Point = e.Bounds.Location
        p.Offset(1, 1)

        If e.Index = MyBase.SelectedIndex AndAlso (e.State And DrawItemState.ComboBoxEdit) = DrawItemState.ComboBoxEdit Then
            itemText = String.Join(", ", Me.checkedItems.ToArray)
        Else
            CheckBoxRenderer.DrawCheckBox(e.Graphics, p, If(isCheckedItem(e.Index), VisualStyles.CheckBoxState.CheckedNormal, VisualStyles.CheckBoxState.UncheckedNormal))
            p.Offset(12, 0)
        End If

        e.Graphics.DrawString(itemText, e.Font, New SolidBrush(e.ForeColor), p.X, p.Y)
        If e.State = DrawItemState.Selected Then
            e.DrawFocusRectangle()
        End If
        MyBase.OnDrawItem(e)
    End Sub

    Private Const WM_CTLCOLORLISTBOX As Integer = &H134

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        MyBase.WndProc(m)
        If m.Msg = WM_CTLCOLORLISTBOX Then
            If n Is Nothing Then
                n = New nWindow(Me)
                n.AssignHandle(m.LParam)
                AddHandler n.checkedChanged, AddressOf checkedChanged
            End If
        End If
    End Sub

    Private Sub checkedChanged(ByVal index As Integer)
        Dim oldValue As CheckState = If(isCheckedItem(index), CheckState.Checked, CheckState.Unchecked)
        Dim newValue As CheckState = If(isCheckedItem(index), CheckState.Unchecked, CheckState.Checked)
        isCheckedItem(index) = Not isCheckedItem(index)
        Me.Invalidate()
        checkedIndices.Clear()
        checkedIndices.AddRange(Enumerable.Range(0, isCheckedItem.Count).Where(Function(x) isCheckedItem(x)).Select(Function(x) x).ToArray)
        checkedItems.Clear()
        checkedItems.AddRange(Enumerable.Range(0, isCheckedItem.Count).Where(Function(x) isCheckedItem(x)).Select(Function(x) MyBase.GetItemText(MyBase.Items(x))).ToArray)
        RaiseEvent ItemCheck(Me, New ItemCheckEventArgs(index, newValue, oldValue))
    End Sub

End Class

Public Class nWindow
    Inherits NativeWindow

#Region "     API"

    Public Declare Function GetScrollInfo Lib "user32" Alias "GetScrollInfo" (ByVal hWnd As IntPtr, _
                        ByVal n As Integer, <MarshalAs(UnmanagedType.Struct)> ByRef lpScrollInfo As SCROLLINFO) As Integer

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure SCROLLINFO
        Public cbSize As Integer
        Public fMask As Integer
        Public nMin As Integer
        Public nMax As Integer
        Public nPage As Integer
        Public nPos As Integer
        Public nTrackPos As Integer
    End Structure

    Private Const SB_ENDSCROLL As Integer = 8

    Const SBS_VERT As Integer = 1
    Const SIF_RANGE As Integer = 1
    Const SIF_PAGE As Integer = 2
    Const SIF_POS As Integer = 4
    Const SIF_TRACKPOS As Integer = 10
    Const SIF_ALL As Integer = (SIF_RANGE Or SIF_PAGE Or SIF_POS Or SIF_TRACKPOS)

    Private Const WM_LBUTTONDOWN As Integer = &H201

#End Region

    Private combo As CheckedCombobox

    Public Event checkedChanged(ByVal index As Integer)

    Public Sub New(ByVal cb As CheckedCombobox)
        combo = cb
    End Sub

    Private lastIndex As Integer = -1

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If m.Msg = WM_LBUTTONDOWN Then
            Dim newIndex As Integer = getIndex(m)

            If newIndex <= combo.Items.Count - 1 And newIndex >= 0 Then
                lastIndex = newIndex
                If New Point(m.LParam.ToInt32).X >= 1 And New Point(m.LParam.ToInt32).X <= 11 Then
                    RaiseEvent checkedChanged(lastIndex)
                    Return
                End If
            End If
        End If
        MyBase.WndProc(m)
    End Sub

    Private Function getIndex(ByVal m As Message) As Integer
        Dim itemHeight As Integer = combo.GetItemHeight(0)
        Dim si As New SCROLLINFO
        si.fMask = SIF_ALL
        si.cbSize = Marshal.SizeOf(si)
        GetScrollInfo(Me.Handle, SBS_VERT, si)

        Dim newIndex As Integer = si.nPos + (New Point(m.LParam.ToInt32).Y \ itemHeight)

        Return newIndex
    End Function

End Class

