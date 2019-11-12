using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Visifire.Charts;

namespace Visifire.Dashboards.ProductAndSales.Views
{
    public partial class ProductWiseSalesView : UserControl
    {
        #region Public Methods

        public ProductWiseSalesView()
        {
            // Required to initialize variables
            InitializeComponent();
            ChartProductWiseRevenue.Rendered += new EventHandler(ChartProductWiseRevenue_Rendered);

            this.Loaded += new RoutedEventHandler(ProductWiseSalesView_Loaded);
        }

        void ProductWiseSalesView_Loaded(object sender, RoutedEventArgs e)
        {
            StoryboardArrowAnimation.Begin();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Selected product
        /// </summary>
        public String SelectedProduct
        {   
            get
            {
                return (String)GetValue(SelectedProductProperty);
            }
            set
            {
                SetValue(SelectedProductProperty, value);
            }
        }

        /// <summary>
        /// Visifire.Dashboards.ProductAndSales.Views.ProductWiseSalesView.SelectedProductProperty
        /// </summary>
        public static readonly DependencyProperty SelectedProductProperty = DependencyProperty.Register
            ("SelectedProduct",
            typeof(String),
            typeof(ProductWiseSalesView), null);

        #endregion

        #region Private Methods

        /// <summary>
        /// On render event handler for the chart "ChartProductWiseRevenue"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChartProductWiseRevenue_Rendered(object sender, EventArgs e)
        {
            HighlightSelectedProduct(null);
        }

        /// <summary>
        /// Event handler for MouseLeftButtonUp for Pie
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pie_DataSeries_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            DataPoint clickedDataPoint = sender as DataPoint;
            SelectedProduct = clickedDataPoint.AxisXLabel;
            SelectOnlyOnePieSegment(clickedDataPoint);
        }

        /// <summary>
        /// Select a Pie and Expload
        /// </summary>
        /// <param name="selectedDataPoint"></param>
        private void SelectOnlyOnePieSegment(DataPoint selectedDataPoint)
        {
            foreach (DataPoint dp in ChartProductWiseRevenue.Series[0].DataPoints)
            {
                if (selectedDataPoint != dp)
                    dp.Exploded = false;
                else
                    selectedDataPoint.Exploded = true;
            }

            HighlightSelectedProduct(selectedDataPoint);
        }

        /// <summary>
        /// Highlight the name of the selected product
        /// </summary>
        /// <param name="selectedDataPoint">Selected DataPoint</param>
        private void HighlightSelectedProduct(DataPoint selectedDataPoint)
        {
            if (selectedDataPoint == null)
            {
                foreach (DataPoint dp in ChartProductWiseRevenue.Series[0].DataPoints)
                {
                    if (dp.Exploded == true)
                    {
                        selectedDataPoint = dp;
                        break;
                    }
                }
            }

            if (selectedDataPoint == null)
                return;

            storyBoard.Stop();
            storyBoard.Children.Clear();

            ColorAnimation animation = new ColorAnimation()
            {
                From = Colors.Black,
                To = (selectedDataPoint.Color as SolidColorBrush).Color,
                Duration = new Duration(new TimeSpan(0, 0, 3)),
                AutoReverse = true,
                RepeatBehavior = RepeatBehavior.Forever
            };

            Storyboard.SetTarget(animation, tbSelectedProduct.Foreground);
            Storyboard.SetTargetProperty(animation, new PropertyPath(SolidColorBrush.ColorProperty));

            storyBoard.Children.Add(animation);

            storyBoard.Begin();
        }

        #endregion

        #region Data

        /// <summary>
        /// Storuboard used for animation
        /// </summary>
        Storyboard storyBoard = new Storyboard();

        #endregion
    }
}