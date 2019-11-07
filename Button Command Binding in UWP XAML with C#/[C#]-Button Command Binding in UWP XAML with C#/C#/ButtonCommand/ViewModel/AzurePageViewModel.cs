using ButtonCommand.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ButtonCommand.ViewModel
{
    public class AzurePageViewModel
    {
        private ICommand backToWelcomePageCommand;
        public ICommand BackToWelcomePageCommand
        {
            get
            {
                return backToWelcomePageCommand ?? (backToWelcomePageCommand = new CommandHandler(() => BackToWelcomePage(), true));
            }
        }

        public void BackToWelcomePage()
        {
            Frame frame = ((Frame)Window.Current.Content) as Frame;

            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }
    }
}
