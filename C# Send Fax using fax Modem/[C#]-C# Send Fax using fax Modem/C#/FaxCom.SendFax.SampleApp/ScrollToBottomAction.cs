using System.Windows.Controls;
using System.Windows.Interactivity;

namespace FaxCom.SendFax.SampleApp
{
    public class ScrollToBottomAction : TriggerAction<RichTextBox>
    {
        protected override void Invoke(object parameter)
        {
            AssociatedObject.ScrollToEnd();
        }
    }
}
