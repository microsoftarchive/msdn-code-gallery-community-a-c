using System;
using System.ComponentModel;
using System.Diagnostics;

namespace LoadGenerator
{
    /// <summary>
    /// This class provides the functionality to continuously moniters the CPU load and provides API to access the same
    /// </summary>
    public class CpuUsage : IDisposable
    {
        public int[] Usage;
        BackgroundWorker worker;

        PerformanceCounter[] cpuCounter;

        private bool isDisposed = false;

        public CpuUsage()
        {
            ProcessorCount = Environment.ProcessorCount;
            cpuCounter = new PerformanceCounter[ProcessorCount];

            for (int i = 0; i < ProcessorCount; i++)
            {
                cpuCounter[i] = new PerformanceCounter();
                cpuCounter[i].CategoryName = "Processor";
                cpuCounter[i].CounterName = "% Processor Time";
                cpuCounter[i].InstanceName = i.ToString();
            }

            Usage = new int[ProcessorCount];

            worker = new BackgroundWorker();
            worker.WorkerSupportsCancellation = true;
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        public int ProcessorCount { get; private set; }

        /// <summary>
        /// Background worker which continuously moniters the CPU
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                for (int index = 0; index < ProcessorCount; index++)
                {
                    GetLoad(index);
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        private void GetLoad(int index)
        {
            float secondValue = cpuCounter[index].NextValue();

            Usage[index] = (int)secondValue;
        }

        public int GetCPULoad(int processorID)
        {
            return Usage[processorID];
        }

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

            worker.CancelAsync();
            worker.Dispose();

            for (int i = 0; i < cpuCounter.Length; i++)
            {
                cpuCounter[i].Dispose();
            }


            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~CpuUsage()
        {
            Dispose(false);
        }
    }
}
