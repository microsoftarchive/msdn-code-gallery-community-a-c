namespace Behavior.Sample1
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;

    /// <summary>
    /// ボタンをクリックするとHello worldというメッセージを表示する
    /// 動作を追加するビヘイビア。
    /// </summary>
    public class HelloWorldBehavior : Behavior<Button>
    {
        /// <summary>
        /// ボタンにアタッチされたときに呼ばれる。
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            // 一般的にイベントの設定のような初期化処理をここでおこなう
            this.AssociatedObject.Click += this.Button_Click;
        }

        /// <summary>
        /// デタッチされたときに呼ばれる。
        /// </summary>
        protected override void OnDetaching()
        {
            // 一般的にOnAttachedでした初期化の後始末をここで行う
            this.AssociatedObject.Click -= this.Button_Click;
            base.OnDetaching();
        }

        /// <summary>
        /// Hello worldを表示する。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello world");
        }
    }
}
