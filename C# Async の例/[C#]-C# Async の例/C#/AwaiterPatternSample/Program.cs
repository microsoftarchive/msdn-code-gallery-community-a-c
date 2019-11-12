using System;
using System.Threading;
using System.Threading.Tasks;

namespace AwaiterPatternSample
{
    /// <summary>
    /// awaitable の自作の例。
    /// せっかく async を使っているのにタスク完了までブロッキングしちゃうという残念な例。
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("非ブロッキング版:");
            var t1 = AwaitSample();
            Console.WriteLine("AwaitSample が完了するのを待たずに、こっちで別処理可能。");
            t1.Wait();

            Console.WriteLine("ブロッキング版:");
            var t2 = BlockingAwaitSample();
            Console.WriteLine("BlockingAwaitSample が完了するまで、この文字列は表示されない。");
            t2.Wait();

        }

        /// <summary>
        /// “awaitable” の自作の例。
        /// Task をラッピングして、同期化（ブロッキング）してしまう。
        /// 
        /// サンプル以外の価値があまりないけども。
        /// </summary>
        static async Task BlockingAwaitSample()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("処理 A-{0} スレッドID: {1}",
                    i,
                    Thread.CurrentThread.ManagedThreadId);

                // Task で非同期処理をしているように見せかけて・・・
                await TaskEx.Run(() =>
                {
                    Console.WriteLine("非同期 {0} スレッドID: {1}",
                        i,
                        Thread.CurrentThread.ManagedThreadId);

                    Thread.Sleep(100);
                })
                .ToBlocking(); // ここで同期化（ブロッキング）しちゃってるという。

                Console.WriteLine("処理 B-{0} スレッドID: {1}",
                    i,
                    Thread.CurrentThread.ManagedThreadId);
            }
        }

        /// <summary>
        /// 普通に Task を await する例。
        /// BlockingAwaitSample との差は、ToBlocking がないだけ。
        /// </summary>
        /// <returns></returns>
        static async Task AwaitSample()
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("処理 A-{0} スレッドID: {1}",
                    i,
                    Thread.CurrentThread.ManagedThreadId);

                await TaskEx.Run(() =>
                {
                    Console.WriteLine("非同期 {0} スレッドID: {1}",
                        i,
                        Thread.CurrentThread.ManagedThreadId);

                    Thread.Sleep(100);
                });

                Console.WriteLine("処理 B-{0} スレッドID: {1}",
                    i,
                    Thread.CurrentThread.ManagedThreadId);
            }
        }
    }
}
