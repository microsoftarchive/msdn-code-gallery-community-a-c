using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace SynchronizationContextSample
{
    /// <summary>
    /// 必ず同じスレッドで実行して欲しい処理のためのメッセージ ポンプ。
    /// </summary>
    public class AgentThread
    {
        Task task;
        BlockingCollection<Action> actions = new BlockingCollection<Action>();

        /// <summary>
        /// コンストラクター内で新しいスレッドを立てる。
        /// アプリケーションが起動中ずっと動き続けるスレッドなので、LongRunning オプション付き。
        /// </summary>
        public AgentThread()
        {
            Context = new AgentSynchronizationContext(this);
            task = Task.Factory.StartNew(Run, TaskCreationOptions.LongRunning);
        }

        /// <summary>
        /// メッセージ ポンプ用のスレッド本体。
        /// キューに Action が Enqueue されるのを待って、Dequeue して実行し続ける。
        /// </summary>
        /// <remarks>
        /// 手抜き実装なのでキャンセルには未対応。
        /// 延々動き続ける。
        /// </remarks>
        private void Run()
        {
            SynchronizationContext.SetSynchronizationContext(this.Context);

            while (true)
            {
                foreach (var action in actions.GetConsumingEnumerable())
                {
                    action();
                }
            }
        }

        /// <summary>
        /// Action 登録。
        /// </summary>
        /// <param name="action">同じスレッドで実行して欲しい処理。</param>
        public void Add(Action action)
        {
            actions.Add(action);
        }

        /// <summary>
        /// 立てたスレッドの同期コンテキスト。
        /// こいつに SwitchTo すれば、あとは必ず同じスレッドで Task が実行されるようになる。
        /// </summary>
        public SynchronizationContext Context { get; private set; }

        /// <summary>
        /// await すると、継続処理を SynchronizationContext.Current.Post するので、
        /// Post を実装すれば継続処理を実行するスレッドを制御できる。
        /// </summary>
        /// <remarks>
        /// 手抜きなので Post 以外未実装。
        /// </remarks>
        class AgentSynchronizationContext : SynchronizationContext
        {
            AgentThread agent;

            public AgentSynchronizationContext(AgentThread agent)
            {
                this.agent = agent;
            }

            public override void Post(SendOrPostCallback d, object state)
            {
                agent.Add(() => { d(state); });
            }
        }
    }
}
