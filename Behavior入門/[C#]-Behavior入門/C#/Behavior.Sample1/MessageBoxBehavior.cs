namespace Behavior.Sample1
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    /// <summary>
    /// ボタンがクリックされると、Messageプロパティに設定した文字列を
    /// メッセージボックスに表示する動作を追加するビヘイビア。
    /// </summary>
    public class MessageBoxBehavior : Behavior<Button>
    {
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register(
                "Message",
                typeof(string),
                typeof(MessageBoxBehavior),
                new PropertyMetadata(string.Empty));

        /// <summary>
        /// ボタンが押された時に表示されるメッセージを取得または設定する。
        /// </summary>
        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        /// <summary>
        /// アタッチ
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            // イベントハンドラの登録
            this.AssociatedObject.Click += this.Button_Click;
        }

        /// <summary>
        /// デタッチ
        /// </summary>
        protected override void OnDetaching()
        {
            // イベントハンドラの解除
            this.AssociatedObject.Click -= this.Button_Click;
            base.OnDetaching();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Messageプロパティに設定された値をメッセージボックスで表示する。
            MessageBox.Show(this.Message);
        }
    }
}
