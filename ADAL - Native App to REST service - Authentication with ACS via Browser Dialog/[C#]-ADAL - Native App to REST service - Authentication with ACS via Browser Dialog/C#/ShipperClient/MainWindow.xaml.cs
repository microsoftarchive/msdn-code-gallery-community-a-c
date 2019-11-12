using System.Windows;

namespace ShipperClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NavigateToShippingClient();
        }

        internal void NavigateToShippingClient()
        {
            mainFrame.Navigate(new ShippingClient());
        }
    }
}
