using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace SynchronizationContextSample
{
    /// <summary>
    /// 同期コンテキスト（SynchronizationContext 継承クラス）を自作すれば、
    /// await 時の Task 実行の挙動を制御可能。
    /// 
    /// 例えば WPF とか Silverlight では、SynchronizationContext が Dispatcher 経由で処理を呼ぶので、
    /// await を使うと必ず UI スレッドで処理されるようになる。
    /// 
    /// ここでは、それと似たような仕組みを自作。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("普通に非同期メソッドを実行:");
            ReadTitleFromWebAsync().Wait();

            Console.WriteLine("常に同じスレッドで実行されるように同期コンテキストを利用");
            RunWithContext().Wait();
        }

        /// <summary>
        /// AgentThread の立てたスレッドに SwitchTo してから ReadTitleFromWebAsync 呼び出し。
        /// </summary>
        private static async Task RunWithContext()
        {
            // 以下の2行を入れることで、この RunAsync メソッド内の処理は必ず同じスレッドで実行されるようになる。
            var agent = new AgentThread();
            //await agent.Context.SwitchTo(); // April refresh での変更点: SwitchTo 廃止。
            SynchronizationContext.SetSynchronizationContext(agent.Context);

            await ReadTitleFromWebAsync();
        }

        /// <summary>
        /// http://ufcpp.net/ の HTML ソースを取ってきて、タイトルを抜き出してコンソールに表示。
        /// </summary>
        private static async Task ReadTitleFromWebAsync()
        {
            var client = new WebClient();

            for (int i = 0; i < 5; i++)
            {
                var html = await client.DownloadStringTaskAsync("http://ufcpp.net/");
                var title = Regex.Match(html, @"title\>(?<title>[^\<]*)\<").Groups["title"].ToString();

                Console.WriteLine("取得したタイトル文字列: {0}, スレッドID: {1}",
                    title,
                    Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
