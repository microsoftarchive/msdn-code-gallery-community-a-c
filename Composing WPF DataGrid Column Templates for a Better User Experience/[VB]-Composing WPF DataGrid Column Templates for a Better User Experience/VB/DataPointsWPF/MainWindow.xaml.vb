Partial Public Class MainWindow
    Inherits Window
    Private _dataPointsSchedulingEntities As DataPointsSchedulingEntities
    Private _taskList As List(Of String)
    Private _statusList As List(Of String)
    Private Const DateScheduledColumnIndex As Integer = 1
    Private Const TaskColumnIndex As Integer = 2

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Function GetScheduleItemsQuery() As ObjectQuery(Of ScheduleItem)
        'Auto-generated and then modified (added orderedby linq metthod and then the cast in the return)
        Dim scheduleItemsQuery =
            _dataPointsSchedulingEntities.ScheduleItems.OrderBy(Function(d) d.DateScheduled)
        'Returns an ObjectQuery.
        Return TryCast(scheduleItemsQuery, ObjectQuery(Of ScheduleItem))
    End Function

    Private Sub Window_Loaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        'Auto-generated except I've cleaned things up a little
        InitializeLists()
        _dataPointsSchedulingEntities = New DataPointsSchedulingEntities
        'Load data into ScheduleItems. You can modify this code as needed.
        Dim scheduleItemsViewSource = (CType(FindResource("scheduleItemsViewSource"), CollectionViewSource))
        Dim scheduleItemsQuery = GetScheduleItemsQuery()
        scheduleItemsViewSource.Source = scheduleItemsQuery.Execute(MergeOption.AppendOnly)
    End Sub

    Private Sub InitializeLists()
        _taskList = New List(Of String) From {"Buff",
                                              "Clean",
                                              "Flush",
                                              "Polish",
                                              "Rotate",
                                              "Sand",
                                              "Scour",
                                              "Scrape",
                                              "Shampoo",
                                              "Wipe"}
        _statusList = New List(Of String) From {"Failed", "Redo", "Success"}
        Dim taskViewSource = (CType(FindResource("taskViewSource"), CollectionViewSource))
        taskViewSource.Source = _taskList
        Dim statusViewSource = (CType(FindResource("statusViewSource"), CollectionViewSource))
        statusViewSource.Source = _statusList
    End Sub

    Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
        _dataPointsSchedulingEntities.SaveChanges()
    End Sub

    Private Sub Window_Unloaded(ByVal sender As Object, ByVal e As RoutedEventArgs)
        _dataPointsSchedulingEntities.Dispose()
    End Sub

    Private Sub scheduleItemsDataGrid_SelectedCellsChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectedCellsChangedEventArgs)

        If e.AddedCells.Count = 0 Then
            Return
        End If
        Dim currentCell = e.AddedCells(0)
        Dim header As String = CStr(currentCell.Column.Header)

        If currentCell.Column Is scheduleItemsDataGrid.Columns(DateScheduledColumnIndex) OrElse
            currentCell.Column Is scheduleItemsDataGrid.Columns(TaskColumnIndex) Then
            scheduleItemsDataGrid.BeginEdit()

        End If
    End Sub
End Class
