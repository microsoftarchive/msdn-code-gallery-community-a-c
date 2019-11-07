using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Author  : Syed Shanu
//Date    : 2014-11-16
//Description : Shanu Audio/Video Player
namespace SHANUAudioVedioPlayListPlayer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            LoadPlayerControl(0);
        }

        private void LoadPlayerControl(int playerType)
        {
            pnlMain.Controls.Clear();

            if (playerType == 0)
            {
                SHANUAudioVedioPlayListPlayer.PlayerControls.AudioVedioCntl objAudioVideo = new PlayerControls.AudioVedioCntl();
                pnlMain.Controls.Add(objAudioVideo);
                objAudioVideo.Dock = DockStyle.Fill;
            }
            else
            {
                PlayerControls.YouTubeCntl objYouTube = new PlayerControls.YouTubeCntl();
                pnlMain.Controls.Add(objYouTube);
                objYouTube.Dock = DockStyle.Fill;
            }
        }
        private void btnfirst_Click(object sender, EventArgs e)
        {
            LoadPlayerControl(0);
        }

        private void btnYouTubePlayer_Click(object sender, EventArgs e)
        {
            LoadPlayerControl(1);
        }
    }
}
