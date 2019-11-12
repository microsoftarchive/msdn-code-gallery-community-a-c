using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;


namespace Chess.Forms
{
    public partial class About : Form
    {
        public About() 
        {
            InitializeComponent();

            lnkLabel.Links.Add(0, 18, "www.chessbin.com");
            lnkBuyNow.Links.Add(0, 255, @"https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=1565220");
            
            Assembly MyAssembly = Assembly.GetExecutingAssembly();

            Version AppVersion = MyAssembly.GetName().Version;


            string MyVersion = AppVersion.Major
                               + "." + AppVersion.Minor
                               + "." + AppVersion.Build
                               + "." + AppVersion.Revision;

            lblVersion.Text = "Version: " + MyVersion;
        }

        private void lnkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Determine which link was clicked within the LinkLabel.
            lnkLabel.Links[lnkLabel.Links.IndexOf(e.Link)].Visited = true;

            // Display the appropriate link based on the value of the 
            // LinkData property of the Link object.
            string target = e.Link.LinkData as string;

            // If the value looks like a URL, navigate to it.
            // Otherwise, display it in a message box.
            if (null != target && target.StartsWith("www"))
            {
                Process.Start(target);
            }
        }

        private void lnkBuyNow_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Donate();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Donate();
        }

        private void Donate()
        {
            string target = lnkBuyNow.Links[0].LinkData as string;
            Process.Start(target);
        }

    }
}