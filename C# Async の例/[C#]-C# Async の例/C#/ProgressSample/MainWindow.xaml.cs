using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System;

namespace ProgressSample
{
    /// <summary>
    /// async/await は BackgroundWorker に代わる新しい進捗報告の仕組みにもできる。
    /// 
    /// BackgroundWorker は、
    /// 1. 非同期処理
    /// 2. 進捗報告
    /// 3. 完了通知
    /// の3つの役目を1つのクラスで負ってて、機能の切り分けがあまりきれいじゃない。
    /// 
    /// async/await では、
    /// 1. 非同期処理を同期っぽく書ける
    /// 2. 進捗報告は IProgress インターフェイスを通して行う
    /// 3. 完了通知は、同期っぽく、非同期メソッドの最後に書けばそれだけで OK。
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 進捗を受け取る側では Progress.ProgressChanged にイベント ハンドラー登録。
            var ep = new Progress<int>();
            ep.ProgressChanged += (s, x) =>
            {
                this.Progress.Value = x;
            };

            RunAsync(ep);
        }

        /// <summary>
        /// 3秒程度かかる長い処理。
        /// 30ミリ秒に1回進捗報告。
        /// </summary>
        /// <param name="progress">進捗報告先。</param>
        private async void RunAsync(IProgress<int> progress)
        {
            this.ResultText.Text = "開始";

            // 重たい処理をするという想定の時は、
            // ↓みたいに TaskEx.Run で新しい Task 作らないと UI スレッドを止めてしまう。
            await TaskEx.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(30);

                    // ここは UI スレッド以外で実行されているので、
                    // 直接 this.Progress.Value = i; ってしてしまうと例外発生。
                    // IProgress.Report 経由で進捗報告。
                    progress.Report(i);
                }
            });

            // await を抜けた時点で、ディスパッチャー経由で UI スレッドに戻る。
            this.ResultText.Text = "完了";
        }
    }
}
