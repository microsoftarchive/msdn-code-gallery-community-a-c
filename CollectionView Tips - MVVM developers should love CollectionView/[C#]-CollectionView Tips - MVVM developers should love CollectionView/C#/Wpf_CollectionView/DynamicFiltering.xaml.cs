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

namespace Wpf_CollectionView
{
    /// <summary>
    /// Interaction logic for DynamicFiltering.xaml
    /// </summary>
    public partial class DynamicFiltering : UserControl
    {
        public DynamicFiltering()
        {
            InitializeComponent();
            this.DataContext = new DynamicFilteringViewModel();
        }
        private void dg_Selected(object sender, RoutedEventArgs e)
        {
            DataGridRow dgr = (DataGridRow)sender;
            dgr.Focusable = true;
            Keyboard.Focus(dgr);
        }
    }
}
