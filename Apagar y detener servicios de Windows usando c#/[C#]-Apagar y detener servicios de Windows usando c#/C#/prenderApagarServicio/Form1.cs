using System;
using System.Windows.Forms;
using System.ServiceProcess;

namespace prenderApagarServicio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            string serviceName = "Alerter";
            ServiceController service = new ServiceController(serviceName);
            int timeoutMilliseconds = 5000;
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch (Exception ex)
            {

            }
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            string serviceName = "Alerter";
            ServiceController service = new ServiceController(serviceName);
            int timeoutMilliseconds = 5000;
            try
            {
                TimeSpan timeout = TimeSpan.FromMilliseconds(timeoutMilliseconds);

                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Running, timeout);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
