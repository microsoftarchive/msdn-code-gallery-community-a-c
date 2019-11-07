using ButtonCommand.ViewModel;
using Windows.UI.Xaml.Controls;


namespace ButtonCommand.View
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainPageViewModel();
        }
    }
}
