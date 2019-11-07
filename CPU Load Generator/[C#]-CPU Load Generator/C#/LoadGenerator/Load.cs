using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;

namespace LoadGenerator
{
    /// <summary>
    /// Creates CPU load as per the target. It internally creates one thread to generate load for each processor
    /// </summary>
    public class LoadManager : IDisposable
    {
        ManualResetEvent[] resetEvent;

        /// <summary>
        /// One for each processor
        /// </summary>
        Thread[] threads;
        private int[] targetLoad = new int[Environment.ProcessorCount];
        Dictionary<int, int> processorThreadMapping;

        CpuUsage usage;

        private bool isDisposed = false;

        /// <summary>
        /// Background worker thread, this thread creates load using sperarate thread
        /// </summary>
        BackgroundWorker worker;

        private int ProcessorCount { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public LoadManager()
        {
            ProcessorCount = Environment.ProcessorCount;
            threads = new Thread[ProcessorCount];

            worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            usage = new CpuUsage();
            processorThreadMapping = new Dictionary<int, int>();

            //Console.Write("Enter Processor id : ");
            //x = int.Parse(Console.ReadLine());

            SetAffinityForAllThreads();

            resetEvent = new ManualResetEvent[ProcessorCount];
            for (int i = 0; i < ProcessorCount; i++)
            {
                resetEvent[i] = new ManualResetEvent(false);
            }

            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Moves all the existing running threads on first processor
        /// </summary>
        private void SetAffinityForAllThreads()
        {
            ProcessThreadCollection collection = Process.GetCurrentProcess().Threads;
            IEnumerator e = collection.GetEnumerator();
            int x = 1 << (0);

            while (e.MoveNext())
            {
                try
                {
                    ProcessThread pt = (ProcessThread)e.Current;
                    pt.ProcessorAffinity = new IntPtr(x);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// Set the load for the given processor
        /// </summary>
        /// <param name="processorID"></param>
        /// <param name="load"></param>
        public void SetLoad(int processorID, int load)
        {
            targetLoad[processorID] = load;
        }

        /// <summary>
        /// Background thread to continuously generate load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < ProcessorCount; i++)
            {
                threads[i] = CreateThreadOnProcessor(i);
                System.Threading.Thread.Sleep(500);
            }

            while (true)
            {
                for (int i = 0; i < ProcessorCount; i++)
                {
                    if (usage.GetCPULoad(i) > targetLoad[i])
                    {
                        resetEvent[i].Reset();
                    }
                    else
                    {
                        resetEvent[i].Set();
                    }
                }

                System.Threading.Thread.Sleep(2000);
            }
        }

        /// <summary>
        /// Generates load on CPU 
        /// </summary>
        private void CreateLoad(int processorID)
        {
            while (true)
            {
                resetEvent[processorID].WaitOne();

                // Calculate the time for delay based on target CPU load
                int time = 10000 - targetLoad[processorID] * 100;
                System.Threading.Thread.Sleep(new TimeSpan(time));
            }
        }

        /// <summary>
        /// Returns the list of thread id of all the threads of the current process
        /// </summary>
        /// <returns></returns>
        private List<int> GetCurrentThreadIds()
        {
            ProcessThreadCollection threadCollection = Process.GetCurrentProcess().Threads;
            IEnumerator e = threadCollection.GetEnumerator();
            List<int> IdList = new List<int>();

            while (e.MoveNext())
            {
                ProcessThread pt = (ProcessThread)e.Current;
                IdList.Add(pt.Id);
            }

            return IdList;
        }

        /// <summary>
        /// Returns the ProcessThread corresponding to given thread id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private ProcessThread GetProcessorThreadByID(int id)
        {
            ProcessThreadCollection threadCollection = Process.GetCurrentProcess().Threads;
            IEnumerator e = threadCollection.GetEnumerator();
            ProcessThread processthread = null;

            while (e.MoveNext())
            {
                ProcessThread pt = (ProcessThread)e.Current;
                if (pt.Id == id)
                {
                    processthread = pt;
                    break;
                }
            }

            return processthread;
        }

        /// <summary>
        /// Creates a new thread on the given processor ID
        /// </summary>
        /// <param name="processorID"></param>
        /// <returns></returns>
        private Thread CreateThreadOnProcessor(int processorID)
        {
            // Get the list of all running threads of the current processor
            List<int> oldIdList = GetCurrentThreadIds();

            // Create the new thread
            Thread thread = new Thread(() => CreateLoad(processorID));
            //Thread thread = new Thread(CreateLoad);
            thread.Start();

            // Get the new list of all running threads of the current processor
            List<int> newIdList = GetCurrentThreadIds();

            // Remove the older id from the list to get the ID of new thread
            newIdList.RemoveAll(Item => oldIdList.Contains(Item));

            if (newIdList.Count > 1)
            {
                //Console.WriteLine("Got more than one process");
                //Console.ReadLine();
            }

            ProcessThread pt = GetProcessorThreadByID(newIdList[0]);

            // Set the affinity of the thread so that it would execute on given processor ID
            pt.ProcessorAffinity = new IntPtr(1 << processorID);

            processorThreadMapping.Add(pt.Id, processorID);

            return thread;
        }

        /// <summary>
        /// Dispose the resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method to dispose the resources
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing)
        {
            if (isDisposed)
            {
                return;
            }

            if (isDisposing)
            {
                // Free any other managed objects here. 
                //
            }

            usage.Dispose();

            for (int i = 0; i < threads.Length; i++)
            {
                threads[i].Abort();
            }

            for (int i = 0; i < resetEvent.Length; i++)
            {
                resetEvent[i].Dispose();
            }

            isDisposed = true;

        }

        /// <summary>
        /// Finalizer
        /// </summary>
        ~LoadManager()
        {
            Dispose(false);
        }
    }
}
