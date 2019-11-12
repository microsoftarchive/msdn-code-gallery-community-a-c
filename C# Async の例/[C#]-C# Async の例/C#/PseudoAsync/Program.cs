using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace PseudoAsync
{
    /// <summary>
    /// async/await はイテレーター ブロックの yield と似たようなことをしている。
    /// ということは、yield を使って疑似的に await 的なことも可能。
    /// （ただ、ちょっと補助的なコードは書かなきゃいけない。）
    /// 
    /// ここで作ってるのは async void 相当のもの。
    /// async Task とか async Task&lt;T&gt; 相当のものを作るのはもっとめんどくさそう。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            string[] uriList = new[] { "http://ufcpp.net/", "http://ufcpp.net/study/", "http://ufcpp.net/study/csharp/" };

            RunTaskAsync(uriList);
            RunPseudoAsync(uriList);
            RunAsyncInside(uriList);

            Console.WriteLine("メインスレッド");
            Thread.Sleep(2000);
        }

        /// <summary>
        /// 複数のウェブ ページから HTML を拾ってきて、最初の80文字を表示するサンプル。
        /// 
        /// 非同期 C# の async/await を利用した版。
        /// </summary>
        /// <param name="uriList">ページの URI リスト。</param>
        private static async void RunTaskAsync(params string[] uriList)
        {
            var client = new WebClient();

            foreach (var uri in uriList)
            {
                var html = await client.DownloadStringTaskAsync(uri);
                ShowTitle(html);
            }
        }

        /// <summary>
        /// RunPseudoAsync の本体。
        /// 
        /// await 相当のことをイテレーターの yield を使って実現。
        /// </summary>
        /// <param name="uriList">ページの URI リスト。</param>
        /// <returns>補助コードとの連携のため、yield return で Task を返す。</returns>
        private static IEnumerable<Task> RunIterator(params string[] uriList)
        {
            var client = new WebClient();

            foreach (var uri in uriList)
            {
                //↓ここから
                var task = client.DownloadStringTaskAsync(uri);
                if (!task.IsCompleted)
                {
                    yield return task;
                }
                var html = task.Result;
                //↑ここまでが await 相当の処理

                ShowTitle(html);
            }

            yield return null;
        }

        /// <summary>
        /// 複数のウェブ ページから HTML を拾ってきて、最初の80文字を表示するサンプル。
        /// 
        /// 似非 await 版。
        /// 補助コード ＋ イテレーターを利用。
        /// </summary>
        /// <param name="uriList">ページの URI リスト。</param>
        private static void RunPseudoAsync(params string[] uriList)
        {
            AsyncHelper(RunIterator(uriList));
        }

        /// <summary>
        /// 補助コード。
        /// 
        /// Task.ContinueWith で、タスクすべてが完了するまで継続呼び出し。
        /// </summary>
        /// <param name="asyncTask">非同期メソッド本体との連携のため、Task の列挙子を受け取る。</param>
        private static void AsyncHelper(IEnumerable<Task> asyncTask)
        {
            var e = asyncTask.GetEnumerator();

            Action a = null;

            a = () =>
            {
                if (e.MoveNext() && e.Current != null)
                {
                    e.Current.ContinueWith(t => a());
                }
            };

            a();
        }

        /// <summary>
        /// じゃあ、最終的に 非同期メソッドがどう展開されているのかというと。
        /// </summary>
        /// <param name="uriList">ページの URI リスト。</param>
        private static void RunAsyncInside(IEnumerable<string> uriList)
        {
            Action a = null;
            var e = uriList.GetEnumerator();
            int state = 0;
            WebClient client = null;
            Task<string> task = null;

            a = () =>
            {
                // yield のしてること = 状態の記憶と復帰
                // 記憶は state 変数の書き換え、
                // 復帰は state の値に応じた goto で。
                switch(state)
                {
                    case 0: goto State0;
                    case 1: goto State1;
                }

                State0:
                client = new WebClient();

                // goto の都合上、ループは if goto とか if return に置き換わる。
                if (!e.MoveNext()) return;

                //↓ここから
                state = 1;
                task = client.DownloadStringTaskAsync(e.Current);
                if (!task.IsCompleted)
                {
                    task.ContinueWith(t => a);
                    return;
                }
                State1:
                var html = task.Result;
                //↑ここまでが await 相当の処理

                ShowTitle(html);
            };

            a();
        }

        /// <summary>
        /// 拾ってきた HTML からタイトルを抽出して表示。
        /// </summary>
        /// <param name="html">HTML のソース。</param>
        private static void ShowTitle(string html)
        {
            var title = Regex.Match(html, @"title\>(?<title>[^\<]*)\<").Groups["title"].ToString();

            Console.WriteLine("取得したタイトル文字列: {0}, スレッドID: {1}",
                title,
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}
