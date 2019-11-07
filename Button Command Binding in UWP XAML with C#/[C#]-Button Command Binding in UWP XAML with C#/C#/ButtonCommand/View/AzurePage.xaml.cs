using ButtonCommand.ViewModel;
using Windows.UI.Xaml.Controls;

namespace ButtonCommand.View
{
    public sealed partial class AzurePage : Page
    {
        
        public AzurePage()
        {
            this.InitializeComponent();
            this.DataContext = new AzurePageViewModel();
        }
    }
}
