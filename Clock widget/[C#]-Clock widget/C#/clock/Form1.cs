using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        System.Drawing.Size desktopArea = SystemInformation.WorkingArea.Size;

        int mouseX = 0;
        int mouseY = 0;
        bool mouseDn;

        private void Form1_Load(object sender, EventArgs e)
        {
            int x = desktopArea.Width;
            int y = desktopArea.Height;
            this.TransparencyKey = (BackColor);
            System.Timers.Timer timer = new System.Timers.Timer();
            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
            this.SetDesktopLocation(x - 300, 100);
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            circularProgressBar1.Invoke((MethodInvoker)delegate {
                circularProgressBar1.Text = DateTime.Now.ToString("hh:mm:ss");
                circularProgressBar1.SubscriptText = DateTime.Now.ToString("tt");

            });

        }

        private void circularProgressBar1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDn = true;
        }

        private void circularProgressBar1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDn)
            {
                mouseX = MousePosition.X -130;
                mouseY = MousePosition.Y -50;
                this.SetDesktopLocation(mouseX, mouseY);
            }
        }

        private void circularProgressBar1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDn = false;
        }

    }
}
