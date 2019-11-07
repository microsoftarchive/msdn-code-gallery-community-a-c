using ButtonCommand.View;
using ButtonCommand.ViewModel.Base;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ButtonCommand.ViewModel
{
    public class MainPageViewModel 
    {
        private ICommand goToAzureCommand;
        public ICommand GoToAzureCommand
        {
            get
            {
                return goToAzureCommand ?? (goToAzureCommand = new CommandHandler(() => GoToAzure(), true));
            }
        }

        public void GoToAzure()
        {
            ((Frame)Window.Current.Content).Navigate(typeof(AzurePage), null);
        }
    }
}
