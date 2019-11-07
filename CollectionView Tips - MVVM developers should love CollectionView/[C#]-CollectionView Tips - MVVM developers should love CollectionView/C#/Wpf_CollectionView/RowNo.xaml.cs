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
using GalaSoft.MvvmLight.Messaging;
using Support;
namespace Wpf_CollectionView
{

    public partial class RowNo : UserControl
    {
        public RowNo()
        {
            InitializeComponent();
            this.DataContext = new RowNoViewModel();
        }
         private void dg_Sorting(object sender, DataGridSortingEventArgs e)
         {
             var msg = new RefreshView();
             Messenger.Default.Send<RefreshView>(msg);
         }

    }
    public static class CVHolder
    {
        public static CollectionView CV;
    }
    public class RowFromObject : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int rn = 0;
            if (CVHolder.CV == null || value == null)
                return rn;

            rn = CVHolder.CV.IndexOf(value);
            return rn+1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return 1;
        }
    }
}
