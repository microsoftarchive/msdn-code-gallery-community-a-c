namespace Behavior.Sample3
{
    using System.Windows;
    using System.Windows.Interactivity;

    /// <summary>
    /// Messageプロパティに設定した文字列をMessageBoxに表示するアクション。
    /// </summary>
    public class MessageBoxAction : TriggerAction<DependencyObject>
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                "Message",
                typeof(string),
                typeof(MessageBoxAction),
                new PropertyMetadata(string.Empty));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        protected override void Invoke(object parameter)
        {
            // Messageプロパティの値を表示する
            MessageBox.Show(this.Message);
        }
    }
}
