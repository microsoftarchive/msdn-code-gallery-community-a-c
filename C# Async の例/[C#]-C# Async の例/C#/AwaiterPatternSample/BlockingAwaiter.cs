using System;
using System.Threading.Tasks;

namespace AwaiterPatternSample
{
    /// <summary>
    /// await は、以下のような “awaiter パターン” に適合しているクラスなら何でも利用可能。
    /// まず、Awaiter GetAwaiter() というシグネチャのメソッドを持つ “awaitable” クラスを作成。
    /// 
    /// ここでは、せっかくの非同期呼び出しを同期化（処理が終わるまでブロッキング）するという、使い道のない例を実装。
    /// </summary>
    /// <typeparam name="T">await で受け取りたい戻り値の型。</typeparam>
    public class BlockingAwaitable<T>
    {
        private BlockingAwaiter<T> _awaiter;

        public BlockingAwaitable(Task<T> task) { _awaiter = new BlockingAwaiter<T>(task); }

        /// <summary>
        /// このメソッドを持つことが “awaitable” の第1条件。
        /// あとは、戻り値の方が後述の BeginAwait と EndAwait を持っていれば OK。
        /// 
        /// インターフェイスとかの実装は不要で、foreach や LINQ と同様に、duck-typing 的。
        /// </summary>
        /// <returns>“awaiter”</returns>
        public BlockingAwaiter<T> GetAwaiter() { return _awaiter; }
    }

    /// <summary>
    /// “awaitable” の GetAwaiter メソッドが返す “awaiter” は、
    /// IsCompleted プロパティ、OnComplete メソッドと OnCompleted メソッドを持つ必要がある。
    /// </summary>
    /// <typeparam name="T">await で受け取りたい戻り値の型。</typeparam>
    public class BlockingAwaiter<T>
    {
        private Task<T> _task;

        public BlockingAwaiter(Task<T> task) { _task = task; }

        /// <summary>
        /// ブロッキングして処理するので常時 true。
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// BeginAwait で非同期処理を開始。
        /// 
        /// ただし、タスクがすでに完了していたら別にわざわざスレッドを立てて完了待ちする必要もないので、
        /// 即座に Current を呼び出して処理を続行する仕組みを持っている。
        /// 
        /// IsCompleted が true を返すなら非同期処理開始、
        /// false を返すならタスクは完了済みとみなして処理続行。
        /// 
        /// この例では、同期化してしまうので、BeginAwait で何か処理する必要はなく、
        /// 単に false を返して処理続行してもらう。
        /// </summary>
        /// <param name="continuation">非同期処理が完了した後に呼び出してほしい継続処理。</param>
        public void OnCompleted(Action continuation)
        {
        }

        /// <summary>
        /// GetResult でタスクの結果を受け取る。
        /// 
        /// ここでは、Task.Wait でブロッキングしてしまって、その結果を返す。
        /// </summary>
        /// <returns></returns>
        public T GetResult()
        {
            _task.Wait();
            return _task.Result;
        }
    }

    /// <summary>
    /// void 版。
    /// 戻り値がない以外は BlockingAwaitable&lt;T&gt; と同じ。
    /// </summary>
    /// <seealso cref="BlockingAwaitable&lt;T&gt;"/>
    public class BlockingAwaitable
    {
        private BlockingAwaiter _awaiter;

        public BlockingAwaitable(Task task) { _awaiter = new BlockingAwaiter(task); }

        public BlockingAwaiter GetAwaiter() { return _awaiter; }
    }

    /// <summary>
    /// void 版。
    /// 戻り値がない以外は BlockingAwaiter&lt;T&gt; と同じ。
    /// </summary>
    /// <seealso cref="BlockingAwaiter&lt;T&gt;"/>
    public class BlockingAwaiter
    {
        private Task _task;

        public BlockingAwaiter(Task task) { _task = task; }

        /// <summary>
        /// ブロッキングして処理するので常時 true。
        /// </summary>
        public bool IsCompleted
        {
            get
            {
                _task.Wait();
                return true;
            }
        }

        public void OnCompleted(Action continuation)
        {
        }

        /// <summary>
        /// GetResult でタスクの結果を受け取る。
        /// 
        /// ここでは、Task.Wait でブロッキングしてしまって、その結果を返す。
        /// </summary>
        /// <returns></returns>
        public void GetResult()
        {
            _task.Wait();
        }
    }

    /// <summary>
    /// Task を BlockingAwaitable でラッピングするための拡張メソッド集。
    /// </summary>
    public static class BlockingAwaitableExtensions
    {
        /// <summary>
        /// Task&lt;T&gt; を BlockingAwaitable&lt;T&gt; でラッピング。
        /// </summary>
        /// <typeparam name="T">await で受け取りたい戻り値の型。</typeparam>
        public static BlockingAwaitable<T> ToBlocking<T>(this Task<T> task)
        {
            return new BlockingAwaitable<T>(task);
        }

        /// <summary>
        /// void 版。
        /// Task を BlockingAwaitable でラッピング。
        /// </summary>
        public static BlockingAwaitable ToBlocking(this Task task)
        {
            return new BlockingAwaitable(task);
        }
    }
}
