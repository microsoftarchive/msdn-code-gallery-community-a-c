namespace Behavior.Sample3
{
    using System.Windows;
    using System.Windows.Interactivity;

    /// <summary>
    /// HelloWorldとメッセージボックスに表示するアクション。
    /// </summary>
    public class HelloWorldAction : TriggerAction<DependencyObject>
    {
        protected override void Invoke(object parameter)
        {
            MessageBox.Show("Hello world");
        }
    }
}
