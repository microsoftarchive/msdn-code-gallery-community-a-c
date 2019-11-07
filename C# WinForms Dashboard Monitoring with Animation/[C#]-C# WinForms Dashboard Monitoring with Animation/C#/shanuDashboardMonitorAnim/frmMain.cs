using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shanuDashboardMonitorAnim
{
    public partial class frmMain : Form
    {
        #region Fields
        //for loading all forms one by one
        Timer tmrfrmDisplay = new Timer();

        int counter = 0;
        
        //for message animation
        Timer timerAnimation = new Timer();
        List<Color> listOfColors = new List<Color>();
        int indexColor = 0;
        int colorTimmer = 100;
        Form innerform = new Form();
       
        //for form move

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
                         int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture(); 

        #endregion

        #region Init
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        //To Display Fomr one by one depend on setting saved
        private void Formdisplay(int formNumber)
        {
            pnlGrid.Controls.Clear();
            this.Opacity = .2;

            switch (formNumber)
            {
                case 1:
                    frmSave1 obj1 = new frmSave1();

                    innerform = obj1;
                    obj1.TopLevel = false;
                    pnlGrid.Controls.Add(obj1);
                    obj1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    obj1.Dock = DockStyle.Fill;
                    obj1.Show();
                     
                    break;
                case 2:
                    frmSave2 obj2 = new frmSave2();
                    innerform = obj2;
                    obj2.TopLevel = false;
                    pnlGrid.Controls.Add(obj2);
                    obj2.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    obj2.Dock = DockStyle.Fill;
                    obj2.Show();
                   
                    break;
                case 3:
                    frmSave3 obj3 = new frmSave3();
                    innerform = obj3;
                    obj3.TopLevel = false;
                    pnlGrid.Controls.Add(obj3);
                    obj3.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    obj3.Dock = DockStyle.Fill;
                    obj3.Show();
                 
                    break;
                case 4:
                    frmSave4 obj4 = new frmSave4();
                    innerform = obj4;
                    obj4.TopLevel = false;
                    pnlGrid.Controls.Add(obj4);
                    obj4.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    obj4.Dock = DockStyle.Fill;
                    obj4.Show();
                  
                    break;
                case 5:
                    frmSave5 obj5 = new frmSave5();
                    innerform = obj5;
                    obj5.TopLevel = false;
                    pnlGrid.Controls.Add(obj5);
                    obj5.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    obj5.Dock = DockStyle.Fill;
                    obj5.Show();
                   
                    break;
                case 6:
                    frmSave6 obj6 = new frmSave6();
                    innerform = obj6;
                    obj6.TopLevel = false;
                    pnlGrid.Controls.Add(obj6);
                    obj6.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                    obj6.Dock = DockStyle.Fill;
                    obj6.Show();
                 
                    break;
            }

           
        }

        #endregion

        #region Overload
        private void frmMain_Load(object sender, EventArgs e)
        {
            //timer to display form one by one with in user defined time range
            tmrfrmDisplay.Enabled = true;
            tmrfrmDisplay.Tick += new EventHandler(tmrformDisplay_Tick);
            tmrfrmDisplay.Start();

            //timer to change the message color and move from left to right
            timerAnimation.Tick += new EventHandler(timerAnimation_Tick);
            listOfColors.Add(Color.MidnightBlue);
            listOfColors.Add(Color.Red);
            listOfColors.Add(Color.DarkOliveGreen);
            listOfColors.Add(Color.RoyalBlue);
            listOfColors.Add(Color.OrangeRed);
            timerAnimation.Enabled = true;
            timerAnimation.Interval = colorTimmer;
        }
        #endregion

        #region Control Events
        //timer for Form animation and for Mesaage Animation, change the message color and move from left to right
        void timerAnimation_Tick(object sender, EventArgs e)
        {
            //to Change the Message font color as random color
            this.lblMessage.ForeColor = listOfColors[indexColor];

            //to animate the form during first time load 
            if (this.Opacity< 1)
                this.Opacity += .1; 

            //incerment the message font color random color 
            indexColor++;
        
            if (indexColor > listOfColors.Count - 1)
            {
                indexColor = 0;              
            }
            //to move the message from left to right

            lblMessage.Location = new Point(lblMessage.Location.X - 3, lblMessage.Location.Y);

            if (lblMessage.Location.X + lblMessage.Width<panel1.Location.X + 100)
            {

                lblMessage.Location = new Point(panel1.Width - 400, lblMessage.Location.Y);
            } 

        }

//timer to display form one by one with in user defined time range
  private void tmrformDisplay_Tick(object sender, EventArgs e)
  {
//Here we check if the form index value has value as 0 then increase the count to display the next form.
    if (GlobalVariable.frmDisplayIndex[counter] == 0)
    {
        counter = counter + 1;
    }
            //Call the Formdisplay method to bind forms to the main form panel 
            Formdisplay(GlobalVariable.frmDisplayIndex[counter]);
            //wait till the time for each form display.
    tmrfrmDisplay.Interval = GlobalVariable.interval[counter];
            //increament the coutner to load next form.
    counter++;
            //if the counter reach the total form displayed for this dashb oard application set the counter to 0 to load the monitoring form from first
    if (counter >= GlobalVariable.formDisplayCount)
    {
        counter = 0;
        tmrfrmDisplay.Enabled = true;
    }
}

        // to move the form
        private void btnFormMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
                this.WindowState = FormWindowState.Maximized;
            }
        }

        //To Close all forms

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        #endregion

      
    }
}
