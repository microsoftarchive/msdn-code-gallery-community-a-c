using Microsoft.Practices.EnterpriseLibrary.Logging;
using System;
using System.Reflection;
using System.ServiceProcess;
using zSiS.AlwaysOnService.Helpers;

namespace zSiS.AlwaysOnService
{
    public partial class Service1 : ServiceBase
    {
        private System.Timers.Timer Timer = new System.Timers.Timer();

        /// <summary>
        /// 
        /// </summary>
        public Service1()
        {
            InitializeComponent();
            Logger.SetLogWriter(new LogWriterFactory().Create());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            try
            {
                Timer.Interval = Properties.Settings.Default.Interval;
                Timer.Elapsed += Timer_Elapsed;
                Timer.Start();
                LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name, string.Format("Service started with parameters_ {0} - {1}", Properties.Settings.Default.ServiceName, Properties.Settings.Default.Interval.ToString()));
            }
            catch (Exception ex)
            {
                LoggingHelper.Exception(MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name, "Checking status for service " + Properties.Settings.Default.ServiceName);
                ServiceController sc = new ServiceController(Properties.Settings.Default.ServiceName);

                LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name, "Current status: " + sc.Status.ToString());

                if (sc.Status == ServiceControllerStatus.Stopped)
                {
                    LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name, "Starting service " + Properties.Settings.Default.ServiceName);
                    sc.Start();
                    LoggingHelper.Trace(MethodBase.GetCurrentMethod().Name, "Started service " + Properties.Settings.Default.ServiceName);
                    LoggingHelper.Information(MethodBase.GetCurrentMethod().Name, "Service " + Properties.Settings.Default.ServiceName + " was stopped. Service restarted.");
                }
            }
            catch (Exception ex)
            {
                LoggingHelper.Exception(MethodBase.GetCurrentMethod().Name, ex);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnStop()
        {
            try
            {
                Timer.Stop();
                Timer.Dispose();
            }
            catch (Exception ex)
            {
                LoggingHelper.Exception(MethodBase.GetCurrentMethod().Name, ex);
            }
        }
    }
}
