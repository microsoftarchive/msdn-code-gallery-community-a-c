using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfChartControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            showChart();
        }
        private void showChart()
        {
            List<KeyValuePair<string, int>> MyValue = new List<KeyValuePair<string, int>>();
            MyValue.Add(new KeyValuePair<string, int>("Administration", 20));
            MyValue.Add(new KeyValuePair<string, int>("Management", 36));
            MyValue.Add(new KeyValuePair<string, int>("Development", 89));
            MyValue.Add(new KeyValuePair<string, int>("Support", 270));
            MyValue.Add(new KeyValuePair<string, int>("Sales", 140));

            ColumnChart1.DataContext = MyValue;
            AreaChart1.DataContext = MyValue;
            LineChart1.DataContext = MyValue;
            PieChart1.DataContext = MyValue;
            BarChart1.DataContext = MyValue;
            BubbleSeries1.DataContext = MyValue;
            ScatterSeries1.DataContext = MyValue;
        }
    }
}
