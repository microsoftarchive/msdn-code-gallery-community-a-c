using System;
using System.Windows;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncSample
{
    /// <summary>
    /// async は GUI での非同期 I/O 待ちに対して使うのが一番相性良さそう。
    /// 非同期 I/O の代わりに Delay でごまかしているものの、GUI での async の使い方の例。
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// C# 4.0 までの書き方。
        /// 
        /// 自分でタスク起動して（Task.Factory.StartNew）、
        /// 処理が終わったら Dispatcher.Invoke 経由で UI スレッドに制御を戻す。
        /// </summary>
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(3000);

                Dispatcher.Invoke(new Action(() =>
                {
                    this.List.Items.Add("3秒経過");
                }));
            });
        }

        /// <summary>
        /// async 版。
        /// 
        /// メソッドを async キーワードで修飾して、
        /// 非同期にしたいところに await って書くだけ。
        /// </summary>
        private async void Button_Click2(object sender, RoutedEventArgs e)
        {
            await TaskEx.Delay(3000);

            this.List.Items.Add("3秒経過");
        }

        /// <summary>
        /// 同期（ブロッキング）版。
        /// 
        /// 書くのは簡単だけども、UI がフリーズ。
        /// </summary>
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            TaskEx.Delay(3000).Wait();

            this.List.Items.Add("3秒経過");
        }
    }
}
