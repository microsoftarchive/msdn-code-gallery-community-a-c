using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Author  : Syed Shanu
//Date    : 2014-11-16
//Description : Shanu Audio/Video Player
namespace SHANUAudioVedioPlayListPlayer.PlayerControls
{
    public partial class YouTubeCntl : UserControl
    {
        public YouTubeCntl()
        {
            InitializeComponent();
        }

        private void btnYoutube_Click(object sender, EventArgs e)
        {
            ShockwaveFlash.Movie = txtUtube.Text.Trim();
        }
    }
}
