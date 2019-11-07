using System.Collections.Generic;
using System.Data.Objects;
using System.Windows;
using System.Windows.Data;
using System.Linq;
using System.Windows.Input;

namespace DataPointsWPF
{

  public partial class MainWindow : Window
  {
    DataPointsSchedulingEntities _dataPointsSchedulingEntities;
    private List<string> _taskList;
    private List<string> _statusList;
    const int DateScheduledColumnIndex = 1;
    const int TaskColumnIndex = 2;
    public MainWindow()
    {
      InitializeComponent();
    }

    private ObjectQuery<ScheduleItem> GetScheduleItemsQuery()
    {
      //Auto-generated and then modified (added orderedby linq metthod and then the cast in the return)
      var scheduleItemsQuery = _dataPointsSchedulingEntities.ScheduleItems.OrderBy(d => d.DateScheduled);
      // Returns an ObjectQuery.
      return scheduleItemsQuery as ObjectQuery<ScheduleItem>;
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      //Auto-generated except I've cleaned things up a little
      InitializeLists();
      _dataPointsSchedulingEntities = new DataPointsSchedulingEntities();
      // Load data into ScheduleItems. You can modify this code as needed.
      var scheduleItemsViewSource = ((CollectionViewSource)(FindResource("scheduleItemsViewSource")));
      var scheduleItemsQuery = GetScheduleItemsQuery();
      scheduleItemsViewSource.Source = scheduleItemsQuery.Execute(MergeOption.AppendOnly);
    }

    private void InitializeLists()
    {
      _taskList = new List<string> { "Buff", "Clean", "Flush", "Polish", "Rotate", "Sand", "Scour", "Scrape", "Shampoo", "Wipe" };
      _statusList = new List<string> { "Failed", "Redo", "Success" };
      var taskViewSource = ((CollectionViewSource)(FindResource("taskViewSource")));
      taskViewSource.Source = _taskList;
      var statusViewSource = ((CollectionViewSource)(FindResource("statusViewSource")));
      statusViewSource.Source = _statusList;
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
      _dataPointsSchedulingEntities.SaveChanges();
    }

    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {
      _dataPointsSchedulingEntities.Dispose();
    }

    private void scheduleItemsDataGrid_SelectedCellsChanged(object sender, System.Windows.Controls.SelectedCellsChangedEventArgs e)
    {

      if (e.AddedCells.Count == 0) return;
      var currentCell = e.AddedCells[0];
      string header = (string)currentCell.Column.Header;

      if (currentCell.Column == scheduleItemsDataGrid.Columns[DateScheduledColumnIndex] 
        || currentCell.Column == scheduleItemsDataGrid.Columns[TaskColumnIndex])
      {
        scheduleItemsDataGrid.BeginEdit();

      }
    }



  }
}
