using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebRole1
{
    public partial class _Default : System.Web.UI.Page
    {
        private static int rotation = 0;
       
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void aniTimer_Tick(object sender, EventArgs e)
        {
            switch (rotation)
            {
                case 0:
                    
                    subText1.Text = "100% Microsoft Azure Cloud based Services";
                    subText2.Text = "Using the latest technologies...";
                    subText3.Text = "Based on 30 years digital forensic experience";
                    subText4.Text = "At a price anyone can afford";
                    break;
                case 1:
                    
                    subText1.Text = "Self Service Digital Forensics";
                    subText2.Text = "Discover who is stealing your sensitive data";
                    subText3.Text = "Prove yourself innocent of copyright infringment or data theft";
                    subText4.Text = "Run by you when it is convienient to you";
                    break;
                case 2:
                    
                    subText1.Text = "Self Service Copyright Management";
                    subText2.Text = "Remove unwanted images and movies of yourself from the Internet";
                    subText3.Text = "Search the internet with thousands of crawlers for your copyrighted data";
                    subText4.Text = "Ensure your digital locker or website is not hosting or linking to illegal material";
                    break;
                case 3:
                    
                    subText1.Text = "For Governments, Law Enforcement, Enterprises, and for You";
                    subText2.Text = "Know exactly how much it is going to cost you before committing";
                    subText3.Text = "Service contracts from 1 month only";
                    subText4.Text = "Full Service Level Agreements available.";
                    break;
                case 4:
                    
                    subText1.Text = "For the Security Services";
                    subText2.Text = "Remotely track, monitor and control terrorist cells";
                    subText3.Text = "Infiltrate the most stuborn of systems";
                    subText4.Text = "Co-ordinate international teams from a single location";
                    break;
                case 5:
                    
                    subText1.Text = "Super-Computer Power";
                    subText2.Text = "Break any encryption or password...";
                    subText3.Text = "...faster and cheaper than ever before";
                    subText4.Text = "...conduct cloud based and cloud focused digital forensic investigations ";
                    break;
                case 6:
                    
                    subText1.Text = "Report Child Abuse Online";
                    subText2.Text = "The easiest system for individuals to report child abuse images and videos";
                    subText3.Text = "Use one of our Internet Explorer or Firefox plugins";
                    subText4.Text = "or use our online service - it is so easy";
                    break;
                case 7:
                    
                    subText1.Text = "We are...";
                    subText2.Text = "";
                    subText3.Text = "";
                    subText4.Text = "";
                    break;
                case 8:
                    
                    subText1.Text = "We are...";
                    subText2.Text = "Dedicated to providing the very best that 21st century technology and knowledge has to offer";
                    subText3.Text = "";
                    subText4.Text = "";
                    break;
                case 9:
                   
                    subText1.Text = "We are...";
                    subText2.Text = "Dedicated to providing the very best that 21st century technology and knowledge has to offer";
                    subText3.Text = "Ridding the Internet of criminals";
                    subText4.Text = "";
                    break;
                case 10:
                   
                    subText1.Text = "We are...";
                    subText2.Text = "Dedicated to providing the very best that 21st century technology and knowledge has to offer";
                    subText3.Text = "Ridding the Internet of criminals";
                    subText4.Text = "Making IT Better!";
                    break;
                case 11:
                   
                    subText1.Text = "We are...";
                    subText2.Text = "";
                    subText3.Text = "";
                    subText4.Text = "";
                    break;
                case 12:
                   
                    subText1.Text = "CCS LABS DIGITAL FORENSICS AND COPYRIGHT MANAGEMENT";
                    subText2.Text = "";
                    subText3.Text = "";
                    subText4.Text = "";
                    rotation = 0;
                    break;
                default:
                    break;
            }
            rotation++;
        }

       
       
    }
}
